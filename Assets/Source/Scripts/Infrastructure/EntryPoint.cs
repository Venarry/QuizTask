using Assets.Source.Scripts.Cells;
using Assets.Source.Scripts.Level;
using Assets.Source.Scripts.SO;
using UnityEngine;

namespace Assets.Source.Scripts.Infrastructure
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private LevelGenerator _levelGenerator;
        [SerializeField] private LevelCellsClickHandler _levelWinHandler;
        [SerializeField] private WinConditionView _winConditionView;
        [SerializeField] private GameRestarter _gameRestarter;
        [SerializeField] private LevelsDataSource _levelsDataSource;

        private void Awake()
        {
            CellFactory cellFactory = new CellFactory();
            IWinCondition winCondition = new LevelWinCondition();

            LevelSO[][] levels = _levelsDataSource.GetAll();

            _levelGenerator.Init(cellFactory, levels);
            _winConditionView.Init(winCondition);
            _gameRestarter.Init(_levelGenerator, winCondition, _winConditionView);
            _levelWinHandler.Init(_levelGenerator, winCondition, _gameRestarter);

            _levelGenerator.SpawnNextLevel(startBounceEffect: true);
        }

        private void OnDestroy()
        {
            _winConditionView.Disable();
            _levelWinHandler.Disable();
        }
    }
}