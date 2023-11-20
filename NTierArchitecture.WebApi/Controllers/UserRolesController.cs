using MediatR;
using Microsoft.AspNetCore.Mvc;
using NTierArchitecture.Business.Features.UserRoles.SetUserRole;
using NTierArchitecture.WebApi.Abstractions;

namespace NTierArchitecture.WebApi.Controllers;

public sealed class UserRolesController : ApiController
{
    public UserRolesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> SetRole(SetUserRoleCommand request, CancellationToken cancellationToken)
    {
        await _mediator.Send(request, cancellationToken);

        return NoContent();
    }

}
