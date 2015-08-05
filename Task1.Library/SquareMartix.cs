using System;
using System.Collections;


namespace Task1.Library
{
    public class SquareMartix<T> : Matrix<T>, IEquatable<SquareMartix<T>>
    {
        private T[][] elements;
        public SquareMartix(T[][] matrix)
        {
            if(matrix == null)
                throw new ArgumentNullException();
            Size = matrix.Length;
            InitElements(Size);
            for (int i = 0; i < Size; i++)
                Array.Copy(matrix[i], elements[i], Size);
        }
        public SquareMartix(int size)
        {
            if (size < 0)
                throw new ArgumentOutOfRangeException();
            Size = size;
            InitElements(size);
        }
        public bool Equals(SquareMartix<T> other)
        {
            if (ReferenceEquals(other, null))
                return false;
            if (ReferenceEquals(other, this))
                return true;
            if (Size != other.Size)
                return false;
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    if (!this[i, j].Equals(other[i, j]))
                        return false;
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
                return false;
            if (ReferenceEquals(obj, this))
                return true;
            SquareMartix<T> m = obj as SquareMartix<T>;
            if (m == null)
                return false;
            else
                return this.Equals(m);
        }

        protected override T GetElement(int i, int j)
        {
            return elements[i][j];
        }

        protected override void SetElement(int i, int j, T value)
        {
            elements[i][j] = value;
        }
        private void InitElements(int size)
        {
            elements = new T[size][];
            for (int i = 0; i < size; i++)
                elements[i] = new T[size];
        }

    }
}
