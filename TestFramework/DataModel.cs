using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFramework
{
    public struct JournalModel
    {
        public string JournalCode;
        public List<NavigationModel> Navigation;
    }
         

    public struct NavigationModel
    {
        public string Category;
        public string Item;
    }
}
