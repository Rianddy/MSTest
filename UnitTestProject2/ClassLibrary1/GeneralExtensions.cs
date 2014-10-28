using NBehave.Narrator.Framework;
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
    static class GeneralExtensions
    {
        private static string BrowserContextKey = "browser";
        public static IWebDriver GetBrowser(this FeatureContext context)
        {
            IWebDriver browser;
            if (context.TryGet<IWebDriver>(BrowserContextKey, out browser))
                return browser;

            throw new Exception("There is no browser in the feature context. Go fix it!");
        }

        public static void SetBrowser(this FeatureContext context, IWebDriver browser)
        {
            context.Add(BrowserContextKey, browser);
        }
    }
}
