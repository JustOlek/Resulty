using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resulty.UnitTests
{
    public class ResultFactoryMethods
    {
        [Test]
        public void SuccessfulResult_IsSuccessTrueAndErrorIsNull()
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
        public void FailedResult_IsSuccessFalseAndErrorIsNotNull()
        {
            var result = Result.Failure(new("", 0));

            Assert.Multiple(() =>
            {
                Assert.That(result.IsSuccess, Is.False);
                Assert.That(result.IsFailure, Is.True);
                Assert.That(result.Error, Is.Not.Null);
            });
        }
    }
}
