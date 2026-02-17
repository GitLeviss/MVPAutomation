using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPAutomation.Locators
{
    public class BooksLocatos
    {
        public string BookOption { get; } = "//a[normalize-space(text())='Computing and Internet']/../..//input";
        //p[normalize-space(text())='The product has been added to your']
    }
}
