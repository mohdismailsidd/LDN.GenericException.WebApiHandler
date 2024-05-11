using System.Diagnostics.CodeAnalysis;

namespace LDN.Framework.GenericException.WebApiHandler.Models
{
    [ExcludeFromCodeCoverage]

    /// <summary>
    ///     The error message for this API error.
    /// </summary>

    public class ApiError
    {
        /// <summary>
        ///     Gets or Sets the Message
        /// </summary>
        /// <value>
        ///     Message
        /// </value>
        ///
        public string Message { get; set; }

        /// <summary>
        ///     Checks the error
        /// </summary>
        public bool IsError { get; set; }

        /// <summary>
        ///     Detail of the error.
        /// </summary>
        public string? Detail { get; set; }
        /// <summary>
        ///     Gets or Sets the validationErrorCollection 
        /// </summary>
        public ValidationErrorCollection? Errors { get; set; }
        /// <summary>
        ///     The error response for this API error.
        /// </summary>
        /// <param name="message"></param>
        public ApiError(string message)
        {
            Message = message;
            IsError = true;
        }
    }
}
