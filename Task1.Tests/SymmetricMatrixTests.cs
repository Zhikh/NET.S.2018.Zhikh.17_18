using System;
using NUnit.Framework;
using Task1.Logic;

namespace Task1.Tests
{
    public class SymmetricMatrixTests
    {
        #region Exceptions
        [Test]
        public void SquareMatrix_ZeroOrder_ArgumentException()
            => Assert.Catch<ArgumentException>(() => new SymmetricMatrix<int>(0));

        [Test]
        public void SquareMatrix_NegativeOrder_ArgumentException()
            => Assert.Catch<ArgumentException>(() => new SymmetricMatrix<int>(-1));
        #endregion

        #region Add value to matrix
        [TestCase(2, new int[] { 1, 2, 2, 4 })]
        [TestCase(3, new int[] { 1, 4, 5, 4, 2, 6, 5, 6, 3 })]
        public void Indexator_SymmetricSequenceOfElements_CorrectResult(int order, int[] values)
        {
            var matrix = new SymmetricMatrix<int>(order);
            matrix.Copy(values);

            int i = 0;
            foreach (var element in matrix)
            {
                Assert.AreEqual(values[i++], element);
            }
        }
        #endregion
    }
}
