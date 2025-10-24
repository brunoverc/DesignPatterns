namespace DesignPatters.FactoryMethodDemo.Domain;

public record PaymentRequest(decimal Amount, string Currency, Dictionary<string, string>? Metadata = null);

public record PaymentResult(bool Success, string TransactionId, string Method, string Message);

public interface IPaymentProcessor
{
    string Method { get; }
    Task<PaymentResult> ProcessAsync(PaymentRequest request, CancellationToken cancellationToken = default);
}