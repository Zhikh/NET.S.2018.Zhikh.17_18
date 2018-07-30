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
        [TestCase(4, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16})]
        [TestCase(4, new int[] { 1, 0, 3, -120, 5, 6, 100, 8, 9, 10, int.MaxValue, 12, 13, int.MinValue, 15, 19})]
        public void Indexator_SequenceOfIntElements_CorrectResult(int order, int[] values)
        {
            var matrix = new SquareMatrix<int>(order);
            matrix.Copy(values);

            int i = 0;
            foreach (var element in matrix)
            {
                Assert.AreEqual(values[i++], element);
            }
        }

        [TestCase(2, "a", "b", "c", "d")]
        [TestCase(2, "a", null, "1", "")]
        public void Indexator_SequenceOfStringElements_CorrectResult(int order, params string[] values)
        {
            var matrix = new SquareMatrix<string>(order);
            matrix.Copy(values);

            int i = 0;
            foreach (var element in matrix)
            {
                Assert.AreEqual(values[i++], element);
            }
        }

        [TestCase(2, new byte[] { 20, 30, 2, 4})]
        public void Indexator_SequenceOfByteElements_CorrectResult(int order, params byte[] values)
        {
            var matrix = new SquareMatrix<byte>(order);
            matrix.Copy(values);

            int i = 0;
            foreach (var element in matrix)
            {
                Assert.AreEqual(values[i++], element);
            }
        }

        #endregion

        #region Adding matrexes
        [TestCase(2, new int[] { 1, 2, 3, 4 })]
        [TestCase(4, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        [TestCase(4, new int[] { 1, 0, 3, -120, 5, 6, 100, 8, 9, 10, int.MaxValue, 12, 13, int.MinValue, 15, 19 })]
        public void Add_SquareMatrixAndSquareMatrix_CorrectResult(int order, int[] values)
        {
            var matrix = new SquareMatrix<int>(order);
            matrix.Copy(values);


            int[] reverseValues = new int[values.Length];
            Array.Copy(values, reverseValues, values.Length);
            Array.Reverse(reverseValues);

            var reverseMatrix = new SquareMatrix<int>(order);
            reverseMatrix.Copy(reverseValues);

            var actual = matrix.Add(reverseMatrix);
            int i = 0;
            foreach (var element in actual)
            {
                Assert.AreEqual(values[i] + reverseValues[i], element);
                i++;
            }
        }

        [TestCase(2, new int[] { 1, 2, 3, 4 }, new int[] { 7, 7 })]
        [TestCase(4, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 }, new int[] { 1, 2, 3, 4 })]
        public void Add_SquareMatrixAndDiagonalMatrix_CorrectResult(int order, int[] squareValues, int[] diagonalValues)
        {
            var squareMatrix = new SquareMatrix<int>(order);
            squareMatrix.Copy(squareValues);
            
            var diagonalMatrix = new DiagonalMatrix<int>(order);
            diagonalMatrix.Copy(diagonalValues);

            int[] values = new int[diagonalMatrix.Lenght];
            int i = 0;
            foreach (var element in diagonalMatrix)
            {
                values[i++] = element;
            }

            var actual = squareMatrix.Add(diagonalMatrix);
            i = 0;
            foreach (var element in actual)
            {
                Assert.AreEqual(squareValues[i] + values[i], element);
                i++;
            }
        }

        [TestCase(2, new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 2, 1 })]
        [TestCase(3, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9},
            new int[] { 1, 4, 5, 4, 2, 6, 5, 6, 3 })]
        public void Add_SquareMatrixAndSymmetricMatrix_CorrectResult(int order, int[] squareValues, int[] SymmetricValues)
        {
            var squareMatrix = new SquareMatrix<int>(order);
            squareMatrix.Copy(squareValues);

            var symmetricValues = new SymmetricMatrix<int>(order);
            symmetricValues.Copy(SymmetricValues);

            int[] values = new int[symmetricValues.Lenght];
            int i = 0;
            foreach (var element in symmetricValues)
            {
                values[i++] = element;
            }

            var actual = squareMatrix.Add(symmetricValues);
            i = 0;
            foreach (var element in actual)
            {
                Assert.AreEqual(squareValues[i] + values[i], element);
                i++;
            }
        }

        [TestCase(2, "1", "", "", "2")]
        public void Add_StringsValues_CorrectResult(int order, params string[] values)
        {
            var matrix = new SquareMatrix<string>(order);
            matrix.Copy(values);


            string[] reverseValues = new string[values.Length];
            Array.Copy(values, reverseValues, values.Length);
            Array.Reverse(reverseValues);

            var reverseMatrix = new SquareMatrix<string>(order);
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
