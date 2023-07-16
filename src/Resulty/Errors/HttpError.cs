using System.Net;

namespace Resulty.Errors
{
    public class HttpError : Error
    {
        protected HttpError(string message, int statusCode) : base(message, statusCode)
        {
        }

        public static Error NotFound(string message = "Not found") =>
            new Error(message, (int)HttpStatusCode.NotFound);

        public static Error BadRequest(string message = "Bad request") =>
            new Error(message, (int)HttpStatusCode.BadRequest);
    }
}
