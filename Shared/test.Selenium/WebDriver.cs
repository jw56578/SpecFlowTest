using System;
using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System.Collections.Generic;
using test.Selenium.DriverConfiguration;

namespace test.SpecFlowPlugin.Selenium
{
    public class WebDriverParameters
    { 
        public string hubUri { get; set; }
        public int commandTimeout { get; set; }
        public string browserName { get; set; }
        public DesiredCapabilitiesConfigCollection capabilities { get; set; }
        public int? browserHeight { get; set; }
        public int? browserWidth { get; set; }
        public List<string> browserTags { get; set; }
        public string version { get; set; }
        public string platform { get; set; }
        public string key { get; set; }
   

    }
    public interface IWebDriverFactory
    {
        IWebDriver GetWebDriver(WebDriverParameters parameters);
    }
    public class WebDriverFactory : IWebDriverFactory
    {

        public IWebDriver GetWebDriver(WebDriverParameters parameters)
        {
            IWebDriver driver = null;
            var desiredCaps = new DesiredCapabilities();



            foreach (var cap in parameters.capabilities)
            {
                desiredCaps.SetCapability(cap.Key, cap.GetValue());
            }
            //desiredCaps.SetCapability(CapabilityType.Platform, new Platform(GetPlatformTypeFromString(parameters.platform)));
            //desiredCaps.SetCapability(CapabilityType.BrowserName, parameters.browserName);
            //if (parameters.version != string.Empty)
            //{
            //    desiredCaps.SetCapability(CapabilityType.Version, parameters.version);
            //}
            var ieOptions = new OpenQA.Selenium.IE.InternetExplorerOptions();
            ieOptions.IgnoreZoomLevel = true;
            ieOptions.UnexpectedAlertBehavior = OpenQA.Selenium.IE.InternetExplorerUnexpectedAlertBehavior.Accept;

            var chromeOptions = new OpenQA.Selenium.Chrome.ChromeOptions();
            chromeOptions.AddAdditionalCapability("unexpectedAlertBehaviour", "Accept");

          

            switch (parameters.browserName.ToUpperInvariant())
            { 
                case "CHROME":
                    driver = new OpenQA.Selenium.Chrome.ChromeDriver(chromeOptions);
                    break;
                case "ANDROIDCHROME":
                    driver = new OpenQA.Selenium.Chrome.ChromeDriver(chromeOptions);
                    break;
                case "IE":
                    driver = new OpenQA.Selenium.IE.InternetExplorerDriver(ieOptions);
                    break;
                case "FIREFOX":
                    driver = new OpenQA.Selenium.Firefox.FirefoxDriver(desiredCaps);
                    break;
            }

            //driver.S(CapabilityType.UNEXPECTED_ALERT_BEHAVIOUR, UnexpectedAlertBehaviour.ACCEPT);



            return driver;

        }

        private static PlatformType GetPlatformTypeFromString(string platformType)
        {
            try
            {
                return (PlatformType)Enum.Parse(typeof(PlatformType), platformType);
            }
            catch (ArgumentException ex)
            {
                throw new System.InvalidCastException("PlatformType '" + platformType + "' was not found in " + typeof(PlatformType), ex);
            }
        }
    }
    public class ScreenShotRemoteWebDriverFactory : IWebDriverFactory
    {

        public IWebDriver GetWebDriver(WebDriverParameters parameters)
        {
            IWebDriver Instance = null;

            // Create all desired capabilities
            var desiredCaps = new DesiredCapabilities();
            foreach (var cap in parameters.capabilities)
            {
                desiredCaps.SetCapability(cap.Key, cap.GetValue());
            }
            desiredCaps.SetCapability(CapabilityType.Platform, new Platform(GetPlatformTypeFromString(parameters.platform)));
            desiredCaps.SetCapability(CapabilityType.BrowserName, parameters.browserName);
            if (parameters.version != string.Empty)
            {
                desiredCaps.SetCapability(CapabilityType.Version, parameters.version);
            }


            // Attempt to instantiate the driver, catching the usual errors and providing more detailed info.
            try
            {
                Instance = new ScreenShotRemoteWebDriver(new Uri(parameters.hubUri), desiredCaps, TimeSpan.FromSeconds(parameters.commandTimeout));
                // If we've specified a browser's height and width, set it - otherwise just maximize it.  Hopefully we have consistent display resolution on our VM's.
                if (parameters.browserHeight != null && parameters.browserWidth != null)
                {
                    Instance.Manage().Window.Size = new Size(parameters.browserWidth.GetValueOrDefault(), parameters.browserHeight.GetValueOrDefault());
                }
                else
                {
                    //Instance.Manage().Window.Maximize();
                }
            }
            catch (Exception ex)
            {
                // If we don't know how to handle the exception better than Selenium, just pass it along.
                if (!(ex is WebDriverException || ex is InvalidOperationException))
                {
                    throw;
                }

                // But if we do... provide some more helpful messages and such.
                if (ex.Message.Contains("No connection could be made because the target machine actively refused it"))
                {
                    throw new System.Net.WebException(
                        "Target machine refused connection at " + parameters.hubUri +
                        ". Check webDriverConfig remoteDriver settings and ensure server is reachable.", ex);
                }

                if (ex.Message.Contains("No enum const class org.openqa.selenium.Platform."))
                {
                    throw new System.InvalidCastException(
                        "Invalid platform type: " + parameters.platform +
                        ". Check webDriverConfig remoteDriver platform setting and ensure it is an exact match of a known enumeration within " +
                        typeof(PlatformType).ToString(), ex);
                }

                if (ex.Message.Contains("Error forwarding the new session cannot find :"))
                {
                    throw new ArgumentException(
                        "No nodes have a browser that matches the requirements: Platform=" + parameters.platform + ", BrowserName=" +
                        parameters.browserName + ", Version=" + parameters.version, ex);
                }

                throw;
            }

            return Instance;

        }

        private static PlatformType GetPlatformTypeFromString(string platformType)
        {
            try
            {
                return (PlatformType)Enum.Parse(typeof(PlatformType), platformType);
            }
            catch (ArgumentException ex)
            {
                throw new System.InvalidCastException("PlatformType '" + platformType + "' was not found in " + typeof(PlatformType), ex);
            }
        }
    }

    public class WebDriver
    {
        public string Platform { get; private set; }
        public string Version { get; private set; }
        public string BrowserName { get; private set; }
        public string Key { get; set; }
        public int? OriginalBrowserHeight { get; private set; }
        public int? OriginalBrowserWidth { get; private set; }
        public List<string> BrowserTags { get; private set; }
        public IWebDriver Instance { get; private set; }

        public WebDriver(IWebDriverFactory wf, string hubUri, int commandTimeout, string browserName, DesiredCapabilitiesConfigCollection capabilities, int? browserHeight, int? browserWidth, List<string> browserTags, string version, string platform, string key)
        { 
            Instance = wf.GetWebDriver(
                new WebDriverParameters
                {
                    hubUri = hubUri,
                    commandTimeout = commandTimeout,
                    capabilities = capabilities,
                    browserHeight = browserHeight,
                    browserWidth = browserWidth,
                    browserName = browserName,
                    browserTags = browserTags,
                }
            );
           
            Platform = platform;
            Version = version;
            BrowserName = browserName;
            OriginalBrowserHeight = browserHeight;
            OriginalBrowserWidth = browserWidth;
            BrowserTags = browserTags;
            Key = key;
        }

    }
}
