using System;
using System.Collections;
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
        
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Order; i++)
            {
                for (int j = 0; j < Order; j++)
                {
                    yield return this[i, j];
                }
            }
        }
       
        public static SquareMatrix<T> operator +(SquareMatrix<T> matrix, T value)
        {
            var result = new SquareMatrix<T>(matrix.Order);

            for (int i = 0; i < matrix.Order; i++)
            {
                for (int j = 0; j < matrix.Order; j++)
                {
                    result[i, j] = (dynamic)matrix[i, j] + value;
                }
            }

            return result;
        }

        public static SquareMatrix<T> operator +(T value, SquareMatrix<T> matrix)
        {
            return matrix + value;
        }

        public SquareMatrix<T> Transpose()
        {
            var matrix = new SquareMatrix<T>(Order);

            for (int i = 0; i < matrix.Order; i++)
            {
                for (int j = 0; j < matrix.Order; j++)
                {
                    matrix[i, j] = this[j, i];
                }
            }

            return matrix;
        }

        #region Private methods

        #endregion
    }
}
