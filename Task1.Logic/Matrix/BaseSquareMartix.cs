using System;
using System.Collections.Generic;

namespace Task1.Logic
{
    public abstract class BaseSquareMatrix<T>
    {
        public BaseSquareMatrix(int order, IComparer<T> comparer = null)
        {
            if (order <= 0)
            {
                throw new ArgumentException($"The {nameof(order)} can't be less than 0 or be 0!");
            }

            Comparer = comparer ??
                (Comparer<T>.Default as IComparer<T> ??
                throw new ArgumentNullException("Comparer's indefined for type of T!"));

            Data = new T[order, order];
            Order = order;
        }

        public event EventHandler<ElementValueArg<T>> ElementValueChanged = delegate { };

        public int Order { get; }

        public int Lenght => Data.Length;

        protected T[,] Data { get; set; }

        protected IComparer<T> Comparer { get; set; }

        public virtual T this[int indexRow, int indexColumn]
        {
            get
            {
                return Data[indexRow, indexColumn];
            }

            protected set
            {
                Data[indexRow, indexColumn] = value;
            }
        }

        public void CopyTo(T[] array, int startRowIndex, int startColunmIndex, int count)
        {
            if (startRowIndex < 0 || startRowIndex >= Order)
            {
                throw new ArgumentException($"The {nameof(startRowIndex)} can't be less than 0 or more than order!");
            }

            if (startColunmIndex < 0 || startColunmIndex >= Order)
            {
                throw new ArgumentException($"The {nameof(startColunmIndex)} can't be less than 0 or more than order!");
            }

            if (count <= 0 /*|| count > Data.Length - (startRowIndex + 1) * Order - startColunmIndex - 1*/)
            {
                throw new ArgumentException($"The {nameof(count)} is out of range!");
            }
            
            int writeValues = 0;
            for (int i = startRowIndex; writeValues != count && i < Order; i++)
            {
                for (int j = startColunmIndex; writeValues != count && j < Order; j++)
                {
                    array[writeValues++] = this[i, j];
                }
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
                    if (Comparer.Compare(this[i, j], this[j, i]) != 0)
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
                result += (dynamic)Data[i, i];
            }

            return result;
        }

        public T Determinant()
        {
            if (Data.Length == 4)
            {
                return ((dynamic)this[0, 0] * this[1, 1]) - ((dynamic)this[0, 1] * this[1, 0]);
            }

            return FindDaterminant((dynamic)Data);
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
                    if (Comparer.Compare(this[i, j], matrix[i, j]) != 0)
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

            return this.Equals(matrix);
        }

        public override int GetHashCode()
        {
            var hashCode = 368104177;
            hashCode = (hashCode * -1521134295) + EqualityComparer<T[,]>.Default.GetHashCode(Data);
            hashCode = (hashCode * -1521134295) + EqualityComparer<IComparer<T>>.Default.GetHashCode(Comparer);
            hashCode = (hashCode * -1521134295) + Order.GetHashCode();
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

            for (int i = 0; i < Data.GetLength(1); i++)
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
