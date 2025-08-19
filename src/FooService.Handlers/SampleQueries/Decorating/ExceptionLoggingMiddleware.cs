using GenericPipelines.Middlewares;
using Microsoft.Extensions.Logging;

namespace FooService.Handlers.SampleQueries.Decorating;

internal sealed class ExceptionLoggingMiddleware<TRequest, TResponse>(ILogger<MetricLoggingMiddleware<TRequest, TResponse>> logger)
    : IMiddleware<TRequest, TResponse>
{
    public async Task<TResponse> InvokeAsync(TRequest request, NextMiddlewareDelegate<TRequest, TResponse> next, CancellationToken ct)
    {
        try
        {
            return await next(request, ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unhandled exception.");
            throw;
        }
    }
}