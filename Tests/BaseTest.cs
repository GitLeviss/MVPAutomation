using Allure.NUnit.Attributes;
using Microsoft.Playwright;
using MVPAutomation.Interfaces;
using MVPAutomation.Runner;
using MVPAutomation.Utils;

namespace MVPAutomation.Tests
{
    public abstract class BaseTest : TestBase, IBaseTest
    {
        protected IValidator _validator;
        protected IActions _actions;

        public IValidator Validator => _validator;

        [SetUp]
        [AllureBefore]
        public async Task BaseSetup()
        {
            await OpenBrowserAsync();
            _validator = new Validators(_page);
            _actions = new Actions(_page);
        }

        [TearDown]
        [AllureAfter]
        public async Task BaseTeardown()
        {
            await CloseBrowserAsync();
        }
    }
}
