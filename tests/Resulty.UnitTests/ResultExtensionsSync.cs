using NUnit.Framework;

namespace Resulty.UnitTests
{
    public class ResultExtensionsSync
    {
        [Test]
        public void SuccessTyped_ReturnSuccessBase()
        {
            Result result = CreateSuccessTypedResult()
                .Then(SuccessFromTypedToBase);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.IsSuccess, Is.True);
            });
        }

        [Test]
        public void SuccessBase_ReturnSuccessTyped()
        {
            Result<object> result = CreateSuccessBaseResult()
                .Then(SuccessFromBaseToTyped);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.IsSuccess, Is.True);
            });
        }

        [Test]
        public void SuccessBase_ReturnSuccessBase()
        {
            Result result = CreateSuccessBaseResult()
                .Then(SuccessFromBaseToBase);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.IsSuccess, Is.True);
            });
        }

        [Test]
        public void SuccessTyped_ReturnSuccessTyped()
        {
            Result<object> result = CreateSuccessTypedResult()
                .Then(SuccessFromTypedToTyped);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.IsSuccess, Is.True);
            });
        }

        [Test]
        public void FailedTyped_ReturnFailedBase()
        {
            Result result = CreateSuccessTypedResult()
                .Then(FailureFromTypedToTyped)
                .Then(SuccessFromTypedToBase);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.IsSuccess, Is.False);
            });
        }

        [Test]
        public void FailedBase_ReturnFailedTyped()
        {
            Result<object> result = CreateSuccessBaseResult()
                .Then(FailureFromBaseToBase)
                .Then(SuccessFromBaseToTyped);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.IsSuccess, Is.False);
            });
        }

        [Test]
        public void FailedBase_ReturnFailedBase()
        {
            Result result = CreateSuccessBaseResult()
                .Then(FailureFromBaseToBase)
                .Then(SuccessFromBaseToBase);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.IsSuccess, Is.False);
            });
        }

        [Test]
        public void FailedTyped_ReturnFailedTyped()
        {
            Result<object> result = CreateSuccessTypedResult()
                .Then(FailureFromTypedToTyped)
                .Then(SuccessFromTypedToTyped);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.IsSuccess, Is.False);
            });
        }

        [Test]
        public void SuccessThenWithTransform()
        {
            Result<string> result =  CreateSuccessIntegerResult()
                .ThenWithTransform(SuccessFromIntToString);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.IsSuccess, Is.True);
            });
        }

        [Test]
        public void FailedThenWithTransform()
        {
            Result<string> result =  CreateSuccessIntegerResult()
                .ThenWithTransform(FailureFromIntToString);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.IsSuccess, Is.False);
            });
        }

        [Test]
        public void MapBaseResult()
        {
            int result = CreateSuccessBaseResult()
                .Map(() => 0, err => -1);

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void MapTypedResultAsync()
        {
            int result = CreateSuccessTypedResult()
                .Map(res => 0, err => -1);

            Assert.That(result, Is.EqualTo(0));
        }

        private static Result<int> CreateSuccessIntegerResult()
        {
            return Result.Success(0);
        }

        private static Result<string> SuccessFromIntToString(int value)
        {
            return Result.Success("");
        }

        private static Result<string> FailureFromIntToString(int value)
        {
            return Result.Failure<string>(new());
        }

        private static Result<object> CreateSuccessTypedResult()
        {
            return Result.Success(new object());
        }

        private static Result CreateSuccessBaseResult()
        {
            return Result.Success();
        }

        private static Result<object> SuccessFromBaseToTyped()
        {
            return Result.Success(new object());
        }

        private static Result SuccessFromTypedToBase(object value)
        {
            return Result.Success();
        }

        private static Result SuccessFromBaseToBase()
        {
            return Result.Success();
        }

        private static Result<object> SuccessFromTypedToTyped(object value)
        {
            return Result.Success(new object());
        }

        private static Result<object> FailureFromBaseToTyped()
        {
            return Result.Failure<object>(new());
        }

        private static Result FailureFromTypedToBase(object value)
        {
            return Result.Failure(new());
        }

        private static Result FailureFromBaseToBase()
        {
            return Result.Failure(new());
        }

        private static Result<object> FailureFromTypedToTyped(object value)
        {
            return Result.Failure<object>(new());
        }
    }
}
