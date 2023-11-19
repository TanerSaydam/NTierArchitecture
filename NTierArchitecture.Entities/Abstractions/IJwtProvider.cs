using NTierArchitecture.Entities.Models;

namespace NTierArchitecture.Entities.Abstractions;
public interface IJwtProvider
{
    Task<string> CreateTokenAsync(AppUser user);
}
