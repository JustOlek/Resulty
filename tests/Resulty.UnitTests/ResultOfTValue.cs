using NUnit.Framework;
using Resulty.Errors;
using System;
using System.Collections.Generic;
namespace Resulty.UnitTests
{
    public class ResultOfTValue
    {
        [Test]
        public void FailedResult_ThrowInvalidOperationException()
        {
            var result = Result.Failure<object>(new Error("", 1));

            Assert.Throws<InvalidOperationException>(() =>
            {
                var value = result.Value;
            });
        }
    }
}
