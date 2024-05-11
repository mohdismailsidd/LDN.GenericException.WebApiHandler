using System.Net;
using System.Runtime.Serialization;

namespace LDN.Framework.GenericException.WebApiHandler.Exceptions
{
	/// <summary>
	///     The Definition of Tokenvalidation exception
	/// </summary>
	[Serializable]
	public class AuthorizationTokenValidationException : Exception
	{
		/// <summary>
		///  Gets the ErrorCode
		/// </summary>
		public int ErrorCode { get; }

		/// <summary>
		///  The Definition of Tokenvalidation exception
		/// </summary>
		public AuthorizationTokenValidationException() : base()
		{
			ErrorCode = (int) HttpStatusCode.BadRequest;
		}
		protected AuthorizationTokenValidationException(
	   SerializationInfo info,
		StreamingContext context) : base(info, context)
		{

		}
	}
}
