// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace GameServer.Entities;

public class HighScore
{
    
    public DateTimeOffset Created { get; }
    public string Name { get; }
    public int Score { get; }
    
    public static HighScore From(IGetHighScores_Flappy_high_score highScore)
    {
        return new HighScore(DateTimeOffset.Parse(highScore.Created_at), highScore.Name, highScore.Score);
    }
    public HighScore(DateTimeOffset created, string name, int score)
    {
        Created = created;
        Name = name;
        Score = score;
    }
}
