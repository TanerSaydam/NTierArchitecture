using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using NTierArchitecture.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.DataAccess.Authorization;
public sealed class RoleAttribute : Attribute, IAuthorizationFilter
{
    private readonly string _role;
    private readonly IUserRoleRepository _userRoleRepository;
    public RoleAttribute(string role, IUserRoleRepository userRoleRepository)
    {
        _role = role;
        _userRoleRepository = userRoleRepository;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var userIdClaim = context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        if(userIdClaim is null)
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        var userHasRole =
            _userRoleRepository
            .GetWhere(p => p.AppUserId.ToString() == userIdClaim.Value)
            .Include(p=> p.AppRole)
            .Any(p=> p.AppRole.Name == _role);

        if(!userHasRole)
        {
            context.Result = new UnauthorizedResult();
            return;
        }
    }
}
