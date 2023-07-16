using Resulty.Errors;
using System;

namespace Resulty
{
    /// <summary>
    /// Represents the result of an operation, including its status and, optionally, an error.
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Gets a value indicates whether result is successful.
        /// </summary>
        public bool IsSuccess { get; }

        /// <summary>
        /// Gets a value indicates wheter result has failed.
        /// </summary>
        public bool IsFailure => !IsSuccess;

        /// <summary>
        /// Gets the error associated with the result if the operation has failed; otherwise, returns NULL.
        /// </summary>
        public Error Error { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Result"/> class.
        /// </summary>
        /// <param name="isSuccess">A flag indicating whether the operation is successful.</param>
        /// <param name="error">The error that occurred during the operation.</param>
        protected Result(bool isSuccess, Error error = null)
        {
            IsSuccess = isSuccess;
            Error = !isSuccess
                ? error
                : throw new ArgumentException("Error should be null for a successful result.");
        }
    }
}
