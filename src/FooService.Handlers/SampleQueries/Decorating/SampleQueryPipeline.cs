using GenericPipelines.Middlewares;

namespace FooService.Handlers.SampleQueries.Decorating;

internal sealed class SampleQueryPipeline<TRequest, TResponse> : Pipeline<TRequest, TResponse>
{
    public SampleQueryPipeline(
        MetricLoggingMiddleware<TRequest, TResponse> metricLoggingMiddleware,
        ExceptionLoggingMiddleware<TRequest, TResponse> exceptionLoggingMiddleware)
        : base(
            // Parameter's order represents nesting hierarchy of middlewares.
            metricLoggingMiddleware,
            exceptionLoggingMiddleware)
    {
    }
}