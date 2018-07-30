namespace Task1.Logic
{
    public static class MatrixExtension
    {
        /// <summary>
        /// Find sum of two matrixes
        /// </summary>
        /// <typeparam name="T"> Type of elements </typeparam>
        /// <param name="left"> Matrix </param>
        /// <param name="right"> Matrix </param>
        /// <returns> Sum </returns>
        public static BaseSquareMatrix<T> Add<T>(this BaseSquareMatrix<T> left, BaseSquareMatrix<T> right)
        {
            var visitor = new MatrixSumVisitor<T>();

            return visitor.DynamicAdd(left, right);
        }
    }
}
