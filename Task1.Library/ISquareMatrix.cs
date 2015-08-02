using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Library
{
    public interface ISquareMatrix<T>
    {
        event EventHandler<ElementChangedEventArgs> ElementChanged;
        int Size { get; }
        T this[int i, int j] { get; set; }
    }
}
