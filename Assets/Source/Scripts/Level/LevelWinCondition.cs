using Assets.Source.Scripts.Cells;
using System;
using System.Collections.Generic;

namespace Assets.Source.Scripts.Level
{
    public class LevelWinCondition : IWinCondition
    {
        private readonly List<string> _usedWinCondition = new List<string>();

        public event Action<string> Installed;

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

            if(availableCells.Count == 0)
            {
                throw new ArgumentNullException("Нет доступного условия для победы");
            }    

            int winIdentificatorIndex = UnityEngine.Random.Range(0, availableCells.Count);
            string winIdentificator = availableCells[winIdentificatorIndex].Identificator;

            _usedWinCondition.Add(winIdentificator);
            Installed?.Invoke(winIdentificator);

            return winIdentificator;
        }
    }
}