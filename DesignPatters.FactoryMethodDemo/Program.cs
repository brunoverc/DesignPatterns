using DesignPatters.FactoryMethodDemo.Domain;
using DesignPatters.FactoryMethodDemo.Factories;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () =>new
{
    Message = "Factory Method Pattern Demo",
    Description = "POST /pay/{method} with JSON: { \"amount\": 120.50, \"currency\": \"BRL\" }"
});

app.MapPost("/pay/{method}", async (string method, PaymentRequest request, CancellationToken ct) =>
{
    PaymentProcessorFactory factory;
    try
    {
        factory = FactorySelector.FromMethod(method);
    }
    catch (ArgumentOutOfRangeException ex)
    {
        return Results.BadRequest(new { error = ex.Message });
    }

    var processor = factory.Create();
    var result = await processor.ProcessAsync(request, ct);
    return result.Success ? Results.Ok(result) : Results.BadRequest(result);
});

app.Run();