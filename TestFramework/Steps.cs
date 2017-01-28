using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using TestFramework.PageObjects;

namespace TestFramework
{
    class Steps
    {
        private static List<JournalModel> data;

        public static List<JournalModel> Start()
        {
            return data = DataFromExcelFile.GetDataFromExcelFile();
        }

        public static bool Check(JournalModel model)
        {
            OpenJournal(model.JournalCode);
            foreach(var a in model.Navigation)
            {
                if (!CheckItem(a))
                {
                    return false;
                }
            }
            return true;
        }

        private static void OpenJournal(string journalCode)
        {
            IWebDriver driver = WebDriver.Driver;
            driver.Navigate().GoToUrl("http://journals.lww.com/" + journalCode);
        }

        private static bool CheckItem(NavigationModel navModel)
        {
            JournalPage page = new JournalPage();
            IWebElement category;
            try
            {
                category = page.GetCategory(navModel.Category);
                category.Click();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            if (navModel.Item != "")
            {
                IWebElement item = page.TryGetItem(navModel.Item);
                if ((item != null) && (item.Text == navModel.Item))
                {
                    category.Click();
                    return true;
                }
                else
                {
                    category.Click();
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
    }
}
