using DesignPatters.FactoryMethodDemo.Domain;

namespace DesignPatters.FactoryMethodDemo.Factories;

public abstract class PaymentProcessorFactory
{
    public abstract IPaymentProcessor Create();
}