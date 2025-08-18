using FooService.Handlers;
using Microsoft.AspNetCore.Http.HttpResults;

namespace FooService;

internal static class RestEndpoints
{
    private static readonly Foo[] SampleTodos =
    [
        new(1, "Walk the dog"),
        new(2, "Do the dishes"),
        new(3, "Do the laundry"),
        new(4, "Clean the bathroom"),
        new(5, "Clean the car")
    ];

    public static Task<Foo[]> GetAllAsync()
    {
        return Task.FromResult(SampleTodos);
    }

    public static async Task<Results<
        NotFound,
        Ok<Foo>
    >> GetByIdAsync(int id)
    {
        Foo? foo = SampleTodos.FirstOrDefault(a => a.Id == id);
        if (foo == null)
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(foo);
    }
}