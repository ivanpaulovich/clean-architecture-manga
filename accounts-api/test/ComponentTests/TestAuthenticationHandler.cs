namespace ComponentTests
{
    using System.Security.Claims;
    using System.Text.Encodings.Web;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;

    /// <summary>
    /// </summary>
    public sealed class TestAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        /// <summary>
        /// </summary>
        /// <param name="options"></param>
        /// <param name="logger"></param>
        /// <param name="encoder"></param>
        /// <param name="clock"></param>
        public TestAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger,
            UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            Claim[] claims =
            {
                new Claim(ClaimTypes.NameIdentifier, "test"), new Claim(ClaimTypes.Name, "test"),
                new Claim("id", "92b93e37-0995-4849-a7ed-149e8706d8ef")
            };

            ClaimsIdentity identity = new ClaimsIdentity(claims, this.Scheme.Name);
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);
            AuthenticationTicket ticket = new AuthenticationTicket(principal, this.Scheme.Name);

            return await Task.FromResult(AuthenticateResult.Success(ticket));
        }
    }
}
