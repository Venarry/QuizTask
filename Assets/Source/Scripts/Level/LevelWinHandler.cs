using Assets.Source.Scripts.Cells;
using Assets.Source.Scripts.Level;
using System;
using UnityEngine;

public class LevelWinHandler
{
    private readonly LevelGenerator _levelGenerator;
    private readonly IWinCondition _winCondition;
    private string _winIdentificator;

    public LevelWinHandler(LevelGenerator levelGenerator, IWinCondition winCondition)
    {
        _levelGenerator = levelGenerator;
        _winCondition = winCondition;

        _levelGenerator.LevelSpawned += OnLevelSpawned;
    }

    ~LevelWinHandler()
    {
        _levelGenerator.LevelSpawned -= OnLevelSpawned;
    }

    private void OnLevelSpawned(Cell[] cells)
    {
        _winIdentificator = _winCondition.RegisterNewCondition(cells);

        Debug.Log(_winIdentificator);

        foreach (Cell cell in cells)
        {
            cell.Clicked += OnCellClick;
        }
    }

    private void OnCellClick(Cell cell)
    {
        if(cell.Identificator == _winIdentificator)
        {
            Debug.Log("DA");
        }
        else
        {
            Debug.Log("Net");
        }
    }
}
