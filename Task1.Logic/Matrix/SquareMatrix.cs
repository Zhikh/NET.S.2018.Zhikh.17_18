using System;
using System.Collections.Generic;

namespace Task1.Logic
{
    public sealed class SquareMatrix<T> : BaseSquareMatrix<T>
    {
        /// <summary>
        /// Initialize properties
        /// </summary>
        /// <param name="order"> Order of matrix </param>
        /// <param name="comparer"> Rules for comparing </param>
        /// <exception cref="ArgumentException"> If order is invalid </exception>
        /// <exception cref="ArgumentNullException"> If type T hasn't comparer </exception>
        public SquareMatrix(int order, IComparer<T> comparer = null) : base(order, comparer)
        {
            base.Data = new T[order * order];
        }
        
        internal override T GetValue(int indexRow, int indexColumn)
        {
            return base.Data[indexRow + indexColumn * Order];
        }

        internal override void SetValue(T value, int indexRow, int indexColumn)
        {
            base.Data[indexRow + indexColumn * Order] = value;
        }

        internal override void ValidateIndexes(int indexRow, int indexColumn)
        {
            if (indexRow < 0 || indexRow > Order ||
                indexColumn < 0 || indexColumn > Order)
            {
                throw new ArgumentException("The index exited from range of matrix!");
            }
        }
    }
}
