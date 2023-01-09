Feature: MainPage
	Test Suite for WSB Academy Main Page
Background: 
	Given Opened WSB Academy Main Page
	And Cookies are accepted by button clicking

Scenario: Check Main Panel Translations for Default Polish URL
	Given Cookies are accepted by button clicking
	And Notifications are agreed by button clicking
	Then I can see correct default Polish translation on Main Panel

Scenario: Search Engine look for phrase and display label about results
	Given Cookies are accepted by button clicking
	And Notifications are agreed by button clicking
	When I typed phrase <TypedPhrases> in Search Engine and click search button
	Then I can see label with searched phrase <TypedPhrases>
Examples: 
| TypedPhrases |
| TestPhrase   |
| 1234567890   |

Scenario: ChatBot opened properly with Welcome Message
Scenario: ChatBot send message without received message from user
Scenario: ChatBot send message without received message from user and receive Email from user in correct format
Scenario: ChatBot send message without received message from user and receive Email from user in incorrect format
Scenario: ChatBot received confirmation message from user and give information about Virtual University
Scenario: ChatBot received confirmation message from user and redirect user to Virtual University Login Page
Scenario: ChatBot received 'No' answer from user
