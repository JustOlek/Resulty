namespace Resulty
{
    /// <summary>
    /// Represents an operation error with a custom status code and an error message
    /// </summary>
    public class Error
    {
        /// <summary>
        /// Gets an error specific code 
        /// </summary>
        public int Code { get; }

        /// <summary>
        /// Gets a message describing the error
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="Error"/> with specific parameters.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <param name="code">Error code.</param>
        public Error(string message, int code = -1)
        {
            Code = code;
            Message = message;
        }
    }
}
