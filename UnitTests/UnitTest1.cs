using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Faker;
using System.IO;
using System.Reflection;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        private TestClass1 testable;

        [TestInitialize]
        public void SetUp()
        {
            testable = Faker.Faker.Create<TestClass1>();
        }

        [TestMethod]
        public void TestString()
        {
            Assert.IsNotNull(testable.val1);
        }
    }
}
