using DesignPatterns.SingletonDemo;
using System.Collections.Concurrent;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => new
{
    Message = "Singleton Pattern demo (.NET 10)",
    Hint = "Access / secrets, /instance, /parallel-check"
});

app.MapGet("/secrets", () => new
{
    AppSecretsSingleton.Instance.ApiKey,
    AppSecretsSingleton.Instance.ServiceUrl,
    AppSecretsSingleton.Instance.EnabledFeatures
});

app.MapGet("/instance", () => new
{
    InstanceHash  = AppSecretsSingleton.Instance.GetHashCode()
});

app.MapGet("/parallel-check", () =>
{
    var bag = new ConcurrentBag<int>();

    Parallel.For(0, 200, _ =>
    {
        var hash = AppSecretsSingleton.Instance.GetHashCode();
        bag.Add(hash);
    });

    var distinct = bag.Distinct().Count();
    return new
    {
        Samples = bag.Count,
        DistinctHashes = distinct,
        InstanceHash = bag.FirstOrDefault()
    };
});

app.Run();