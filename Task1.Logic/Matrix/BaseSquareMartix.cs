using System;
using System.Collections.Generic;

namespace Task1.Logic
{
    public abstract class BaseSquareMatrix<T>
    {
        #region public API
        /// <summary>
        /// Initialize properties
        /// </summary>
        /// <param name="order"> Order of matrix </param>
        /// <param name="comparer"> Rules for comparing </param>
        /// <exception cref="ArgumentException"> If order is invalid </exception>
        /// <exception cref="ArgumentNullException"> If type T hasn't comparer </exception>
        public BaseSquareMatrix(int order, IComparer<T> comparer = null)
        {
            if (order <= 0)
            {
                throw new ArgumentException($"The {nameof(order)} can't be less than 0 or be 0!");
            }

            Comparer = comparer ??
                (typeof(IComparable<T>).IsAssignableFrom(typeof(T)) ||
                typeof(IComparable).IsAssignableFrom(typeof(T)) ?
                Comparer = Comparer<T>.Default :
                throw new ArgumentNullException("Comparer's indefined for type of T!"));

            Order = order;

            Lenght = Order * Order;
        }

        /// <summary>
        /// Event of chamging values in matrix
        /// </summary>
        public event EventHandler<ElementValueArg<T>> ElementValueChanged = delegate { };

        /// <summary>
        /// Order of matrix
        /// </summary>
        public int Order { get; }

        /// <summary>
        /// Number of elements
        /// </summary>
        public int Lenght { get; }

        /// <summary>
        /// Indexatot
        /// </summary>
        /// <param name="indexRow"> Index of row </param>
        /// <param name="indexColumn"> Index of column </param>
        /// <returns> Element by [indexRow, indexColumn] </returns>
        public virtual T this[int indexRow, int indexColumn]
        {
            get
            {
                ValidateIndexes(indexRow, indexColumn);

                return GetValue(indexRow, indexColumn);
            }

            set
            {
                ValidateIndexes(indexRow, indexColumn);

                var elementArg = new ElementValueArg<T>(this[indexRow, indexColumn], value);
                OnElementValueChange(this, elementArg);

                SetValue(value, indexRow, indexColumn);
            }
        }

        internal abstract void SetValue(T value, int indexRow, int indexColumn);
        internal abstract T GetValue(int indexRow, int indexColumn);
        internal abstract void ValidateIndexes(int indexRow, int indexColumn);

        /// <summary>
        /// Copy elements from matrix to sz-array
        /// </summary>
        /// <param name="array"> Array for copying </param>
        /// <param name="startRowIndex"> Row index for start copying </param>
        /// <param name="startColumnIndex"> Row Column for start copying </param>
        /// <param name="count"> Number of elements </param>
        /// <exception cref="ArgumentException"> If startRowIndex, startColumnIndex, count are out if range </exception>
        ///<exception cref="ArgumentNullException"> If array is null </exception>
        public void CopyTo(T[] array, int startRowIndex, int startColumnIndex, int count)
        {
            CheckOnValid(array, startRowIndex, startColumnIndex, count);

            int writeValues = 0;
            for (int i = startRowIndex; writeValues != count && i < Order; i++)
            {
                for (int j = startColumnIndex; writeValues != count && j < Order; j++)
                {
                    array[writeValues++] = this[i, j];
                }
            }
        }

        /// <summary>
        /// Get object of IEnumerator for matrix
        /// </summary>
        /// <returns> IEnumerator </returns>
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

        /// <summary>
        /// Check matric on being symmetric
        /// </summary>
        /// <returns> If matrix is symmetric, true, else - false </returns>
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

        /// <summary>
        /// Find sum of elements of main diagonal
        /// </summary>
        /// <returns> Trace </returns>
        public T Trace()
        {
            dynamic result = default(T);

            for (int i = 0; i < Order; i++)
            {
                result += (dynamic)this[i, i];
            }

            return result;
        }

        /// <summary>
        /// Calculate determanant of matrix
        /// </summary>
        /// <returns> Determinant of matrix </returns>
        public T Determinant()
        {
            if (Data.Length == 4)
            {
                return ((dynamic)this[0, 0] * this[1, 1]) - ((dynamic)this[0, 1] * this[1, 0]);
            }

            return FindDaterminant((dynamic)Data);
        }

        /// <summary>
        /// Check on equal two matrix
        /// </summary>
        /// <param name="matrix"> Second matrix for checking </param>
        /// <returns> If matrix is simular, true, else - false </returns>
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

        /// <summary>
        /// Check on equal two matrix
        /// </summary>
        /// <param name="matrix"> Second matrix for checking </param>
        /// <returns> If matrix is simular, true, else - false </returns>
        public override bool Equals(object obj)
        {
            var matrix = obj as BaseSquareMatrix<T>;

            return this.Equals(matrix);
        }
        #endregion

        #region Protected methods and properties
        /// <summary>
        /// Container for values of matrix
        /// </summary>
        protected T[] Data { get; set; }

        /// <summary>
        /// Rules for comparing
        /// </summary>
        protected IComparer<T> Comparer { get; set; }

        /// <summary>
        /// Inform listeners about changing of element
        /// </summary>
        /// <param name="sender"> Creator of event </param>
        /// <param name="eventArgs"> Detail information about event </param>
        protected virtual void OnElementValueChange(object sender, ElementValueArg<T> eventArgs)
        {
            ElementValueChanged?.Invoke(this, eventArgs);
        }
        #endregion

        #region Private methods
        private void CheckOnValid(T[] array, int startRowIndex, int startColumnIndex, int count)
        {
            if (array == null)
            {
                throw new ArgumentException($"The {nameof(array)} can't be null!");
            }

            if (startRowIndex < 0 || startRowIndex >= Order)
            {
                throw new ArgumentException($"The {nameof(startRowIndex)} can't be less than 0 or more than order!");
            }

            if (startColumnIndex < 0 || startColumnIndex >= Order)
            {
                throw new ArgumentException($"The {nameof(startColumnIndex)} can't be less than 0 or more than order!");
            }

            if (count <= 0 /*|| count > Data.Length - (startRowIndex + 1) * Order - startColunmIndex - 1*/)
            {
                throw new ArgumentException($"The {nameof(count)} is out of range!");
            }
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
        #endregion
    }
}
