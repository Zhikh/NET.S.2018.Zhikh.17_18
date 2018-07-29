using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Logic
{
    public abstract class Matrix<T>
    {
        protected T[,] _container;
        protected IComparer<T> _comparer;

        public Matrix(int order, IComparer<T> comparer = null)
        {
            if (order <= 0)
            {
                throw new ArgumentException($"The {nameof(order)} can't be less than 0 or be 0!");
            }

            _comparer = comparer ??
                (Comparer<T>.Default as IComparer<T> ??
                throw new ArgumentNullException("Comparer's indefined for type of T!"));

            _container = new T[order, order];
            Order = order;
        }

        public int Order { get; }

        public virtual T this[int indexRow, int indexColumn]
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

        public bool IsSymmetric()
        {
            for (int i = 0; i < Order; i++)
            {
                for (int j = 0; j < Order; j++)
                {
                    if (_comparer.Compare(this[i, j], this[j, i]) != 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public T Trace()
        {
            dynamic result = default(T);

            for (int i = 0; i < Order; i++)
            {
                result += (dynamic)_container[i, i];
            }

            return result;
        }

    }
}
