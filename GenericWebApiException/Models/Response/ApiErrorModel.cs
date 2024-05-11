namespace LDN.Framework.GenericException.WebApiHandler.Models.Response
{
    /// <summary>
    ///     Error model
    /// </summary>
    public sealed class ApiErrorModel
    {
        /// <summary>
        ///     General error code - default value if nothing is specified
        /// </summary>
        public const string ErrorCodeGeneral = @"GL10000";

        /// <summary>
        ///     General error code for bad request - something wrong was passed from the client to the service.
        /// </summary>
        public const string ErrorCodeGeneralBadRequest = @"GL10001";

        /// <summary>
        ///     Default error message
        /// </summary>
        public const string ErrorMessageDefault = @"An error occurred on the server preventing it to handle the request successfully.";

        /// <summary>
        ///     Default error message
        /// </summary>
        public const string ErrorMessageDefaultBadRequest = @"Wrong or invalid data was sent to the service. Please, review it.";

        /// <summary>
        ///     Default error detail message
        /// </summary>
        public const string ErrorDetailDefault = @"Check the logs for further detail.";

        /// <summary>
        ///    Initialize an instance of <see cref="ApiErrorModel"/> 
        /// </summary>
        public ApiErrorModel()
        {
        }

        /// <summary>
        ///     Initialize an instance of <see cref="ApiErrorModel"/> with error message
        /// </summary>
        /// <param name="message"></param>
        public ApiErrorModel(string message)
        {
            Message = message;
        }

        /// <summary>
        ///     Model for APIError
        /// </summary>
        /// <param name="httpStatus"></param>
        /// <param name="errorCode"></param>
        public ApiErrorModel(int httpStatus, string errorCode = ErrorCodeGeneral)
        {
            HttpStatus = httpStatus;
            ErrorCode = errorCode;
        }

        /// <summary>
        ///     HTTP status code (number as string).
        /// </summary>
        public int HttpStatus { get; set; }

        /// <summary>
        ///     Gets or sets the response code.
        /// </summary>
        /// <value>
        /// The response code.
        /// </value>
        public int ResponseCode { get; set; }

        /// <summary>
        ///     Gets or Sets the ErrorCode
        /// </summary>
        /// <value>
        ///     ErrorCode
        /// </value>
        public string? ErrorCode { get; set; }

        /// <summary>
        ///     Gets or Sets the Message
        /// </summary>
        /// <value>
        ///     Message
        /// </value>
        public string? Message { get; set; }

        /// <summary>
        ///     Detail of the error.
        /// </summary>
        public string? Detail { get; set; }

        /// <summary>
        ///  URL to find more about the error.
        /// </summary>
        public string? ErrorInfoUrl { get; set; }
    }
}
