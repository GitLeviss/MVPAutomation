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
    public class ShoppingCartPage : BasePage
    {
        HomePageLocators _home = new HomePageLocators();
        BooksLocatos _books = new BooksLocatos();
        ShoppingCartLocators _shop = new ShoppingCartLocators();
        public ShoppingCartPage(IPage page, IActions actions) : base(page, actions){}


        public async Task OpenShoppingCart()
        {
            await _actions.ClickAsync(_home.ShoppingCartButton, "Click on shopping cart to go to shopping cart page");
        }

        public async Task AgreeWithTerms()
        {
            await _actions.ClickAsync(_shop.TermsCheckbox, "Agree with terms and conditions");
        }
        public async Task ClickOnCheckout()
        {
            await _actions.ClickAsync(_shop.CheckoutButton, "Click on checkout");
        }
        public async Task ClickOnContinueBillingAdress()
        {
            await _actions.ClickAsync(_shop.ContinueBillingAdress, "Click on Continue Billing Adress");
        }
        public async Task ClickOnContinueShippingAdress()
        {
            await _actions.ClickAsync(_shop.ContinueShippingAdress, "Click on Continue Shipping Adress");
        }
        public async Task ClickOnContinueShippingMethod()
        {
            await _actions.ClickAsync(_shop.ContinueShippingMethod, "Click on Continue Shipping Method");
        }
        public async Task ClickOnContinuePaymentMethod()
        {
            await _actions.ClickAsync(_shop.ContinuePaymentMethod, "Click on Continue Payment Method");
        }
        public async Task ClickOnContinuePaymentInfo()
        {
            await _actions.ClickAsync(_shop.ContinuePaymentInfo, "Click on Continue Payment Info");
        }
        public async Task ClickOnButtonToConfirmOrder()
        {
            await _actions.ClickAsync(_shop.ButtonConfirmOrder, "Click on Button Confirm Order");
        }




    }
}
