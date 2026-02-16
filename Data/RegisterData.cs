using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPAutomation.Data
{
    public class RegisterData
    {

        public string FirstsName { get; set; } = "User";
        public string LastsName { get; set; } = "Test " + new Random().Next(0, 9999);
        public static string Email { get; set; } = "email" + new Random().Next(0, 9999) + "@teste.com";
        public string Password { get; } = "Test@123";
        public string ConfirmPassword { get; } = "Test@123";


    }
}
