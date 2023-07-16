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
        /// <param name="error">The error that occurred during the operation. Pass null if the operation is successful.</param>
        /// <exception cref="ArgumentException">Thrown when the operation is failed (isSuccess = false) and the error parameter is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the operation is successful (isSuccess = true) and the error parameter is not null.</exception>
        protected Result(bool isSuccess, Error error = null)
        {
            IsSuccess = isSuccess;
            Error = isSuccess ? ValidateErrorForSuccess(error) : ValidateErrorForFailure(error);
        }

        /// <summary>
        /// Creates a new instance of the successful <see cref="Result"/> class.
        /// </summary>
        /// <returns>A new instance of the <see cref="Result"/> class representing a success.</returns>
        public static Result Success() => 
            new Result(true);

        /// <summary>
        /// Creates a new instance of the failed <see cref="Result"/> class
        /// </summary>
        /// <param name="error">An error that caused the failure.</param>
        /// <returns>A new instance of the <see cref="Result"/> class representing a failure.</returns>
        public static Result Failure(Error error) =>
            new Result(false, error);

        /// <summary>
        /// Creates a new instance of the failed <see cref="Result{T}"/> class
        /// </summary>
        /// <typeparam name="T">Type of a value associated with the result</typeparam>
        /// <param name="error">An error that caused the failure.</param>
        /// <returns>A new instance of the <see cref="Result{T}"/> class representing a failure.</returns>
        public static Result<T> Failure<T>(Error error) =>
            new Result<T>(default, false, error);

        /// <summary>
        /// Creates a new instance of the successful <see cref="Result{T}"/> class.
        /// </summary>
        /// <typeparam name="T">Type of a value associated with the result</typeparam>
        /// <param name="value">A value associated with the result.</param>
        /// <returns>A new instance of the <see cref="Result{T}"/> class representing a success.</returns>
        public static Result<T> Success<T>(T value) =>
            new Result<T>(value, true);

        private static Error ValidateErrorForFailure(Error error)
        {
            if (error == null)
            {
                throw new ArgumentException("Error should be not null for a failed result.");
            }

            return error;
        }

        private static Error ValidateErrorForSuccess(Error error)
        {
            if (error!= null)
            {
                throw new ArgumentException("Error should be null for a successful result.");
            }

            return error;
        }
    }
}
