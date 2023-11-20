using Microsoft.AspNetCore.Mvc;

namespace NTierArchitecture.DataAccess.Authorization;
public sealed class RoleFilterAttribute : TypeFilterAttribute
{
    public RoleFilterAttribute(string role) : base(typeof(RoleAttribute))
    {
        Arguments = new object[] { role };
    }
}
