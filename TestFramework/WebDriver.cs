using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

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

        public static void waitForElement(By element, int timeOut)
        {
            try
            {
                WebDriverWait waiter = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOut));
                waiter.Until(ExpectedConditions.ElementIsVisible(element));
            }
            catch
            {
                Screenshot screen = ((ITakesScreenshot)WebDriver.Driver).GetScreenshot();
                screen.SaveAsFile("C:/Users/Maksim_Siarheichyk/screen.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }

    }
}
