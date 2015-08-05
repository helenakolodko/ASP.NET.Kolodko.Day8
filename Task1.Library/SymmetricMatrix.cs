using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Library
{
    public class SymmetricMatrix<T>: Matrix<T>, IEquatable<SymmetricMatrix<T>>
    {
        private T[][] elements;

        public SymmetricMatrix(T[][] matrix)
        {
            if (matrix == null)
                throw new ArgumentNullException();
            Size = matrix.Length;
            InitElements(Size);
            for (int i = 0; i < Size; i++)
                Array.Copy(matrix[i], elements[i], i + 1);
        }

        public SymmetricMatrix(int size)
        {
            if (size < 0)
                throw new ArgumentOutOfRangeException();
            Size = size;
            InitElements(size);
        }

        public bool Equals(SymmetricMatrix<T> other)
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
            SymmetricMatrix<T> m = obj as SymmetricMatrix<T>;
            if (m == null)
                return false;
            else
                return this.Equals(m);
        }

        protected override T GetElement(int i, int j)
        {
            if (i < j)
                return elements[j][i];
            return elements[i][j];
        }

        protected override void SetElement(int i, int j, T value)
        {
            if (i > j)
                elements[i][j] = value;
            else
                elements[j][i] = value;
            if (i != j)
            {
                OnElementChanged(this, new ElementChangedEventArgs(j, i));
            }
        }

        private void InitElements(int size)
        {
            elements = new T[size][];
            for (int i = 0; i < size; i++)
                elements[i] = new T[i + 1];
        }
    }
}
