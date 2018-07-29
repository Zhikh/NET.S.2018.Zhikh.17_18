using System;

namespace Task1.Logic
{
    public sealed class MatrixSumVisitor<T> : MatrixVisitor<T>
    {
        /// <summary>
        /// Result of sum operation for matrix
        /// </summary>
        public T[,] Sum { get; private set; }

        /// <summary>
        /// Calculate sum
        /// </summary>
        /// <param name="left"> Matrix </param>
        /// <param name="right"> Matrix </param>
        /// <exception cref="ArgumentException"> If matrixes have dufferent order </exception>
        /// <exception cref="ArgumentNullException"> If one of matrix is null </exception>
        protected override void Visit(BaseSquareMatrix<T> left, BaseSquareMatrix<T> right)
        {
            if (left == null || right == null)
            {
                throw new ArgumentNullException("Matrix can't be null!");
            }

            if (left.Order != right.Order)
            {
                throw new ArgumentException("Order of matrix should be equal!");
            }

            int n = left.Order;
            Sum = new T[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Sum[i, j] = (dynamic)left[i, j] + right[i, j];
                }
            }
        }
    }
}
