namespace WebApi.DependencyInjection.Metrics
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;
    using Prometheus;

    public class RequestMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public RequestMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<RequestMiddleware>();
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var path = httpContext.Request.Path.Value;
            var method = httpContext.Request.Method;

            var counter = Metrics.CreateCounter(
                "http_requests_total",
                "HTTP Requests Total",
                new CounterConfiguration
                {
                    LabelNames = new[] { "path", "method", "status" },
                });

            var statusCode = 200;

            try
            {
                await _next.Invoke(httpContext);
            }
            catch (Exception)
            {
                statusCode = 500;
                counter.WithLabels(path, method, statusCode.ToString()).Inc();
            }

            if (path != "/metrics")
            {
                statusCode = httpContext.Response.StatusCode;
                counter.WithLabels(path, method, statusCode.ToString()).Inc();
            }
        }
    }
}
