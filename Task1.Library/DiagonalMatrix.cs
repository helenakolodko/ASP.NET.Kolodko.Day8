using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Library
{
    public class DiagonalMatrix<T> : Matrix<T>, IEquatable<DiagonalMatrix<T>>
    {
        private T[] elements;
        public DiagonalMatrix(T[][] matrix)
        {
            if (matrix == null)
                throw new ArgumentNullException();
            Size = matrix.Length;
            elements = new T[Size];
            for (int i = 0; i < Size; i++)
                elements[i] = matrix[i][i];
        }
        public DiagonalMatrix(int size)
        {
            if (size < 0)
                throw new ArgumentOutOfRangeException();
            Size = size;
            elements = new T[size];
        }

        public bool Equals(DiagonalMatrix<T> other)
        {
            if (ReferenceEquals(other, null))
                return false;
            if (ReferenceEquals(other, this))
                return true;
            if (Size != other.Size)
                return false;
            return ((IStructuralEquatable)elements).Equals(other.elements, StructuralComparisons.StructuralEqualityComparer);          
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
                return false;
            if (ReferenceEquals(obj, this))
                return true;
            DiagonalMatrix<T> m = obj as DiagonalMatrix<T>;
            if (m == null)
                return false;
            else
                return this.Equals(m);
        }

        protected override T GetElement(int i, int j)
        {
            if (i == j)
                return elements[i];
            else
                return default(T);
        }

        protected override void SetElement(int i, int j, T value)
        {
            if (i == j)
                elements[i] = value;
            else if (!value.Equals(default(T)))
                throw new ArgumentOutOfRangeException();
        }
    }
}
