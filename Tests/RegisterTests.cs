using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using MVPAutomation.Pages;

namespace MVPAutomation.Tests
{
    [AllureOwner("Levi QA")]
    [AllureNUnit]
    [Parallelizable(ParallelScope.Self)]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureSuite("Register UI")]
    public class RegisterTests : BaseTest
    {
        [Test, Order(1)]
        [AllureName("Deve registrar um usuário com sucessoDeve registrar um usuário com sucesso")]
        public async Task ShouldRegisterUserSuccessfull()
        {
            var registerPage = new RegisterPage(_page, _actions);
            await registerPage.ClickOnRegisterButton();
            await registerPage.FillRegisterForm();
            await registerPage.ClickSubmitForm();
            await _validator.GetByTextToBeVisibleAsync("Your registration completed"
                , "Validate if success message is visible on screen of user");
        }
    }
}

