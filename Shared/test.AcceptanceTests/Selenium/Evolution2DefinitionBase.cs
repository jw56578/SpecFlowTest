using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using OpenQA.Selenium;
using TechTalk.SpecFlow;

using test.Selenium;
using test.SpecFlowPlugin.Selenium;
using OpenQA.Selenium.Support.UI;
using BoDi;

namespace test.Evolution2.AcceptanceTests
{
    [Binding]
    public class Evolution2DefinitionBase : StepDefinitionBase
    {
        IConfiguration config;
        public Evolution2DefinitionBase(IWebDriverFactory wf, IConfiguration config)
            : base(wf)
        {
            this.config = config;
        }

        [AfterTestRun]
        private static void AfterTestRun()
        {
            WebDriverManager.Dispose();
        }
                        
        private bool PutDriverInStartingState(IWebDriver driver)
        {
            // Encode a token to use for the site.
            //int companyId = 8604;
            //int companyId = 9042;
            // 8708 = Winner Subaru VW
            int companyId = 8708;
            int? customerId = null;
            //var cipher =  eLead.Common.Helpers.ModifiedBase64Encryption.Create(new List<string>() { "rueven", "snarffles" });
            var parts = System.Web.HttpUtility.ParseQueryString(string.Empty);
            parts.Add("cid", companyId.ToString());
            parts.Add("uid", customerId.ToString());
            var unencodedToken = parts.ToString();
            var token = "";// cipher.Encode(unencodedToken);

            driver.Navigate().GoToUrl("http://192.168.1.75/selfserve/?token=" + token);
            driver.SetTestMode(true);
            // Wait until we have booted.
            driver.Wait(10, d => d.GetCurrentControllerName() != "undefined");
            // Wait until the jQuery is ready.
            driver.Wait(180, d => d.JQueryIsLoaded());
            return true;
        }

        [Given(@"I am logged into evolution with username ""(.*)"" and password ""(.*)""")]
        private void GivenIAmLoggdIntoEvolutionWithUsernameAndPasswordAndEnvironment(string username, string password)
        {

            Given(string.Format("I have navigated to the url \"" + config.RootUrl + "loginstay.asp" + "\""));
            When(string.Format("I type \"{0}\" into the \"#user\" element", username));
            And(string.Format("I type \"{0}\" into the \"[name=Password]\" element", password));
            And(string.Format("I click the element \"#image1\""));
            Then("I wait \"4\" seconds until the browser url contains \"/eLead-V45/elead_track/index.aspx?login=1\"");
        }

        protected string GetUrl(string path) {

            return config.RootUrl + path;
        }
    }
}
