using System.Collections.Generic;

namespace Task1.Logic
{
    public class SquareMatrix<T> : BaseSquareMatrix<T>
    {
        /// <summary>
        /// Initialize object of an n-by-n matrix is known as a square matrix of order n.
        /// </summary>
        /// <param name="order"> Number of elements in row/column /</param>
        public SquareMatrix(int order, IComparer<T> comparer = null) : base(order, comparer)
        {
        }

        public void Insert(T value, int rowIndex, int columnIndex)
        {
            this[rowIndex, columnIndex] = value;
        }
    }
}
