using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Core.Domain.Interfaces
{
    public interface IAppUser
    {
        string Name { get; }
        Guid GetUserId();
        string GetUserEmail();
        bool IsAuthenticated();
        bool IsInRole(string role);
        IEnumerable<Claim> GetClaimsIdentity();

    }
}
