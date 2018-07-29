using System;
using System.Collections.Generic;

namespace Task1.Logic
{
    public sealed class DiagonalMatrix<T> : BaseSquareMatrix<T>
    {
        public DiagonalMatrix(int order, IComparer<T> comparer = null) : base(order, comparer)
        {
        }
        
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
