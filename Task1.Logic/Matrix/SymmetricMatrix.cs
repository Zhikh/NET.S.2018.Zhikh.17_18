using System;
using System.Collections.Generic;

namespace Task1.Logic
{
    public sealed class SymmetricMatrix<T> : BaseSquareMatrix<T>
    {
        /// <summary>
        /// Initialize properties
        /// </summary>
        /// <param name="order"> Order of matrix </param>
        /// <param name="comparer"> Rules for comparing </param>
        /// <exception cref="ArgumentException"> If order is invalid </exception>
        /// <exception cref="ArgumentNullException"> If type T hasn't comparer </exception>
        public SymmetricMatrix(int order, IComparer<T> comparer = null) : base(order, comparer)
        {
            int size = 0;
            int temp = order;

            while(temp > 0)
            {
                size += temp--;
            }

            Data = new T[size];
        }
        
        /// <summary>
        /// Add value to matrix by symmetric way
        /// </summary>
        /// <param name="value"> Value for inserting </param>
        /// <param name="rowIndex"> Row index </param>
        /// <param name="columnIndex"> Column index </param>
        //public void Insert(T value, int rowIndex, int columnIndex)
        //{
        //    base.Data[rowIndex, columnIndex] = value;

        //    if (rowIndex != columnIndex)
        //    {
        //        base.Data[columnIndex, rowIndex] = value;
        //    }
        //}

        internal override T GetValue(int indexRow, int indexColumn)
        {
            return indexRow >= indexColumn ? Data[indexRow*(indexRow + 1) / 2 + indexColumn] :
                Data[indexColumn * (indexColumn + 1) / 2 + indexRow];
        }

        internal override void SetValue(T value, int indexRow, int indexColumn)
        {
            if (indexRow >= indexColumn)
            {
                Data[indexRow * (indexRow + 1) / 2 + indexColumn] = value;
            }
            else
            {
                Data[indexColumn * (indexColumn + 1) / 2 + indexRow] = value;
            }
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
