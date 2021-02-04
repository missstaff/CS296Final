using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace StephenKingFanSite.Models
{
    public class UserVM
    {
        public IEnumerable<AppUser> Users { get; set; }
        public IEnumerable<IdentityRole> Roles { get; set; }
    }
}
