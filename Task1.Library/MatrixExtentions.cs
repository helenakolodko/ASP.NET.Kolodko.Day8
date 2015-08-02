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
            MethodInfo addition = m1.GetType().GetMethod("op_Addition", BindingFlags.Static | BindingFlags.Public);
            if (addition == null)
                throw new InvalidOperationException("Can't add matrixes of type that doesn't define addition operation.");
            return Add<T>(m1, m2, GetAddition<T>());
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

        public static Func<T, T, T> GetAddition<T>()
        {
            var paramA = Expression.Parameter(typeof(T), "a");
            var paramB = Expression.Parameter(typeof(T), "b");

            BinaryExpression body = Expression.Add(paramA, paramB);

            return Expression.Lambda<Func<T, T, T>>(body, paramA, paramB).Compile();
        }
    }
}
