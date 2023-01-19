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

Scenario: Selected semester numer with displayed correct Academic start year and end year and semester numer data
When I enter correct Username to Username field
And I enter correct Password to Password field
And I click login button
Then I can see default URL Address
And I can see correct User Info
And I can see correct User Album Number
When I select semester numer <SemesterNumer> in dropdown
And I click filter button
Then I can see correct semester numer <SemesterNumer> on Announcements Header with <Language> translation
And I can see correct Academic start year <StartAcademicYear> and Academic end year <EndAdacemicYear> on Announcements Header with <Language> translation

Examples: 
| SemesterNumer | StartAcademicYear | EndAdacemicYear | Language |
| 1             | 2019              | 2020            | Polish   |
| 2             | 2019              | 2020            | Polish   |
| 7             | 2022              | 2023            | Polish   |


Scenario: Virtual University User Page has correct Polish translation on Announcements
When I enter correct Username to Username field
And I enter correct Password to Password field
And I click login button
Then I can see default URL Address
And I can see correct User Info
And I can see correct User Album Number
And I can see correct Polish translation on Announcements Page

Scenario: Virtual University User Page has correct English translation on Announcements
When I enter correct Username to Username field
And I enter correct Password to Password field
And I click login button
Then I can see default URL Address
And I can see correct User Info
And I can see correct User Album Number
When I switch language options dropdown to English
Then I can see correct English translation on Announcements Page

