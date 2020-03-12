namespace WebApi.Modules.Common
{
    using Microsoft.AspNetCore.Builder;
    using Prometheus;

    public static class HttpMetricsExtensions
    {
        public static IApplicationBuilder UseMangaHttpMetrics(this IApplicationBuilder appBuilder)
        {
            return appBuilder.UseHttpMetrics(options =>
            {
                options.RequestDuration.Enabled = false;
                options.InProgress.Enabled = false;
                options.RequestCount.Counter = Metrics.CreateCounter(
                    "http_requests_total",
                    "HTTP Requests Total",
                    new CounterConfiguration {LabelNames = new[] {"controller", "method", "code"}});
            });
        }
    }
}
