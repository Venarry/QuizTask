using Assets.Source.Scripts.Cells;
using System;
using System.Collections.Generic;

namespace Assets.Source.Scripts.Level
{
    public class LevelWinCondition : IWinCondition
    {
        private readonly LevelGenerator _levelGenerator;
        private readonly List<string> _usedWinCondition = new List<string>();

        public void Reset()
        {
            _usedWinCondition.Clear();
        }

        public string RegisterNewCondition(Cell[] cells)
        {
            List<Cell> availableCells = new List<Cell>();

            foreach (Cell cell in cells)
            {
                if (_usedWinCondition.Contains(cell.Identificator) == false)
                {
                    availableCells.Add(cell);
                }
            }

            int winIdentificatorIndex = UnityEngine.Random.Range(0, availableCells.Count);
            return availableCells[winIdentificatorIndex].Identificator;
        }
    }
}