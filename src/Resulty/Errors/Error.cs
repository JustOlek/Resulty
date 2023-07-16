namespace Resulty.Errors
{
    /// <summary>
    /// Represents an operation error with a custom status code and an error message
    /// </summary>
    public class Error
    {
        /// <summary>
        /// Gets an error specific status code 
        /// </summary>
        public int StatusCode { get; }

        /// <summary>
        /// Gets a message describing the error
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="Error"/> with specific parameters.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <param name="code">Error status code.</param>
        public Error(string message, int statusCode)
        {
            StatusCode = statusCode;
            Message = message;
        }
    }
}
