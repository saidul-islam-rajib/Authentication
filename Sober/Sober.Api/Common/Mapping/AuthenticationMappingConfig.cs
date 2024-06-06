using Mapster;
using Sober.Application.Authentication.Commands.Register;
using Sober.Application.Authentication.Common;
using Sober.Application.Authentication.Queries.Login;
using Sober.Contracts.Authentication;

namespace Sober.Api.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterRequest, RegisterCommand>();
            config.NewConfig<LoginRequest, LoginQuery>();

            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest, src => src.User);
        }
    }
}
