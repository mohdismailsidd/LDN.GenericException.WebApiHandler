using System.Runtime.Serialization;

namespace LDN.Framework.GenericException.WebApiHandler.Exceptions
{
	/// <summary>
	///     The definition API Response for NotFound Exception
	/// </summary>
	[Serializable]
	public class ApiNotFoundException : Exception
	{
		/// <summary>
		///     Definition of APINotFound exception
		/// </summary>
		public ApiNotFoundException() : base()
		{

		}
		/// <summary>
		///  Definition of APINotFound exception
		/// </summary>
		/// <param name="message"></param>
		public ApiNotFoundException(string message) : base(message)
		{

		}
		protected ApiNotFoundException(
	   SerializationInfo info,
	   StreamingContext context) : base(info, context)
		{

		}
	}
}
