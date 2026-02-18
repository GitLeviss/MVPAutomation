using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPAutomation.Locators
{
    public class ShoppingCartLocators
    {
        public string TermsCheckbox { get; } = "//input[@id='termsofservice']";
        public string CheckoutButton { get; } = "//button[@id='checkout']";
        public string ContinueBillingAdress { get; } = "//div[@id='billing-buttons-container']//input";
        public string ContinueShippingAdress { get; } = "//div[@id='shipping-buttons-container']//input";
        public string ContinueShippingMethod { get; } = "//div[@id='shipping-method-buttons-container']//input";
        public string ContinuePaymentMethod { get; } = "//div[@id='payment-method-buttons-container']//input";
        public string ContinuePaymentInfo { get; } = "//div[@id='payment-info-buttons-container']//input";
        public string ButtonConfirmOrder { get; } = "//div[@id='confirm-order-buttons-container']//input";

        

    }
}
