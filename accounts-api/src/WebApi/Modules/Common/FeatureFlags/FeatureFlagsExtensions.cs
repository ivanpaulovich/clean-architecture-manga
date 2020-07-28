namespace WebApi.Modules.Common.FeatureFlags
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.FeatureManagement;

    /// <summary>
    ///     Feature Flags Extension.
    /// </summary>
    public static class FeatureFlagsExtensions
    {
        /// <summary>
        ///     Add Feature Flags dependencies.
        /// </summary>
        public static IServiceCollection AddFeatureFlags(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddFeatureManagement(configuration);

            IFeatureManager featureManager = services.BuildServiceProvider()
                .GetRequiredService<IFeatureManager>();

            services.AddMvc()
                .ConfigureApplicationPartManager(apm =>
                    apm.FeatureProviders.Add(
                        new CustomControllerFeatureProvider(featureManager)));

            return services;
        }
    }
}
