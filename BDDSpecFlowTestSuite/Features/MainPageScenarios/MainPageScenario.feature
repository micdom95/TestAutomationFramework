Feature: MainPage
	Test Suite for WSB Academy Main Page
Background: 
	Given Opened WSB Academy Main Page
	And Cookies are accepted by button clicking

Scenario: Check Main Panel Translations for Default Polish URL
	Then I can see correct default Polish translation on Main Panel

Scenario: Search Engine look for phrase and display label about results
	When I typed phrase <TypedPhrases> in Search Engine and click search button with selected <Languages> page language
	Then I can see label with searched phrase <TypedPhrases>
Examples: 
| TypedPhrases | Languages |
| TestPhrase   | Polish    |
| 1234567890   | Polish    |
