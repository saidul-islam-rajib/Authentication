using Authentication.Domain.Entities.User;

namespace Authentication.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
