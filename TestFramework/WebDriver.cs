using System;
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
                if (driver == null)
                {
                    driver = new ChromeDriver(TestData.ChromeDriverPath);
                    driver.Manage().Window.Maximize();
                }

                return driver;
            }
        }

        public static void DriverCancel()
        {
            driver.Quit();
            driver = null;
        } 

        public static void TakeScreenshot(string name)
        {
            Screenshot screen = ((ITakesScreenshot)WebDriver.Driver).GetScreenshot();
            string fileName = string.Format("{0}{1}",DateTime.Now.ToLongTimeString().Replace(':', '.'), name);
            string path = string.Format("{0}{1}{2}", TestData.ScreenshotFolderPath,fileName,TestData.ScreenshotFilesExtention);
            screen.SaveAsFile(path, System.Drawing.Imaging.ImageFormat.Jpeg);
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
                TakeScreenshot(element.ToString());
            }
        }

    }
}
