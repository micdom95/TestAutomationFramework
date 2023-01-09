Feature: VirtualUniversityScenario
	Test Suite for Virtual University Pages
Background: 
	Given Opened Virtual University Login Page

Scenario: Log in to Virtual University with empty Login and empty Password with error message
When I enter text  to Username field
And I enter text  to Password field
And I click login button
Then I can see Empty Login Error Message

Scenario: Log in to Virtual University with UserName and empty Password with error message
When I enter text SomeFakeUsername@FakeDomain to Username field
And I enter text  to Password field
And I click login button
Then I can see Empty Password Error Message

Scenario: Log in to Virtual University with incorrect UserName and incorrect Password with error message
When I enter text SomeFakeUsername@FakeDomain to Username field
And I enter text SomeFakePassword to Password field
And I click login button
Then I can see Wrong Login Error Message

Scenario: Log in to Virtual University with correct UserName and correct Password
When I enter correct Username to Username field
And I enter correct Password to Password field
And I click login button
Then I can see default URL Address
And I can see correct User Info
And I can see correct User Album Number

Scenario: Virtual University User Page has correct language translation on Announcements
When I enter correct Username to Username field
And I enter correct Password to Password field
And I click login button
Then I can see default URL Address
And I can see correct User Info
And I can see correct User Album Number
And I can see correct "<LanguageType>" translation on Announcements Page

Examples: 
| LanguageType |
| Polish       |
| English      |
