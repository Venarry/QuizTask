namespace Assets.Source.Scripts.Configs
{
    public static class QuizMath
    {
        public static float GetPositionOnLine(int columnsCount, int currentColumnIndex, float spacing)
        {
            float summaryDistance = (columnsCount - 1) * spacing;
            float centerPosition = summaryDistance - summaryDistance / 2;
            float currentColumnPosition = currentColumnIndex * spacing;

            return currentColumnPosition - centerPosition;
        }
    }
}