using MediatR;

namespace NTierArchitecture.Business.Features.Roles.CreateRole;
public sealed record CreateRoleCommand(
    string Name): IRequest<Unit>;
