using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using MVPAutomation.Data;
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
        [AllureName("Should Register user successfull")]
        public async Task ShouldRegisterUserSuccessfull()
        {
            var registerPage = new RegisterPage(_page, _actions);
            await registerPage.ClickOnRegisterButton();
            await registerPage.FillRegisterForm();
            await registerPage.ClickSubmitForm();
            await _validator.GetByTextToBeVisibleAsync("Your registration completed"
                , "Validate if success message is visible on screen of user");
        }
        [Test, Order(2)]
        [AllureName("Shouldn´t register user with name and last name empty")]
        public async Task ShouldntRegisterUserWithoutNameAndLastName()
        {
            var dataTest = new RegisterData
            {
                FirstsName = string.Empty,
                LastsName = string.Empty
            };
            var registerPage = new RegisterPage(_page, _actions, dataTest);
            await registerPage.ClickOnRegisterButton();
            await registerPage.FillRegisterForm();
            await registerPage.ClickSubmitForm();
            await _validator.GetByTextToBeVisibleAsync("First name is required."
                , "Validate if error message of first name is mandatory is visible on screen of user");
            await _validator.GetByTextToBeVisibleAsync("Last name is required."
                , "Validate if error message of last name is mandatory is visible on screen of user");
        }
        [Test, Order(3)]
        [AllureName("Shouldn´t Register User With Different Password")]
        public async Task ShouldntRegisterUserWithDifferentPassword()
        {
            var dataTest = new RegisterData
            {
                ConfirmPassword = "DiffPassword"
            };  
            var registerPage = new RegisterPage(_page, _actions, dataTest);
            await registerPage.ClickOnRegisterButton();
            await registerPage.FillRegisterForm();
            await registerPage.ClickSubmitForm();
            await _validator.GetByTextToBeVisibleAsync("First name is required."
                , "Validate if error message of first name is mandatory is visible on screen of user");
            await _validator.GetByTextToBeVisibleAsync("Last name is required."
                , "Validate if error message of last name is mandatory is visible on screen of user");
        }
    }
}

