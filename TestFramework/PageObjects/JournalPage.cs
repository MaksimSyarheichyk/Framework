using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace TestFramework.PageObjects
{
    class JournalPage
    {
        By category = By.ClassName(TestData.CategoryPath);
        By item = By.ClassName(TestData.ItemPath);

        public IWebElement GetCategory(string categoryName)
        {
            //WebDriver.waitForElement(category, 15);
            List<IWebElement> elements = WebDriver.Driver.FindElements(category).ToList();
            try
            {
                IWebElement element = elements.Single(i => i.Text == categoryName);
                return element;
            }
            catch
            {
                WebDriver.TakeScreenshot(categoryName);
            }
            return null; 
        }
                
        public IWebElement TryGetItem(string itemName, string cat)
        {
           // WebDriver.waitForElement(item, 15);
            List <IWebElement> elements = WebDriver.Driver.FindElements(item).ToList();
            try
            {
                IWebElement element = elements.Single(i => i.Text == itemName);
                return element;
            }
            catch
            {
                WebDriver.TakeScreenshot(itemName);
            }
            return null;
        }

    }
}
