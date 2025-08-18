using FooService.Handlers.Middleware;
using GenericPipelines.Middlewares;

namespace FooService.Handlers.Pipelines;

internal sealed class LoggingPipeline<TRequest, TResponse> : Pipeline<TRequest, TResponse>
{
    public LoggingPipeline(LoggingMiddleware<TRequest, TResponse> loggingMiddleware)
        : base(loggingMiddleware)
    {
    }
}