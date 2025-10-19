using DesignPatterns.SingletonDemo;
using Xunit;

namespace DesignPatternsTests;

public class SingletonTests
{
    [Fact]
    public void Instance_Should_Be_Same_Reference()
    {
        var a = AppSecretsSingleton.Instance;
        var b = AppSecretsSingleton.Instance;

        Assert.True(object.ReferenceEquals(a, b));
        Assert.Equal(a.GetHashCode(), b.GetHashCode());
    }
}