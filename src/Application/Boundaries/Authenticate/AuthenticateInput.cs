namespace Application.Boundaries.Authenticate
{
    using Domain.ValueObjects;

    public sealed class AuthenticateInput : IUseCaseInput
    {
        public Username Username { get; }
        public Password Password { get; }
        public string JWTSecret { get; }

        public AuthenticateInput(Username username, Password password, string jwtSecret)
        {
            Username = username;
            Password = password;
            JWTSecret = jwtSecret;
        }
    }
}
