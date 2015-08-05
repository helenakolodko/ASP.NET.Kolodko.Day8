using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Library
{
    public abstract class Matrix<T>
    {
        public event EventHandler<ElementChangedEventArgs> ElementChanged = delegate { };
        public int Size { get; protected set; }
        public T this[int i, int j]
        {
            get
            {
                if (i < 0 || i > Size - 1 || j < 0 || j > Size - 1)
                    throw new ArgumentOutOfRangeException();
                return GetElement(i, j);
            }
            set
            {
                if (i < 0 || i > Size - 1 || j < 0 || j > Size - 1)
                    throw new ArgumentOutOfRangeException();
                SetElement(i, j, value);
                OnElementChanged(this, new ElementChangedEventArgs(i, j));
            }
        }
        protected abstract T GetElement(int i, int j);
        protected abstract void SetElement(int i, int j, T value);
        protected virtual void OnElementChanged(object sender, ElementChangedEventArgs e)
        {
            ElementChanged(sender, e);
        }

    }
}
