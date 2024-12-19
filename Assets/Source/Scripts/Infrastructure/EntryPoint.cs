using Assets.Source.Scripts.Cells;
using Assets.Source.Scripts.Level;
using Assets.Source.Scripts.SO;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private LevelGenerator _levelGenerator;
    [SerializeField] private LevelSO _level;

    private void Awake()
    {
        CellFactory cellFactory = new CellFactory();
        IWinCondition winCondition = new LevelWinCondition();

        _levelGenerator.Init(cellFactory);

        LevelWinHandler levelWinHandler = new LevelWinHandler(_levelGenerator, winCondition);
        _levelGenerator.SpawnLevel(_level);
    }
}
