using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Scripts.SO
{
    [CreateAssetMenu(fileName = "NewLevel", menuName = "Quiz/Create level")]
    public class LevelSO : ScriptableObject
    {
        [SerializeField] private List<CellSO> _cells;
        [SerializeField] private int _columnsCount = 3;

        public CellSO[] Cells => _cells.ToArray();
        public int ColumnsCount => _columnsCount;
    }
}