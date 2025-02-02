using ErrorOr;
using MediatR;
using Authentication.Application.Authentication.Common;

namespace Authentication.Application.Authentication.Queries.Login;

public record LoginQuery
(
    string Email,
    string Password
) : IRequest<ErrorOr<AuthenticationResult>>;
