using Xunit;

namespace Backend.Test;

public class UnitTest1
{
    [Fact]
    public void HelloWorld_ReturnsExpectedMessage()
    {
        string result = "Hello World backend ";
        Assert.Equal("Hello World backend .Net!", result);
    }
}
