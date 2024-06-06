using ErrorOr;
using MediatR;
using Sober.Application.Authentication.Common;

namespace Sober.Application.Authentication.Commands.Register
{
    public record RegisterCommand
    (
        string FirstName,
        string LastName,
        string Email,
        string Password

    ) : IRequest<ErrorOr<AuthenticationResult>>;
}
