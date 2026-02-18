using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using MVPAutomation.Data;
using MVPAutomation.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPAutomation.Tests
{
    [AllureOwner("Levi QA")]
    [AllureNUnit]
    [Parallelizable(ParallelScope.Self)]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureSuite("Login UI")]
    public class LoginTests : BaseTest
    {
        [Test, Order(1)]
        [AllureName("Should do login successfull")]
        public async Task ShouldDoLoginSuccessfull()
        {
            var login = new LoginPage(_page, _actions);
            await login.DoLogin();
            await _validator.GetByTextToBeVisibleAsync("teste006@email.com"
                , "Validate if user email is visible on screen");
        }
        [Test, Order(2)]
        [AllureName("Shouldn´t do login with empty fields")]
        public async Task ShouldntDoLoginWithEmptyFields()
        {
            var dataTest = new LoginData
            {
                Email = string.Empty,
                Password = string.Empty
            };
            var login = new LoginPage(_page, _actions, dataTest);
            await login.DoLogin();
            await _validator.GetByTextToBeVisibleAsync("Login was unsuccessful. Please correct the errors and try again."
                , "Validate if Error message is visible on screen");
            await _validator.GetByTextToBeVisibleAsync("No customer account found"
                , "Validate if Error message is visible on screen");
        }
        [Test, Order(3)]
        [AllureName("Shouldn´t do login with invalid Email")]
        public async Task ShouldntDoLoginWithInvalidEmail()
        {
            var dataTest = new LoginData
            {
                Email = "emailteste.com"                
            };
            var login = new LoginPage(_page, _actions, dataTest);
            await login.DoLogin();
            await _validator.GetByTextToBeVisibleAsync("Please enter a valid email address."
                , "Validate if Error message is visible on screen");
        }
        [Test, Order(4)]
        [AllureName("Shouldn´t do login with invalid Password")]
        public async Task ShouldntDoLoginWithInvalidPassword()
        {
            var dataTest = new LoginData
            {
                Password = "invalid"                
            };
            var login = new LoginPage(_page, _actions, dataTest);
            await login.DoLogin();
            await _validator.GetByTextToBeVisibleAsync("The credentials provided are incorrect"
                , "Validate if Error message is visible on screen");
        }
        [Test, Order(5)]
        [AllureName("Shouldn Fail Test!")]
        public void FailTest()
        {
            Assert.Fail("Example of fail test");
        }


    }
}
