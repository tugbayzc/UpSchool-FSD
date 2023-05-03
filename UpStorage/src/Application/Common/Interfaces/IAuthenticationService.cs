using Application.Common.Models.Auth;
using Application.Features.Auth.Commands.Login;
using Microsoft.AspNetCore.Identity;

namespace Application.Common.Interfaces;

public interface IAuthenticationService
{
    Task<string> CreateUserAsync(CreateUserDto createUserDto, CancellationToken cancellationToken);
    Task<string> GenerateEmailActivationTokenAsync(string userId, CancellationToken cancellationToken);

    Task<bool> CheckIfUserExists(string email, CancellationToken cancellationToken);

    Task<JwtDto> LoginAsync(AuthLoginRequest authLoginRequest, CancellationToken cancellationToken);
}