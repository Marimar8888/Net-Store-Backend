using System.Runtime.Serialization;

namespace net_store_backend.Application
{
    [Serializable]
    internal class MalformedFilterException : Exception
    {
        public MalformedFilterException()
        {
        }

        public MalformedFilterException(string? message) : base(message)
        {
        }

        public MalformedFilterException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected MalformedFilterException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}