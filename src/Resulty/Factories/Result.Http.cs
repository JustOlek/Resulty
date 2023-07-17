using System.Net;

namespace Resulty
{
    public partial class Result
    {
        /// <summary>
        /// Creates a successful result without a value.
        /// </summary>
        /// <returns>A successful result.</returns>
        public static Result Ok() => Success();

        /// <summary>
        /// Creates a successful result with a value.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="value">The value associated with the result.</param>
        /// <returns>A successful result with the specified value.</returns>
        public static Result<T> Ok<T>(T value) => Success(value);

        /// <summary>
        /// Creates a result indicating a not found error.
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <returns>A result indicating a not found error.</returns>
        public static Result NotFound(string message = "Not Found") =>
            Failure(new Error(message, (int)HttpStatusCode.NotFound));

        /// <summary>
        /// Creates a result indicating a not found error with a value.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="message">The error message.</param>
        /// <returns>A result indicating a not found error with the specified value.</returns>
        public static Result<T> NotFound<T>(string message = "Not Found") =>
            Failure<T>(new Error(message, (int)HttpStatusCode.NotFound));

        /// <summary>
        /// Creates a result indicating a bad request error.
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <returns>A result indicating a bad request error.</returns>
        public static Result BadRequest(string message = "Bad Request") =>
            Failure(new Error(message, (int)HttpStatusCode.BadRequest));

        /// <summary>
        /// Creates a result indicating a bad request error with a value.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="message">The error message.</param>
        /// <returns>A result indicating a bad request error with the specified value.</returns>
        public static Result<T> BadRequest<T>(string message = "Bad Request") =>
            Failure<T>(new Error(message, (int)HttpStatusCode.BadRequest));

        /// <summary>
        /// Creates a result indicating a conflict error.
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <returns>A result indicating a conflict error.</returns>
        public static Result Conflict(string message = "Conflict") =>
            Failure(new Error(message, (int)HttpStatusCode.Conflict));

        /// <summary>
        /// Creates a result indicating a conflict error with a value.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="message">The error message.</param>
        /// <returns>A result indicating a conflict error with the specified value.</returns>
        public static Result<T> Conflict<T>(string message = "Conflict") =>
            Failure<T>(new Error(message, (int)HttpStatusCode.Conflict));

        /// <summary>
        /// Creates a result indicating a payment required error.
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <returns>A result indicating a payment required error.</returns>
        public static Result PaymentRequired(string message = "Payment Required") =>
            Failure(new Error(message, (int)HttpStatusCode.PaymentRequired));

        /// <summary>
        /// Creates a result indicating a payment required error with a value.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="message">The error message.</param>
        /// <returns>A result indicating a payment required error with the specified value.</returns>
        public static Result<T> PaymentRequired<T>(string message = "Payment Required") =>
            Failure<T>(new Error(message, (int)HttpStatusCode.PaymentRequired));

        /// <summary>
        /// Creates a result indicating a forbidden error.
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <returns>A result indicating a forbidden error.</returns>
        public static Result Forbidden(string message = "Forbidden") =>
            Failure(new Error(message, (int)HttpStatusCode.Forbidden));

        /// <summary>
        /// Creates a result indicating a forbidden error with a value.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="message">The error message.</param>
        /// <returns>A result indicating a forbidden error with the specified value.</returns>
        public static Result Forbidden<T>(string message = "Forbidden") =>
            Failure<T>(new Error(message, (int)HttpStatusCode.Forbidden));

        /// <summary>
        /// Creates a result indicating an internal server error.
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <returns>A result indicating an internal server error.</returns>
        public static Result InternalServerError(string message = "Internal Server Error") =>
            Failure(new Error(message, (int)HttpStatusCode.InternalServerError));

        /// <summary>
        /// Creates a result indicating an internal server error with a value.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="message">The error message.</param>
        /// <returns>A result indicating an internal server error with the specified value.</returns>
        public static Result<T> InternalServerError<T>(string message = "Internal Server Error") =>
            Failure<T>(new Error(message, (int)HttpStatusCode.InternalServerError));

    }
}
