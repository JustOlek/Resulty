﻿using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Resulty
{
    public static class ResultExtensions
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
        /// Chains a result asynchronously with a function that takes a result and returns a task of a typed result.
        /// </summary>
        /// <typeparam name="T">The type of the result.</typeparam>
        /// <param name="task">The task representing a result.</param>
        /// <param name="next">The function that will be invoked in the chain if the result is successful.</param>
        /// <returns>A task representing the result of the operation.</returns>
        public static async Task<Result<T>> ThenAsync<T>(this Task<Result> task, Func<Task<Result<T>>> next)
        {
            var result = await task;
            return result.IsSuccess ? await next() : Result.Failure<T>(result.Error);
        }

        /// <summary>
        /// Chains a typed result asynchronously with a function that takes a typed result and returns a task of typed result with transformation.
        /// </summary>
        /// <typeparam name="TIn">The type of the input result.</typeparam>
        /// <typeparam name="TOut">The type of the output result.</typeparam>
        /// <param name="task">The task representing a typed result.</param>
        /// <param name="next">The function that will be invoked in the chain if the result is successful.</param>
        /// <returns>A task representing the transformed typed result of the operation.</returns>
        public static async Task<Result<TOut>> ThenWithTransformAsync<TIn, TOut>(this Task<Result<TIn>> task, Func<Result<TIn>, Task<Result<TOut>>> next)
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
        /// Chains a result with a synchronous function if the result is successful.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="next">The function that will be invoked in the chain if the result is successful.</param>
        /// <returns>The result of the operation.</returns>
        public static Result<T> Then<T>(this Result<T> result, Func<Result<T>, Result<T>> next)
        {
            return result.IsSuccess ? next(result) : result;
        }

        /// <summary>
        /// Chains a result with a synchronous function if the result is successful.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="next">The function that will be invoked in the chain if the result is successful.</param>
        /// <returns>The result of the operation.</returns>
        public static Result<T> Then<T>(this Result result, Func<Result, Result<T>> next)
        {
            return result.IsSuccess ? next(result) : Result.Failure<T>(result.Error);
        }

        /// <summary>
        /// Chains a result with a synchronous function if the result is successful.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="next">The function that will be invoked in the chain if the result is successful.</param>
        /// <returns>The result of the operation.</returns>
        public static Result Then<T>(this Result<T> result, Func<Result<T>, Result> next)
        {
            return result.IsSuccess ? next(result) : Result.Failure(result.Error);
        }

        /// <summary>
        /// Chains a typed result with a synchronous transformation function.
        /// </summary>
        /// <typeparam name="TIn">The type of the input result.</typeparam>
        /// <typeparam name="TOut">The type of the output result.</typeparam>
        /// <param name="result">The typed result.</param>
        /// <param name="transform">The function that will be invoked in the chain to transform the result.</param>
        /// <returns>The transformed typed result of the operation.</returns>
        public static Result<TOut> ThenWithTransform<TIn, TOut>(this Result<TIn> result, Func<Result<TIn>, Result<TOut>> transform)
        {
            return result.IsSuccess ? transform(result) : Result.Failure<TOut>(result.Error);
        }

        /// <summary>
        /// Maps the result of a task returning a typed result asynchronously with the provided success and error functions.
        /// </summary>
        /// <typeparam name="TIn">The type of the input result.</typeparam>
        /// <typeparam name="TOut">The type of the mapped result.</typeparam>
        /// <param name="task">The task representing a result.</param>
        /// <param name="onSuccess">The function to invoke if the result is successful.</param>
        /// <param name="onError">The function to invoke if the result is an error.</param>
        /// <returns>A task representing the mapped result of the operation.</returns>
        public static async Task<TOut> MapAsync<TIn, TOut>(this Task<Result<TIn>> task, Func<TIn, TOut> onSuccess, Func<Error, TOut> onError)
        {
            var result = await task;
            return result.IsSuccess ? onSuccess(result.Value) : onError(result.Error);
        }

        /// <summary>
        /// Maps the result of a task returning a result without a value asynchronously with the provided success and error functions.
        /// </summary>
        /// <typeparam name="TOut">The type of the mapped result.</typeparam>
        /// <param name="task">The task representing a result without a value.</param>
        /// <param name="onSuccess">The function to invoke if the result is successful.</param>
        /// <param name="onError">The function to invoke if the result is an error.</param>
        /// <returns>A task representing the mapped result of the operation.</returns>
        public static async Task<TOut> MapAsync<TOut>(this Task<Result> task, Func<TOut> onSuccess, Func<Error, TOut> onError)
        {
            var result = await task;
            return result.IsSuccess ? onSuccess() : onError(result.Error);
        }

        /// <summary>
        /// Maps the result of a task returning a typed result synchronously with the provided success and error functions.
        /// </summary>
        /// <typeparam name="TIn">The type of the input result.</typeparam>
        /// <typeparam name="TOut">The type of the mapped result.</typeparam>
        /// <param name="onSuccess">The function to invoke if the result is successful.</param>
        /// <param name="onError">The function to invoke if the result is an error.</param>
        /// <returns>The mapped result of the operation.</returns>
        public static TOut Map<TIn, TOut>(this Result<TIn> result, Func<TIn, TOut> onSuccess, Func<Error, TOut> onError)
        {
            return result.IsSuccess ? onSuccess(result.Value) : onError(result.Error);
        }

        /// <summary>
        /// Maps the result of a task returning a result without a value synchronously with the provided success and error functions.
        /// </summary>
        /// <typeparam name="TOut">The type of the mapped result.</typeparam>
        /// <param name="onSuccess">The function to invoke if the result is successful.</param>
        /// <param name="onError">The function to invoke if the result is an error.</param>
        /// <returns>The mapped result of the operation.</returns>
        public static TOut Map<TOut>(this Result result, Func<TOut> onSuccess, Func<Error, TOut> onError)
        {
            return result.IsSuccess ? onSuccess() : onError(result.Error);
        }

        /// <summary>
        /// Ensures that a specified condition is met for a <see cref="Result"/> object.
        /// If the condition is not met, a failure <see cref="Result"/> is returned with the specified error.
        /// </summary>
        /// <param name="result">The <see cref="Result"/> object to validate.</param>
        /// <param name="predicate">
        /// A function that represents the condition to be checked. 
        /// The condition is expected to return <c>true</c> if valid and <c>false</c> otherwise.
        /// </param>
        /// <param name="onError">
        /// A function that generates an <see cref="Error"/> object if the <paramref name="predicate"/> returns <c>false</c>.
        /// </param>
        /// <returns>
        /// A successful <see cref="Result"/> if the condition is met or the input <paramref name="result"/> is already a failure; 
        /// otherwise, a failure <see cref="Result"/> with the error generated by <paramref name="onError"/>.
        /// </returns>
        public static Result Ensure(this Result result, Func<bool> predicate, Func<Error> onError)
        {
            if (result.IsFailure)
            {
                return result;
            }

            if (predicate())
            {
                return result;
            }

            return Result.Failure(onError());
        }
    }
}
