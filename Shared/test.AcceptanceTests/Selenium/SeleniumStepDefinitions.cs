using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using test.SpecFlowPlugin.Selenium;
using test.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoDi;

namespace test.Evolution2.AcceptanceTests
{

    [Binding]
    public class SeleniumStepDefinitions : StepDefinitionBase
    {
        protected IMethodDecorator _methodDecorator;
        protected StepContext _stepContext;
        public SeleniumStepDefinitions(IWebDriverFactory wf,IMethodDecorator md,StepContext sc)
            : base(wf)
        {
            _methodDecorator = md;
            _stepContext = sc;
        }

        [Given(@"I am using the ""(.*)"" browser")]
        private void GivenIAmUsingTheBrowser(string remoteDriverKey)
        {
            if (!WebDriverManager.DriverExists(remoteDriverKey))
            {
                WebDriverManager.AddWebDriver(remoteDriverKey);
            }

            CurrentDriverEntry = WebDriverManager.GetWebDriver(remoteDriverKey);


        }

        [Given(@"I have navigated to the url ""(.*)""")]
        private  void GivenIHaveNavigatedToTheUrl(string url)
        {
            _methodDecorator.Before(new MethodParameters{Url=url});
            CurrentDriver.Navigate().GoToUrl(url);
            _methodDecorator.After(new MethodParameters { Url = url });
        }

        [When(@"I have navigated to the url ""(.*)""")]
        private void WhenIHaveNavigatedToTheUrl(string url)
        {
            _methodDecorator.Before(new MethodParameters { Url = url });
            CurrentDriver.Navigate().GoToUrl(url);
            _methodDecorator.After(new MethodParameters { Url = url });
        }


        [Given(@"The checkbox ""(.*)"" is checked")]
        public  void GivenTheCheckboxIsChecked(string cssSelector)
        {
            
            CurrentDriver.ScrollElementIntoView(cssSelector);
            var el = CurrentDriver.GetElementFromActivePage(cssSelector);
            if (el.Selected == false)
            {
                el.Click();
            }
        }

        [Given(@"The checkbox ""(.*)"" is not checked")]
        public static void GivenTheCheckboxIsNotChecked(string cssSelector)
        {
            CurrentDriver.ScrollElementIntoView(cssSelector);
            var el = CurrentDriver.GetElementFromActivePage(cssSelector);
            if (el.Selected)
            {
                el.Click();
            }
        }

        [When(@"I check the ""(.*)"" checkbox")]
        public static void WhenICheckTheCheckbox(string cssSelector)
        {
            CurrentDriver.ScrollElementIntoView(cssSelector);
            var el = CurrentDriver.GetElementFromActivePage(cssSelector);
            if (el.Selected)
            {
                throw new InvalidOperationException("The checkbox is already checked.");
            }
            el.Click();
        }

        [When(@"I uncheck the ""(.*)"" checkbox")]
        public static void WhenIUncheckTheCheckbox(string cssSelector)
        {
            CurrentDriver.ScrollElementIntoView(cssSelector);
            var el = CurrentDriver.GetElementFromActivePage(cssSelector);
            if (el.Selected == false)
            {
                throw new InvalidOperationException("The checkbox is already unchecked.");
            }
            el.Click();
        }

        [Then(@"The checkbox ""(.*)"" is checked")]
        public static void ThenTheCheckboxIsChecked(string cssSelector)
        {
            CurrentDriver.ScrollElementIntoView(cssSelector);
            Assert.IsTrue(CurrentDriver.GetElementFromActivePage(cssSelector).Selected);
        }

        [Then(@"The checkbox ""(.*)"" is not checked")]
        public static void ThenTheCheckboxIsNotChecked(string cssSelector)
        {
            CurrentDriver.ScrollElementIntoView(cssSelector);
            Assert.IsFalse(CurrentDriver.GetElementFromActivePage(cssSelector).Selected);
        }

        [Given(@"The element ""(.*)"" has ""(.*)"" typed into it")]
        public static void GivenTheElementHasTypedIntoIt(string cssSelector, string keys)
        {
            CurrentDriver.ScrollElementIntoView(cssSelector);
            var el = CurrentDriver.GetElementFromActivePage(cssSelector);
            el.Clear();
            el.SendKeys(keys);
        }

        [When(@"I type ""(.*)"" into the ""(.*)"" element")]
        public void WhenITypeIntoTheElement(string keys, string cssSelector)
        {
            _methodDecorator.Before(new MethodParameters{CssSelector=cssSelector});
            var el = CurrentDriver.GetElementFromActivePage(cssSelector);
            el.SendKeys(keys);
            _methodDecorator.After(new MethodParameters { CssSelector = cssSelector });
        }

