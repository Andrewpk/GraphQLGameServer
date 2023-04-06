using GameServer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GameServer.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class HighScoreController : ControllerBase
{
    
    private readonly IHasuraClient _client;
    private readonly ILogger<HighScoreController> _logger;
    private readonly ILoggerFactory _loggerFactory;

    public HighScoreController(IHasuraClient client, ILogger<HighScoreController> logger, ILoggerFactory loggerFactory)
    {
        _client = client;
        _logger = logger;
        _loggerFactory = loggerFactory;
    }

    // GET: /HighScores
    [HttpGet]
    [Route("/HighScores")]
    [ProducesResponseType(typeof(GetHighScoresResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(GetHighScoresResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(GetHighScoresResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Get()
    {
        var result = await _client.GetHighScores.ExecuteAsync();

        _loggerFactory.CreateLogger<GetHighScoresResponse>();
        var response = new GetHighScoresResponse(result, _loggerFactory.CreateLogger<GetHighScoresResponse>());
        
        if (response is {ResponseData.Count: < 1, ErrorMessage: null})
        {
            response.ErrorMessage = "No high scores found";
            return NotFound(response);
        }
        if (response.ErrorMessage != null)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, response);
        }

        return Ok(response);
    }
}
