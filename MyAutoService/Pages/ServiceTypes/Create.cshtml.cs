using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyAutoService.Models;

namespace MyAutoService.Pages.ServiceTypes
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public ServiceType ServiceType { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }
    }
}