        [When(@"I type more than ""(.*)"" characters into the ""(.*)"" element")]
        public void WhenITypeMoreThanCharactersIntoTheElement(int characters, string cssSelector)
        {
            _methodDecorator.Before(new MethodParameters { CssSelector = cssSelector });
            var el = CurrentDriver.GetElementFromActivePage(cssSelector);

            for (int i = 0; i <= characters;i++ )
                el.SendKeys(_stepContext.RandomChar().ToString());

            _methodDecorator.After(new MethodParameters { CssSelector = cssSelector });
        }



        [Then(@"The element ""(.*)"" has the exact text ""(.*)""")]
        public static void ThenTheElementHasTheExactText(string cssSelector, string text)
        {
            CurrentDriver.ScrollElementIntoView(cssSelector);
            Assert.AreEqual(text, CurrentDriver.GetElementFromActivePage(cssSelector).Text);
        }

        [Then(@"The element ""(.*)"" contains the text ""(.*)""")]
        public static void ThenTheElementContainsTheText(string cssSelector, string text)
        {
            CurrentDriver.ScrollElementIntoView(cssSelector);
            Assert.IsTrue(CurrentDriver.GetElementFromActivePage(cssSelector).Text.Contains(text));
        }

        [Then(@"The element ""(.*)"" has the class ""(.*)""")]
        public static void TheTheElemenHasTheClass(string cssSelector, string className)
        {
            CurrentDriver.ScrollElementIntoView(cssSelector);
            Assert.IsTrue(CurrentDriver.GetElementFromActivePage(cssSelector).GetAttribute("class").Contains(className));
        }

        [Then(@"The element ""(.*)"" has a value containing ""(.*)""")]
        public static void ThenTheElementHasAValueContaining(string cssSelector, string text)
        {
            CurrentDriver.ScrollElementIntoView(cssSelector);
            Assert.IsTrue(CurrentDriver.GetElementFromActivePage(cssSelector).GetAttribute("value").Contains(text));
        }

        [Given(@"The element ""(.*)"" is empty")]
        public static void GivenTheElementIsEmpty(string cssSelector)
        {
            CurrentDriver.ScrollElementIntoView(cssSelector);
            CurrentDriver.GetElementFromActivePage(cssSelector).Clear();
        }

        [When(@"I click the element ""(.*)""")]
        public static void WhenIClickTheElement(string cssSelector)
        {
            CurrentDriver.ScrollElementIntoView(cssSelector);
            CurrentDriver.GetElementFromActivePage(cssSelector).Click();
        }

        [When(@"I wait ""(.*)"" milliseconds")]
        public static void WhenIWaitMilliseconds(int milliseconds)
        {
            System.Threading.Thread.Sleep(milliseconds);
        }
        [Given(@"I wait ""(.*)"" milliseconds")]
        public static void GivenIWaitMilliseconds(int milliseconds)
        {
            System.Threading.Thread.Sleep(milliseconds);
        }


        [Given(@"I accept alert")]
        public static void ThenIAcceptAlert()
        {
            var wait = new WebDriverWait(CurrentDriver, TimeSpan.FromSeconds(10));
            IAlert alert = wait.Until(drv => AlertIsPresent(drv));
            if(alert != null)
                alert.Accept();
      }


        [Then(@"I am told ""(.*)""")]
        public static void ThenIAmTold(string expectedMessage)
        {
            var wait = new WebDriverWait(CurrentDriver, TimeSpan.FromSeconds(10));
            IAlert alert = wait.Until(drv => AlertIsPresent(drv));
            var actualMessage = alert.Text;
            alert.Accept();
            Assert.IsTrue(actualMessage.Contains(expectedMessage), "Alert should have contained {0}, but was: {1}", expectedMessage, actualMessage);
        }

        public static IAlert AlertIsPresent(IWebDriver drv)
        {
            try
            {
                // Attempt to switch to an alert
                return drv.SwitchTo().Alert();
            }
            catch (OpenQA.Selenium.NoAlertPresentException)
            {
                // We ignore this execption, as it means there is no alert present...yet.
                return null;
            }

            // Other exceptions will be ignored and up the stack
        }

        [Then(@"I can see the ""(.*)"" element")]
        public static void ThenICanSeeTheElement(string cssSelector)
        {
            CurrentDriver.ScrollElementIntoView(cssSelector);
            CurrentDriver.WaitUntilDisplayed(20, By.CssSelector(cssSelector));
        }

