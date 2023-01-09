Feature: ChatBotScenario
	Test Suite for ChatBot functionality
Background: 
	Given Opened WSB Academy Main Page
	And Cookies are accepted by button clicking
	And Cookies are deleted
	And Page is refreshed
	And Frame is switched to ChatBot button

Scenario: ChatBot opened properly with Welcome Message
	When I click ChatBot button
	And I switch to ChatBot Frame
	Then I can see proper ChatBot Headline
	And I can see ChatBot Welcome Message

Scenario: ChatBot send message without received message from user
	When I click ChatBot button
	And I switch to ChatBot Frame
	Then I can see ChatBot Welcome Message
	And I wait and see ChatBot Message about not received answer from user
	
Scenario: ChatBot send message without received message from user and receive Email from user in correct format
	When I click ChatBot button
	And I switch to ChatBot Frame
	Then I can see ChatBot Welcome Message
	And I wait and see ChatBot Message about not received answer from user
	When I enter text test@test.com in ChatBot text field and send
	Then I can see Message about received Email in correct format

Scenario: ChatBot send message without received message from user and receive Email from user in incorrect format
	When I click ChatBot button
	And I switch to ChatBot Frame
	Then I can see ChatBot Welcome Message
	And I wait and see ChatBot Message about not received answer from user
	When I enter text IncorrectEmailFormat in ChatBot text field and send
	Then I can see Message about Email incorrect format

Scenario: ChatBot received confirmation message from user and give information about Virtual University
	When I click ChatBot button
	And I switch to ChatBot Frame
	Then I can see ChatBot Welcome Message
	When I click ChatBot Yes button
	Then I can see Accepted Contact Message
	When I click ChatBot Yes button
	Then I can see Category Information to select
	When I click Virtual University Category button
	Then I can see Redirect to Virtual University Message

Scenario: ChatBot received confirmation message from user and redirect user to Virtual University Login Page
	When I click ChatBot button
	And I switch to ChatBot Frame
	Then I can see ChatBot Welcome Message
	When I click ChatBot Yes button
	Then I can see Accepted Contact Message
	When I click ChatBot Yes button
	Then I can see Category Information to select
	When I click Virtual University Category button
	Then I can see Redirect to Virtual University Message
	When I click Redirect to Virtual University link
	Then I am redirected to Login Page with correct URL

Scenario: ChatBot received 'No' answer from user
	When I click ChatBot button
	And I switch to ChatBot Frame