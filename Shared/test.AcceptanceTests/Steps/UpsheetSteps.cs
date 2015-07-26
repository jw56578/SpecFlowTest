using test.SpecFlowPlugin.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace test.Evolution2.AcceptanceTests.Steps
{
    [Binding]
    public class UpsheetSteps:Evolution2DefinitionBase
    {
        UpsheetContext _context;
        StepContext _stepContext;
        public UpsheetSteps(UpsheetContext context,StepContext stepContext,IWebDriverFactory f,IConfiguration config)
            :base(f,config)
        {
            _context = context;
            _stepContext = stepContext;
        }
        [Given(@"I go to the upsheet")]
        public void GivenIGoToTheUpsheet()
        {
            //wait until the main evo window settles so no erros occur when nagivating away 
            Given("I wait \"3000\" milliseconds");
            And("I have navigated to the url \"" + base.GetUrl("eLead-V45/elead_track/newprospects/upsheet.aspx") + "\"");
        }


        [When(@"I enter over the maximum characters into the field:")]
        public void WhenIEnterOverTheMaximumCharactersIntoTheField(Table table)
        {
            var fields = table.CreateSet<UpsheetField>();
            foreach(var field in fields){
                When("I type more than \"" + field.MaxCharacter.ToString() + "\" characters into the \"" + field.CssSelector + "\" element");
                var wait = new WebDriverWait(CurrentDriver, TimeSpan.FromSeconds(10));
                IAlert alert = wait.Until(drv => SeleniumStepDefinitions.AlertIsPresent(drv));
                var actualMessage = alert.Text;
                alert.Accept();
                _context.Messages.Add(actualMessage);
            }
        }
        [When(@"I enter maximum characters into the field:")]
        public void WhenIEnterMaximumCharactersIntoTheField(Table table)
        {
            var fields = table.CreateSet<UpsheetField>();
            foreach (var field in fields)
            {
                var randomString = _stepContext.RandomString(field.MaxCharacter);
                When("I type \"" + randomString + "\" into the \"" + field.CssSelector + "\" element");
                _context.EnteredIntoFields.Add(field.CssSelector, randomString);
            }
        }

        [Then(@"I am told:")]
        public void ThenIAmTold(Table table)
        {
            var messages = table.CreateSet<UpsheetField>();
            foreach (var msg in messages) {
                Assert.IsTrue(_context.Messages.Contains(msg.Description + " is limited to " + msg.MaxCharacter + " characters"));
            }
        }

        [Then(@"The field should have the number of characters in it:")]
        public void ThenTheFieldShouldHaveTheNumberOfCharactersInIt(Table table)
        {
            var fields = table.CreateSet<UpsheetField>();
            foreach (var field in fields) {
                Assert.IsTrue(CurrentDriver.GetElementFromActivePage(field.CssSelector).GetAttribute("value").Length == field.MaxCharacter);
            }
        }
        [When(@"I open a new window")]
        public void WhenIOpenANewWindow()
        {
            IJavaScriptExecutor jscript = CurrentDriver as IJavaScriptExecutor;
            jscript.ExecuteScript("window.open()");
            string secondWindow = CurrentDriver.WindowHandles[1];
            _context.NewWindow = secondWindow;
        }
        [When(@"I switch to new window")]
        public void WhenISwitchToNewWindow()
        {
            CurrentDriver.SwitchTo().Window(_context.NewWindow);
        }
        [When(@"I find the last id created")]
        public void WhenIFindTheLastIdCreated()
        {
            var table = CurrentDriver.GetElementFromActivePage("#results");
            var rows = table.FindElements(By.TagName("tr"));
            var tds = rows[1].FindElements(By.TagName("td"));
            string id = tds[1].Text;
            _context.LastIdCreated = id;
        }
        [When(@"I navigate to the specific upsheet url")]
        public void WhenINavigateToTheSpecificUpsheetUrl()
        {
            And("I have navigated to the url \"" + GetUrl("eLead-V45/elead_track/newprospects/upsheet.aspx?ID=" + _context.LastIdCreated ) + "\"");
        }

        [Then(@"All the fields have the same values")]
        public void ThenAllTheFieldsHaveTheSameValues()
        {
            foreach (var field in _context.EnteredIntoFields) {
                Assert.IsTrue(CurrentDriver.GetElementFromActivePage(field.Key).GetAttribute("value") == field.Value);
            }
        }
        [When(@"I navigate to the upsheet log")]
        public void WhenINavigateToTheUpsheetLog()
        {
            And("I have navigated to the url \"" + GetUrl("eLead-V45/elead_track/NewProspects/UpSheetMenu.asp") + "\"");
        }


    }

    public class UpsheetContext
    {
        public UpsheetContext()
        {
            Messages = new List<string>();
            EnteredIntoFields = new Dictionary<string, string>();
        }
        public List<string> Messages { get; private set; }
        public Dictionary<string, string> EnteredIntoFields { get; set; }
        public string NewWindow { get; set; }
        public string LastIdCreated { get; set; }
    }

    public class UpsheetField
    {
        public int MaxCharacter { get; set; }
        public string CssSelector { get; set; }
        public string Description { get; set; }

    }

}
