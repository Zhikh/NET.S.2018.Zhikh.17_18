using System;
using System.Runtime.Serialization;

namespace Task1.Logic.Exceptions
{
    class InvalidMatrixOperationException : ApplicationException
    {
        public InvalidMatrixOperationException() { }

        public InvalidMatrixOperationException(string message) : base(message) { }

        public InvalidMatrixOperationException(string message, Exception inner) : base(message, inner) { }

        protected InvalidMatrixOperationException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
