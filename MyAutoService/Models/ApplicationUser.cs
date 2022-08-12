using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MyAutoService.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name ="نام مشتری")]
        [MaxLength(200)]
        public string? Name { get; set; }

        [MaxLength(400)]
        public string? Address { get; set; }

        /*[Display(Name = "ایمیل")]
        public override string Email {
            get { return base.Email; }
            set { base.Email = value; }
        }*/
        
        [Display(Name = "شماره تلفن")]
        public override string PhoneNumber {
            get { return base.PhoneNumber; }
            set { base.PhoneNumber = value; }
        }
    }


}
