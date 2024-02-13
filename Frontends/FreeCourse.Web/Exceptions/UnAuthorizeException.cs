using System;
using System.Runtime.Serialization;

namespace FreeCourse.Web.Exceptions
{
    public class UnAuthorizeException : System.Exception
    {
        public UnAuthorizeException()
        {
        }

        public UnAuthorizeException(string message) : base(message)
        {
        }

        public UnAuthorizeException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        protected UnAuthorizeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
