using FooService;
using FooService.Handlers;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.AddHandlersModule();

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
});

var app = builder.Build();

var todosApi = app.MapGroup("/foos");

todosApi.MapGet("/", RestEndpoints.GetAllAsync);
todosApi.MapGet("/{id}", RestEndpoints.GetByIdAsync);
todosApi.MapDelete("/{id}", RestEndpoints.DeleteAsync);

app.Run();