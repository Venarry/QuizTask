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

        private void Awake()
        {
            CellFactory cellFactory = new CellFactory();
            IWinCondition winCondition = new LevelWinCondition();
            LevelsDataSource levelsDataSource = new LevelsDataSource();

            LevelSO[] levels = levelsDataSource.GetAll();

            _levelGenerator.Init(cellFactory, levels);
            _gameRestarter.Init(_levelGenerator, winCondition);
            _levelWinHandler.Init(_levelGenerator, winCondition, _gameRestarter);
            _winConditionView.Init(winCondition);

            _levelGenerator.SpawnNextLevel(startBounceEffect: true);
        }
    }
}