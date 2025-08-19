using GenericPipelines;

namespace FooService.Handlers.SampleQueries;

public record GetAllQuery;

public interface IGetAllQueryHandler : IRequestHandler<GetAllQuery, Foo[]>;