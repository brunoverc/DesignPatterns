using DesignPatters.FactoryMethodDemo.Domain;

namespace DesignPatters.FactoryMethodDemo.Processors;

public sealed class PixPaymentProcessor : IPaymentProcessor
{
    public string Method => "PIX";

    public Task<PaymentResult> ProcessAsync(PaymentRequest request, CancellationToken cancellationToken = default)
    {
        if (request.Amount <= 0) 
            return Task.FromResult(new PaymentResult(false, "", Method, "Invalid amount"));

        var txId = $"pix_{Guid.NewGuid():N}";
        return Task.FromResult(new PaymentResult(true, txId, Method, "Payment processed via PIX"));
    }
}