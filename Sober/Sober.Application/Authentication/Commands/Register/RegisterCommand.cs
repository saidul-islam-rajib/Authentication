using ErrorOr;
using MediatR;
using Authentication.Application.Authentication.Common;

namespace Authentication.Application.Authentication.Commands.Register;

public record RegisterCommand
(
    string FirstName,
    string LastName,
    string Email,
    string Password

) : IRequest<ErrorOr<AuthenticationResult>>;
