namespace DesignPatters.FactoryMethodDemo.Factories;

public static class FactorySelector
{
    public static PaymentProcessorFactory FromMethod(string method) =>
        method.ToLowerInvariant() switch
        {
            "pix" or "px" => new PixPaymentFactory(),
            "credit" or "card" or "creditcard" => new CreditCardPaymentFactory(),
            "boleto" => new BoletoPaymentFactory(),
            _ => throw new ArgumentOutOfRangeException(nameof(method), $"Unsupported mathod: {method}")
        };
}