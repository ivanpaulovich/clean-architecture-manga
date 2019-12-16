namespace WebApi.DependencyInjection.Metrics
{
    using Microsoft.AspNetCore.Builder;

    public static class RequestMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestMiddleware(this IApplicationBuilder appBuilder)
        {
            return appBuilder.UseMiddleware<RequestMiddleware>();
        }
    }
}
