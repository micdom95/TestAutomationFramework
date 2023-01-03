using Automation_Logic.Handlers;
using AutomationLogic.Common.Extensions;
using FluentAssertions;
using OpenQA.Selenium;
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

        private IWebElement ChatBotYesButton => _driver.FindElement(By.XPath("//div[@class='usercom-bot-answer-item']//p[contains(@text,'Tak')]"));

        private IWebElement ChatBotNoButton => _driver.FindElement(By.XPath(""));

        private IWebElement ChatBotNotReceivedAnswerMessage => _driver.FindElement(By.XPath("//div[contains(@class,'lastMessageInGroup')]//p[contains(text(),'Nie otrzymałem')]"));

        private IWebElement ChatBotReceivedAnswerMessage => _driver.FindElement(By.XPath("//div[contains(@class,'lastMessageInGroup')]//p[contains(text(),'Dziękujemy')]"));

        private IWebElement ChatBotTextArea => _driver.FindElement(By.XPath("//textarea[@class='usercom-compose-textarea']"));

        private Dictionary<string, string> ChatBotMessages = new Dictionary<string, string>()
        {
            ["WelcomeMessage"] = "Cześć, tu automatyczny chatbot Akademii WSB. Jestem tu po to, by pomóc Ci znaleźć istotne informacje. Dasz mi szansę?",
            ["NotReveivedAnswerMessage"] = "Nie otrzymałem od Ciebie jednoznacznej odpowiedzi, więc przyjmuję, że nie jesteś w tej chwili zainteresowany/a rozmową ze mną. Jeśli jednak chcesz, by konsultant Akademii WSB skontaktował się z Tobą, zostaw nam swój adres e-mail",
            ["ReceivedAnswerMessage"] = "Dziękujemy, skontaktujemy się z Tobą najszybciej, jak się da!"
        };

        public void SwitchToChatBotButtonFrame()
        {
            WaitForActions.WaitUntilFrameIsAvailable(_driver, "usercom-launcher-dot-frame", 90);
        }

        public void SwitchToChatBotFrame()
        {
            _frameHandler.SwitchToDefaultContent();
            WaitForActions.WaitUntilFrameIsAvailable(_driver, "usercom-board-frame");
        }

        public void ClickChatBotButton()
        {
            ChatBotButton.Displayed.Should().BeTrue();
            ChatBotButton.Click();
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

        public void EnterTextToTextArea(string message)
        {
            ChatBotTextArea.Displayed.Should().BeTrue();
            ChatBotTextArea.SendKeys(message);
        }

        public void CheckChatBotHeadline()
        {
            ChatBotHeadline.Text.Should().Be("Chat Bot Akademii WSB ");
        }

        public void CheckWelcomeMessage()
        {
            WaitForActions.WaitUntilElementVisible(_driver, By.XPath("//div[@class='usercom-message-content-wrapper']//p[contains(text(),'Cześć')]"));
            ChatBotWelcomeMessage.Text.Should().Be(ChatBotMessages["WelcomeMessage"]);
        }

        public void CheckNotReceivedAnswerMessage()
        {
            WaitForActions.WaitUntilElementVisible(_driver, By.XPath("//div[contains(@class,'lastMessageInGroup')]//p[contains(text(),'Nie otrzymałem')]"), 120);
           ChatBotNotReceivedAnswerMessage.Text.Should().Be(ChatBotMessages["NotReveivedAnswerMessage"]);
        }

        public void CheckReveivedAnswerMessage()
        {
            ChatBotReceivedAnswerMessage.Text.Should().Be(ChatBotMessages["ReceivedAnswerMessage"]);
        }
    }
}
