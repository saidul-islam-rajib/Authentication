namespace Authentication.Contracts.AuthenticationRequestResponse;

public record RegisterRequest
(
    string FirstName,
    string LastName,
    string Email,
    string Password
);
