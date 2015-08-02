using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Library
{
    class DiagonalMatrix<T>: ISquareMatrix<T>
    {
        private T[] elements;

        public event EventHandler<ElementChangedEventArgs> ElementChanged;
        public int Size { get; private set; }
        public T this[int i, int j]
        {
            get
            {
                if (i < 0 || i > Size - 1 || j < 0 || j > Size - 1)
                    throw new ArgumentOutOfRangeException();
                if (i == j)
                    return elements[i];
                else
                    return default(T);
            }
            set
            {
                if (i < 0 || i > Size - 1 || j < 0 || j > Size - 1)
                    throw new ArgumentOutOfRangeException();
                if (i == j)
                    elements[i] = value;
                else if (!value.Equals(default(T)))
                    throw new ArgumentOutOfRangeException();
            }
        }

        public DiagonalMatrix(int size)
        {
            if (size < 0)
                throw new ArgumentOutOfRangeException();
            Size = size;
            elements = new T[size];
        }

        protected virtual void OnElementChanged(object sender, ElementChangedEventArgs e)
        {
            ElementChanged(sender, e);
        }
    }
}
