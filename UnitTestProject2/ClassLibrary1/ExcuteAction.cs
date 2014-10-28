using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBehave.Narrator.Framework;

namespace CPOPQR.FunctionalTests.Steps
{
    [ActionSteps]
    public class ExcuteAction
    {
        Actions actions;
        
        public ExcuteAction()
        {
            actions = new Actions();
        }

        [Given(@"an $typeOfBrowser browser")]
        public void OpenBrowser(String typeOfBrowser)
        {
            actions.OpenSpecifiedBrowser(typeOfBrowser);
        }
   
        [When(@"I visit $url")]
        public void VisitUrl(String url)
        {
            actions.VisitSpecifiedUrl(url);
        }

        [When(@"I select $fieldValue from the $fieldName of drop-down list")]
        [When(@"I will fill in the field $fieldName with $fieldValue")]
        public void FillTheField(String fieldName, String fieldValue)
        {
            actions.FillTheField(fieldName, fieldValue);
        }

        [When(@"I select $fieldValue from the $fieldName of select list")]
        public void SelectTheField(String fieldName, String fieldValue)
        {
            actions.SelectByValueFromElementName(fieldName, fieldValue);
        }

        [When(@"I click tab with id $elementId from Dashboard")]
        [When(@"I click button $elementId by id")]
        [When(@"I click checkbox $elementId by id")]
        [When(@"I click with id $elementId")]
        public void ClickElementById(String elementId)
        {
            actions.ClickById(elementId);
        }

        [When(@"I click button $elementName by name")]
        [When(@"I click with name $elementName")]
        public void ClickElementByName(String elementName)
        {
            actions.ClickByName(elementName);
        }

        [When(@"I click button $valueOfAttribute")]
        public void ClickElementByAttribute(String valueOfAttribute)
        {
            actions.ClickElementByAttribute(valueOfAttribute);
        }

        [When(@"I will click the url $urlTxt")]
        public void ClickUrlByUrlTxt(String urlTxt)
        {
            actions.ClickWithUrlTxt(urlTxt);
        }

        [When(@"I click $valueOfType with specified content of $content contained in parent element $parentTagName")]
        public void ClickTagNameWithSpecifiedContentInTable(String valueOfType, String content, String parentTagName)
        {
            actions.ClickByTagnameWithSpecifiedContent(valueOfType, content, parentTagName);
        }

        [When(@"I am at the page titled $pageTitle")]
        [Then(@"I should see the page titled $pageTitle")]
        public void SeePageTitle(String pageTitle)
        {
            actions.FindTitle(pageTitle);
        }

        [Then(@"I should see the $tagName contains content $content")]
        public void SearchContent(String content, String tagName)
        {
            actions.SearchTableWithSpecifiedContent(content, tagName);
        }

        [Then(@"The $attributeName of element of $elementId is $attributeValue")]
        public void Validate(String attributeName, String elementId, String attributeValue)
        {
            actions.ValidateElementWithAttributeAndName(attributeName, elementId, attributeValue);
        }

        [When(@"I click element contains field called $fieldName and text $text")]
        public void ClickElementWithSpecifiedChildElment(String fieldName, String text)
        {
            actions.ClickParentElementByXPath(fieldName,text);
        }

        [When(@"I click element contains child field with id $elementId")]
        public void ClickParentElementThroughChildElmentWithId(String elementId)
        {
            actions.ClickParentElement(elementId);
        }

        [When(@"I want to find sibling element with tagname $tagName of element with id $elementId")]
        [When(@"I click sibling element with tagname $tagName of element with id $elementId")]
        public void ClickSiblingElementWithLocationOfId(String tagName, String elementId)
        {
            actions.ClickSiblingElement(tagName, elementId);
        }

        [When(@"I click $tagName Of specified element with id $elementId")]
        public void ClickChildElement(String tagName, String elementId)
        {
            actions.ClickTagElementContainedBySpecifiedElementWithId(tagName, elementId);
        }
    }
}
