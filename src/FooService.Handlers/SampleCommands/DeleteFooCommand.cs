using GenericPipelines;

namespace FooService.Handlers.SampleCommands;

public record DeleteFooCommand(int Id);

public interface IDeleteFooCommandHandler : IRequestHandler<DeleteFooCommand>;