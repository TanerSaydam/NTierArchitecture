using MediatR;

namespace NTierArchitecture.Business.Features.Roles.GetRoles;
public sealed record GetRolesQuery(): IRequest<List<GetRolesQueryResponse>>;
