

namespace MVPAutomation.Interfaces
{
    public interface IActions
    {
        Task FillAsync(string locator, string text, string step);
        Task ClickAsync(string locator, string step);
        Task ChooseSelectorAsync(string locator, string option, string step);
    }
}
