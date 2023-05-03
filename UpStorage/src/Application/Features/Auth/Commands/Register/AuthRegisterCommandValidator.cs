using Application.Common.Interfaces;
using FluentValidation;

namespace Application.Features.Auth.Commands.Register;

public class AuthRegisterCommandValidator:AbstractValidator<AuthRegisterCommand>
{
    private readonly IAuthenticationService _authenticationService;
    
    public AuthRegisterCommandValidator(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;

        RuleFor(x => x.Email)
            .MustAsync(CheckIfUserExists)
            .WithMessage("There is already an user with given email");
    }

    private async Task<bool> CheckIfUserExists(string email, CancellationToken cancellationToken)
    {
        var doesExists = await _authenticationService.CheckIfUserExists(email, cancellationToken);

        if (doesExists) return false;
        return true;

    }

}