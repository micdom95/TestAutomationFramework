﻿using Automation_Logic.Handlers;
using Automation_Logic.Setup.DriverSetup;
using AutomationLogic.Common.Extensions;
using AutomationLogic.Handlers;
using AutomationLogic.Setup;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObjects.Functionalities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestSuite.Enums;
using TestSuite.PageObjects.CommonElements;
using TestSuite.PageObjects.MainPage;

namespace TestSuite.TestsSuite
{
    [TestFixture]
    public class MainPageTests
    {
        [Test]
        [Category("Smoke Test")]
        [Parallelizable]
        public void WSBMainPage_OpeningWSBMainPage_WSBMainPageOpenedProperly()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--disable-notifications");
            var driverSetup = new DriverSetup();

            using (IWebDriver _driver = driverSetup.ReturnDriver(DriverType.Chrome))
            {
                var mainPageActions = new MainPageActions(_driver);
                var commonElementsActions = new CommonElementsActions(_driver);
                mainPageActions.NavigateToWSBMainPage();
                commonElementsActions.ClickAcceptCookieButton();
                mainPageActions.CheckMainPanelTranslations(Languages.Polish);
            }
        }

        [Test]
        [TestCase("TestPhrase")]
        [Category("Search Engine")]
        [Description("Search Engine Test - Checking typed phrase")]
        [Parallelizable]
        public void WSBMainPage_SearchEngineTest_SearchEngineFindsProperPhrase(string searchText)
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--disable-notifications");
            var driverSetup = new DriverSetup();
            using (IWebDriver _driver = driverSetup.ReturnDriver(DriverType.Chrome))
            {
                var mainPageActions = new MainPageActions(_driver);
                var commonElementsActions = new CommonElementsActions(_driver);
                mainPageActions.NavigateToWSBMainPage();
                commonElementsActions.ClickAcceptCookieButton();
                mainPageActions.SearchTextInSearchEngine(searchText, Languages.Polish);
                mainPageActions.CheckSearchResultLabel(searchText);
            }
        }

        [Test]
        [Category("ChatBot")]
        [Description("ChatBot - Check properly opened ChatBot with Welcome Message")]
        [Parallelizable]
        public void WSBMainPage_ChatBot_CheckProperlyOpenedChatBotWithWelcomeMessage()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--disable-notifications");

            var driverSetup = new DriverSetup();
            using (IWebDriver _driver = driverSetup.ReturnDriver(DriverType.Chrome))
            {
                var mainPageActions = new MainPageActions(_driver);
                var commonElementsActions = new CommonElementsActions(_driver);
                var cookiesHanlder = new CookiesHandler(_driver);
                var chatBot = new ChatBot(_driver);

                mainPageActions.NavigateToWSBMainPage();
                commonElementsActions.ClickAcceptCookieButton();
                cookiesHanlder.DeleteAllCookies();
                _driver.Navigate().Refresh();
                chatBot.SwitchToChatBotButtonFrame();
                chatBot.ClickChatBotButton();
                chatBot.SwitchToChatBotFrame();
                chatBot.CheckChatBotHeadline();
                chatBot.CheckWelcomeMessage();
            }
        }

        [Test]
        [Category("ChatBot")]
        [Description("ChatBot - Check ChatBot without received answer from user")]
        [Parallelizable]
        public void WSBMainPage_ChatBot_CheckChatBotWithNoReceivedUserAnswer()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--disable-notifications");

            var driverSetup = new DriverSetup();
            using (IWebDriver _driver = driverSetup.ReturnDriver(DriverType.Chrome))
            {
                var mainPageActions = new MainPageActions(_driver);
                var commonElementsActions = new CommonElementsActions(_driver);
                var cookiesHanlder = new CookiesHandler(_driver);
                var chatBot = new ChatBot(_driver);

                mainPageActions.NavigateToWSBMainPage();
                commonElementsActions.ClickAcceptCookieButton();
                cookiesHanlder.DeleteAllCookies();
                _driver.Navigate().Refresh();
                chatBot.SwitchToChatBotButtonFrame();
                chatBot.ClickChatBotButton();
                chatBot.SwitchToChatBotFrame();
                chatBot.CheckWelcomeMessage();
                chatBot.CheckNotReceivedUserAnswerMessage();
            }
        }

        [Test]
        [Category("ChatBot")]
        [Description("ChatBot - Check ChatBot without received answer from user")]
        [Parallelizable]
        public void WSBMainPage_ChatBot_CheckChatBotWithNoReceivedUserAnswerAndSendedCorrectEmailFormat()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--disable-notifications");

            var driverSetup = new DriverSetup();
            using (IWebDriver _driver = driverSetup.ReturnDriver(DriverType.Chrome))
            {
                var mainPageActions = new MainPageActions(_driver);
                var commonElementsActions = new CommonElementsActions(_driver);
                var cookiesHanlder = new CookiesHandler(_driver);
                var chatBot = new ChatBot(_driver);

                mainPageActions.NavigateToWSBMainPage();
                commonElementsActions.ClickAcceptCookieButton();
                cookiesHanlder.DeleteAllCookies();
                _driver.Navigate().Refresh();
                chatBot.SwitchToChatBotButtonFrame();
                chatBot.ClickChatBotButton();
                chatBot.SwitchToChatBotFrame();
                chatBot.CheckWelcomeMessage();
                chatBot.CheckNotReceivedUserAnswerMessage();
                chatBot.SendMessage("test@test.com");
                chatBot.CheckReceivedEmailMessage();
            }
        }

        [Test]
        [Category("ChatBot")]
        [Description(@"ChatBot - Check ChatBot with received answer 'No'")]
        [Parallelizable]
        public void WSBMainPage_ChatBot_CheckChatBotWithReceivedAnswerNo()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--disable-notifications");

            var driverSetup = new DriverSetup();
            using (IWebDriver _driver = driverSetup.ReturnDriver(DriverType.Chrome))
            {
                var mainPageActions = new MainPageActions(_driver);
                var commonElementsActions = new CommonElementsActions(_driver);
                var cookiesHanlder = new CookiesHandler(_driver);
                var chatBot = new ChatBot(_driver);

                mainPageActions.NavigateToWSBMainPage();
                commonElementsActions.ClickAcceptCookieButton();
                cookiesHanlder.DeleteAllCookies();
                _driver.Navigate().Refresh();
                chatBot.SwitchToChatBotButtonFrame();
                chatBot.ClickChatBotButton();
                chatBot.SwitchToChatBotFrame();
                chatBot.CheckWelcomeMessage();
                chatBot.ClickChatBotNoButton();
                chatBot.CheckDeclinedContactMessage();
            }
        }
    }
}
