using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPAutomation.interfaces
{
    public interface IActions
    {
        Task FillAsync(string locator, string text, string step);
        Task ClickAsync(string locator, string step);
        Task ChooseSelectorAsync(string locator, string option, string step);
    }
}
