using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace LDN.Framework.GenericException.WebApiHandler.Models
{
    [ExcludeFromCodeCoverage]
	[Serializable]
  
    public class InputValidationException : Exception
    {
        private const string DefaultMessage = "Provided input is not valid";
        /// <summary>
        ///     Gets or Sets the Class ValidationError
        /// </summary>

        public ValidationErrorCollection Errors { get; set; }
        /// <summary>
        ///     InputvalidationException
        /// </summary>
        public InputValidationException() : base(DefaultMessage)
        {
            Errors = new ValidationErrorCollection();
        }
        /// <summary>
        ///     InputValidation Exception Message
        /// </summary>
        /// <param name="message"></param>
        public InputValidationException(string message) : base(message)
        {
            Errors = new ValidationErrorCollection();
        }
     
        /// <summary>
        ///     Definition of InputvalidationException
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public InputValidationException(string message, Exception innerException) : base(message, innerException)
        {
            Errors = new ValidationErrorCollection();
        }
        protected InputValidationException(
      SerializationInfo info,
      StreamingContext context):base(info, context)
        {

            Errors = new ValidationErrorCollection();
        }
    }
}
