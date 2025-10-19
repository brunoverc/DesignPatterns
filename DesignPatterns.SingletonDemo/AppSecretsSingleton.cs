using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;

namespace DesignPatterns.SingletonDemo;

public sealed class AppSecretsSingleton
{
    // Lazy guarantees single initialization and thread-safety (ExecutionAndPublication)
    private static readonly Lazy<AppSecretsSingleton> _instance = new(() => new AppSecretsSingleton(),
        LazyThreadSafetyMode.ExecutionAndPublication);
    
    //Unique public point to access
    public static AppSecretsSingleton Instance => _instance.Value;
    
    public string ApiKey { get; }
    public string ServiceUrl { get; }
    public IReadOnlyList<string> EnabledFeatures { get; }

    private AppSecretsSingleton()
    {
        var path = Path.Combine(AppContext.BaseDirectory, "appsettings.secrets.json");
        if(!File.Exists(path))
            throw new FileNotFoundException("appsettings.secrets.json not found", path);

        var json = File.ReadAllText(path);
        
        var payload = JsonSerializer.Deserialize<SecretsPayload>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        }) ?? throw new InvalidOperationException("Falha ao desserializar segredos.");

        ApiKey = payload.ApiKey ?? string.Empty;
        ServiceUrl = payload.ServiceUrl ?? string.Empty;
        EnabledFeatures = payload.EnabledFeatures?.ToArray() ?? Array.Empty<string>();
    }
    
    private sealed class SecretsPayload
    {
        [JsonPropertyName("ApiKey")] 
        public string? ApiKey { get; set; }
        [JsonPropertyName("ServiceUrl")] 
        public string? ServiceUrl { get; set; }
        [JsonPropertyName("EnabledFeatures")] 
        public string[]? EnabledFeatures { get; set; }
    }
}