using MediatR;
using Microsoft.EntityFrameworkCore;
using NTierArchitecture.Entities.Repositories;

namespace NTierArchitecture.Business.Features.Roles.GetRoles;

internal sealed class GetRolesQueryHandler : IRequestHandler<GetRolesQuery, List<GetRolesQueryResponse>>
{
    private readonly IRoleRepository _roleRepository;

    public GetRolesQueryHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<List<GetRolesQueryResponse>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
    {
        var response = 
            await _roleRepository.GetAll()
            .Select(r=> new GetRolesQueryResponse(r.Id, r.Name))
            .ToListAsync(cancellationToken);

        return response;
    }
}
