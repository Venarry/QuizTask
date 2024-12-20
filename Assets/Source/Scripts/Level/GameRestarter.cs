using Assets.Source.Scripts.Effects;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Source.Scripts.Level
{
    public class GameRestarter : MonoBehaviour
    {
        [SerializeField] private FadeImage _loadingPanel;

        private LevelGenerator _levelGenerator;
        private IWinCondition _winCondition;
        private WinConditionView _winConditionView;

        public void Init(LevelGenerator levelGenerator, IWinCondition winCondition, WinConditionView winConditionView)
        {
            _levelGenerator = levelGenerator;
            _winCondition = winCondition;
            _winConditionView = winConditionView;
        }

        public async Task Restart()
        {
            _loadingPanel.Show();

            await _loadingPanel.Turn();

            _levelGenerator.ResetLevels();
            _winCondition.Reset();
            _winConditionView.ResetFadeState();

            int delayBeforeRestert = 1000;
            await Task.Delay(delayBeforeRestert);

            _levelGenerator.SpawnNextLevel(startBounceEffect: true);
            _loadingPanel.Hide();
        }
    }
}