namespace WebApi.Modules.Common
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using System.Linq;
    using System.Text.Json;

    /// <summary>
    /// </summary>
    public static class LoggingExtensions
    {
        /// <summary>
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddInvalidRequestLogging(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(o =>
            {
                o.InvalidModelStateResponseFactory = actionContext =>
                {
                    ILogger<Startup>? logger = actionContext
                        .HttpContext
                        .RequestServices
                        .GetRequiredService<ILogger<Startup>>();

                    var errors = actionContext.ModelState
                        .Values
                        .SelectMany(x => x.Errors)
                        .Select(x => x.ErrorMessage)
                        .ToList();

                    string jsonModelState = JsonSerializer.Serialize(errors);
                    logger.LogWarning("Invalid request.", jsonModelState);

                    var problemDetails = new ValidationProblemDetails(actionContext.ModelState);
                    return new BadRequestObjectResult(problemDetails);
                };
            });

            return services;
        }
    }
}
