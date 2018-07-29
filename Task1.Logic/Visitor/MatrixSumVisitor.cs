using System;

namespace Task1.Logic
{
    public sealed class MatrixSumVisitor<T> : MatrixVisitor<T>
    {
        public T[,] Sum { get; private set; }

        protected override void Visit(BaseSquareMatrix<T> left, BaseSquareMatrix<T> right)
        {
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
