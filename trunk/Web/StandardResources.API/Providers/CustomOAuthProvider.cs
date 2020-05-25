using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using StandardResources.API.Infrastructure;
using StandardResources.Entities.Constants;
using StandardResources.Entities.Domain;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace StandardResources.API.Providers
{
    public class CustomOAuthProvider : OAuthAuthorizationServerProvider
    {
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return Task.FromResult<object>(null);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var allowedOrigin = "*";

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { allowedOrigin });

            var userManager = context.OwinContext.GetUserManager<ApplicationUserManager>();

            ApplicationUser user = await userManager.FindByNameAsync(context.UserName);

            if (user == null)
            {
                var userInfo = await context.Request.ReadFormAsync();

                var userEmail = userInfo.Where(w => w.Key == "email").SingleOrDefault().Value;

                user = new ApplicationUser()
                {
                    UserName = context.UserName,
                    Email = userEmail != null ? userEmail[0] : null
                };

                var userAddedResult = await userManager.CreateAsync(user, context.Password);

                if (userAddedResult.Succeeded)
                {
                    var roleAddesResult = await userManager.AddToRoleAsync(user.Id, Constants.RoleNames.ACCOUNT);
                }
            }

            ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(userManager, "JWT");

            oAuthIdentity.AddClaims(ExtendedClaimsProvider.GetClaims(user));

            var ticket = new AuthenticationTicket(oAuthIdentity, null);

            context.Validated(ticket);
        }
    }
}