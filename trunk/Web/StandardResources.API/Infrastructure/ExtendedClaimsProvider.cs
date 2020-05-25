using StandardResources.Entities.Domain;
using System.Collections.Generic;
using System.Security.Claims;

namespace StandardResources.API.Infrastructure
{
    public static class ExtendedClaimsProvider
    {
        public static IEnumerable<Claim> GetClaims(ApplicationUser user)
        {
            List<Claim> claims = new List<Claim>();

            claims.Add(CreateClaim("userName", user.UserName));

            return claims;
        }

        public static Claim CreateClaim(string type, string value)
        {
            return new Claim(type, value, ClaimValueTypes.String);
        }
    }
}