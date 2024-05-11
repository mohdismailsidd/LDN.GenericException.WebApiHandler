using System.Runtime.Serialization;

namespace LDN.Framework.GenericException.WebApiHandler.Exceptions
{

	[Serializable]
	public class ApiBadRequestException : Exception
	{
		/// <summary>
		/// Exception class for bad request
		/// </summary>
		public ApiBadRequestException() : base()
		{

		}
		protected ApiBadRequestException(
	   SerializationInfo info,
	   StreamingContext context) : base(info, context)
		{

		}
		/// <summary>
		/// APIException class for bad Message
		/// </summary>
		/// <param name="message"></param>
		public ApiBadRequestException(string message) : base(message)
		{

		}
	}
}
