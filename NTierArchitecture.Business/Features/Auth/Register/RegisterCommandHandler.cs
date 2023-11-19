using MediatR;
using Microsoft.AspNetCore.Identity;
using NTierArchitecture.Entities.Models;

namespace NTierArchitecture.Business.Features.Auth.Register;

internal sealed class RegisterCommandHandler : IRequestHandler<RegisterCommand, Unit>
{
    private readonly UserManager<AppUser> _userManager;

    public RegisterCommandHandler(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Unit> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var checkUserNameExists = await _userManager.FindByNameAsync(request.UserName);
        if(checkUserNameExists is not null)
        {
            throw new ArgumentException("Bu kullanıcı adı daha önce kullanılmış!");
        }

        var checkEmailExists = await _userManager.FindByEmailAsync(request.Email);
        if(checkEmailExists is not null)
        {
            throw new ArgumentException("Bu mail adresi daha önce kullanılmış!");
        }

        AppUser appUser = new()
        {
            Id = Guid.NewGuid(),
            Email = request.Email,
            Name = request.Name,
            Lastname = request.Lastname,
            UserName = request.UserName
        };

        await _userManager.CreateAsync(appUser, request.Password);

        return Unit.Value;
    }
}
