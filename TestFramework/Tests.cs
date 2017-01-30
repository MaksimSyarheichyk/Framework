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
        public void Test(JournalModel a)
        {
            Steps.OpenJournal(a.JournalCode);
            foreach (var b in a.Navigation)
            {
                string message = string.Format("Fail for Journal: {0}\nCategory: {1}\nItem: {2}\nPlease, check! ", a.JournalCode, b.Category, b.Item);
                Assert.True(Steps.CheckItem(b), message);
            }
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            Steps.End();
        }
    }
}
