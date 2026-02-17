using Microsoft.Playwright;
using MVPAutomation.Interfaces;
using MVPAutomation.Utils;

namespace MVPAutomation.Pages
{
    public abstract class BasePage : IPageBase
    {
        protected readonly IPage _page;
        protected readonly IActions _actions;

        public IActions Actions => _actions;

        protected BasePage(IPage page, IActions actions)
        {
            _page = page;
            _actions = actions;
        }
    }
}
