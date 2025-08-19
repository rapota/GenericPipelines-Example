using GenericPipelines.Middlewares;

namespace FooService.Handlers.SampleCommands.Decorating;

internal sealed class SampleCommandPipeline<TRequest> : Pipeline<TRequest>
{
    public SampleCommandPipeline(CommandLoggingMiddleware<TRequest> commandLoggingMiddleware)
        : base(commandLoggingMiddleware)
    {
    }
}