using System;
using System.Collections.Generic;

namespace Task1.Logic
{
    public sealed class DiagonalMatrix<T> : BaseSquareMatrix<T>
    {
        public DiagonalMatrix(int order, IComparer<T> comparer = null) : base(order, comparer)
        {
        }

        public override T this[int indexRow, int indexColumn]
        {
            get
            {
                return _container[indexRow, indexColumn];
            }

            set
            {
                if (indexColumn != indexRow)
                {
                    throw new ArgumentException("Indexes must be equal!");
                }

                if (indexRow == indexColumn)
                {
                    _container[indexColumn, indexRow] = value;
                }
            }
        }
    }
}
