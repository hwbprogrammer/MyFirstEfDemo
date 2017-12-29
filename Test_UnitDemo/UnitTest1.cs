using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyFirstEF.Service;

namespace Test_UnitDemo
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.IsTrue(ProductService.GetSun(10)==55);
        }
    }
}
