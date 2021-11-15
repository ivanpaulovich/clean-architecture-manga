namespace WebApi.Modules.Common;

using Microsoft.AspNetCore.Builder;
using Prometheus;

/// <summary>
///     Http Metrics Extensions.
/// </summary>
public static class HttpMetricsExtensions
{
    /// <summary>
    ///     Add Prometheus dependencies.
    /// </summary>
    public static IApplicationBuilder UseCustomHttpMetrics(this IApplicationBuilder appBuilder) =>
        appBuilder
            .UseMetricServer()
            .UseHttpMetrics(options =>
            {
                options.RequestDuration.Enabled = true;
                options.InProgress.Enabled = true;
                options.RequestCount.Enabled = true;
            });
}
