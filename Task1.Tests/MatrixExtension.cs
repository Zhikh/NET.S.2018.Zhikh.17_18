using System;
using Task1.Logic;

namespace Task1.Tests
{
    public static class MatrixExtension
    {
        #region Extensions for matrixes
        /// <summary>
        /// Copy values from array to square matrix
        /// </summary>
        /// <typeparam name="T"> Type of elements </typeparam>
        /// <param name="matrix"> Matrix for copying in </param>
        /// <param name="values"> Values for copying out </param>
        /// <exception cref="ArgumentNullException"> If values is null </exception>
        /// <exception cref="ArgumentException"> If values lenght is more than lenght of matrix </exception>
        public static void Copy<T>(this SquareMatrix<T> matrix, T[] values)
        {
            Validate(matrix, values);

            CopyToMatrix(matrix, values);
        }

        /// <summary>
        /// Copy values from array to diagonal matrix
        /// </summary>
        /// <typeparam name="T"> Type of elements </typeparam>
        /// <param name="matrix"> Matrix for copying in </param>
        /// <param name="values"> Values for copying out </param>
        /// <exception cref="ArgumentNullException"> If values is null </exception>
        /// <exception cref="ArgumentException"> If values lenght is more than lenght of matrix </exception>
        public static void Copy<T>(this DiagonalMatrix<T> matrix, T[] values)
        {
            Validate(matrix, values);

            for (int i = 0; i < matrix.Order; i++)
            {
                matrix[i, i] = values[i];
            }
        }

        /// <summary>
        /// Copy values from array to symmetric matrix
        /// </summary>
        /// <typeparam name="T"> Type of elements </typeparam>
        /// <param name="matrix"> Matrix for copying in </param>
        /// <param name="values"> Values for copying out </param>
        /// <exception cref="ArgumentNullException"> If values is null </exception>
        /// <exception cref="ArgumentException"> If values lenght is more than lenght of matrix </exception>
        public static void Copy<T>(this SymmetricMatrix<T> matrix, T[] values)
        {
            Validate(matrix, values);

            CopyToMatrix(matrix, values);
        }
        #endregion

        #region Private methods
        private static void Validate<T>(BaseSquareMatrix<T> matrix, T[] values)
        {
            if (values == null)
            {
                throw new ArgumentNullException($"The {nameof(values)} can't be null");
            }

            if (values.Length > matrix.Lenght)
            {
                throw new ArgumentException($"The number of element of {nameof(values)} can't more than capacity of matrix!");
            }
        }
        private static void CopyToMatrix<T>(BaseSquareMatrix<T> matrix, T[] values)
        {
            int k = 0;
            for (int i = 0; i < matrix.Order; i++)
            {
                for (int j = 0; j < matrix.Order; j++)
                {
                    matrix[i, j] = values[k++];
                }
            }
        }
        #endregion
    }
}
