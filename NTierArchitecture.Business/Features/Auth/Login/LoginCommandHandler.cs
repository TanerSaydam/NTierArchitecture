using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NTierArchitecture.Entities.Models;

namespace NTierArchitecture.Business.Features.Auth.Login;

internal sealed class LoginCommandHandler : IRequestHandler<LoginCommand, Unit>
{
    private readonly UserManager<AppUser> _userManager;

    public LoginCommandHandler(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Unit> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        AppUser appUser = await _userManager.Users.Where(p => p.UserName == request.UserNameOrEmail || p.Email == request.UserNameOrEmail).FirstOrDefaultAsync(cancellationToken);

        if(appUser is null)
        {
            throw new ArgumentException("Kullanıcı bulunamadı!");
        }

        bool checkPassword = await _userManager.CheckPasswordAsync(appUser, request.Password);
        if(!checkPassword)
        {
            throw new ArgumentException("Şifre yanlış!");
        }

        return Unit.Value;
    }
}
