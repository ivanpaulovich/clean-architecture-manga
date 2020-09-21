namespace EndToEndTests
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Microsoft.Extensions.Configuration;
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
            });
    }
}
