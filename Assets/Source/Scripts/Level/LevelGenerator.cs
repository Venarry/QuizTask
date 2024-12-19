using Assets.Source.Scripts.Cells;
using Assets.Source.Scripts.SO;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Source.Scripts.Level
{
    public class LevelGenerator : MonoBehaviour
    {
        private const float CellsSize = 200;

        [SerializeField] private Transform _cellsParent;
        [SerializeField] private float _outline = 10;

        private readonly List<Cell> _spawnedCells = new List<Cell>();
        private readonly Queue<LevelSO> _levels = new Queue<LevelSO>();
        private readonly QuizGrid _grid = new QuizGrid();
        private CellFactory _cellFactory;

        public event Action<Cell[]> LevelSpawned;

        public bool HasLevels => _levels.Count > 0;

        public void Init(CellFactory cellFactory, LevelSO[] levels)
        {
            _cellFactory = cellFactory;

            foreach (LevelSO level in levels)
            {
                _levels.Enqueue(level);
            }
        }

        public void SpawnNextLevel()
        {
            ClearLevel();

            LevelSO nextLevel = _levels.Dequeue();

            CellSO[] cells = nextLevel.Cells;
            int columnsCount = nextLevel.ColumnsCount;

            _grid.Generate(cells.Length, columnsCount, CellsSize - _outline);

            for (int i = 0; i < cells.Length; i++)
            {
                int rowIndex = i / columnsCount;
                int columnsIndex = i % columnsCount;

                Cell spawnedCell = _cellFactory.Create(
                        cellSO: cells[i],
                        position: _grid.GetPosition(rowIndex, columnsIndex),
                        size: CellsSize,
                        parent: _cellsParent);

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