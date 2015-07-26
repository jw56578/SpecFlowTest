using TechTalk.SpecFlow;
using OpenQA.Selenium;
using System.Configuration;

using test.Selenium.DriverConfiguration;

namespace test.SpecFlowPlugin.Selenium
{
    public class StepDefinitionBase : Steps
    {
        protected static WebDriverManager WebDriverManager;
       
        protected static IWebDriver CurrentDriver
        {
            get { return CurrentDriverEntry.Instance; }
        }

        protected static WebDriver CurrentDriverEntry
        {
            get
            {
                string key = (string)ScenarioContext.Current["CurrentDriverKey"];
                return WebDriverManager.GetWebDriver(key);
            }
            set
            {
                if (!ScenarioContext.Current.ContainsKey("CurrentDriverKey"))
                {
                    ScenarioContext.Current.Add("CurrentDriverKey", null);
                }
                ScenarioContext.Current["CurrentDriverKey"] = value.Key;
            }
        }

        protected StepDefinitionBase(IWebDriverFactory f)
        {
            if (WebDriverManager == null)
            {
                ConfigurationSectionHandler webDriverConfig =
                    (ConfigurationSectionHandler)ConfigurationManager.GetSection("webDriverConfig");
                WebDriverManager = new WebDriverManager(webDriverConfig,f);
            }
        }
        protected StepDefinitionBase():this(new ScreenShotRemoteWebDriverFactory())
        { 
            
        }
               
    }
}
