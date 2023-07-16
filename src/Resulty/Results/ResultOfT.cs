using System;

namespace Resulty
{
    /// <summary>
    /// Represents the result of an operation, including its status and, optionally, an error.
    /// </summary>
    /// <typeparam name="T">Type of a value associated with the result</typeparam>
    public class Result<T> : Result
    {
        private readonly T _value;

        /// <summary>
        /// Gets the value associated with the result.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when attempting to access the value from a failed result.</exception>
        public T Value => IsSuccess ? _value : throw new InvalidOperationException("Value cannot be retrieved from a failed result.");

        /// <summary>
        /// Initializes a new instance of the <see cref="Result{T}"/> class.
        /// </summary>
        /// <param name="value">The value associated with the result.</param>
        /// <param name="isSuccess">A flag indicating whether the operation is successful.</param>
        /// <param name="error">The error that occurred during the operation. Pass null if the operation is successful.</param>
        /// <exception cref="ArgumentException">Thrown when the operation is failed (isSuccess = false) and the error parameter is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the operation is successful (isSuccess = true) and the error parameter is not null.</exception>
        public Result(T value, bool isSuccess, Error error = null)
            : base(isSuccess, error)
        {
            _value = value;
        }
    }
}
