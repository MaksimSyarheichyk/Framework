using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace TestFramework
{
    public class WebDriver
    {
        private WebDriver() { }

        private static IWebDriver driver;

        public static IWebDriver Driver
        {
            get
            {
                if (driver==null)
                {
                    driver = new ChromeDriver(TestData.ChromeDriverPath);
                    driver.Manage().Window.Maximize();
                }

                return driver;
            }
        }

    }
}
