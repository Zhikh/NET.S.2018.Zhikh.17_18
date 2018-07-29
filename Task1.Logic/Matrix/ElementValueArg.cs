using System;

namespace Task1.Logic
{
    public class ElementValueArg<T> : EventArgs
    {
        public ElementValueArg(T oldElement, T newElement)
        {
            this.OldValue = oldElement;
            this.NewValue = newElement;
        }
        
        public T OldValue { get; }

        public T NewValue { get; }
    }
}
