using UnityEngine;

namespace Assets.Source.Scripts.Level
{
    public class QuizGrid
    {
        private Vector2[,] _cells;

        public void Generate(int elementsCount, int colomns, float cellSize)
        {
            int rowCount = Mathf.CeilToInt((float)elementsCount / colomns);
            _cells = new Vector2[rowCount, colomns];

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colomns; j++)
                {
                    float cellYPosition = GetPositionOnLine(rowCount, rowCount - i - 1, cellSize);
                    float cellXPosition = GetPositionOnLine(colomns, j, cellSize);

                    _cells[i, j] = new Vector2(cellXPosition, cellYPosition);
                }
            }
        }

        public Vector2 GetPosition(int row, int colomn) =>
            _cells[row, colomn];

        private float GetPositionOnLine(int columnsCount, int currentColumnIndex, float spacing)
        {
            float summaryDistance = (columnsCount - 1) * spacing;
            float centerPosition = summaryDistance - summaryDistance / 2;
            float currentColumnPosition = currentColumnIndex * spacing;

            return currentColumnPosition - centerPosition;
        }
    }
}