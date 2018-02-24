using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ClansHuntApp.Monitor.Exceptions
{
    [Serializable]
    public class DataOperationException : Exception
    {
        public DataOperationException() : base() { }
        public DataOperationException(string message) : base(message) { }
        public DataOperationException(string message, Exception innerException) : base(message, innerException) { }
        protected DataOperationException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
