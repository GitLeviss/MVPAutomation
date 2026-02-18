using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using MVPAutomation.Pages;

namespace MVPAutomation.Tests
{
    [AllureOwner("Levi QA")]
    [AllureNUnit]
    [Parallelizable(ParallelScope.Self)]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureSuite("Shopping Cart UI")]
    public class ShoppingCartTests : BaseTest
    {

        LoginPage _login;

        [SetUp, Order(2)]
        public async Task DoLogin()
        {
            _login = new LoginPage(_page,_actions);
            await _login.DoLogin();
        }

        [Test, Order(1)]
        [AllureName("Should realize shopping successful")]
        public async Task ShouldDoBuySuccessfull()
        {
            var books = new BooksPage(_page, _actions);
            var shoppingCart = new ShoppingCartPage(_page, _actions);
            await books.AddBookOnCart();
            await _validator.GetByTextToBeVisibleAsync("The product has been added to your"
                , "Validate if success message is visible to user");
            await shoppingCart.OpenShoppingCart();
            await shoppingCart.AgreeWithTerms();
            await shoppingCart.ClickOnCheckout();
            await shoppingCart.ClickOnContinueBillingAdress();
            await shoppingCart.ClickOnContinueShippingAdress();
            await shoppingCart.ClickOnContinueShippingMethod();
            await shoppingCart.ClickOnContinuePaymentMethod();
            await shoppingCart.ClickOnContinuePaymentInfo();
            await shoppingCart.ClickOnButtonToConfirmOrder();
            await _validator.GetByTextToBeVisibleAsync("Your order has been successfully processed!"
                , "Validate if success message is visible to user");
        }


    }
}
