using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using StandardResources.DAL;
using StandardResources.Entities.Domain;
using System;

namespace StandardResources.API.Infrastructure
{
    public class ApplicationUserStore :
        UserStore<ApplicationUser, ApplicationRole, int,
            ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>,
        IUserStore<ApplicationUser, int>,
        IDisposable
    {
        public ApplicationUserStore() : this(new ApplicationDbContext())
        {
            base.DisposeContext = true;
        }

        public ApplicationUserStore(ApplicationDbContext context) : base(context)
        {

        }
    }
}