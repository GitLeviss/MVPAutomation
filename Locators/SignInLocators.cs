using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPAutomation.Locators
{
    public class SignInLocators
    {
        protected string EmailField { get; } = "//span[normalize-space(text())='User Name']/../..//input[@id='idToken1']";
        protected string PasswordField { get; } = "//span[normalize-space(text())='Password']/../..//input[@id='idToken2']";
        protected string LoginButton { get; } = "#loginButton_0";

    }
}
