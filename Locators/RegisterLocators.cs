using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPAutomation.Locators
{
    public class RegisterLocators
    {

        public string CheckboxMaleGender { get; } = "#gender-male";
        public string InputFistName { get; } = "#FirstName";
        public string InputLastName { get; } = "#LastName";
        public string InputEmail { get; } = "#Email";
        public string InputPassword { get; } = "#Password";
        public string InputConfirmPassword { get; } = "#ConfirmPassword";
        public string ButtonRegister { get; } = "#register-button";

        //div[normalize-space(text())='Your registration completed']


    }
}
