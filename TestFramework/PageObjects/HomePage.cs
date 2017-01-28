using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TestFramework.PageObjects
{
    class HomePage
    {
        public IWebElement searchInput { get { return WebDriver.Driver.FindElement(By.XPath("//*[contains(@id, 'SearchBox_txtKeywords')]")); } }
        public IWebElement searchButton { get { return WebDriver.Driver.FindElement(By.XPath("//*[contains(@id, 'btnGlobalSearchMagnifier")); } }

        public HomePage(){ }
    }
}
