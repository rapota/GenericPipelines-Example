using System.Diagnostics;
using GenericPipelines.Middlewares;
using Microsoft.Extensions.Logging;

namespace FooService.Handlers.SampleQueries.Decorating;

internal sealed class MetricLoggingMiddleware<TRequest, TResponse>(ILogger<MetricLoggingMiddleware<TRequest, TResponse>> logger)
    : IMiddleware<TRequest, TResponse>
{
    public async Task<TResponse> InvokeAsync(TRequest request, NextMiddlewareDelegate<TRequest, TResponse> next, CancellationToken ct)
    {
        Stopwatch sw = Stopwatch.StartNew();
        try
        {
            return await next(request, ct);
        }
        finally
        {
            sw.Stop();

            Type type = request?.GetType() ?? typeof(TRequest);
            logger.LogInformation("{request} request completed in {elapsed} ms.", type.Name, sw.Elapsed);
        }
    }
}