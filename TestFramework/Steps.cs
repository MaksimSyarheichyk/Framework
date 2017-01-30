using System.Collections.Generic;
using OpenQA.Selenium;
using TestFramework.PageObjects;

namespace TestFramework
{
    class Steps
    {
        public static List<JournalModel> Start()
        {
            return DataFromExcelFile.GetDataFromExcelFile();
        }
        
        public static void OpenJournal(string journalCode)
        {
            IWebDriver driver = WebDriver.Driver;
            driver.Navigate().GoToUrl(TestData.BaseUrl + journalCode);
        }

        public static bool CheckItem(NavigationModel navModel)
        {
            JournalPage page = new JournalPage();
            IWebElement category;
            try
            {
                if (navModel.Item == null)
                {
                    category = page.TryGetItem(navModel.Category, navModel.Category);
                    if (category.Text == navModel.Category)
                        return true;
                    else
                    {
                        WebDriver.TakeScreenshot(navModel.Category);
                        return false;
                    }
                }
                else
                {
                    category = page.GetCategory(navModel.Category);
                    category.Click();
                }
            }
            catch
            {
                WebDriver.TakeScreenshot(navModel.Category);
                return false;
            }
            try
            {
                IWebElement item = page.TryGetItem(navModel.Item, navModel.Category);
                if (item.Text == navModel.Item)
                {
                    category.Click();
                    return true;
                }
                else
                {
                    category.Click();
                    WebDriver.TakeScreenshot(navModel.Item);
                    return false;
                }
            }
            catch
            {
                WebDriver.TakeScreenshot(navModel.Item);
                return false;
            }
        }

        public static void End()
        {
            WebDriver.DriverCancel();
        }
    }
}
