using Assets.Source.Scripts.Cells;
using System;

namespace Assets.Source.Scripts.Level
{
    public interface IWinCondition
    {
        public event Action<string> Installed;
        public string RegisterNewCondition(Cell[] cells);
        public void Reset();
    }
}