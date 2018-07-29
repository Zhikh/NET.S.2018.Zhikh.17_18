using System;
using System.Collections.Generic;

namespace Task1.Logic
{
    public sealed class DiagonalMatrix<T> : BaseSquareMatrix<T>
    {
        /// <summary>
        /// Initialize properties
        /// </summary>
        /// <param name="order"> Order of matrix </param>
        /// <param name="comparer"> Rules for comparing </param>
        /// <exception cref="ArgumentException"> If order is invalid </exception>
        /// <exception cref="ArgumentNullException"> If type T hasn't comparer </exception>
        public DiagonalMatrix(int order, IComparer<T> comparer = null) : base(order, comparer)
        {
        }

        /// <summary>
        /// Add value to matrix (only diagonal elements)
        /// </summary>
        /// <param name="value"> Value for inserting </param>
        /// <param name="rowIndex"> Row index </param>
        /// <param name="columnIndex"> Column index </param>
        public void Insert(T value, int index)
        {
            if (Comparer.Compare(value, default(T)) == 0)
            {
                throw new ArgumentException($"The {nameof(value)} can't be null!");
            }

            base.Data[index, index] = value;
        }
    }
}
