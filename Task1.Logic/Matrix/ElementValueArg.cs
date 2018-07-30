using System;

namespace Task1.Logic
{
    public class ElementValueArg<T> : EventArgs
    {
        public ElementValueArg(T oldElement, T newElement, int indexRow, int indexColumn)
        {
            this.OldValue = oldElement;
            this.NewValue = newElement;

            this.IndexRow = indexRow;
            this.IndexColumn = indexColumn;
        }
        
        public T OldValue { get; }

        public T NewValue { get; }

        public int IndexRow { get; }

        public int IndexColumn { get; }
    }
}
