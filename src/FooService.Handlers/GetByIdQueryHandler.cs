using FooService.Handlers.Pipelines;
using GenericPipelines;
using GenericPipelines.Middlewares;

namespace FooService.Handlers;

public record GetByIdQuery(int Id);

public interface IGetByIdQueryHandler: IRequestHandler<GetByIdQuery, Foo?>;

[PipelineDecorated<LoggingPipeline<GetByIdQuery, Foo>>]
internal sealed class GetByIdQueryHandler : IGetByIdQueryHandler
{
    private static readonly Foo[] SampleTodos =
    [
        new(1, "Walk the dog"),
        new(2, "Do the dishes"),
        new(3, "Do the laundry"),
        new(4, "Clean the bathroom"),
        new(5, "Clean the car")
    ];

    public Task<Foo?> HandleAsync(GetByIdQuery request, CancellationToken ct = default)
    {
        Foo? foo = SampleTodos.FirstOrDefault(a => a.Id == request.Id);
        return Task.FromResult(foo);
    }
}