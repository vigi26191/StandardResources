using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using StandardResources.DAL;
using StandardResources.Entities.Domain;

namespace StandardResources.API.Infrastructure
{
    public class ApplicationUserManager : UserManager<ApplicationUser, int>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser, int> store) : base(store)
        {

        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var appDbContext = context.Get<ApplicationDbContext>();
            var appUserManager = new ApplicationUserManager(new ApplicationUserStore(appDbContext));

            return appUserManager;
        }
    }
}