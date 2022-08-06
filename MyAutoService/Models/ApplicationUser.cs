using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MyAutoService.Models
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(400)]
        public string Address { get; set; }
    }
}
