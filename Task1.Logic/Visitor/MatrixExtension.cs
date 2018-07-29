namespace Task1.Logic
{
    public static class MatrixExtension
    {
        public static T[,] Add<T>(this BaseSquareMatrix<T> left, BaseSquareMatrix<T> right)
        {
            var visitor = new MatrixSumVisitor<T>();

            visitor.DynamicVisit(left, right);

            return visitor.Sum;
        }
    }
}
