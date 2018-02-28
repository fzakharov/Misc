using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace PtRpg.Tests.Unit
{
    [TestFixture]
    public class UnitTest1
    {

        [Test]
        public void TestMethod1()
        {
            var dep = Mock.Of<IInterface>();

            dep.Should().NotBeNull();
        }
    }
}
