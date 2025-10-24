using DesignPatters.FactoryMethodDemo.Domain;

namespace DesignPatters.FactoryMethodDemo.Processors;

public sealed class CreditCardPaymentProcessor : IPaymentProcessor
{
    public string Method => "CREDIT_CARD";

    public Task<PaymentResult> ProcessAsync(PaymentRequest request, CancellationToken ct = default)
    { 
        if (request.Amount > 10000)
            return Task.FromResult(new PaymentResult(false, "", Method, "Amount exceeds card limit"));

        var txId = $"cc_{Guid.NewGuid():N}";
        return Task.FromResult(new PaymentResult(true, txId, Method, "Payment processed via Credit Card"));
    }
}