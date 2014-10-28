using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CPOPQR.FunctionalTests.Steps
{
    static class IWebElementExtensions
    {
         public static IWebElement GetParent(this IWebElement e)
        {
            return e.FindElement(By.XPath(".."));
        }

        public static void ClickAndWait(this IWebElement e, int timeSpan)
        {
            e.Click();
            Thread.Sleep(timeSpan);
        }

        public static void SelectByTextAndWait(this SelectElement e, String value, int timespan)
        {
            e.SelectByText(value);
            Thread.Sleep(timespan);
        }

        public static IWebElement SearchElement(this IWebDriver driver, By by)
        {
            int timeoutInSeconds = 30;
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));
            }
            return driver.FindElement(by);
        }

        public static IEnumerable<IWebElement> SearchElements(this IWebDriver driver, By by)
        {
            double timeoutInSeconds = 30d;
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElements(by));
            }
            return driver.FindElements(by);
        }
    }
}
