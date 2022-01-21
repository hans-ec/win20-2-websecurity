using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace _01_AspNetMVC_LocalIdentity.Models
{
    public class AppUser : IdentityUser
    {
        [Required]
        [StringLength(50)]
        [PersonalData]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [PersonalData]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        [PersonalData]
        public string StreetName { get; set; }

        [Required]
        [StringLength(10)]
        [PersonalData]
        public string PostalCode { get; set; }

        [Required]
        [StringLength(50)]
        [PersonalData]
        public string City { get; set; }
    }
}
