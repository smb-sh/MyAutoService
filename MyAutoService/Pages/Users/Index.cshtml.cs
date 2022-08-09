using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyAutoService.Data;
using MyAutoService.Models;

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
        public List<ApplicationUser> ApplicationUserList { get; set; } 
        public async Task<IActionResult> OnGet()
        {
            ApplicationUserList = await _db.ApplicationUsers.ToListAsync();
            return Page();
        }
    }
}
