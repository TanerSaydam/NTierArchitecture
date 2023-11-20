using MediatR;

namespace NTierArchitecture.Business.Features.UserRoles.SetUserRole;
public sealed record SetUserRoleCommand(
    Guid UserId,
    Guid RoleId): IRequest<Unit>;
