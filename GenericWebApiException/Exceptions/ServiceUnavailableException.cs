using System.Runtime.Serialization;

namespace LDN.Framework.GenericException.WebApiHandler.Exceptions
{
    public class ServiceUnavailableException : Exception
    {
        public ServiceUnavailableException() : base()
        {

        }

        protected ServiceUnavailableException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {

        }

        /// <summary>
        /// Service unavailable class for bad Message
        /// </summary>
        /// <param name="message"></param>
        public ServiceUnavailableException(string message) : base(message)
        {

        }
    }
}
