using System.IO;
using NUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    [TestClass]
    public class MyTestClass
    {
        [TestMethod]
        public void MyTestMethod()
        {
            var homePage = new HomePage();
            homePage.NavigateHere();
            homePage.Login("avkozlov_by", "Minsk2017");
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            WebDriver.KillDriver();
        }
    }

    [TestFixture]
    public class MyTestClass2
    {
        [Test]
        [NUnit.Framework.Ignore("123")]
        public void MyTestMethod(string a)
        {
            var homePage = new HomePage();
            homePage.NavigateHere();
            homePage.Login("avkozlov_by", "Minsk2017");
        }

        [TestFixtureTearDown]
        public static void Cleanup()
        {
            WebDriver.KillDriver();
        }
    }
}
