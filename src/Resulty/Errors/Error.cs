namespace Resulty
{
    /// <summary>
    /// Represents an operation error with a custom status code and an error message
    /// </summary>
    public class Error
    {
        /// <summary>
        /// Gets an error type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets an error title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets detailed description of the error
        /// </summary>
        public string Detail { get; set; }
    }
}
