using Assets.Source.Scripts.Cells;
using Assets.Source.Scripts.Configs;
using Assets.Source.Scripts.SO;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Scripts.Level
{
    public class LevelGenerator : MonoBehaviour
    {
        private const float CellsSize = 200;

        [SerializeField] private Transform _cellsParent;
        [SerializeField] private float _outline = 10;

        private readonly List<Cell> _spawnedCells = new List<Cell>();
        private CellFactory _cellFactory;
        private string _winIdentificator;

        public event Action<Cell[]> LevelSpawned;

        public void Init(CellFactory cellFactory)
        {
            _cellFactory = cellFactory;
        }

        public void SpawnLevel(LevelSO level)
        {
            Row[] rows = level.Rows;

            for (int i = 0; i < rows.Length; i++)
            {
                Row row = rows[i];
                CellSO[] cells = row.Cells;

                for (int j = 0; j < cells.Length; j++)
                {
                    CellSO currentCellSO = cells[j];

                    float cellYPosition = QuizMath.GetPositionOnLine(rows.Length, rows.Length - i - 1, CellsSize - _outline);
                    float cellXPosition = QuizMath.GetPositionOnLine(cells.Length, j, CellsSize - _outline);

                    Cell spawnedCell = _cellFactory.Create(
                        cellSO: currentCellSO,
                        position: new Vector3(cellXPosition, cellYPosition, 0),
                        size: CellsSize,
                        parent: _cellsParent);

                    _spawnedCells.Add(spawnedCell);
                }
            }

            LevelSpawned?.Invoke(_spawnedCells.ToArray());
        }
    }
}