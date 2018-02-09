namespace Acerola.UI
{
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Autofac.Extensions.DependencyInjection;
    using Microsoft.Extensions.Configuration;
    using Serilog;
    using Serilog.Events;
    using System.IO;

    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                    .UseStartup<Startup>()
                    .ConfigureAppConfiguration((builderContext, config) =>
                    {
                        IHostingEnvironment env = builderContext.HostingEnvironment;
                        config.AddJsonFile("autofac.json")
                        .AddEnvironmentVariables();
                    })
                    .UseSerilog((hostingContext, loggerConfiguration) =>
                    {
                        loggerConfiguration.MinimumLevel.Debug()
                            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                            .Enrich.FromLogContext()
                            .WriteTo.RollingFile(Path.Combine(hostingContext.HostingEnvironment.ContentRootPath, "logs/log-{Date}.log"));
                    })
                    .ConfigureServices(services => services.AddAutofac())
                    .Build();
        }
    }
}
