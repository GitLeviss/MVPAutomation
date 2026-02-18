using Microsoft.Playwright;
using MVPAutomation.Data;
using MVPAutomation.Interfaces;
using MVPAutomation.Locators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPAutomation.Pages
{
    public class LoginPage : BasePage
    {
        HomePageLocators _home = new HomePageLocators();
        LoginLocators _login = new LoginLocators();
        LoginData _data = new LoginData();
        public LoginPage(IPage page, IActions actions, LoginData data = null) : base(page, actions)
        {
            _data = data ?? new LoginData();
        }
    
    
        public async Task DoLogin()
        {
            await _actions.ClickAsync(_home.LogInButton, "Click on login Button to fill credentials");
            await _actions.FillAsync(_login.EmailField, _data.Email, "Insert email on email input");
            await _actions.FillAsync(_login.PasswordField, _data.Password, "Insert passwrod on email password");
            await _actions.ClickAsync(_login.LoginButton, "Submit Login");
        }

    }

}
