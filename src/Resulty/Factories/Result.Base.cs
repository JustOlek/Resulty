namespace Resulty
{
    public partial class Result
    {
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
    }
}
