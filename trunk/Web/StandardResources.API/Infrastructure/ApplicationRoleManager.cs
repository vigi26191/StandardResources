using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using StandardResources.DAL;
using StandardResources.Entities.Domain;

namespace StandardResources.API.Infrastructure
{
    public class ApplicationRoleManager : RoleManager<ApplicationRole, int>
    {
        public ApplicationRoleManager(IRoleStore<ApplicationRole, int> roleStore) : base(roleStore)
        {

        }

        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
        {
            var appDbContext = context.Get<ApplicationDbContext>();
            var appRoleManager = new ApplicationRoleManager(new ApplicationRoleStore(appDbContext));

            return appRoleManager;
        }
    }
}