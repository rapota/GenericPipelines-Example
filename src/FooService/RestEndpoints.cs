using FooService.Handlers;
using FooService.Handlers.SampleQueries;
using Microsoft.AspNetCore.Http.HttpResults;

namespace FooService;

internal static class RestEndpoints
{
    public static async Task<Foo[]> GetAllAsync(IGetAllQueryHandler handler, CancellationToken ct)
    {
        return await handler.HandleAsync(new GetAllQuery(), ct);
    }

    public static async Task<Results<
        NotFound,
        Ok<Foo>
    >> GetByIdAsync(IGetByIdQueryHandler handler, int id, CancellationToken ct)
    {
        Foo? foo = await handler.HandleAsync(new GetByIdQuery(id), ct);
        if (foo == null)
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(foo);
    }
}