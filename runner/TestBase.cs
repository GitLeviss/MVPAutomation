using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using MVPAutomation.Utils;

namespace MVPAutomation.Runner
{
    public class TestBase
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
                Headless = false
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
            var appLink = config["Links:tricentis"] ?? env;
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

        protected async Task CloseBrowserAsync()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status.ToString();

            try
            {
                if (_page != null)
                {
                    await VideoUtils.ForceVideoFinalization(_page);
                }

                if (_context != null)
                {
                    await _context.CloseAsync();
                }

                if (_page != null)
                {
                    await VideoHelper.AttachVideoAsync(_page, status);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao processar vídeo no teardown: {ex.Message}");
            }
            finally
            {
                try
                {
                    if (_browser != null)
                    {
                        await _browser.CloseAsync();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao fechar browser: {ex.Message}");
                }

                try
                {
                    _playwright?.Dispose();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao dispose playwright: {ex.Message}");
                }
            }
        }



    }
}
