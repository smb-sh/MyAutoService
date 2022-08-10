using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyAutoService.Data;
using MyAutoService.Models;
using MyAutoService.Models.ViewModels;
using MyAutoService.Utilities;

namespace MyAutoService.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public UsersListViewModel UsersListViewModel { get; set; }
        public async Task<IActionResult> OnGet(int pageId = 1)
        {
            UsersListViewModel = new UsersListViewModel()
            {
                ApplicationUserList = await _db.ApplicationUsers.ToListAsync(),

            };
            StringBuilder param = new StringBuilder();
            param.Append("/Users?pageId=:");
            var count = UsersListViewModel.ApplicationUserList.Count;
            UsersListViewModel.PagingInfo = new PagingInfo()
            {
                CurrentPage = pageId,
                ItemPerPage = SD.PagingUserCount,
                TotalItems = count,
                UrlParam = param.ToString()
            };
            UsersListViewModel.ApplicationUserList = UsersListViewModel.ApplicationUserList.OrderBy(u => u.Name)
                .Skip((pageId - 1) * SD.PagingUserCount)
                .Take(SD.PagingUserCount).ToList();
            return Page();
        }
    }
}
