using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Library
{
    public class SquareMartix<T>: ISquareMatrix<T>
    {
        private T[][] elements;

        public event EventHandler<ElementChangedEventArgs> ElementChanged = delegate { };
        public int Size { get; private set; }
        public T this[int i, int j]
        {
            get
            {
                if (i < 0 || i > Size - 1 || j < 0 || j > Size - 1)
                    throw new ArgumentOutOfRangeException();
                return elements[i][j];
            }
            set
            {
                if (i < 0 || i > Size - 1 || j < 0 || j > Size - 1)
                    throw new ArgumentOutOfRangeException();
                elements[i][j] = value;
            }
        }
        
        public SquareMartix(int size)
        {
            if (size < 0)
                throw new ArgumentOutOfRangeException();
            Size = size;
            elements = new T[size][];
            for (int i = 0; i < size; i++)
                elements[i] = new T[size];
        }

        protected virtual void OnElementChanged(object sender, ElementChangedEventArgs e)
        {
            ElementChanged(sender, e);
        }

    }
}
