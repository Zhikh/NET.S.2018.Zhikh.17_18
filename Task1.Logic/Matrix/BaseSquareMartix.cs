using System;
using System.Collections.Generic;

namespace Task1.Logic
{
    public abstract class BaseSquareMatrix<T>
    {
        protected T[,] _container;
        protected IComparer<T> _comparer;
        public event EventHandler<ElementValueArg<T>> ElementValueChanged = delegate { };
        
        public BaseSquareMatrix(int order, IComparer<T> comparer = null)
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

        public T Determinant()
        {
            if (_container.Length == 4)
            {
                return (dynamic)this[0, 0] * this[1, 1] - (dynamic)this[0, 1] * this[1, 0];
            }

            return FindDaterminant((dynamic)_container);
        }

        public bool Equals(BaseSquareMatrix<T> matrix)
        {
            if (Order != matrix.Order)
            {
                return false;
            }

            for (int i = 0; i < Order; i++)
            {
                for (int j = 0; j < Order; j++)
                {
                    if (_comparer.Compare(this[i, j], matrix[i, j]) != 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public override bool Equals(object obj)
        {
            var matrix = obj as BaseSquareMatrix<T>;

            return Equals(matrix);
        }

        public override int GetHashCode()
        {
            var hashCode = 368104177;
            hashCode = hashCode * -1521134295 + EqualityComparer<T[,]>.Default.GetHashCode(_container);
            hashCode = hashCode * -1521134295 + EqualityComparer<IComparer<T>>.Default.GetHashCode(_comparer);
            hashCode = hashCode * -1521134295 + Order.GetHashCode();
            return hashCode;
        }

        protected virtual void OnElementValueChange(object sender, ElementValueArg<T> eventArgs)
        {
            ElementValueChanged?.Invoke(this, eventArgs);
        }

        private dynamic FindDaterminant(dynamic[,] matrix)
        {
            int sign = 1;
            dynamic result = default(T);

            for (int i = 0; i < _container.GetLength(1); i++)
            {
                dynamic[,] minor = null;

                result += sign * matrix[0, i] * FindDaterminant(minor);
                sign = -sign;
            }

            return result;
        }

        private void GetMinor(T[,] minor, int n)
        {
            minor = new T[Order, Order];

            for (int i = 1; i < Order; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    minor[i - 1, j] = this[i, j];
                }

                for (int j = n + 1; j < Order; j++)
                {
                    minor[i - 1, j - 1] = this[i, j];
                }
            }
        }
    }
}
