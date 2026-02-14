using Allure.NUnit.Attributes;
using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using MVPAutomation.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPAutomation.utils
{
    public class Validator : IValidator
    {
        private readonly IValidator _validator;
        private readonly IPage _page;

        public Validator(IPage page, IValidator validator)
        {
            this._page = page;
            this._validator = validator;
        }

        [AllureStep("Validate Url - on step: {step}")]
        public async Task ValidateUrl(string expectedUrl, string step)
        {
            try
            {
                await _page.WaitForURLAsync(expectedUrl);
                await Expect(_page).ToHaveURLAsync(expectedUrl);
            }
            catch (Exception ex)
            {
                throw new PlaywrightException($"Don´t possible validate expected Url: '{expectedUrl}' on step: '{step}'. Details: {ex.Message}");
            }
        }

        [AllureStep("Validate Message of Locator returned is visible - on step: {step}")]
        public async Task LocatorToBeVisibleAsync(string locator, string step)
        {
            try
            {
                await _page.WaitForSelectorAsync(locator, new PageWaitForSelectorOptions
                {
                    State = WaitForSelectorState.Visible
                });
                await Expect(_page.Locator(locator)).ToBeVisibleAsync();
            }
            catch (Exception ex)
            {
                throw new PlaywrightException($"Don´t possible validate/found the element:'{locator}' on step: '{step}'. Details: {ex.Message}");
            }
        }

        [AllureStep("Validate locator to have text - on step: {step}")]
        public async Task LocatorToHaveTextAsync(string locator, string expectedText, string step)
        {
            try
            {
                ILocator element = _page.Locator(locator);
                await Expect(element).ToHaveTextAsync(expectedText);
            }
            catch (Exception ex)
            {
                throw new PlaywrightException($"Don´t possible validate/found the element on {step}. Details {ex.Message}");
            }

        }

        [AllureStep("Validate text is visible on screen - on step: {step}")]
        public async Task GetByTextToBeVisibleAsync(string expectedText, string step)
        {
            try
            {
                ILocator text = _page.GetByText(expectedText);
                await Expect(text).ToBeVisibleAsync();
            }
            catch (Exception ex)
            {
                throw new PlaywrightException($"Don´t possible validate/found the element on {step}. Details {ex.Message}");
            }

        }





    }
}
