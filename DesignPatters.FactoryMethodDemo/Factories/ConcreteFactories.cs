using DesignPatters.FactoryMethodDemo.Domain;
using DesignPatters.FactoryMethodDemo.Processors;

namespace DesignPatters.FactoryMethodDemo.Factories;

public sealed class PixPaymentFactory : PaymentProcessorFactory
{
    public override IPaymentProcessor Create() => new PixPaymentProcessor();
}

public sealed class CreditCardPaymentFactory : PaymentProcessorFactory
{
    public override IPaymentProcessor Create() => new CreditCardPaymentProcessor();
}

public sealed class BoletoPaymentFactory : PaymentProcessorFactory
{
    public override IPaymentProcessor Create() => new BoletoPaymentProcessor();
}