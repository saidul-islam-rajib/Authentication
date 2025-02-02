using Mapster;
using Authentication.Application.Authentication.Commands.Register;
using Authentication.Application.Authentication.Common;
using Authentication.Application.Authentication.Queries.Login;
using Authentication.Contracts.AuthenticationRequestResponse;

namespace Authentication.Api.Common.Mapping;

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
