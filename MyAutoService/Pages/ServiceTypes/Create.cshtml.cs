using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyAutoService.Models;
using MyAutoService.Data;
using Microsoft.AspNetCore.Authorization;
using MyAutoService.Utilities;
using System.Data;

namespace MyAutoService.Pages.ServiceTypes
{
    [Authorize(Roles = SD.AdminEndUser)]
    public class CreateModel : PageModel
    {
        private ApplicationDbContext _db;

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
            
        }


        /*[BindProperty]*/
        public ServiceType ServiceType { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }



        public async Task<IActionResult> OnPostAsync(ServiceType serviceType)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                _db.serviceTypes.Add(serviceType);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
        }
        /*public IActionResult OnPost(ServiceType serviceType)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                _db.serviceTypes.Add(serviceType);
                _db.SaveChanges();
                return RedirectToPage("Index");
            }
        }*/
    }
}

