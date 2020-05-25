using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace StandardResources.Entities.Domain
{
    public class ApplicationUser : IdentityUser<int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        public ApplicationUser()
        {
            CreatedDate = DateTime.Now;
        }

        public DateTime CreatedDate { get; set; }

        public string Designation { get; set; }

        public ICollection<ApplicationUserRole> UserRoles { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser, int> manager, string authenticationType)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            return userIdentity;
        }
    }
}
