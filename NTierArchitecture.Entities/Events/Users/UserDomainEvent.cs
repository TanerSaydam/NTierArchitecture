using MediatR;
using NTierArchitecture.Entities.Models;

namespace NTierArchitecture.Entities.Events.Users;
public sealed class UserDomainEvent : INotification
{
    public AppUser AppUser { get; }

    public UserDomainEvent(AppUser appUser)
    {
        AppUser = appUser;
    }
}
