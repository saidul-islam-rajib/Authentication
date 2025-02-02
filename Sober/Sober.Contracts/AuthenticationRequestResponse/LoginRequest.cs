namespace Authentication.Contracts.AuthenticationRequestResponse;

public record LoginRequest
(
    string Email,
    string Password
);
