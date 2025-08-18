using System.Text.Json.Serialization;
using FooService.Handlers;

namespace FooService;

[JsonSerializable(typeof(Foo[]))]
internal partial class AppJsonSerializerContext : JsonSerializerContext;