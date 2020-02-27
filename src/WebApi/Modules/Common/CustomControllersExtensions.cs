namespace WebApi.Modules.Common
{
    using Microsoft.Extensions.DependencyInjection;

    public static class CustomControllersExtensions
    {
        public static IServiceCollection AddCustomControllers(this IServiceCollection services)
        {
            services
                .AddMvc(options => { options.Filters.Add(typeof(ExceptionFilter)); });

            services
                .AddHttpContextAccessor()
                .AddControllers()
                .AddControllersAsServices();

            return services;
        }
    }
}
