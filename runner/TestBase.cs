using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using MVPAutomation.utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPAutomation.runner
{
    internal class TestBase
    {
        protected IPage _page;
        private IPlaywright? _playwright;
        private IBrowser? _browser;
        private IBrowserContext? _context;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            VideoHelper.ClearOldVideos();
        }

        protected async Task<IPage> OpenBrowserAsync()
        {
            _playwright = await Playwright.CreateAsync();
            var launchOptions = new BrowserTypeLaunchOptions
            {
                Headless = true
            };

            _browser = await _playwright.Chromium.LaunchAsync(launchOptions);
            var videosDir = Path.Combine(TestContext.CurrentContext.TestDirectory, "videos");
            Directory.CreateDirectory(videosDir);

            var contextOptions = new BrowserNewContextOptions
            {
                ViewportSize = new ViewportSize { Width = 1920, Height = 1080 },
                IgnoreHTTPSErrors = true,
                RecordVideoDir = videosDir,
                RecordVideoSize = new RecordVideoSize { Width = 1366, Height = 768 }
            };

            _context = await _browser.NewContextAsync(contextOptions);
            _page = await _context.NewPageAsync();
            _page.SetDefaultTimeout(60000);
            _page.SetDefaultNavigationTimeout(60000);

            var config = new ConfigurationBuilder()
                .SetBasePath(TestContext.CurrentContext.TestDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            var env = Environment.GetEnvironmentVariable("APP_LINK");
            var appLink = config["Links:App"] ?? env;
            _page.DOMContentLoaded += async (sender, e) =>
            {
                await _page.AddStyleTagAsync(new PageAddStyleTagOptions
                {
                    Content = "body { zoom: 0.75; }"
                });
            };
            await _page.GotoAsync(appLink!, new PageGotoOptions
            {
                Timeout = 60000,
                WaitUntil = WaitUntilState.NetworkIdle
            });
            await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            
            return _page;

        }


    }
}
