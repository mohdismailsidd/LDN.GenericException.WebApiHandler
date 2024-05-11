using System.Diagnostics.CodeAnalysis;

namespace LDN.Framework.GenericException.WebApiHandler.Models
{
    [ExcludeFromCodeCoverage]
    
    public class ValidationError
    {

        /// <summary>
        ///     The error message for this validation error.
        /// </summary>
        public string Message { get; set; }=String.Empty;

        /// <summary>
        ///     The name of the field that this error relates to.
        /// </summary>
        public string? ControlID { get; set; }

        /// <summary>
        ///     An ID set for the Error. This ID can be used as a correlation between bus object and UI code.
        /// </summary>
        public string ID { get; set; }=string.Empty;
       /// <summary>
       ///  Initializes new instance of object class
       /// </summary>
        public ValidationError() : base() { }
        /// <summary>
        ///     error message for validation error
        /// </summary>
        /// <param name="message"></param>
        public ValidationError(string message)
        {
            Message = message;
        }
        /// <summary>
        ///     Adds a validation error if the condition is true. Otherwise no item is 
        ///     added.
        /// <seealso>Class ValidationError</seealso>
        /// </summary>
        /// <param name="Message">
        /// The message for this error
        /// </param>
        /// <param name="FieldName">
      
        /// </param>
        /// <returns>value of condition</returns>
        public ValidationError(string message, string fieldName)
        {
            Message = message;
            ControlID = fieldName;
        }
        /// <summary>
        ///     Adds a validation error if the condition is true. Otherwise no item is 
        ///     added.
        /// <seealso>Class ValidationError</seealso>
        /// </summary>
        /// <param name="Message">
        ///     The message for this error
        /// </param>
        /// <param name="FieldName">
        ///     Name of the UI field (optional) that this error relates to. Used optionally
        ///     by the databinding classes.
        /// </param>
        /// <param name="ID">
        ///     An optional Error ID.
        /// </param>
        /// <returns>value of condition</returns>
        
        public ValidationError(string message, string fieldName, string id)
        {
            Message = message;
            ControlID = fieldName;
            ID = id;
        }
        /// <summary>
        ///     Message in ToString
        /// </summary>
        /// <returns>Error message of validation error</returns>
        public override string ToString()
        {
            return Message;
        }
    }
}