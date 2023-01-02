using Automation_Logic.Handlers;
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

        public ChatBot(IWebDriver driver, FrameHandler frameHandler)
        {
            _driver = driver;
            _frameHandler = frameHandler;
        }

        private IWebElement ChatBotButton => _driver.FindElement(By.XPath("//div[@class='usercom-launcher-dot']"));

        private IWebElement ChatBotHeadline => _driver.FindElement(By.XPath("//div[@data-view='chatMessages']//div[@class='usercom-heading usercom-heading-messages usercom-heading-messages--middle usercom-heading-messages--small']//div[@class='usercom-messages-h1']"));

        private IWebElement ChatBotWelcomeMessage => _driver.FindElement(By.XPath("//div[@class='message-wrapper usercom-avatar-in-message']//p[contains(text(),'Cześć')]"));

        private IWebElement ChatBotNotReceivedAnswerMessage => _driver.FindElement(By.XPath("//div[contains(@class,'lastMessageInGroup')]//p[contains(text(),'Nie otrzymałem')]"));

        private IWebElement ChatBotReceivedAnswerMessage => _driver.FindElement(By.XPath("//div[contains(@class,'lastMessageInGroup')]//p[contains(text(),'Dziękujemy')]"));

        private Dictionary<string, string> ChatBotMessages = new Dictionary<string, string>()
        {
            ["WelcomeMessage"] = "Cześć, tu automatyczny chatbot Akademii WSB. Jestem tu po to, by pomóc Ci znaleźć istotne informacje. Dasz mi szansę?",
            ["NotReveivedAnswerMessage"] = "Nie otrzymałem od Ciebie jednoznacznej odpowiedzi, więc przyjmuję, że nie jesteś w tej chwili zainteresowany/a rozmową ze mną. Jeśli jednak chcesz, by konsultant Akademii WSB skontaktował się z Tobą, zostaw nam swój adres e-mail",
            ["ReceivedAnswerMessage"] = "Dziękujemy, skontaktujemy się z Tobą najszybciej, jak się da!"
        };

        public void SwitchToChatBotButtonFrame()
        {
            _frameHandler.SwitchToFrameByID("usercom-launcher-dot-frame");
        }

        public void SwitchToChatBotFrame()
        {
            _frameHandler.SwitchToFrameByID("usercom-board-frame");
        }

        public void ClickChatBotButton()
        {
            ChatBotButton.Displayed.Should().BeTrue();
            ChatBotButton.Click();
        }

        public void CheckChatBotHeadline()
        {
            ChatBotHeadline.Text.Should().Be("Chat Bot Akademii WSB ");
        }

        public void CheckWelcomeMessage()
        {
            ChatBotWelcomeMessage.Text.Should().Be(ChatBotMessages["WelcomeMessage"]);
        }

        public void CheckNotReceivedAnswerMessage()
        {
            ChatBotNotReceivedAnswerMessage.Text.Should().Be(ChatBotMessages["NotReveivedAnswerMessage"]);
        }

        public void CheckReveivedAnswerMessage()
        {
            ChatBotReceivedAnswerMessage.Text.Should().Be(ChatBotMessages["ReceivedAnswerMessage"]);
        }
    }
}
