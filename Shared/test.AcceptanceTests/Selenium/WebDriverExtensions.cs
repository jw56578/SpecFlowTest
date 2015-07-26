using System;
using System.Diagnostics;
using System.Drawing;
using System.Collections.ObjectModel;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using test.Selenium;

namespace test.Evolution2.AcceptanceTests
{
    public static class WebDriverExtensions
    {
        static string cssPrefix = "";

        #region Required Application Specific Extensions
        // This should be replaced for any given application; this isn't a one-size-fits-all sort of thing.
        public static IWebElement GetElementFromActivePage(this IWebDriver driver, string cssSelector, double timeoutSeconds = 20)
        {
            IWebElement element = null;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(WebDriverTimeoutException),typeof(UnhandledAlertException));
            try
            {
                element = wait.Until(drv =>
                {
                    try
                    {
                        return drv.FindElement(By.CssSelector(cssPrefix + cssSelector));
                    }
                    catch (NoSuchElementException ex)
                    {
                        return null;
                    }
                });
            }
            catch (WebDriverTimeoutException ex)
            {
                return null;
            }

            return element;
        }

        #endregion

        #region Application Specific Extensions

        public static string GetCurrentControllerName(this IWebDriver driver)
        {
            string currentControllerName;
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            try
            {
                currentControllerName = (string)js.ExecuteScript("return router.routeStack.getActiveState().get('controllerName')");
            }
            catch
            {
                currentControllerName = "undefined";
            }
            return currentControllerName;
        }

        public static string GetCurrentControllerAction(this IWebDriver driver)
        {
            string currentControllerAction;
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            try
            {
                currentControllerAction = (string)js.ExecuteScript("return router.routeStack.getActiveState().get('controllerAction')");
            }
            catch
            {
                currentControllerAction = "undefined";
            }
            return currentControllerAction;
        }

        public static Rectangle GetHeaderRect(this IWebDriver driver)
        {
            var js = (IJavaScriptExecutor)driver;
            int headerWidth = int.Parse(js.ExecuteScript("return document.getElementById('appHeader').offsetWidth").ToString());
            int headerHeight = int.Parse(js.ExecuteScript("return document.getElementById('appHeader').offsetHeight").ToString());
            return new Rectangle(0, 0, headerWidth, headerHeight);
        }

        #endregion

        #region Generic Extensions, dependent upon Application Specific Extensions

        public static IWebElement ScrollElementIntoView(this IWebDriver driver, string cssSelector)
        {
            var element = GetElementFromActivePage(driver, cssSelector);
            return ScrollElementIntoView(driver, element);
        }

        public static IWebElement ScrollElementIntoView(this IWebDriver driver, IWebElement element)
        {
            // Scroll the element into view so finicky WebDrivers can interact with it.  Also factor in the header/footer occlusion for the Firefox driver.
            var offsetRect = driver.GetElementPositionWithinUsableViewport(element);
            var js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(" + offsetRect.X + ", " + offsetRect.Y + ");");
            return element;
        }

        public static Point GetElementPositionWithinUsableViewport(this IWebDriver driver, IWebElement element)
        {
            var elementRect = new Rectangle(element.Location.X, element.Location.Y, element.Size.Width, element.Size.Height);
            var scrollY = elementRect.Top;
            var scrollX = elementRect.Left;
            return new Point(scrollX, scrollY);
        }

        // Should do this in native js so we remove jquery requirement
        public static void SetTestMode(this IWebDriver driver, bool testMode)
        {
            driver.Wait(180, d => d.JQueryIsLoaded());
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            if (testMode)
            {
                js.ExecuteScript("jQuery('body').addClass('web-test-mode'); return void 0;", null);
            }
            else
            {
                js.ExecuteScript("jQuery('body').removeClass('web-test-mode'); return void 0", null);
            }
        }

        public static bool JQueryIsLoaded(this IWebDriver driver)
        {
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            var result = js.ExecuteScript("return (typeof jQuery === 'function');");
            Debug.WriteLine("JQueryIsLoaded: " + result.ToString());
            return (bool)result;
        }

        #endregion

        public static IWebElement GetSelectedOption(this IWebDriver driver, string cssSelector)
        {
            SelectElement selectElement = new SelectElement(driver.GetElementFromActivePage(cssSelector));
            try
            {
                return selectElement.SelectedOption;
            }
            catch (NoSuchElementException ex)
            {
                return null;
            }
        }
    }
}
