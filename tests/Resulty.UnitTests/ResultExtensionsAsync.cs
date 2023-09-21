using NUnit.Framework;

namespace Resulty.UnitTests
{
    public class ResultThenExtensions
    {
        [Test]
        public async Task SuccessTyped_ReturnSuccessBaseAsync()
        {
            Result result = await CreateSuccessTypedResultAsync()
                .ThenAsync(SuccessFromTypedToBaseAsync);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.IsSuccess, Is.True);
            });
        }

        [Test]
        public async Task SuccessBase_ReturnSuccessTypedAsync()
        {
            Result<object> result = await CreateSuccessBaseResultAsync()
                .ThenAsync(SuccessFromBaseToTypedAsync);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.IsSuccess, Is.True);
            });
        }

        [Test]
        public async Task SuccessBase_ReturnSuccessBaseAsync()
        {
            Result result = await CreateSuccessBaseResultAsync()
                .ThenAsync(SuccessFromBaseToBaseAsync);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.IsSuccess, Is.True);
            });
        }

        [Test]
        public async Task SuccessTyped_ReturnSuccessTypedAsync()
        {
            Result<object> result = await CreateSuccessTypedResultAsync()
                .ThenAsync(SuccessFromTypedToTypedAsync);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.IsSuccess, Is.True);
            });
        }

        [Test]
        public async Task FailedTyped_ReturnFailedBaseAsync()
        {
            Result result = await CreateSuccessTypedResultAsync()
                .ThenAsync(FailureFromTypedToTypedAsync)
                .ThenAsync(SuccessFromTypedToBaseAsync);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.IsSuccess, Is.False);
            });
        }

        [Test]
        public async Task FailedBase_ReturnFailedTypedAsync()
        {
            Result<object> result = await CreateSuccessBaseResultAsync()
                .ThenAsync(FailureFromBaseToBaseAsync)
                .ThenAsync(SuccessFromBaseToTypedAsync);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.IsSuccess, Is.False);
            });
        }

        [Test]
        public async Task FailedBase_ReturnFailedBaseAsync()
        {
            Result result = await CreateSuccessBaseResultAsync()
                .ThenAsync(FailureFromBaseToBaseAsync)
                .ThenAsync(SuccessFromBaseToBaseAsync);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.IsSuccess, Is.False);
            });
        }

        [Test]
        public async Task FailedTyped_ReturnFailedTypedAsync()
        {
            Result<object> result = await CreateSuccessTypedResultAsync()
                .ThenAsync(FailureFromTypedToTypedAsync)
                .ThenAsync(SuccessFromTypedToTypedAsync);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.IsSuccess, Is.False);
            });
        }

        [Test]
        public async Task SuccessThenWithTransformAsync()
        {
            Result<string> result = await CreateSuccessIntegerResultAsync()
                .ThenWithTransformAsync(SuccessFromIntToStringAsync);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.IsSuccess, Is.True);
            });
        }

        [Test]
        public async Task FailedThenWithTransformAsync()
        {
            Result<string> result = await CreateSuccessIntegerResultAsync()
                .ThenWithTransformAsync(FailureFromIntToStringAsync);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.IsSuccess, Is.False);
            });
        }

        [Test]
        public async Task MapBaseResultAsync()
        {
            int result = await CreateSuccessBaseResultAsync()
                .MapAsync(() => 0, err => -1);

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public async Task MapTypedResultAsync()
        {
            int result = await CreateSuccessTypedResultAsync()
                .MapAsync(res => 0, err => -1);

            Assert.That(result, Is.EqualTo(0));
        }


        private static async Task<Result<int>> CreateSuccessIntegerResultAsync()
        {
            return await Task.FromResult(Result.Success(0));
        }

        private static async Task<Result<string>> SuccessFromIntToStringAsync(int value)
        {
            return await Task.FromResult(Result.Success(""));
        }

        private static async Task<Result<string>> FailureFromIntToStringAsync(int value)
        {
            return await Task.FromResult(Result.Failure<string>(new()));
        }

        private static async Task<Result<object>> CreateSuccessTypedResultAsync()
        {
            return await Task.FromResult(Result.Success(new object()));
        }

        private static async Task<Result> CreateSuccessBaseResultAsync()
        {
            return await Task.FromResult(Result.Success());
        }

        private static async Task<Result<object>> SuccessFromBaseToTypedAsync()
        {
            return await Task.FromResult(Result.Success(new object()));
        }

        private async static Task<Result> SuccessFromTypedToBaseAsync(object value)
        {
            return await Task.FromResult(Result.Success());
        }

        private async static Task<Result> SuccessFromBaseToBaseAsync()
        {
            return await Task.FromResult(Result.Success());
        }

        private async static Task<Result<object>> SuccessFromTypedToTypedAsync(object value)
        {
            return await Task.FromResult(Result.Success(new object()));
        }

        private static async Task<Result<object>> FailureFromBaseToTypedAsync()
        {
            return await Task.FromResult(Result.Failure<object>(new()));
        }

        private async static Task<Result> FailureFromTypedToBaseAsync(object value)
        {
            return await Task.FromResult(Result.Failure(new()));
        }

        private async static Task<Result> FailureFromBaseToBaseAsync()
        {
            return await Task.FromResult(Result.Failure(new()));
        }

        private async static Task<Result<object>> FailureFromTypedToTypedAsync(object value)
        {
            return await Task.FromResult(Result.Failure<object>(new()));
        }
    }
}
