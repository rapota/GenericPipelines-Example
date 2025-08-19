using FooService.Handlers.SampleQueries.Decorating;
using GenericPipelines.Middlewares;

namespace FooService.Handlers.SampleQueries;

[PipelineDecorated<SampleQueryPipeline<GetAllQuery, Foo[]>>]
internal sealed class GetAllQueryHandler : IGetAllQueryHandler
{
    private static readonly Foo[] SampleTodos =
    [
        new(1, "Walk the dog"),
        new(2, "Do the dishes"),
        new(3, "Do the laundry"),
        new(4, "Clean the bathroom"),
        new(5, "Clean the car")
    ];

    public Task<Foo[]> HandleAsync(GetAllQuery request, CancellationToken ct = default)
    {
        return Task.FromResult(SampleTodos);
    }
}