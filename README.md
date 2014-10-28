MSTest
=========

I wrote this program which is based on Agile Test-driven Development.

Firstly, feature files are created in Gherkin text like this: 
```
Feature: Dashboard Summary
Scenario: Load dashboard from login
  Given I am at the page titled "xxxx"
  When I select "xxxx" from the "xxxx"
  Then I should see "xxxx"
```
In this way, businessman can also create this kind of feature file to test web application without knowing any knowledge of programming.

==========

Then my program will test the feature file like this:
```
[TestMethod]
public void Dashboard()
{
    Assert.AreEqual(true, @"features\Dashboard.feature".ExecuteTest().FeatureFaildOrNot());
}
```
==========

Moreover, I used NBehave framework to parse the Gherkin and retrieve the key word/action
```
[When(@"I select $fieldValue from the $fieldName of drop-down list")]
[When(@"I will fill in the field $fieldName with $fieldValue")]
public void FillTheField(String fieldName, String fieldValue)
{
    actions.FillTheField(fieldName, fieldValue);
}
```
==========

Finally, I used Web Selenium to operate on DOM of the page according to the actions parsed by Gherkin.
```
public void FillTheField(String fieldName, String fieldValue)
{
    SearchElementBy(By.Id(fieldName)).SendKeys(fieldValue);
}
```
