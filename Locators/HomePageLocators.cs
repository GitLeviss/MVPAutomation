using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPAutomation.Locators
{
    public class HomePageLocators
    {

        public string LogInButton { get; } = "//a[normalize-space(text())='Log in']";
        public string RegisterButton { get; } = "//a[normalize-space(text())='Register']";
        public string ShoppingCartButton { get; } = "//span[normalize-space(text())='Shopping cart']";
        public string WishlistButton { get; } = "//span[normalize-space(text())='Wishlist']";
        public string BooksButton { get; } = "//ul[@class='top-menu']//a[@href='/books']";


    }
}
