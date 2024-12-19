using Assets.Source.Scripts.Level;

public class GameRestarter
{
    private readonly LevelGenerator _levelGenerator;
    private readonly IWinCondition _winCondition;

    public GameRestarter(LevelGenerator levelGenerator, IWinCondition winCondition)
    {
        _levelGenerator = levelGenerator;
        _winCondition = winCondition;
    }

    public void Restart()
    {
        _levelGenerator.ResetLevels();
        _winCondition.Reset();

        _levelGenerator.SpawnNextLevel(startBounceEffect: true);
    }
}
