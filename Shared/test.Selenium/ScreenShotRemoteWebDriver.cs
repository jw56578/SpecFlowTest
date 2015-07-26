using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace test.SpecFlowPlugin.Selenium
{
    public class ScreenShotRemoteWebDriver : RemoteWebDriver, ITakesScreenshot
    {
        public ScreenShotRemoteWebDriver(Uri RemoteAdress, ICapabilities capabilities, TimeSpan commandTimeout)
            : base(RemoteAdress, capabilities, commandTimeout)
        {
        }

        public Screenshot GetScreenshot()
        {
            Response screenshotResponse = this.Execute(DriverCommand.Screenshot, null);
            string base64 = screenshotResponse.Value.ToString();
            return new Screenshot(base64);
        }
    }
}
