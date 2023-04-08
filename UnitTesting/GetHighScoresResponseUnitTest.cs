using GameServer;
using GameServer.Entities;
using Microsoft.Extensions.Logging;
using Moq;
using StrawberryShake;

namespace UnitTesting;

public class GetHighScoresResponseUnitTest
{
    [Fact]
    public void Test_Constructor_Empty_Params_Throws()
    {
        var mockOperationResult = new Mock<IOperationResult<IGetHighScoresResult>>();
        var mockLogger = new Mock<ILogger<GetHighScoresResponse>>();
        GetHighScoresResponse ConstructorLambda() => new(mockOperationResult.Object, mockLogger.Object);
        Assert.Throws<ArgumentNullException>(ConstructorLambda);
    }
}
