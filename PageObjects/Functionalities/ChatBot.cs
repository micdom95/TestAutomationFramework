using Automation_Logic.Handlers;
using AutomationLogic.Common.Extensions;
using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjects.Functionalities
{
    public class ChatBot
    {
        private IWebDriver _driver;
        private FrameHandler _frameHandler;

        public ChatBot(IWebDriver driver)
        {
            _driver = driver;
            _frameHandler = new FrameHandler(driver);
        }

        private IWebElement ChatBotButton => _driver.FindElement(By.XPath("//div[@class='usercom-launcher-dot']"));

        private IWebElement ChatBotHeadline => _driver.FindElement(By.XPath("//div[@data-view='chatMessages']//div[@class='usercom-heading usercom-heading-messages usercom-heading-messages--middle usercom-heading-messages--small']//div[@class='usercom-messages-h1']"));

        private IWebElement ChatBotWelcomeMessage => _driver.FindElement(By.XPath("//div[@class='usercom-message-content-wrapper']//p[contains(text(),'Cześć')]"));

        private IWebElement ChatBotYesButton => _driver.FindElement(By.XPath("//div[@class='usercom-bot-answer-item']//*[text()[contains(.,'Tak')]]"));

        private IWebElement ChatBotNoButton => _driver.FindElement(By.XPath("//div[@class='usercom-bot-answer-item']//*[text()[contains(.,'Nie')]]"));

        private IWebElement ChatBotVirtualUniversityButton => _driver.FindElement(By.XPath("//div[@class='usercom-bot-answer-item']//*[text()[contains(.,'Wirtualna Uczelnia')]]"));

        private IWebElement ChatBotNotReceivedAnswerMessage => _driver.FindElement(By.XPath("//div[contains(@class,'usercom-message-content-wrapper')]//p[contains(text(),'Nie otrzymałem')]"));

        private IWebElement ChatBotReceivedEmailMessage => _driver.FindElement(By.XPath("//div[contains(@class,'usercom-message-content-wrapper')]//p[contains(text(),'Dziękujemy')]"));

        private IWebElement ChatBotDeclinedContactMessage => _driver.FindElement(By.XPath("//div[@class='usercom-message-content-wrapper']//p[contains(text(),'Rozumiem.')]"));

        private IWebElement ChatBotAcceptedContactThanksMessage => _driver.FindElement(By.XPath("//div[contains(@class,'usercom-message-content-wrapper')]//p[contains(text(),'Super!')]"));

        private IWebElement ChatBotAcceptedContactQuestionMessage => _driver.FindElement(By.XPath("//div[contains(@class,'usercom-message-content-wrapper')]//p//strong"));

        private IWebElement ChatBotSelectInformationCategoryMessage => _driver.FindElement(By.XPath("//div[@class='usercom-message-content-wrapper']//p[contains(text(),'Wybierz')]"));

        private IWebElement ChatBotRedirectToVirtualUniversityMessage => _driver.FindElement(By.XPath("//div[contains(@class,'usercom-message-content-wrapper')]//p[contains(text(),'Aby przejść')]"));

        private IWebElement ChatBotRedirectToVirtualUniversityLink => ChatBotRedirectToVirtualUniversityMessage.FindElement(By.XPath("//p[contains(text(),'Aby przejść')]/a[contains(text(),'kliknij')]")); //TODO

        private IWebElement ChatBotWrongEmailFormatInformationContainer => _driver.FindElement(By.XPath("//div[@class='usercom-compose-wrapper']"));

        private IWebElement ChatBotWrongEmailFormatInformation => _driver.FindElement(By.XPath("//div[@data-error]"));

        private IWebElement ChatBotTextArea => _driver.FindElement(By.XPath("//input[@class='usercom-compose-textarea']"));

        private Dictionary<string, string> ChatBotMessages = new Dictionary<string, string>()
        {
            ["WelcomeMessage"] = "Cześć, tu automatyczny chatbot Akademii WSB. Jestem tu po to, by pomóc Ci znaleźć istotne informacje. Dasz mi szansę?",
            ["NotReveivedAnswerMessage"] = "Nie otrzymałem od Ciebie jednoznacznej odpowiedzi, więc przyjmuję, że nie jesteś w tej chwili zainteresowany/a rozmową ze mną. Jeśli jednak chcesz, by konsultant Akademii WSB skontaktował się z Tobą, zostaw nam swój adres e-mail",
            ["ReceivedEmailMessage"] = "Dziękujemy, skontaktujemy się z Tobą najszybciej, jak się da!",
            ["DeclinedContactMessage"] = "Rozumiem. Zachęcam zatem do pozostawienia swojego adresu e-mail. Nasz konsultant skontaktuje się z Tobą, jak tylko wrócimy do pracy.",
            ["AcceptedContactThanksMessage"] = "Super! Proszę Cię zatem, odpowiedz na kilka pytań:",
            ["AcceptedContactQuestionMessage"] = "Czy jesteś obecnie studentem/słuchaczem, doktorantem Akademii WSB?",
            ["SelectInformationCategory"] = "Wybierz kategorię w obszarze, której poszukujesz informacji."
        };

        public void ClickChatBotButton()
        {
            ChatBotButton.Displayed.Should().BeTrue();
            ChatBotButton.Click();
        }

        public void SwitchToChatBotButtonFrame()
        {
            WaitForActions.WaitUntilFrameIsAvailable(_driver, "usercom-launcher-dot-frame", 300);
        }

        public void SwitchToChatBotFrame()
        {
            _frameHandler.SwitchToDefaultContent();
            WaitForActions.WaitUntilFrameIsAvailable(_driver, "usercom-board-frame");
        }

        public void ClickChatBotYesButton()
        {
            ChatBotYesButton.Displayed.Should().BeTrue();
            ChatBotYesButton.Click();
        }

        public void ClickChatBotNoButton()
        {
            ChatBotNoButton.Displayed.Should().BeTrue();
            ChatBotNoButton.Click();
        }

        public void ClickChatBotVirtualUniversityButton()
        {
            ChatBotVirtualUniversityButton.Displayed.Should().BeTrue();
            ChatBotVirtualUniversityButton.Click();
        }

        public void ClickChatBotRedirectToVirtualUniversityLink()
        {
            ChatBotRedirectToVirtualUniversityLink.Displayed.Should().BeTrue();
            ChatBotRedirectToVirtualUniversityLink.Click();
            WaitForActions.WaitForPageIsLoaded(_driver);
        }

        public void EnterTextToTextArea(string message)
        {
            ChatBotTextArea.Displayed.Should().BeTrue();
            Actions actions = new Actions(_driver);
            actions.MoveToElement(ChatBotTextArea).Click();
            ChatBotTextArea.SendKeys(message);
        }

        public void SendMessage(string message)
        {
            EnterTextToTextArea(message);
            ChatBotTextArea.SendKeys(Keys.Enter);
        }

        public void CheckChatBotHeadline()
        {
            ChatBotHeadline.Text.Should().Be("Chat Bot Akademii WSB");
        }

        public void CheckWelcomeMessage()
        {
            WaitForActions.WaitUntilElementVisible(_driver, By.XPath("//div[@class='usercom-message-content-wrapper']//p[contains(text(),'Cześć')]"));
            ChatBotWelcomeMessage.Text.Should().Be(ChatBotMessages["WelcomeMessage"]);
        }

        public void CheckNotReceivedUserAnswerMessage()
        {
            WaitForActions.WaitUntilElementVisible(_driver, By.XPath("//div[contains(@class,'lastMessageInGroup')]//p[contains(text(),'Nie otrzymałem')]"), 600);
            ChatBotNotReceivedAnswerMessage.Text.Should().Be(ChatBotMessages["NotReveivedAnswerMessage"]);
        }

        public void CheckDeclinedContactMessage()
        {
            WaitForActions.WaitUntilElementVisible(_driver, By.XPath("//div[@class='usercom-message-content-wrapper']//p[contains(text(),'Rozumiem.')]"));
            ChatBotDeclinedContactMessage.Text.Should().Be(ChatBotMessages["DeclinedContactMessage"]);
        }

        public void CheckAcceptedContactMessage()
        {
            WaitForActions.WaitUntilElementVisible(_driver, By.XPath("//div[contains(@class,'usercom-message-content-wrapper')]//p[contains(text(),'Super!')]"));
            ChatBotAcceptedContactThanksMessage.Text.Should().Be(ChatBotMessages["AcceptedContactThanksMessage"]);
            ChatBotAcceptedContactQuestionMessage.Text.Should().Be(ChatBotMessages["AcceptedContactQuestionMessage"]);
        }

        public void CheckSelectInformationCategoryMessage()
        {
            WaitForActions.WaitUntilElementVisible(_driver, By.XPath("//div[@class='usercom-message-content-wrapper']//p[contains(text(),'Wybierz')]"));
            ChatBotSelectInformationCategoryMessage.Text.Should().Be(ChatBotMessages["SelectInformationCategory"]);
        }

        public void CheckReceivedEmailMessage()
        {
            WaitForActions.WaitUntilElementVisible(_driver, By.XPath("//div[contains(@class,'lastMessageInGroup')]//p[contains(text(),'Dziękujemy')]"));
            ChatBotReceivedEmailMessage.Text.Should().Be(ChatBotMessages["ReceivedEmailMessage"]);
        }

        public void CheckRedirectToVirtualUniversityMessage()
        {
            WaitForActions.WaitUntilElementVisible(_driver, By.XPath("//div[contains(@class,'usercom-message-content-wrapper')]//p[contains(text(),'Aby przejść')]"));
            ChatBotRedirectToVirtualUniversityMessage.Displayed.Should().BeTrue();
            ChatBotRedirectToVirtualUniversityMessage.Text.Should().Be("Aby przejść na stronę wirtualnej uczelni kliknij tutaj.");
        }

        public void CheckWrongEmailFormatInformation()
        {
            WaitForActions.WaitUntilElementExists(_driver, By.XPath("//div[@class='usercom-compose-wrapper']"));
            var attribute = ChatBotWrongEmailFormatInformationContainer.GetAttribute("data-error");
            attribute.Should().Be("Wprowadź prawidłowy adres email");
            ChatBotWrongEmailFormatInformation.Displayed.Should().BeTrue();
        }
    }
}
