using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TestFramework
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void Test()
        {
            List<JournalModel> a = DataFromExcelFile.GetDataFromExcelFile();
            List<string> d = new List<string>();

            foreach(var b in a)
            {
                foreach(var c in b.Navigation)
                {
                    d.Add(b.JournalCode + " - " + c.Category + " " + c.Item);
                }
            }
            File.WriteAllLines("out.txt", d.ToArray());

        }
    }
}
