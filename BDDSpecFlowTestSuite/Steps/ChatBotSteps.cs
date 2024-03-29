﻿using PageObjects.Functionalities;
using TechTalk.SpecFlow;

namespace BDDSpecFlowTestSuite.Steps
{
    [Binding]
    public class ChatBotSteps
    {
        ChatBot _chatBot;

        public ChatBotSteps(ChatBot chatBot)
        {
            _chatBot = chatBot;
        }

        [Given(@"Frame is switched to ChatBot button")]
        public void SwitchToChatBotButtonFrame()
        {
            _chatBot.SwitchToChatBotButtonFrame();
        }

        [Given(@"ChatBot button is clicked")]
        [When(@"I click ChatBot button")]
        public void ClickChatBotButton()
        {
            _chatBot.ClickChatBotButton();
        }

        [Given(@"Frame is switched to ChatBot")]
        [When(@"I switch to ChatBot Frame")]
        public void SwitchToChatBotFrame()
        {
            _chatBot.SwitchToChatBotFrame();
        }

        [When(@"I enter text (.*) in ChatBot text field and send")]
        public void EnterTextTextInChatBotTextField(string message)
        {
            _chatBot.SendMessage(message);
        }

        [When(@"I click ChatBot Yes button")]
        public void ClickChatBotYesButton()
        {
            _chatBot.ClickChatBotYesButton();
        }

        [When(@"I click ChatBot No Button")]
        public void ClickChatBotNoButton()
        {
            _chatBot.ClickChatBotNoButton();
        }

        [When(@"I click Virtual University Category button")]
        public void ClickVirtualUniversityCategoryButton()
        {
            _chatBot.ClickChatBotVirtualUniversityButton();
        }

        [When(@"I click Redirect to Virtual University link")]
        public void ClickRedirectToVirtualUniversityLink()
        {
            _chatBot.ClickChatBotRedirectToVirtualUniversityLink();
        }

        [When(@"I click Email Contact button")]
        public void ClickEmailContactButton()
        {
            _chatBot.ClickChatBotSelectEmailContactButton();
        }

        [Then(@"I can see proper ChatBot Headline")]
        public void AssertProperChatBotHeadline()
        {
            _chatBot.CheckChatBotHeadline();
        }

        [Then(@"I can see ChatBot Welcome Message")]
        public void AssertChatBotWelcomeMessage()
        {
            _chatBot.CheckWelcomeMessage();
        }

        [Then(@"I wait and see ChatBot Message about not received answer from user")]
        public void AssertChatBotMessageAboutNotReceivedAnswerFromUser()
        {
            _chatBot.CheckNotReceivedUserAnswerMessage();
        }

        [Then(@"I can see Message about received Email in correct format")]
        public void AssertMessageAboutReceivedEmail()
        {
            _chatBot.CheckReceivedEmailMessage();
        }

        [Then(@"I can see Message about Email incorrect format")]
        public void AssertMessageAboutEmailIncorrectFormat()
        {
            _chatBot.CheckWrongEmailFormatInformation();
        }

        [Then(@"I can see Accepted Contact Message")]
        public void AssertAcceptedContactMessage()
        {
            _chatBot.CheckAcceptedContactMessage();
        }

        [Then(@"I can see Category Information to select")]
        public void AssertCategoryInformationToSelect()
        {
            _chatBot.CheckSelectInformationCategoryMessage();
        }

        [Then(@"I can see Redirect to Virtual University Message")]
        public void AssertRedirectionToVirtualUniversityMessage()
        {
            _chatBot.CheckRedirectToVirtualUniversityMessage();
        }

        [Then(@"I can see Chatbot Suggested Contact Message")]
        public void AssertChatbotSuggestedContactMessage()
        {
            _chatBot.CheckDeclinedContactMessage();
        }

        [Then(@"I can see Request for Email Address Message")]
        public void AssertRequestForEmailAddressMessage()
        {
            _chatBot.CheckRequestForEmailAddressMessage();
        }

    }
}
