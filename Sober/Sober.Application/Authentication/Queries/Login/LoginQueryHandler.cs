using ErrorOr;
using MediatR;
using Sober.Application.Authentication.Common;
using Sober.Application.Common.Interfaces.Authentication;
using Sober.Application.Common.Interfaces.Persistence;
using Sober.Domain.Common.Errors;
using Sober.Domain.Entities.User;

namespace Sober.Application.Authentication.Queries.Login
{
    public class LoginQueryHandler
        : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public LoginQueryHandler(
            IJwtTokenGenerator jwtTokenGenerator,
            IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            // 1. Validate the user exits
            if (_userRepository.GetUserByEmail(query.Email) is not User user)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            // 2. Validate the password is correct
            if (user.Password != query.Password)
            {
                return new[] { Errors.Authentication.InvalidCredentials };
            }

            // 3. Create JWT token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token);
        }
    }
}
