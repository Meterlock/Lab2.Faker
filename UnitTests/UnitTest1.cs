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

        [TestMethod]
        public void TestBool()
        {
            Assert.IsTrue(testable.val2);
        }

        [TestMethod]
        public void TestByte()
        {
            Assert.AreNotEqual(0, testable.val3);
        }

        [TestMethod]
        public void TestChar()
        {
            Assert.AreNotEqual('\0', testable.val4);
        }

        [TestMethod]
        public void TestDateTime()
        {
            DateTime expected = new DateTime();
            Assert.AreNotEqual(expected, testable.val5);
        }

        [TestMethod]
        public void TestDouble()
        {
            Assert.AreNotEqual(0, testable.val6);
        }

        [TestMethod]
        public void TestFloat()
        {
            Assert.AreNotEqual(0, testable.val7);
        }

        [TestMethod]
        public void TestInt()
        {
            Assert.AreNotEqual(0, testable.val8);
        }

        [TestMethod]
        public void TestLong()
        {
            Assert.AreNotEqual(0, testable.val9);
        }

        [TestMethod]
        public void TestList()
        {
            Assert.IsNotNull(testable.val10);
        }

        [TestMethod]
        public void TestCycling()
        {
            Assert.IsNull(testable.val11.val1);
        }

        [TestMethod]
        public void TestConstructor()
        {
            TestClass3 class3 = Faker.Faker.Create<TestClass3>();
            Assert.AreNotEqual(0, class3.val1);
            Assert.IsNotNull(class3.val2);
            Assert.IsTrue(class3.val3);
        }
    }
}
