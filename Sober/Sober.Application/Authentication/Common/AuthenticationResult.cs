using Sober.Domain.Entities.User;

namespace Sober.Application.Authentication.Common
{
    public record AuthenticationResult
    (
        User User,
        string Token
    );
}
