using System;
using System.Threading.Tasks;

namespace Resulty
{
    public static class ResultChaining
    {
        /// <summary>
        /// Chains a result asynchronously with a function that takes a result and returns a task of result.
        /// </summary>
        /// <param name="task">The task representing a result.</param>
        /// <param name="next">The function that will be invoked in the chain if the result is successful.</param>
        /// <returns>A task representing the result of the operation.</returns>
        public static async Task<Result> ThenAsync(this Task<Result> task, Func<Result, Task<Result>> next)
        {
            var result = await task;
            return result.IsSuccess ? await next(result) : result;
        }

        /// <summary>
        /// Chains a result asynchronously with a function that takes a typed result and returns a task of typed result.
        /// </summary>
        /// <typeparam name="T">The type of the result.</typeparam>
        /// <param name="task">The task representing a typed result.</param>
        /// <param name="next">The function that will be invoked in the chain if the result is successful.</param>
        /// <returns>A task representing the typed result of the operation.</returns>
        public static async Task<Result<T>> ThenAsync<T>(this Task<Result<T>> task, Func<Result<T>, Task<Result<T>>> next)
        {
            var result = await task;
            return result.IsSuccess ? await next(result) : result;
        }

        /// <summary>
        /// Chains a result asynchronously with a function that takes a typed result and returns a task of result.
        /// </summary>
        /// <typeparam name="T">The type of the result.</typeparam>
        /// <param name="task">The task representing a typed result.</param>
        /// <param name="next">The function that will be invoked in the chain if the result is successful.</param>
        /// <returns>A task representing the result of the operation.</returns>
        public static async Task<Result> ThenAsync<T>(this Task<Result<T>> task, Func<Result<T>, Task<Result>> next)
        {
            var result = await task;
            return result.IsSuccess ? await next(result) : result;
        }

        /// <summary>
        /// Chains a typed result asynchronously with a function that takes a typed result and returns a task of typed result with transformation.
        /// </summary>
        /// <typeparam name="TIn">The type of the input result.</typeparam>
        /// <typeparam name="TOut">The type of the output result.</typeparam>
        /// <param name="task">The task representing a typed result.</param>
        /// <param name="next">The function that will be invoked in the chain if the result is successful.</param>
        /// <returns>A task representing the transformed typed result of the operation.</returns>
        public static async Task<Result<TOut>> ThenWithTransformationAsync<TIn, TOut>(this Task<Result<TIn>> task, Func<Result<TIn>, Task<Result<TOut>>> next)
        {
            var result = await task;
            return result.IsSuccess ? await next(result) : Result.Failure<TOut>(result.Error);
        }

        /// <summary>
        /// Chains a result with a synchronous function if the result is successful.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="next">The function that will be invoked in the chain if the result is successful.</param>
        /// <returns>The result of the operation.</returns>
        public static Result Then(this Result result, Func<Result, Result> next)
        {
            return result.IsSuccess ? next(result) : result;
        }

        /// <summary>
        /// Chains a typed result with a synchronous transformation function.
        /// </summary>
        /// <typeparam name="TIn">The type of the input result.</typeparam>
        /// <typeparam name="TOut">The type of the output result.</typeparam>
        /// <param name="result">The typed result.</param>
        /// <param name="transform">The function that will be invoked in the chain to transform the result.</param>
        /// <returns>The transformed typed result of the operation.</returns>
        public static Result<TOut> ThenWithTransformation<TIn, TOut>(this Result<TIn> result, Func<Result<TOut>> transform)
        {
            if (result.IsSuccess)
            {
                return transform.Invoke();
            }

            return Result.Failure<TOut>(result.Error);
        }

    }
}
