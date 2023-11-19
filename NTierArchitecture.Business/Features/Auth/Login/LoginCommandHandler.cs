using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NTierArchitecture.Entities.Abstractions;
using NTierArchitecture.Entities.Models;

namespace NTierArchitecture.Business.Features.Auth.Login;

internal sealed class LoginCommandHandler : IRequestHandler<LoginCommand, LoginCommandResponse>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IJwtProvider _jwtProvider;

    public LoginCommandHandler(UserManager<AppUser> userManager, IJwtProvider jwtProvider)
    {
        _userManager = userManager;
        _jwtProvider = jwtProvider;
    }

    public async Task<LoginCommandResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
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

        string token = await _jwtProvider.CreateTokenAsync(appUser);

        return new(AccessToken: token, UserId: appUser.Id);
    }
}
