using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace test.Selenium
{
    public static class WebDriverExtensions
    {
        public static void WaitForNewWindow(this IWebDriver driver, int timeoutInSeconds)
        {
            string windowHandle = driver.CurrentWindowHandle;
            driver.Wait(timeoutInSeconds, webDriver => webDriver.WindowHandles[0] != windowHandle);
            driver.SwitchTo().Window(driver.WindowHandles[0]);
        }

        public static bool ElementExists(this IWebDriver driver, By by)
        {
            System.Threading.Thread.Sleep(5);
            try
            {
                driver.FindElement(by);
                return true;
            } catch (NoSuchElementException)
            {
                return false;
            }
        }

        public static bool ElementIsDisplayed(this IWebDriver driver, By by)
        {
            System.Threading.Thread.Sleep(5);
            IWebElement el;
            bool isDisplayed = false;
            bool gotBoolean;

            if (driver.ElementExists(by))
            {
                el = driver.FindElement(by);
                do
                {
                    // For whatever reason, on Android this often throws an InvalidCastException
                    try
                    {
                        isDisplayed = el.Displayed;
                        gotBoolean = true;
                    } catch (InvalidCastException)
                    {
                        // Loop until we get either a true or false
                        gotBoolean = false;
                    }
                } while (gotBoolean == false);
                return isDisplayed;
            }
            else
            {
                return false;
            }
        }

        public static void Wait(this IWebDriver driver, int timeoutInSeconds, Func<IWebDriver, bool> condition)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, timeoutInSeconds));
            wait.Until(condition);
        }

        public static IWebElement WaitUntilDisplayed(this IWebDriver driver, int timeoutInSeconds, By by)
        {
            // Wait until it exists.
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, timeoutInSeconds));
            wait.Until(d => d.ElementExists(by));
            // Wait until it's visible.
            wait = new WebDriverWait(driver, new TimeSpan(0, 0, timeoutInSeconds));
            wait.Until(d => d.ElementIsDisplayed(by));

            // Seems to prevent null reference and invalid cast exceptions on Android.
            System.Threading.Thread.Sleep(50);

            return driver.FindElement(by);
        }

        public static IAlert WaitUntilAlert(this IWebDriver driver, int timeoutInSeconds)
        {
            System.Threading.Thread.Sleep(5);
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, timeoutInSeconds));
            return wait.Until(GetAlert);
        }

        private static IAlert GetAlert(IWebDriver driver)
        {
            try
            {
                return driver.SwitchTo().Alert();
            } catch (NoAlertPresentException)
            {
                return null;
            }
        }
    }
}
