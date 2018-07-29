using System.Collections.Generic;

namespace Task1.Logic
{
    public sealed class SymmetricMatrix<T> : BaseSquareMatrix<T>
    {
        public SymmetricMatrix(int order, IComparer<T> comparer = null) : base(order, comparer)
        {
        }
        
        public void Insert(T value, int rowIndex, int columnIndex)
        {
            base.Data[rowIndex, columnIndex] = value;

            if (rowIndex != columnIndex)
            {
                base.Data[columnIndex, rowIndex] = value;
            }
        }
    }
}