        [Then(@"I can't see the ""(.*)"" element")]
        public static void ThenICantSeeTheElement(string cssSelector)
        {
            IWebElement nonVisibleElement = null;
            CurrentDriver.ScrollElementIntoView(cssSelector);
            try
            {
                nonVisibleElement = CurrentDriver.WaitUntilDisplayed(1, By.CssSelector(cssSelector));
            }
            catch (WebDriverTimeoutException ex)
            {

            }

            Assert.IsNull(nonVisibleElement);
        }
        [Then(@"I wait ""(.*)"" seconds until the browser url contains ""(.*)""")]
        public static void IWaitSecondsUntilTheBrowserUrlContains(int seconds,string url)
        {
            var wait = new WebDriverWait(new SystemClock(), CurrentDriver, new TimeSpan(0, 0, seconds), new TimeSpan(0, 0, 0, 0, 1));
            wait.Until(driver => driver.Url.Contains(url));

        }

        [Then(@"I wait ""(.*)"" seconds until the browser is redirected to ""(.*)""")]
        public static void ThenIWaitSecondsUntilTheBrowserIsRedirectedTo(int seconds, string url)
        {
            var wait = new WebDriverWait(new SystemClock(), CurrentDriver, new TimeSpan(0, 0, seconds), new TimeSpan(0, 0, 0, 0, 1));
            wait.Until(driver => driver.Url == url);

        }
        [Then(@"I can't find the ""(.*)"" element")]
        public static void ThenICantFindTheElement(string cssSelector)
        {
            IWebElement nonExistantElement = null;
            try
            {
                nonExistantElement = CurrentDriver.GetElementFromActivePage(cssSelector, .5);
            }
            catch (NoSuchElementException ex)
            {
            }

            Assert.IsNull(nonExistantElement);
        }

        [Then(@"The number of ""(.*)"" elements is greater than ""(\d+)""")]
        public static void ThenTheNumberofElementsIsGreaterThan(string cssSelector, int number)
        {
            var wait = new WebDriverWait(new SystemClock(), CurrentDriver, new TimeSpan(0, 0, 20), new TimeSpan(0, 0, 0, 0, 1));
            wait.Until(driver => driver.FindElements(By.CssSelector(cssSelector)).Count > number);
        }

        [Then(@"The number of ""(.*)"" elements is less than ""(\d+)""")]
        public static void ThenTheNumberofElementsIsLessThan(string cssSelector, int somethingElse)
        {
            var wait = new WebDriverWait(new SystemClock(), CurrentDriver, new TimeSpan(0, 0, 20), new TimeSpan(0, 0, 0, 0, 1));
            wait.Until(driver => driver.FindElements(By.CssSelector(cssSelector)).Count < somethingElse);
        }

        [Then(@"I can see a link containing the text ""(.*)""")]
        public static void ThenICanSeeALinkContainingTheText(string text)
        {
            Assert.IsNotNull(CurrentDriver.ScrollElementIntoView(CurrentDriver.FindElement(By.LinkText(text))));
        }

        [When(@"I select a random option in the ""(.*)"" element")]
        public static IWebElement WhenISelectARandomOptionInTheElement(string cssSelector)
        {
            SelectElement selectElement = new SelectElement(CurrentDriver.GetElementFromActivePage(cssSelector));
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            var randomIndex = rnd.Next(selectElement.Options.Count);
            var randomOption = selectElement.Options[randomIndex];
            selectElement.SelectByIndex(randomIndex);
            ScenarioContext.Current["randomOption:" + cssSelector] = randomOption;
            ScenarioContext.Current["randomOptionText:" + cssSelector] = randomOption.Text;
            return randomOption;
        }

        [When(@"I select a random option in ""(.*)"" that results in options for ""(.*)""")]
        public static IWebElement WhenTheRandomOptionSelectedForResultsInOptionsFor(string cssFirstSelector, string cssSecondSelector)
        {
            var firstOption = SeleniumStepDefinitions.WhenISelectARandomOptionInTheElement(cssFirstSelector);
            SeleniumStepDefinitions.WhenIWaitMilliseconds(2500);
            var secondSelect = new SelectElement(CurrentDriver.GetElementFromActivePage(cssSecondSelector));
            if (secondSelect.Options.Count > 0)
            {
                return firstOption;
            }
            return WhenTheRandomOptionSelectedForResultsInOptionsFor(cssFirstSelector, cssSecondSelector);
        }

        [When(@"I go backwards")]
        public static void WhenIGoBackwards()
        {
            CurrentDriver.Navigate().Back();
        }

    }
    public class StepContext
    {
        private static Random random = new Random((int)DateTime.Now.Ticks);
        public char RandomChar()
        {
            return (char)random.Next('A', 'Z' + 1);  
        }
        public string RandomString(int length) {

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < length; i++) {
                sb.Append(RandomChar().ToString());
            }
            return sb.ToString();
        }
    }
}
