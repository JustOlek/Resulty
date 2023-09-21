using NUnit.Framework;
namespace Resulty.UnitTests
{
    public class ResultMisc
    {
        [Test]
        public void GetValueFromFailedResult_ThrowInvalidOperationException()
        {
            var result = Result.Failure<object>(new Error());

            Assert.Throws<InvalidOperationException>(() =>
            {
                var value = result.Value;
            });
        }
    }
}
