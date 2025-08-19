using FooService.Handlers.SampleCommands.Decorating;
using GenericPipelines.Middlewares;
using Microsoft.Extensions.Logging;

namespace FooService.Handlers.SampleCommands;

[PipelineDecorated<SampleCommandPipeline<DeleteFooCommand>>]
internal sealed class DeleteFooCommandHandler : IDeleteFooCommandHandler
{
    private readonly ILogger<DeleteFooCommandHandler> _logger;

    public DeleteFooCommandHandler(ILogger<DeleteFooCommandHandler> logger)
    {
        _logger = logger;
    }

    public Task HandleAsync(DeleteFooCommand request, CancellationToken ct = default)
    {
        _logger.LogInformation("Deleted {id}", request.Id);
        return Task.CompletedTask;
    }
}