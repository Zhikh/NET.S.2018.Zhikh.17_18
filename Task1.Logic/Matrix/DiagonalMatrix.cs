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
            base.Data = new T[order];
        }
        
        internal override T GetValue(int indexRow, int indexColumn)
        {
            return indexRow == indexColumn ? base.Data[indexRow] : default(T);
        }

        internal override void SetValue(T value, int indexRow, int indexColumn)
        {
            if (indexRow != indexColumn)
            {
                throw new ArgumentException("The index exited from range of matrix!");
            }

            if (Comparer.Compare(value, default(T)) == 0)
            {
                throw new ArgumentException($"The {nameof(value)} can't be null!");
            }

            base.Data[indexRow] = value;
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
