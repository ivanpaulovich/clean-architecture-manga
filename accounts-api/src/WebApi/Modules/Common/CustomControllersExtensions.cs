namespace WebApi.Modules.Common
{
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    ///     Custom Controller Extensions.
    /// </summary>
    public static class CustomControllersExtensions
    {
        /// <summary>
        ///     Add Custom Controller dependencies.
        /// </summary>
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
