using Authentication.Domain.Entities.User;

namespace Authentication.Application.Authentication.Common;

public record AuthenticationResult
(
    User User,
    string Token
);
