using Allure.NUnit.Attributes;
using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using MVPAutomation.Interfaces;

namespace MVPAutomation.Utils
{
    public class Actions : IActions
    {

        private readonly IPage _page;

        public Actions(IPage page)
        {
            this._page = page;        
        }

        [AllureStep("Write: '{text}' — on step: {step}")]
        public async Task FillAsync(string locator, string text, string step)
        {
            try
            {
                var element = _page.Locator(locator);
                await Expect(element).ToBeVisibleAsync();
                await Expect(element).ToBeEnabledAsync();
                await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
                await element.FocusAsync();
                await element.FillAsync(text);
            }
            catch (Exception ex)
            {
                throw new PlaywrightException(
                    $"Error writing text on '{locator}' at step {step}. Details: {ex.Message}"
                );
            }
        }


        [AllureStep("Click - on step: {step}")]
        public async Task ClickAsync(string locator, string step)
        {
            try
            {
                var element = _page.Locator(locator);

                await Expect(element).ToBeVisibleAsync();
                await Expect(element).ToBeEnabledAsync();
                await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);

                await element.ClickAsync();
            }
            catch (Exception ex)
            {
                throw new PlaywrightException(
                    $"Error clicking '{locator}' on step {step}. Details: {ex.Message}"
                );
            }
        }
        [AllureStep("Click - on step: {step}")]
        public async Task ChooseSelectorAsync(string locator,string option, string step)
        {
            try
            {
                var element = _page.Locator(locator);

                await Expect(element).ToBeVisibleAsync();
                await Expect(element).ToBeEnabledAsync();
                await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
                await element.SelectOptionAsync(option);

            }
            catch (Exception ex)
            {
                throw new PlaywrightException(
                    $"Error to interact with locator '{locator}' to select on step {step}. Details: {ex.Message}"
                );
            }
        }


    }
}
