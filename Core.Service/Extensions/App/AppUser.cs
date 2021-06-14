using Core.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Core.Service.Extensions
{
    public class AppUser : IAppUser
    {

        private readonly IHttpContextAccessor _accessor;

        public AppUser(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public string Name => _accessor.HttpContext.User.Identity.Name;



        public IEnumerable<Claim> GetClaimsIdentity()=>
                            _accessor.HttpContext.User.Claims;

        public string GetUserEmail()=>
                       IsAuthenticated() ? _accessor.HttpContext.User.GetUserEmail() : "";

        public Guid GetUserId() =>
                    IsAuthenticated() ? Guid.Parse(_accessor.HttpContext.User.GetUserId()) : Guid.Empty;



        public bool IsAuthenticated() =>
                    _accessor.HttpContext.User.Identity.IsAuthenticated;

        public bool IsInRole(string role) =>
                _accessor.HttpContext.User.IsInRole(role);

       
    }
}
