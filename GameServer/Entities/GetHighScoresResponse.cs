using StrawberryShake;

namespace GameServer.Entities;
public class GetHighScoresResponse : BaseResponse<List<HighScore>>
{
    private readonly ILogger<GetHighScoresResponse>? _logger;

    
    public GetHighScoresResponse(IOperationResult<IGetHighScoresResult> operationResult, ILogger<GetHighScoresResponse>? logger) 
        : base(PrepareResponse(operationResult, out var errorMessage), errorMessage)
    {
        _logger = logger;
        
        if (!String.IsNullOrWhiteSpace(errorMessage))
        {
            _logger?.LogError(errorMessage);
            ErrorMessage = "We're sorry, there seems to be a problem. Please try again.";
        }
    }

    private static List<HighScore>? PrepareResponse(IOperationResult<IGetHighScoresResult> operationResult, out String? errorMessage)
    {
        var responseData = operationResult.Data?.Flappy_high_score.ToList().ConvertAll(HighScore.From);
        errorMessage = null;
        if (operationResult.Errors.Count > 0)
        {
            errorMessage = operationResult.Errors.First().Message;
        }

        return responseData;
    }
}
