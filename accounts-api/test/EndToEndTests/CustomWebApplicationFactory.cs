namespace EndToEndTests
{
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using System.Collections.Generic;
    using WebApi;

    /// <summary>
    /// </summary>
    public sealed class CustomWebApplicationFactory : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder) => builder.ConfigureAppConfiguration(
            (context, config) =>
            {
                config.AddInMemoryCollection(
                    new Dictionary<string, string>
                    {
                        ["PersistenceModule:UseFake"] = "false",
                        ["PersistenceModule:DefaultConnection"] = "Server=localhost;User Id=sa;Password=<YourStrong!Passw0rd>;Database=Accounts;",
                        ["CurrencyExchangeModule:UseFake"] = "false"
                    });
            }).ConfigureServices(services =>
        {
            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = "Test";
                    x.DefaultChallengeScheme = "Test";
                })
                .AddScheme<AuthenticationSchemeOptions, TestAuthenticationHandler>(
                    "Test", options => { });
        });
    }
}
