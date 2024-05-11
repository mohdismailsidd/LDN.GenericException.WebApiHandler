using LDN.Framework.GenericException.WebApiHandler.Exceptions;
using LDN.Framework.GenericException.WebApiHandler.Models;
using LDN.Framework.GenericException.WebApiHandler.Models.Response;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace LDN.Framework.GenericException.WebApiHandler.ExceptionFilter
{
    [ExcludeFromCodeCoverage]

    public sealed class ApiExceptionFilter<T> : ExceptionFilterAttribute
    {
        private const string CORRELATION_HEADER = "x-corelation-id";
        private readonly IHostingEnvironment _hostingEnv;
        private readonly ILogger<T> _logger;
        /// <summary>
        /// Initializes a new instance of the <see cref="Error"/> class.
        /// </summary>
        /// <param name="hostingEnv"></param>
        /// <param name="logger"></param>
        public ApiExceptionFilter(IHostingEnvironment hostingEnv, ILogger<T> logger)
        {
            _hostingEnv = hostingEnv;
            _logger = logger;
        }

        /// <summary>
        ///     To override exceptions to create custom exception model for API's
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public override void OnException(ExceptionContext context)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            else
            {
                ApiErrorModel error = new ApiErrorModel(context.Exception.Message);
                if (_hostingEnv.IsDevelopment())
                {
                    error.Detail = context!.Exception!.StackTrace!;
                }

                string errorCode = string.Empty;
                string correlationId = GetHeader(context.HttpContext);
                string errorMessage = context.Exception.Message;
                Tuple<string, string> errorResult = new Tuple<string, string>(null, null);
                var exceptionMessage = $"{correlationId} : {errorMessage}";
                switch (context.Exception)
                {

                    case InputValidationException _:
                        var ex = context.Exception as InputValidationException;
                        context.HttpContext.Response.StatusCode = HttpStatusCode.BadRequest.GetHashCode();
                        errorCode = "BadRequest";
                        _logger.LogError(context.Exception, exceptionMessage);
                        break;
                    case ApiNotFoundException _:
                        context.HttpContext.Response.StatusCode = HttpStatusCode.NotFound.GetHashCode();
                        errorResult = FormatError(errorMessage);
                        errorCode = errorResult.Item2 ?? "NotFound";
                        errorMessage = errorResult.Item1;
                        _logger.LogError(context.Exception, exceptionMessage);
                        break;
                    case ApiBadRequestException _:
                        context.HttpContext.Response.StatusCode = HttpStatusCode.BadRequest.GetHashCode();
                        errorResult = FormatError(errorMessage);
                        errorCode = errorResult.Item2 ?? "BadRequest";
                        errorMessage = errorResult.Item1;
                        _logger.LogError(context.Exception, exceptionMessage);
                        break;
                    case ApiException _:
                        errorCode = "InternalServerError";
                        context.HttpContext.Response.StatusCode = HttpStatusCode.InternalServerError.GetHashCode();
                        _logger.LogError(context.Exception, exceptionMessage);
                        break;
                    case ArgumentException _:
                        context.HttpContext.Response.StatusCode = HttpStatusCode.BadRequest.GetHashCode();
                        errorCode = "BadRequest";
                        _logger.LogError(context.Exception, exceptionMessage);
                        break;
                    case KeyNotFoundException _:
                        context.HttpContext.Response.StatusCode = HttpStatusCode.NotFound.GetHashCode();
                        errorCode = "NotFound";
                        _logger.LogError(context.Exception, exceptionMessage);
                        break;
                    case InvalidOperationException _:
                        context.HttpContext.Response.StatusCode = HttpStatusCode.MethodNotAllowed.GetHashCode();
                        errorCode = "MethodNotAllowed";
                        _logger.LogError(context.Exception, exceptionMessage);
                        break;
                    case UnauthorizedAccessException _:
                        context.HttpContext.Response.StatusCode = HttpStatusCode.Unauthorized.GetHashCode();
                        errorCode = "UnauthorizedAccess";
                        _logger.LogError(context.Exception, exceptionMessage);
                        break;
                    case AccessViolationException _:
                        context.HttpContext.Response.StatusCode = HttpStatusCode.Forbidden.GetHashCode();
                        errorCode = "AccessViolation";
                        _logger.LogError(context.Exception, exceptionMessage);
                        break;
                    case ServiceUnavailableException _:
                        context.HttpContext.Response.StatusCode = HttpStatusCode.ServiceUnavailable.GetHashCode();
                        errorCode = "ServiceUnavailable";
                        _logger.LogError(context.Exception, exceptionMessage);
                        break;
                    case DatabaseException _:
                        context.HttpContext.Response.StatusCode = HttpStatusCode.ServiceUnavailable.GetHashCode();
                        errorCode = "ServiceUnavailable";
                        _logger.LogError(context.Exception, exceptionMessage);
                        break;
                    default:
                        context.HttpContext.Response.StatusCode = HttpStatusCode.InternalServerError.GetHashCode();
                        _logger.LogError(context.Exception, exceptionMessage);
                        break;
                };

                var apiResponseModel = new ApiResponseResult<Exception>
                {
                    CorrelationId = correlationId,
                    Success = false,
                    Errors = new List<ApiErrorModel> { new ApiErrorModel () {
                            ResponseCode = context.HttpContext.Response.StatusCode,
                            HttpStatus = context.HttpContext.Response.StatusCode,
                            ErrorCode= errorCode,
                            Message = errorMessage,
                        }
                    },
                };


                context.Result = new JsonResult(apiResponseModel);
                base.OnException(context);
            }
        }

        private string GetHeader(HttpContext httpContext)
        {
            if (httpContext.Request.Headers.Any(x => x.Key == CORRELATION_HEADER))
            {
                return httpContext.Request.Headers[CORRELATION_HEADER].FirstOrDefault();
            }
            return httpContext.TraceIdentifier;
        }

        private Tuple<string, string> FormatError(string error)
        {
            var result = error.Split(",");
            if (result != null && result.Length > 0)
            {
                return Tuple.Create(result[0], result[1]);
            }
            return new Tuple<string, string>(error, null);
        }
    }
}
