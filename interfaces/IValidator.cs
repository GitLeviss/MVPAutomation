namespace MVPAutomation.interfaces
{
    public interface IValidator
    {
        Task ValidateUrl(string expectedUrl, string step);
        Task LocatorToBeVisibleAsync(string locator, string step);
        Task LocatorToHaveTextAsync(string locator, string expectedText, string step);
        Task GetByTextToBeVisibleAsync(string expectedText, string step);
    }
}