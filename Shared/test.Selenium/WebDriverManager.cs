using System;
using System.Collections.Generic;
using System.Linq;

using test.Selenium.DriverConfiguration;
using OpenQA.Selenium;

namespace test.SpecFlowPlugin.Selenium
{
    public class WebDriverManager : IDisposable
    {
        private readonly ConfigurationSectionHandler _webDriverConfig;
        private readonly Dictionary<string, WebDriver> _webDrivers;
        private readonly IWebDriverFactory _webDriverFactory;


        public WebDriverManager(ConfigurationSectionHandler webDriverConfig,IWebDriverFactory webDriverFactory)
        {
            _webDriverConfig = webDriverConfig;
            _webDrivers = new Dictionary<string, WebDriver>();
            _webDriverFactory = webDriverFactory;
        }

        public bool DriverExists(string key)
        {
            return _webDrivers.ContainsKey(key);
        }

        public WebDriver AddWebDriver(string key)
        {
            // Retrieve configuration values
            RemoteWebDriverConfigElement remoteDriverConfig;
            try
            {
                remoteDriverConfig = _webDriverConfig.RemoteDrivers.First(driver => driver.Key == key);
            }
            catch (InvalidOperationException ex)
            {
                throw new NotFoundException("No driver in webDriverConfig with key: " + key + ". Ensure you are using the test.SpecFlowPlugin and you have defined at least one active remoteDriver", ex);
            }

            string hubUri = (remoteDriverConfig.HubUri == String.Empty) ? _webDriverConfig.RemoteDrivers.DefaultHubUri : remoteDriverConfig.HubUri;
            int commandTimeout = (_webDriverConfig.RemoteDrivers.CommandTimeout == 0) ? 60 : _webDriverConfig.RemoteDrivers.CommandTimeout;
            string platform = remoteDriverConfig.Platform;
            string version = remoteDriverConfig.Version;
            string browserName = remoteDriverConfig.BrowserName;
            int? browserHeight = remoteDriverConfig.BrowserHeight;
            int? browserWidth = remoteDriverConfig.BrowserWidth;
            string browserTagsText = remoteDriverConfig.BrowserTags;

            List<string> browserTagsList = new List<string>();
            if (browserTagsText != null)
            {
                string[] browserTags = browserTagsText.Split();
                browserTagsList = browserTags.ToList<string>();
            }

            var createdDriver = new WebDriver(_webDriverFactory,hubUri, commandTimeout, browserName, remoteDriverConfig.DesiredCapabilities, browserHeight, browserWidth, browserTagsList, version, platform, key);

            _webDrivers.Add(key, createdDriver);

            return createdDriver;
        }

        public WebDriver GetWebDriver(string key)
        {
            return _webDrivers[key];
        }

        public void RemoveWebDriver(string key)
        {
            GetWebDriver(key).Instance.Quit();
            _webDrivers.Remove(key);
        }

        public void Dispose()
        {
            foreach (KeyValuePair<string, WebDriver> driver in _webDrivers)
            {
                driver.Value.Instance.Quit();
            }
            _webDrivers.Clear();
        }
    }
}
