using LDN.Framework.GenericException.WebApiHandler.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LDN.Framework.GenericException.WebApiHandler.Extensions
{
    /// <summary>
    ///     Contains extension methods for MVC action results
    /// </summary>
    public static class ApiActionResultExtensions
    {
        /// <summary>
        ///     Gets the success result.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result">The result.</param>
        /// <param name="httpStatusCode">The HTTP status code.</param>
        /// <param name="correlationId">The correlation identifier.</param>
        /// <returns>Gets the object result</returns>
        public static ObjectResult GetApiSuccessResult<T>(this T result,
            int httpStatusCode = StatusCodes.Status200OK,
            string correlationId = null!)
        {
            var apiResponseModel = new ApiResponseResult<T>(
                result, httpStatusCode)
            {
                CorrelationId = correlationId
            };

            return GetApiObjectResult(apiResponseModel,
                apiResponseModel.HttpStatusForResponse);
        }

        /// <summary>
        ///     Gets the created at route result.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result">The result</param>
        /// <param name="routeName">Name of the route</param>
        /// <param name="routeValues">The route values</param>
        /// <param name="correlationId">The correlation identifier</param>
        /// <returns> Created response with location header</returns>
        public static CreatedAtRouteResult GetApiCreatedAtRouteResult<T>(
            this T result,
            string routeName,
            object routeValues,
            string correlationId = null!)
        {
            var apiResponseModel = new ApiResponseResult<T>(
                result,
                StatusCodes.Status201Created)
            {
                CorrelationId = correlationId
            };

            return new CreatedAtRouteResult(
                routeName,
                routeValues,
                apiResponseModel);
        }

        /// <summary>
        ///     Gets the created at action result.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result">The result.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="correlationId">The correlation identifier.</param>
        /// <returns> Created response with location header</returns>
        public static CreatedAtActionResult GetApiCreatedAtActionResult<T>(
            this T result,
            string actionName,
            string controllerName,
            object routeValues,
            string correlationId = null!)
        {
            var apiResponseModel = new ApiResponseResult<T>(
                result, StatusCodes.Status201Created)
            {
                CorrelationId = correlationId
            };

            return new CreatedAtActionResult(
                actionName,
                controllerName,
                routeValues,
                apiResponseModel);
        }

        /// <summary>
        /// Gets the error result.
        /// </summary>
        /// <param name="error">The error.</param>
        /// <param name="correlationId">The correlation identifier.</param>
        /// <returns>Object result</returns>
        public static ObjectResult GetApiErrorResult(
            this ApiErrorModel error,
            string correlationId = null!)
        {
            var apiResponseModel = new ApiResponseResult<ApiErrorModel>(
                error)
            {
                CorrelationId = correlationId
            };

            return GetApiObjectResult(apiResponseModel,
                apiResponseModel.HttpStatusForResponse);
        }

        /// <summary>
        /// Gets the result.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result">The result.</param>
        /// <param name="errors">The errors.</param>
        /// <param name="httpStatusCode">The HTTP status code.</param>
        /// <param name="correlationId">The correlation identifier.</param>
        /// <returns>Object Result</returns>
        public static ObjectResult GetApiResult<T>(
            this T result,
            IEnumerable<ApiErrorModel> errors,
            int httpStatusCode = StatusCodes.Status200OK,
            string correlationId = null!)
        {
            var apiResponseModel = new ApiResponseResult<T>(
                result, httpStatusCode, errors)
            {
                CorrelationId = correlationId
            };

            return GetApiObjectResult(apiResponseModel,
                apiResponseModel.HttpStatusForResponse);
        }



        /// <summary>
        ///     Gets the object result.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="httpStatusCode">The HTTP status code.</param>
        /// <returns>object result.</returns>
        private static ObjectResult GetApiObjectResult(
            object model, int httpStatusCode)
        {
            return new ObjectResult(model)
            {
                StatusCode = httpStatusCode
            };
        }
    }
}
