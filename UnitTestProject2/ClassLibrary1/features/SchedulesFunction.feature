Feature: The Functions In Schedules Page

Scenario: Login into site
  Given an Firefox browser
  When I visit xxxx
  And I will fill in the field UserName with xxx
  And I will fill in the field Password with xxx
  Then I click button LoginButton by id
  Then I should see the page titled xxx

Scenario: Switching view from Dashboard Summary to Schedules
  Given I am at the page titled xxxx
  When I click tab with id xxx from Dashboard
  Then I should see the page titled xxxxx
