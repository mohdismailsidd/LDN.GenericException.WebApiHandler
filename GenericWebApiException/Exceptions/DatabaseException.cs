using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace LDN.Framework.GenericException.WebApiHandler.Exceptions
{
    [Serializable]
    public class DatabaseException : Exception
    {
        public const string DATABASE_NOT_AVAILABLE = "Database is down. Please contact administrator.";

        /// <summary>
		/// Exception class for bad request
		/// </summary>
		public DatabaseException() : base()
        {

        }

        protected DatabaseException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {

        }

        /// <summary>
        /// APIException class for bad Message
        /// </summary>
        /// <param name="message"></param>
        public DatabaseException(string message) : base(message)
        {
        }
    }
}
