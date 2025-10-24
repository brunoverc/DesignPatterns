using DesignPatters.FactoryMethodDemo.Domain;

namespace DesignPatters.FactoryMethodDemo.Processors;

public sealed class BoletoPaymentProcessor : IPaymentProcessor
{
    public string Method => "BOLETO";

    public Task<PaymentResult> ProcessAsync(PaymentRequest request, CancellationToken ct = default)
    {
        if (request.Amount < 5)
            return Task.FromResult(new PaymentResult(false, "", Method, "Minimum amount for boleto is 5"));

        var txId = $"boleto_{Guid.NewGuid():N}";
        return Task.FromResult(new PaymentResult(true, txId, Method, "Boleto issued"));
    }
}