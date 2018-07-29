using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Logic
{
    public class SquareMatrix<T>
    {
        private T[,] _container;

        /// <summary>
        /// Initialize object of an n-by-n matrix is known as a square matrix of order n.
        /// </summary>
        /// <param name="order"> Number of elements in row/column /</param>
        public SquareMatrix(int order)
        {
            if (order <= 0)
            {
                throw new ArgumentException($"The {nameof(order)} can't be less than 0 or be 0!");
            }

            _container = new T[order, order];
            Order = order;
        }

        public int Order { get; }

        public T this[int indexRow, int indexColumn]
        {
            get
            {
                return _container[indexRow, indexColumn];
            }

            set
            {
                _container[indexRow, indexColumn] = value;
            }
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
        #region Private methods

        #endregion
    }
}
