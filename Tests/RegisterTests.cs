using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using Microsoft.Playwright;
using MVPAutomation.Interfaces;
using MVPAutomation.Pages;
using MVPAutomation.Runner;
using MVPAutomation.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPAutomation.Tests
{
    [AllureOwner("Levi QA")]
    [AllureNUnit]
    [Parallelizable(ParallelScope.Self)]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureSuite("Register UI")]
    public class RegisterTests : TestBase
    {
        private IValidator _validator;

        [SetUp]
        [AllureBefore]
        public async Task Setup()
        {
            await OpenBrowserAsync();
            _validator = new Validators(_page);
        }

        [TearDown]
        [AllureAfter]
        public async Task Teardown()
        {
            await CloseBrowserAsync();
        }

        [Test, Order(1)]
        [AllureName("Deve registrar um usuário com sucessoDeve registrar um usuário com sucesso")]
        public async Task ShouldRegisterUserSuccessfull()
        {
            var registerPage = new RegisterPage(_page);            
            await registerPage.ClickOnRegisterButton();
            await registerPage.FillRegisterForm();
            await registerPage.ClickSubmitForm();
            await _validator.GetByTextToBeVisibleAsync("Your registration completed"
                , "Validate if success message is visible on screen of user");
        }




    }
}
