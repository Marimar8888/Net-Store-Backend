using System.Runtime.Serialization;

namespace net_store_backend.Domain.Persistence
{
    public class ForeingKeyException : Exception
    {
        public ForeingKeyException() { }
        
        public ForeingKeyException(string? message) : base(message) { }

        public ForeingKeyException(string? message, Exception? innerException) : base(message, innerException) { }

        protected ForeingKeyException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
