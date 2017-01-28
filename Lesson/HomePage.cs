using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace ClassLibrary1
{
    public class HomePage
    {
        public IWebElement LoginInput { get { return WebDriver.Driver.FindElement(By.XPath("//*[contains(@id, 'txt_UserName')]")); }}
        public IWebElement PasswordInput { get { return WebDriver.Driver.FindElement(By.XPath("//*[contains(@id, 'txt_Password')]")); } }
        public IWebElement LoginButton { get { return WebDriver.Driver.FindElement(By.XPath("//*[contains(@id, 'LoginButton')]")); } }

        public HomePage()
        {

        }

        public void Login(string user, string pasw)
        {
            LoginInput.SendKeys(user);
            PasswordInput.SendKeys(pasw);
            LoginButton.Click();
        }

        public void NavigateHere()
        {
            WebDriver.Driver.Navigate().GoToUrl("http://journals.lww.com/pages/default.aspx");
        }

    }
}
