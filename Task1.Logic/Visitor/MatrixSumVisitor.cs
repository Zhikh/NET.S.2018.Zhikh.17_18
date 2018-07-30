using Microsoft.CSharp.RuntimeBinder;
using System;
using Task1.Logic.Exceptions;

namespace Task1.Logic
{
    public sealed class MatrixSumVisitor<T> : MatrixVisitor<T>
    {
        protected override SymmetricMatrix<T> Add(SymmetricMatrix<T> left, SymmetricMatrix<T> right)
        {
            ValidateParams(left, right);

            var result = new SymmetricMatrix<T>(left.Order);
            AddByEachElement(left, right, result);

            return result;
        }

        protected override DiagonalMatrix<T> Add(DiagonalMatrix<T> left, DiagonalMatrix<T> right)
        {
            ValidateParams(left, right);

            var result = new DiagonalMatrix<T>(left.Order);
            AddByEachElement(left, right, result);

            return result;
        }

        protected override SquareMatrix<T> Add(SquareMatrix<T> left, BaseSquareMatrix<T> right)
        {
            ValidateParams(left, right);

            var result = new SquareMatrix<T>(left.Order);
            AddByEachElement(left, right, result);

            return result;
        }

        protected override SquareMatrix<T> Add(BaseSquareMatrix<T> left, SquareMatrix<T> right)
        {
            return this.Add(right, left);
        }

        protected override SymmetricMatrix<T> Add(SymmetricMatrix<T> left, DiagonalMatrix<T> right)
        {
            ValidateParams(left, right);

            var result = new SymmetricMatrix<T>(left.Order);
            AddByEachElement(left, right, result);

            return result;
        }

        protected override SymmetricMatrix<T> Add(DiagonalMatrix<T> left, SymmetricMatrix<T> right)
        {
            return this.Add(right, left);
        }

        #region Additional methods
        private static void ValidateParams(BaseSquareMatrix<T> left, BaseSquareMatrix<T> right)
        {
            if (left == null || right == null)
            {
                throw new InvalidMatrixOperationException("Matrix can't be null!");
            }

            if (left.Order != right.Order)
            {
                throw new InvalidMatrixOperationException("Order of matrix should be equal!");
            }
        }

        private static void AddByEachElement(BaseSquareMatrix<T> left, BaseSquareMatrix<T> right, BaseSquareMatrix<T> result)
        {
            try
            {
                int n = left.Order;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        result[i, j] = (dynamic)left[i, j] + right[i, j];
                    }
                }
            }
            catch(RuntimeBinderException ex)
            {
                throw new NotSupportedException(nameof(T), ex);
            }
        }
        #endregion
    }
}
