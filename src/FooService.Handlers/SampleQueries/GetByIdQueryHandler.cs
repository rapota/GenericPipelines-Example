using FooService.Handlers.SampleQueries.Decorating;
using GenericPipelines.Middlewares;

namespace FooService.Handlers.SampleQueries;

[PipelineDecorated<SampleQueryPipeline<GetByIdQuery, Foo>>]
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