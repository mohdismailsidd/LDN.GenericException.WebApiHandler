namespace LDN.Framework.GenericException.WebApiHandler.Erros
{
    /// <summary>
    /// Encapsulates error details.
    /// </summary>
    public class Error
    {
        /// <summary>
        /// Gets or sets the error code.
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// Gets or sets the error description.
        /// </summary>
        public string ErrorDescription { get; set; }

        /// <summary>
        /// Error Details
        /// </summary>
        /// <param name="errorCode">The error code.</param>
        /// <param name="errorDescription">The error description.</param>
        /// 
        public Error(string errorCode, string errorDescription)
        {
            ErrorCode = errorCode;
            ErrorDescription = errorDescription;
        }
    }
}
