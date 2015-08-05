using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Task1.Library
{
    public static class MatrixExtentions
    {
        public static dynamic Add<T>(this Matrix<T> m1, Matrix<T> m2)
        {
            if (m2 == null)
                throw new ArgumentNullException();
            if (m1.Size != m2.Size)
                throw new InvalidOperationException("Can't add matrixes of different sizes.");
            try
            {
                Func<T, T, T> addition = GetAddition<T>();
                return Add<T>(m1, m2, addition);
            }
            catch(InvalidOperationException e)
            {
                throw new NotSupportedException("Type doesn't support addition operation");
            }
        }

        public static dynamic Add<T>(this Matrix<T> m1, Matrix<T> m2, Func<T, T, T> addition)
        {
            if (m2 == null)
                throw new ArgumentNullException();
            if (m1.Size != m2.Size)
                throw new InvalidOperationException("Can't add matrixes of different sizes.");
            if (addition == null)
                throw new ArgumentNullException();

            dynamic a = m1, b = m2;

            return GetAdditionMatrix<T>(a, b, addition);
        }

        private static SquareMartix<T> GetAdditionMatrix<T>(this Matrix<T> m1, Matrix<T> m2, Func<T, T, T> addition)
        {
            SquareMartix<T> result = new SquareMartix<T>(m1.Size);
            for (int i = 0; i < m1.Size; i++)
                for (int j = 0; j < m1.Size; j++)
                    result[i, j] = addition(m1[i, j], m2[i, j]);

            return result;
        }

        private static DiagonalMatrix<T> GetAdditionMatrix<T>(this DiagonalMatrix<T> m1, DiagonalMatrix<T> m2, Func<T, T, T> addition)
        {
            DiagonalMatrix<T> result = new DiagonalMatrix<T>(m1.Size);
            for (int i = 0; i < m1.Size; i++)
                result[i, i] = addition(m1[i, i], m2[i, i]);

            return result;
        }

        private static SymmetricMatrix<T> GetAdditionMatrix<T>(this SymmetricMatrix<T> m1, SymmetricMatrix<T> m2, Func<T, T, T> addition)
        {
            return BuildSymmetricMatrix<T>(m1, m2, addition);
        }

        private static SymmetricMatrix<T> GetAdditionMatrix<T>(this DiagonalMatrix<T> m1, SymmetricMatrix<T> m2, Func<T, T, T> addition)
        {
            return BuildSymmetricMatrix<T>(m1, m2, addition);
        }

        private static SymmetricMatrix<T> GetAdditionMatrix<T>(this SymmetricMatrix<T> m1, DiagonalMatrix<T> m2, Func<T, T, T> addition)
        {
            return BuildSymmetricMatrix<T>(m1, m2, addition);
        }


        private static SymmetricMatrix<T> BuildSymmetricMatrix<T>(Matrix<T> m1, Matrix<T> m2, Func<T, T, T> addition)
        {
            SymmetricMatrix<T> result = new SymmetricMatrix<T>(m1.Size);
            for (int i = 0; i < m1.Size; i++)
                for (int j = 0; j < i + 1; j++)
                    result[i, j] = addition(m1[i, j], m2[i, j]);

            return result;
        }

        private static Func<T, T, T> GetAddition<T>()
        {
            var paramA = Expression.Parameter(typeof(T), "a");
            var paramB = Expression.Parameter(typeof(T), "b");

            BinaryExpression body = Expression.Add(paramA, paramB);

            return Expression.Lambda<Func<T, T, T>>(body, paramA, paramB).Compile();
        }
    }
}
