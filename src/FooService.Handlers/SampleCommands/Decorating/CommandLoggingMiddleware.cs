using GenericPipelines.Middlewares;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace FooService.Handlers.SampleCommands.Decorating;

internal sealed class CommandLoggingMiddleware<TRequest>(ILogger<CommandLoggingMiddleware<TRequest>> logger)
    : IMiddleware<TRequest>
{
    public async Task InvokeAsync(TRequest request, NextVoidMiddlewareDelegate<TRequest> next, CancellationToken ct)
    {
        Stopwatch sw = Stopwatch.StartNew();
        try
        {
            await next(request, ct);
        }
        finally
        {
            sw.Stop();

            Type type = request?.GetType() ?? typeof(TRequest);
            logger.LogInformation("{request} request completed in {elapsed} ms.", type.Name, sw.Elapsed);
        }
    }
}