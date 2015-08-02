using System;

namespace Task1.Library
{
    public class ElementChangedEventArgs: EventArgs
    {
        public int Row { get; set; }
        public int Coloumn { get; set; }
        public ElementChangedEventArgs(int row, int coloumn)
            : base()
        {
            Row = row;
            Coloumn = coloumn;
        }
    }
}
