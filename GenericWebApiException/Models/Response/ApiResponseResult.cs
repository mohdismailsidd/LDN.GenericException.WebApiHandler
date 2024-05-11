
using System.Net;
using System.Runtime.Serialization;

namespace LDN.Framework.GenericException.WebApiHandler.Models.Response
{
    /// <summary>
    ///     Common model for API response
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class ApiResponseResult<T>
    {
        /// <summary>
        ///     Response Result
        /// </summary>
        public ApiResponseResult()
        {

        }
        /// <summary>
        ///     The HTTP status code
        /// </summary>
        private readonly int? _httpStatusCode;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ApiResponseModel{T}"/> class.
        /// </summary>
        /// <param name="httpStatusCode"></param>
        /// <param name="errors">The errors.</param>
        public ApiResponseResult(int httpStatusCode , IEnumerable<ApiErrorModel> errors = null!)
        {
            _httpStatusCode = httpStatusCode;
            Errors = errors?.ToList();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ApiResponseModel{T}"/> class.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="httpStatusCode">The HTTP status code.</param>
        /// <param name="errors">The errors.</param>
        public ApiResponseResult(T result, int? httpStatusCode = null, IEnumerable<ApiErrorModel> errors = null!)
        {
            Success = true;
            Result = result;
            Errors = errors?.ToList();
            _httpStatusCode = httpStatusCode;
        }

        /// <summary>
        ///     A response with a single error
        /// </summary>
        /// <param name="singleError"></param>
        public ApiResponseResult(ApiErrorModel singleError)
        {
            Success = false;
            Result = default;
            Errors = new List<ApiErrorModel> { singleError };
        }

        /// <summary>
        ///     A response with many errors
        /// </summary>
        /// <param name="listOfErrors"></param>
        public ApiResponseResult(IEnumerable<ApiErrorModel> listOfErrors)
        {
            Success = false;
            Result = default;
            Errors = new List<ApiErrorModel>();
            foreach (var error in listOfErrors)
            {
                Errors.Add(error);
            }
        }

        /// <summary>
        ///     Gets the HTTP status code for response.
        /// </summary>
        /// <value>
        ///     The HTTP status code for response.
        /// </value>
        [IgnoreDataMember]
        public int HttpStatusForResponse
        {
            get
            {
                if (_httpStatusCode.HasValue)
                    return _httpStatusCode.Value;

                if (Success)
                    return (int)HttpStatusCode.OK;

                return Errors!=null && Errors.Any()
                    ? Errors.First().HttpStatus
                    : (int)HttpStatusCode.InternalServerError;
            }
        }

        /// <summary>
        /// Indicates whether the request was successful or failed.
        /// If 'true', then the 'Result' member will have the data.
        /// Else, the request failed and the 'Errors' member will have further information.
        /// </summary>
        /// <value>
        ///   <c>true</c> if success; otherwise, <c>false</c>.
        /// </value>
        [DataMember(Order = 10, Name = "success", IsRequired = true, EmitDefaultValue = true)]
        public bool Success { get; set; }

        /// <summary>
        ///     An ID to track the request and response in the log files and provided back to the client.
        /// </summary>
        [DataMember(Order = 20, Name = "correlationId", IsRequired = false, EmitDefaultValue = true)]
        public string? CorrelationId { get; set; }

        /// <summary>
        ///     List of errors (only available if the request failed).
        /// </summary>
        [DataMember(Order = 30, Name = "errors", IsRequired = false, EmitDefaultValue = true)]
        public List<ApiErrorModel>? Errors { get; set; }

        /// <summary>
        ///     Result model.
        /// </summary>
        [DataMember(Order = 40, Name = "result", IsRequired = false, EmitDefaultValue = true)]
        public T? Result { get; set; }

    }
}
