using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Service.Extensions
{
    public class CustomAuthorize
    {
        public static bool ValidarClaimsUsuario(HttpContext context,string claimName,string claimValue)
        {
            return context.User.Identity.IsAuthenticated &&
                   context.User.Claims.Any(claim => claim.Type == claimName && claim.Value.Contains(claimValue));
        }



    }
}
