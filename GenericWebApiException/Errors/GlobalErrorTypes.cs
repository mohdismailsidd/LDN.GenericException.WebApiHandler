namespace LDN.Framework.GenericException.WebApiHandler.Erros
{ /// <summary>
  /// Defines global error types.
  /// </summary>
    public enum GlobalErrorTypes
    {
        /// <summary>
        /// Invalid top/skip values in OData URL query string.
        /// </summary>
        InvalidTopSkipValues,

        /// <summary>
        /// Not found error.
        /// </summary>
        NotFound,

        /// <summary>
        /// Field is required.
        /// </summary>
        FieldIsRequired,

        /// <summary>
        /// Fields are required.
        /// </summary>
        FieldsAreRequired,

        /// <summary>
        /// Bad search parameter.
        /// </summary>
        BadSearchParam,

        /// <summary>
        /// Input model is not valid.
        /// </summary>
        PayloadIsNotValid,

        /// <summary>
        /// Some fields of the payload are not valid.
        /// </summary>
        PayloadIsNotValidDetailed,

        #region "SERVER ERRORS"

        /// <summary>
        /// Internal server error.
        /// </summary>
        InternalServerError,

        /// <summary>
        /// Resource not found error.
        /// </summary>
        ResourceNotFoundError,

        #endregion

        #region "INVALID REQUEST HEADERS"

        /// <summary>
        /// Auth error.
        /// </summary>
        AuthError,

        /// <summary>
        /// AuthTokenIsNotValid
        /// </summary>
        AuthTokenIsNotValid,

        #endregion

        #region "SETTINGS ERRORS"

        /// <summary>
        ///  SettingsNotInitialized - 90001
        /// </summary>
        SettingsNotInitialized,

        /// <summary>
        /// Query contains invalid parameters.
        /// </summary>
        InvalidSearchParameters

        #endregion
    }
}
