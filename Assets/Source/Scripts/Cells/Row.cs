using Assets.Source.Scripts.SO;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Scripts.Cells
{
    [Serializable]
    public class Row
    {
        [SerializeField] private List<CellSO> _cells;

        public int ColumnsCount => _cells.Count;
        public CellSO[] Cells => _cells.ToArray();
    }
}