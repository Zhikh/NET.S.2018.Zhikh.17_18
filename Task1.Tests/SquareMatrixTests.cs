using System;
using NUnit.Framework;
using Task1.Logic;

namespace Task1.Tests
{
    [TestFixture]
    public class SquareMatrixTests
    {
        #region Exceptions
        [Test]
        public void SquareMatrix_ZeroOrder_ArgumentException()
            => Assert.Catch<ArgumentException>(() => new SquareMatrix<int>(0));

        [Test]
        public void SquareMatrix_NegativeOrder_ArgumentException()
            => Assert.Catch<ArgumentException>(() => new SquareMatrix<int>(-1));
        #endregion

        #region Add value to matrix
        [TestCase(2, new int[] { 1, 2, 3, 4})]
        [TestCase(2, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15})]
        [TestCase(2, new int[] { 1, 0, 3, -120, 5, 6, 100, 8, 9, 10, int.MaxValue, 12, 13, int.MinValue, 15})]
        public void Indexator_SequenceOfElements_CorrectResult(int order, int[] values)
        {
            var matrix = new SquareMatrix<int>(order);
            AddValues(order, values, matrix);

            int i = 0;
            foreach (var element in matrix)
            {
                Assert.AreEqual(values[i++], element);
            }
        }
        #endregion

        #region Additional methods
        private static void AddValues<T>(int order, T[] values, SquareMatrix<T> matrix)
        {
            int k = 0;
            for (int i = 0; i < order; i++)
            {
                for (int j = 0; j < order; j++)
                {
                    matrix.Insert(values[k++], i, j);
                }
            }
        }
        #endregion
    }
}
