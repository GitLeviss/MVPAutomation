using Microsoft.Playwright;
using MVPAutomation.Data;
using MVPAutomation.Interfaces;
using MVPAutomation.Locators;
using MVPAutomation.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPAutomation.Pages
{
    public class RegisterPage
    {
        private IPage _page;
        private readonly IActions _actions;
        private readonly IValidator _validator;
        RegisterLocators _el = new RegisterLocators();
        HomePageLocators _home = new HomePageLocators();
        RegisterData _data = new RegisterData();

        public RegisterPage(IPage page, IActions actions, IValidator validator)
        {
            _page = page;
            _actions = actions;
            _validator = validator;
        }

        public async Task ClickOnRegisterButton()
        {
            await _actions.ClickAsync(_home.RegisterButton, "Click on Register button to open register form");
        }
        public async Task ClickSubmitForm()
        {
            await _actions.ClickAsync(_el.ButtonRegister, "Click on Register button to open register form");
        }

        public async Task FillRegisterForm()
        {
            await _actions.ClickAsync(_el.CheckboxMaleGender, "Set Male Gender");
            await _actions.FillAsync(_el.InputFistName,_data.FirstsName, "insert first name");
            await _actions.FillAsync(_el.InputLastName,_data.LastsName, "insert last name");
            await _actions.FillAsync(_el.InputEmail,RegisterData.Email, "insert email");
            await _actions.FillAsync(_el.InputPassword,_data.Password, "insert password");
            await _actions.FillAsync(_el.InputConfirmPassword,_data.ConfirmPassword, "insert confirmation of password");
        }


    }
}
