using FooService.Handlers.Middleware;
using FooService.Handlers.Pipelines;
using GenericPipelines.Generated;
using Microsoft.Extensions.DependencyInjection;

namespace FooService.Handlers;

public static class HandlersModuleExtensions
{
    public static IServiceCollection AddHandlersModule(this IServiceCollection services)
    {
        services
            .AddTransient(typeof(LoggingMiddleware<,>))
            .AddTransient(typeof(LoggingPipeline<,>))
        ;

        // This one is generated
        services.RegisterDecoratedRequestHandlers();

        return services;
    }
}