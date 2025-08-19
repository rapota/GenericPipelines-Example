using GenericPipelines;

namespace FooService.Handlers.SampleQueries;

public record GetByIdQuery(int Id);

public interface IGetByIdQueryHandler : IRequestHandler<GetByIdQuery, Foo?>;
