using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1.Library;

namespace Task1.Tests
{
    [TestClass]
    public class MatrixTest
    {
        [TestMethod]
        public void Add_IntSquareMatrixes_GivesCorrectValue()
        {
            var m1 = new SquareMartix<int>(new int[][] { new int[] { 1, 1, 1 }, new int[] { 1, 1, 1 }, new int[] { 1, 1, 1 } });
            var m2 = new SquareMartix<int>(new int[][] { new int[] { 1, 1, 1 }, new int[] { 2, 2, 2 }, new int[] { 3, 3, 3 } });

            dynamic actual = m1.Add(m2);
            var expected = new SquareMartix<int>(new int[][] { new int[] { 2, 2, 2 }, new int[] { 3, 3, 3 }, new int[] { 4, 4, 4} });

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Add_IntSquareAndSymmetricMatrixes_GivesCorrectValue()
        {
            var m1 = new SquareMartix<int>(new int[][] { new int[] { 1, 1, 1 }, new int[] { 1, 1, 1 }, new int[] { 1, 1, 1 } });
            var m2 = new SymmetricMatrix<int>(new int[][] { new int[] { 1, 4, 5 }, new int[] { 4, 2, 6 }, new int[] { 5, 6, 3 } });

            dynamic actual = m1.Add(m2);
            var expected = new SquareMartix<int>(new int[][] { new int[] { 2, 5, 6 }, new int[] { 5, 3, 7 }, new int[] { 6, 7, 4 } });

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Add_IntDiagonalAndSymmetricMatrixes_ReturnesSymmetricMatrix()
        {
            var m1 = new DiagonalMatrix<int>(new int[][] { new int[] { 1, 0, 0 }, new int[] { 0, 1, 0 }, new int[] { 0, 0, 1 } });
            var m2 = new SymmetricMatrix<int>(new int[][] { new int[] { 1, 4, 5 }, new int[] { 4, 2, 6 }, new int[] { 5, 6, 3 } });

            dynamic actual = m1.Add(m2);

            Assert.IsTrue(actual is SymmetricMatrix<int>);
        }

        [TestMethod]
        public void Add_IntDiagonalAndSymmetricMatrixes_GivesCorrectValue()
        {
            var m1 = new DiagonalMatrix<int>(new int[][] { new int[] { 1, 0, 0 }, new int[] { 0, 1, 0 }, new int[] { 0, 0, 1 } });
            var m2 = new SymmetricMatrix<int>(new int[][] { new int[] { 1, 4, 5 }, new int[] { 4, 2, 6 }, new int[] { 5, 6, 3 } });

            dynamic actual = m1.Add(m2);
            var expected = new SymmetricMatrix<int>(new int[][] { new int[] { 2, 4, 5 }, new int[] { 4, 3, 6 }, new int[] { 5, 6, 4 } });

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void Add_StringSquareMatrixes_ThrowsException()
        {
            var m1 = new SquareMartix<string>(new string[][] { new string[] {"hello "}});
            var m2 = new SquareMartix<string>(new string[][] { new string[] { "world"} });

            dynamic actual = m1.Add(m2);
        }
    }
}
