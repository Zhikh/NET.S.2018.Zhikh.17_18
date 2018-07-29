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
                    matrix[i, j] = values[k++];
                }
            }
        }
        #endregion
    }
}
