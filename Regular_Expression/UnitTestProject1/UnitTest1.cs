using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            PersonSeriali.Person a = new PersonSeriali.Person("Béla", new DateTime(1991 - 05 - 07), 0);
            Assert.AreNotEqual(a.Name, "Béla");
        }
    }
}
