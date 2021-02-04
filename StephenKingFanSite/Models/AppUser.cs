using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StephenKingFanSite.Models
{
    public class AppUser : IdentityUser
    {
        [NotMapped]
        public IList<string> RolesNames { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "User name should be between 2 and 50 characters long.")]
        public string Name { get; set; }
    }
}
