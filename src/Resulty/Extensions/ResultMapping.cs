using System.Threading.Tasks;
using System;

namespace Resulty.Extensions
{
    public static class ResultMapping
    {
        public static async Task<TOut> MapAsync<TIn, TOut>(this Task<Result<TIn>> task, Func<TIn, TOut> onSuccess, Func<Error, TOut> onError)
        {
            var result = await task;
            return result.IsSuccess ? onSuccess(result.Value) : onError(result.Error);
        }

        public static async Task<T> MapAsync<T>(this Task<Result> task, Func<T> onSuccess, Func<Error, T> onError)
        {
            var result = await task;
            return result.IsSuccess ? onSuccess() : onError(result.Error);
        }
    }
}
