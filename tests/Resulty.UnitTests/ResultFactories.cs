using NUnit.Framework;

namespace Resulty.UnitTests
{
    public class ResultFactories
    {
        [Test]
        public void Success_IsSuccessTrueAndErrorIsNull()
        {
            var result = Result.Success();
            
            Assert.Multiple(() =>
            {
                Assert.That(result.IsSuccess, Is.True);
                Assert.That(result.IsFailure, Is.False);
                Assert.That(result.Error, Is.Null);
            });
        }

        [Test]
        public void Failure_IsSuccessFalseAndErrorIsNotNull()
        {
            var result = Result.Failure(new("", 0));

            Assert.Multiple(() =>
            {
                Assert.That(result.IsSuccess, Is.False);
                Assert.That(result.IsFailure, Is.True);
                Assert.That(result.Error, Is.Not.Null);
            });
        }

        [Test]
        public void SuccessWithNullValue_IsSucessTrueAndValueIsNull()
        {
            var result = Result.Success<object>(null);

            Assert.Multiple(() =>
            {
                Assert.That(result.IsSuccess, Is.True);
                Assert.That(result.IsFailure, Is.False);
                Assert.That(result.Error, Is.Null);
                Assert.That(result.Value, Is.Null);
            });
        }

        [Test]
        public void SuccessWithValue_IsSucessTrueAndValueNotNull()
        {
            var result = Result.Success<object>("");

            Assert.Multiple(() =>
            {
                Assert.That(result.IsSuccess, Is.True);
                Assert.That(result.IsFailure, Is.False);
                Assert.That(result.Error, Is.Null);
                Assert.That(result.Value, Is.Not.Null);
            });
        }
    }
}
