using NUnit.Framework;
using Resulty.Errors;

namespace Resulty.UnitTests
{
    public class ResultConstructor
    {

        [Test]
        public void WithSuccessAndNotNullError_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => BrokenResult.WithSuccessAndError());
        }
    }

    public class BrokenResult : Result
    {
        private BrokenResult(bool isSuccess, Error error) : base(isSuccess, error)
        {
        }

        public static BrokenResult WithSuccessAndError() => new(true, new Error("", 1));
    }
}