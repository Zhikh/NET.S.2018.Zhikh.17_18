using System;
using NUnit.Framework;
using Task1.Logic;

namespace Task1.Tests
{
    public class DiagonalMatrixTests
    {
        #region Exceptions
        [Test]
        public void SquareMatrix_ZeroOrder_ArgumentException()
            => Assert.Catch<ArgumentException>(() => new DiagonalMatrix<int>(0));

        [Test]
        public void SquareMatrix_NegativeOrder_ArgumentException()
            => Assert.Catch<ArgumentException>(() => new DiagonalMatrix<int>(-1));

        [Test]
        public void Insert_ZeroValue_ArgumentException()
           => Assert.Catch<ArgumentException>(() =>
           {
               var matrix = new DiagonalMatrix<int>(2);

               matrix.Insert(0, 1);
           });
        #endregion

        #region Add value to matrix
        [TestCase(2, new int[] { 1, 2 }, ExpectedResult = new int[] { 1, 0, 0, 2 })]
        [TestCase(4, new int[] { -1, 12, 1000, int.MaxValue }, 
            ExpectedResult = new int[] { -1, 0, 0, 0, 0, 12, 0, 0, 0, 0, 1000, 0, 0, 0, 0, int.MaxValue })]
        public int[] Indexator_SequenceOfElements_CorrectResult(int order, int[] values)
        {
            var matrix = new DiagonalMatrix<int>(order);
            AddValues(order, values, matrix);

            int[] actual = new int[matrix.Lenght];
            matrix.CopyTo(actual, 0, 0, matrix.Lenght);

            return actual;
        }
        #endregion

        #region Additional methods
        private static void AddValues<T>(int order, T[] values, DiagonalMatrix<T> matrix)
        {
            int k = 0;
            for (int i = 0; i < order; i++)
            {
                matrix.Insert(values[i], i);
            }
        }
        #endregion
    }
}
