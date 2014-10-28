using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using NBehave.Narrator.Framework;

namespace CPOPQR.FunctionalTests.Steps
{
    public class Actions
    {
        public void OpenSpecifiedBrowser(String typeOfBrowser)
        {
            if (typeOfBrowser.Equals("Internet Explorer"))
                InitializeIE();
            else
                if (typeOfBrowser.Equals("Chrome"))
                    InitializeChrome();
                else
                    if (typeOfBrowser.Equals("Firefox"))
                        InitializeFirefox();
                    else
                        throw new Exception("No such browser type!");
        }

        public void VisitSpecifiedUrl(String url)
        {
            FeatureContext.Current.GetBrowser().Navigate().GoToUrl(url);
        }

        public void FindTitle(String pageTitle)
        {
            if (!GetBrowser().Title.Equals(pageTitle))
                throw new Exception("Not expected page title!");
        }

        public IWebDriver GetBrowser()
        {
            return FeatureContext
                .Current.GetBrowser();
        }

        public IEnumerable<IWebElement> SearchElementsBy(By by)
        {
            return GetBrowser()
                .SearchElements(by);
        }

        public IWebElement SearchElementBy(By by)
        {
            return GetBrowser()
                .SearchElement(by);
        }

        public IWebElement SearchElementParentBy(By by)
        {
            return GetBrowser()
                .SearchElement(by)
                .GetParent();
        }

        public void FillTheField(String fieldName, String fieldValue)
        {
            SearchElementBy(By.Id(fieldName))
                .SendKeys(fieldValue);
        }

        public void SelectByValueFromElementName(String fieldName, String value)
        {
            new SelectElement(SearchElementBy(By.Name(fieldName)))
                .SelectByTextAndWait(value, 1000);
        }

        public void ClickAndWaitWithTime(By by, int timeSpan) 
        {
            SearchElementBy(by)
                .ClickAndWait(timeSpan);
        }

        public void ClickById(String elementId)
        {
            ClickAndWaitWithTime(By.Id(elementId), 1000);
        }

        public void ClickByName(String elementName)
        {
            ClickAndWaitWithTime(By.Name(elementName), 1000);
        }

        public void ClickWithUrlTxt(String urlTxt)
        {
            ClickAndWaitWithTime(By.LinkText(urlTxt),1000);
        }

        public void ClickElementByAttribute(String valueOfAttribute)
        {
            SearchElementsBy(By.TagName("input"))
                .Where(e => e.GetAttribute("value")
                    .Equals(valueOfAttribute))
                .ToList()
                .ForEach(e => e.ClickAndWait(1000));
        }

        public IEnumerable<IWebElement> CollectionContainsTextAndDisplayed(By by, String content)
        {
            return SearchElementsBy(by)
                .Where(ec => ec.Text.Equals(content) && ec.Displayed);
        }
        public void ClickByTagnameWithSpecifiedContent(String valueOfType, String content, String parentTagName)
        {
            CollectionContainsTextAndDisplayed(By.TagName(parentTagName), content)
                .ToList()
                .ForEach(i => i
                    .FindElements(By.XPath(".//*"))
                    .First(e => e.Displayed && e.GetAttribute("type").Equals(valueOfType))
                    .Click());
        }

        public void SearchTableWithSpecifiedContent(String content, String tagName)
        {
            int count = 0;
            new WebDriverWait(GetBrowser(), TimeSpan.FromSeconds(30d))
                .Until<bool>(dr =>
                {
                    count = SearchElementsBy(By.TagName(tagName))
                        .Where(i => i.Text.Contains(content))
                        .Count();
                    return count > 0;
                });
            if (count==0)
                throw new Exception("Not expected content in specified table!");
        }

        public void ClickParentElementByXPath(String fieldName, String content)
        {
            CollectionContainsTextAndDisplayed(By.TagName(fieldName), content)
                .First()
                .GetParent()
                .ClickAndWait(100);
        }

        public void ClickParentElement(String elementId)
        {
            SearchElementParentBy(By.Id(elementId))
                .ClickAndWait(1000);
        }

        public void ClickSiblingElement(String tagName, String elementId)
        {
            SearchElementParentBy(By.Id(elementId))
                .FindElement(By.TagName(tagName))
                .Click();
        }

        public void ClickTagElementContainedBySpecifiedElementWithId(String tagName, String elementId)
        {
            SearchElementBy(By.Id(elementId))
                .FindElement(By.TagName(tagName))
                .Click();
        }

        public void ValidateElementWithAttributeAndName(String attributeName, String elementId, String attributeValue)
        {
            string value = null;
            new WebDriverWait(GetBrowser(), TimeSpan.FromSeconds(30d))
                .Until<bool>(dr => 
                {
                    value = SearchElementBy(By.Id(elementId))
                        .GetAttribute(attributeName);
                    return !string.IsNullOrEmpty(value);
                });
            if (!value.Equals(attributeValue))
                throw new Exception("Not valid value for specified attribute of the Element");
        }

        private void InitializeIE()
        {
            FeatureContext.Current.SetBrowser(new InternetExplorerDriver());
        }
        private void InitializeFirefox()
        {
            FeatureContext.Current.SetBrowser(new FirefoxDriver());
        }
        private void InitializeChrome()
        {
            ChromeOptions options = new ChromeOptions();
            FeatureContext.Current.SetBrowser(new ChromeDriver(options));
        }
    }
}
