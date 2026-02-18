using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPAutomation.Locators
{
    public class LoginLocators
    {
        public string EmailField { get; } = "#Email";
        public string PasswordField { get; } = "#Password";
        public string LoginButton { get; } = "//input[@class='button-1 login-button']";

    }
}
