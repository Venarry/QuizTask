using Assets.Source.Scripts.Level;
using System.Threading.Tasks;
using UnityEngine;

public class GameRestarter : MonoBehaviour
{
    [SerializeField] private FadeInEffect _loadingPanel;

    private LevelGenerator _levelGenerator;
    private IWinCondition _winCondition;

    public void Init(LevelGenerator levelGenerator, IWinCondition winCondition)
    {
        _levelGenerator = levelGenerator;
        _winCondition = winCondition;
    }

    public async Task Restart()
    {
        _loadingPanel.Show();

        await _loadingPanel.Turn();

        _levelGenerator.ResetLevels();
        _winCondition.Reset();

        int delayBeforeRestert = 1000;
        await Task.Delay(delayBeforeRestert);

        _levelGenerator.SpawnNextLevel(startBounceEffect: true);
        _loadingPanel.Hide();
    }
}
