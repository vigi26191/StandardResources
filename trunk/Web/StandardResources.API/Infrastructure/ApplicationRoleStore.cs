using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using StandardResources.DAL;
using StandardResources.Entities.Domain;
using System;

namespace StandardResources.API.Infrastructure
{
    public class ApplicationRoleStore :
        RoleStore<ApplicationRole, int, ApplicationUserRole>,
        IQueryableRoleStore<ApplicationRole, int>,
        IRoleStore<ApplicationRole, int>,
        IDisposable
    {
        public ApplicationRoleStore():base(new IdentityDbContext())
        {
            base.DisposeContext = true;
        }

        public ApplicationRoleStore(ApplicationDbContext context) : base(context)
        {

        }
    }
}