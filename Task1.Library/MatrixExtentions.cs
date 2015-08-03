using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Task1.Library
{
    public static class MatrixExtentions
    {
        public static SquareMartix<T> Add<T>(this ISquareMatrix<T> m1, ISquareMatrix<T> m2)
        {
            if (m1.Size != m2.Size)
                throw new InvalidOperationException("Can't add matrixes of different sizes.");
            try
            {
                Func<T, T, T> addition = GetAddition<T>();
                return Add<T>(m1, m2, addition);
            }
            catch(InvalidOperationException e)
            {
                throw e;
            }
        }

        public static SquareMartix<T> Add<T>(this ISquareMatrix<T> m1, ISquareMatrix<T> m2, Func<T, T, T> addition)
        {
            if (m1.Size != m2.Size)
                throw new InvalidOperationException("Can't add matrixes of different sizes.");
            if (addition == null)
                throw new ArgumentNullException();

            SquareMartix<T> result = new SquareMartix<T>(m1.Size);
            for (int i = 0; i < m1.Size; i++)
                for (int j = 0; j < m1.Size; j++)
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
