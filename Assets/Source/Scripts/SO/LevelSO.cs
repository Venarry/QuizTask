using Assets.Source.Scripts.Cells;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Scripts.SO
{
    [CreateAssetMenu(fileName = "NewLevel", menuName = "Quiz/Create level")]
    public class LevelSO : ScriptableObject
    {
        [SerializeField] private List<Row> _rows;

        public Row[] Rows => _rows.ToArray();

        private void OnValidate()
        {
            if (_rows.Count == 0)
                return;

            int colInFirstRow = _rows[0].ColumnsCount;

            for (int i = 1; i < _rows.Count; i++)
            {
                Row curentRow = _rows[i];

                if (curentRow.ColumnsCount != colInFirstRow)
                {
                    Debug.LogWarning("Число столбцов разное");
                }
            }
        }
    }
}