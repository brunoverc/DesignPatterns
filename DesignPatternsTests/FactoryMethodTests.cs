using DesignPatters.FactoryMethodDemo.Domain;
using DesignPatters.FactoryMethodDemo.Factories;
using DesignPatters.FactoryMethodDemo.Processors;
using Xunit;

namespace DesignPatternsTests;

public class FactoryMethodTests
{
    [Theory]
    [InlineData("pix", typeof(PixPaymentProcessor))]
    [InlineData("credit", typeof(CreditCardPaymentProcessor))]
    [InlineData("boleto", typeof(BoletoPaymentProcessor))]
    public void FactorySelector_Should_Return_Correct_ConcreteFactory_And_Product(string method, Type expectedProcessor)
    {
        var factory = FactorySelector.FromMethod(method);
        var processor = factory.Create();

        Assert.NotNull(factory);
        Assert.NotNull(processor);
        Assert.Equal(expectedProcessor, processor.GetType());
    }

    [Fact]
    public async Task PixProcessor_Should_Process_Successfully_For_Positive_Amount()
    {
        var factory = new PixPaymentFactory();
        var processor = factory.Create();

        var request = new PaymentRequest(10m, "BRL");
        var result = await processor.ProcessAsync(request);

        Assert.True(result.Success);
        Assert.Equal("PIX", result.Method);
        Assert.False(string.IsNullOrWhiteSpace(result.TransactionId));
    }

    [Fact]
    public async Task CreditCardProcessor_Should_Fail_When_Amount_Exceeds_Limit()
    {
        var factory = new CreditCardPaymentFactory();
        var processor = factory.Create();

        var request = new PaymentRequest(20000m, "BRL");
        var result = await processor.ProcessAsync(request);

        Assert.False(result.Success);
        Assert.Equal("CREDIT_CARD", result.Method);
        Assert.True(string.IsNullOrWhiteSpace(result.TransactionId));
    }

    [Fact]
    public async Task BoletoProcessor_Should_Fail_When_Amount_Is_Too_Low()
    {
        var factory = new BoletoPaymentFactory();
        var processor = factory.Create();

        var request = new PaymentRequest(3m, "BRL");
        var result = await processor.ProcessAsync(request);

        Assert.False(result.Success);
        Assert.Equal("BOLETO", result.Method);
    }
}