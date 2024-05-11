using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace LDN.Framework.GenericException.WebApiHandler.Models
{
	[ExcludeFromCodeCoverage]
	[Serializable]

	public class ApiException : Exception
	{
		/// <summary>
		///     Gets the ErrorCode
		/// </summary>
		public int ErrorCode { get; }
		/// <summary>
		///     An Initialization of <see cref="ApiException"/> class
		/// </summary>
		public ApiException() : base()
		{
			ErrorCode = -1;
		}
		/// <summary>
		///     An Initialization of <see cref="ApiException"/> class
		/// </summary>
		/// <param name="message"></param>
		public ApiException(string message) : this(message, new Exception(message)) { }
		/// <summary>
		///     An Initialization of <see cref="ApiException"/> class
		/// </summary>
		/// <param name="message"></param>
		/// <param name="innerException"></param>

		public ApiException(string message, Exception innerException) : this(message, innerException, -1) { }
		/// <summary>
		///     Initializes new Instance of ExceptionClass
		/// </summary>
		/// <param name="message"></param>
		/// <param name="ex"></param>
		/// <param name="code"></param>
		public ApiException(string message, Exception ex, int code) : base(message, ex)
		{
			ErrorCode = code;
		}
		protected ApiException(
	   SerializationInfo info,
	   StreamingContext context) : base(info, context)
		{

		}
	}
}