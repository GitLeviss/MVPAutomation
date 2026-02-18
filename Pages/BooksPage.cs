using Microsoft.Playwright;
using MVPAutomation.Interfaces;
using MVPAutomation.Locators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPAutomation.Pages
{
    public class BooksPage : BasePage
    {

        HomePageLocators _home = new HomePageLocators();
        BooksLocatos _books = new BooksLocatos();

        public BooksPage(IPage page, IActions actions) : base(page, actions)
        {
        }


        public async Task AddBookOnCart()
        {
            await _actions.ClickAsync(_home.BooksButton, "Click on books to expando books options");
            await _actions.ClickAsync(_books.BookOption, "Click on Book \"Computing and Internet option\" to add on cart");
        }



    }
}
