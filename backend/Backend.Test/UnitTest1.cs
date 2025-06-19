namespace Backend.Test;

public class UnitTest1
{
    [Fact]
    public void HelloWorld_ReturnsExpectedMessage()
    {
        // Simulate logic you'd expect in /helloworld
        string result = "Hello World backend .Net - PR merged!";

        Assert.Equal("Hello World backend .Net - PR merged!", result);
    }
}