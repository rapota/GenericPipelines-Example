using FooService;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
});

var app = builder.Build();

var todosApi = app.MapGroup("/foos");

todosApi.MapGet("/", RestEndpoints.GetAllAsync);
todosApi.MapGet("/{id}", RestEndpoints.GetByIdAsync);

app.Run();