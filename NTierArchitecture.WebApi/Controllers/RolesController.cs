using MediatR;
using Microsoft.AspNetCore.Mvc;
using NTierArchitecture.Business.Features.Roles.CreateRole;
using NTierArchitecture.Business.Features.Roles.GetRoles;
using NTierArchitecture.WebApi.Abstractions;

namespace NTierArchitecture.WebApi.Controllers;

public sealed class RolesController : ApiController
{
    public RolesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        await _mediator.Send(request, cancellationToken);

        return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> GetAll(GetRolesQuery request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);

        return Ok(response);
    }
}