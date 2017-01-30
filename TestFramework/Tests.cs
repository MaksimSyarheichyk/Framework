using NUnit.Framework;
using System.Collections.Generic;

namespace TestFramework
{
    [TestFixture]
    public class Tests
    {
        static List<JournalModel> Batch { get { return Steps.Start(); } }

        [Test]
        [TestCaseSource("Batch")]
        public void Test(JournalModel jourModel)
        {
            Steps.OpenJournal(jourModel.JournalCode);
            foreach (var navModel in jourModel.Navigation)
            {
                string message = string.Format("Fail for Journal: {0}\nCategory: {1}\nItem: {2}\nPlease, check! ", jourModel.JournalCode, navModel.Category, navModel.Item);
                Assert.True(Steps.CheckItem(navModel), message);
            }
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            Steps.End();
        }
    }
}
