using Assets.Source.Scripts.Cells;
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
        private readonly List<LevelSO> _levels = new List<LevelSO>();
        private readonly QuizGrid _grid = new QuizGrid();
        private CellFactory _cellFactory;
        private int _activeLevelIndex = 0;

        public event Action<Cell[]> LevelSpawned;

        public bool HasLevels => _levels.Count > _activeLevelIndex;

        public void Init(CellFactory cellFactory, LevelSO[] levels)
        {
            _cellFactory = cellFactory;

            _levels.AddRange(levels);
            _activeLevelIndex = 0;
        }

        public void ResetLevels()
        {
            _activeLevelIndex = 0;
        }

        public void SpawnNextLevel(bool startBounceEffect)
        {
            ClearLevel();

            if (HasLevels == false)
                return;

            LevelSO nextLevel = _levels[_activeLevelIndex];
            _activeLevelIndex++;

            CellSO[] cells = nextLevel.Cells;
            int columnsCount = nextLevel.ColumnsCount;

            _grid.Generate(cells.Length, columnsCount, CellsSize - _outline);

            for (int i = 0; i < cells.Length; i++)
            {
                int rowIndex = i / columnsCount;
                int columnIndex = i % columnsCount;

                Cell spawnedCell = _cellFactory.Create(
                        cellSO: cells[i],
                        position: _grid.GetPosition(rowIndex, columnIndex),
                        size: CellsSize,
                        parent: _cellsParent);

                if(startBounceEffect == true)
                {
                    spawnedCell.StartCellBounceEffect();
                }

                _spawnedCells.Add(spawnedCell);
            }

            LevelSpawned?.Invoke(_spawnedCells.ToArray());
        }

        private void ClearLevel()
        {
            foreach (Cell cell in _spawnedCells)
            {
                Destroy(cell.gameObject);
            }

            _spawnedCells.Clear();
        }
    }
}