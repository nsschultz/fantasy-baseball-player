using System;
using System.Runtime.Serialization;

namespace FantasyBaseball.PlayerService.Exceptions
{
    /// <summary>Exception that is thrown when there is problem with the request.</summary>
    [Serializable]
    public class BadRequestException : Exception
    {
        // <summary>Initializes a new instance of the exception class with the default error message.</summary>
        public BadRequestException() : base("The given request was invalid.") { }

        /// <summary>Initializes a new instance of the exception class with a specified error message.</summary>
        /// <param name="message">The message that describes the error.</param>
        public BadRequestException(string message) : base(message) { }

        /// <summary>Initializes a new instance of the exception class with a specified error message.</summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">
        ///     The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) 
        ///     if no inner exception is specified.
        /// </param>
        public BadRequestException(string message, Exception innerException) : base(message, innerException) { }

        /// <summary>Initializes a new instance of the System.Exception class with serialized data.</summary>
        /// <param name="info">
        ///     The System.Runtime.Serialization.SerializationInfo that holds the serialized
        ///     object data about the exception being thrown.
        /// </param>
        /// <param name="context">
        ///     The System.Runtime.Serialization.StreamingContext that contains contextual information
        ///     about the source or destination..
        /// </param>
        protected BadRequestException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}