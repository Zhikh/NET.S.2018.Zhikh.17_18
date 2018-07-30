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

               matrix[1, 1] = 0;
           });
        #endregion

        #region Add value to matrix
        [TestCase(2, new int[] { 1, 2 }, ExpectedResult = new int[] { 1, 0, 0, 2 })]
        [TestCase(4, new int[] { -1, 12, 1000, int.MaxValue }, 
            ExpectedResult = new int[] { -1, 0, 0, 0, 0, 12, 0, 0, 0, 0, 1000, 0, 0, 0, 0, int.MaxValue })]
        public int[] Indexator_SequenceOfElements_CorrectResult(int order, int[] values)
        {
            var matrix = new DiagonalMatrix<int>(order);
            matrix.Copy(values);

            int[] actual = new int[matrix.Lenght];
            matrix.CopyTo(actual, 0, 0, matrix.Lenght);

            return actual;
        }
        #endregion

        #region Adding matrixes
        [TestCase(4, new int[] { 1, 2, 3, 4 })]
        [TestCase(16, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        [TestCase(16, new int[] { 1, 2, 3, -120, 5, 6, 100, 8, 9, 10, int.MaxValue, 12, 13, int.MinValue, 15, 19 })]
        public void Add_DiagonalMatrixAndDiagonalMatrix_CorrectResult(int order, int[] values)
        {
            var matrix = new DiagonalMatrix<int>(order);
            matrix.Copy(values);


            int[] reverseValues = new int[values.Length];
            Array.Copy(values, reverseValues, values.Length);
            Array.Reverse(reverseValues);

            var reverseMatrix = new DiagonalMatrix<int>(order);
            reverseMatrix.Copy(reverseValues);

            var actual = matrix.Add(reverseMatrix);
            int i = 0;
            foreach (var element in actual)
            {
                Assert.AreEqual(values[i] + reverseValues[i], element);
                i++;
            }
        }
        #endregion
    }
}
