using FooService.Handlers.SampleCommands.Decorating;
using FooService.Handlers.SampleQueries.Decorating;
using GenericPipelines.Generated;
using Microsoft.Extensions.DependencyInjection;

namespace FooService.Handlers;

public static class HandlersModuleExtensions
{
    public static IServiceCollection AddHandlersModule(this IServiceCollection services) =>
        services
            .AddMiddlewares()

            .AddPipelines()

            // This one is generated
            .RegisterDecoratedRequestHandlers();

    private static IServiceCollection AddMiddlewares(this IServiceCollection services) =>
        services
            .AddTransient(typeof(CommandLoggingMiddleware<>))

            .AddTransient(typeof(MetricLoggingMiddleware<,>))
            .AddTransient(typeof(ExceptionLoggingMiddleware<,>))
        ;

    private static IServiceCollection AddPipelines(this IServiceCollection services) =>
        services
            .AddTransient(typeof(SampleCommandPipeline<>))
            .AddTransient(typeof(SampleQueryPipeline<,>))
        ;
}