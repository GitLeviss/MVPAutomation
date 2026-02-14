using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPAutomation.utils
{
    public static class VideoUtils
    {
        public static async Task ForceVideoFinalization(IPage page)
        {
            try
            {
                await Task.Delay(500);

                await page.EvaluateAsync("() => document.body.style.backgroundColor = 'transparent'");
                await Task.Delay(200);
                await page.EvaluateAsync("() => document.body.style.backgroundColor = ''");
            }
            catch
            {
            }
        }

        public static async Task<bool> IsVideoRecording(IPage page)
        {
            try
            {
                var video = page.Video;
                if (video == null) return false;

                var path = await video.PathAsync();
                return !string.IsNullOrEmpty(path);
            }
            catch
            {
                return false;
            }
        }
        public static async Task WaitForVideoStabilization(IPage page, int maxWaitMs = 3000)
        {
            int elapsed = 0;
            int checkInterval = 500;

            while (elapsed < maxWaitMs)
            {
                if (await IsVideoRecording(page))
                {
                    await Task.Delay(checkInterval);
                    elapsed += checkInterval;
                }
                else
                {
                    break;
                }
            }
        }
    }
}
