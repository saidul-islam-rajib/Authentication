using ErrorOr;
using MediatR;
using Sober.Application.Authentication.Common;

namespace Sober.Application.Authentication.Queries.Login
{
    public record LoginQuery
    (
        string Email,
        string Password
    ) : IRequest<ErrorOr<AuthenticationResult>>;
}
