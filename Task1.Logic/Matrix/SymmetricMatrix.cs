using System.Collections.Generic;

namespace Task1.Logic
{
    public sealed class SymmetricMatrix<T> : BaseSquareMatrix<T>
    {
        public SymmetricMatrix(int order, IComparer<T> comparer = null) : base(order, comparer)
        {
        }

        public override T this[int indexRow, int indexColumn]
        {
            get
            {
                return base.Data[indexRow, indexColumn];
            }

            set
            {
                base.Data[indexRow, indexColumn] = value;

                if (indexRow != indexColumn)
                {
                    base.Data[indexColumn, indexRow] = value;
                }
            }
        }
    }
}
