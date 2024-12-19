using Assets.Source.Scripts.Cells;
using System;

namespace Assets.Source.Scripts.Level
{
    public interface IWinCondition
    {
        public string RegisterNewCondition(Cell[] cells);
        public void Reset();
    }
}