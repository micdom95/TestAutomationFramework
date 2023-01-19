using Automation_Logic.Handlers;
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
using TestSuite.PageObjects.VirtualUniveristy;

namespace TestSuite.TestsSuite
{
    using static SetUpTestsConfiguration;
    
    [TestFixture]
    public class MainPageTests
    {
        DriverSetup _driverSetup;
        IWebDriver _driver;
        MainPageActions _mainPageActions;
        CommonElementsActions _commonElementsActions;
        CookiesHandler _cookiesHandler;
        ChatBot _chatBot;

        [SetUp]
        public void SetUpVirtualUniversityTestsFixture()
        {
            _driverSetup = new DriverSetup();
            _driver = _driverSetup.ReturnDriver(_driverType);
            _mainPageActions = new MainPageActions(_driver);
            _commonElementsActions = new CommonElementsActions(_driver);
            _cookiesHandler = new CookiesHandler(_driver);
            _chatBot = new ChatBot(_driver);
        }

        [Test]
        [Category("Smoke Test")]
        [Parallelizable]
        public void WSBMainPage_OpeningWSBMainPage_WSBMainPageOpenedProperlyWithDefaultTranslation()
        {
            _mainPageActions.NavigateToWSBMainPage();
            _commonElementsActions.ClickAcceptCookieButton();
            _mainPageActions.CheckMainPanelTranslations(Languages.Polish);
        }

        [Test]
        [TestCase("TestPhrase")]
        [Category("Search Engine")]
        [Description("Search Engine Test - Checking typed phrase")]
        [Parallelizable]
        public void WSBMainPage_SearchEngineTest_SearchEngineFindsProperPhrase(string searchText)
        {
            _mainPageActions.NavigateToWSBMainPage();
            _commonElementsActions.ClickAcceptCookieButton();
            _mainPageActions.SearchTextInSearchEngine(searchText, Languages.Polish);
            _mainPageActions.CheckSearchResultLabel(searchText);
        }

        [Test]
        [Category("ChatBot")]
        [Description("ChatBot - Check properly opened ChatBot with Welcome Message")]
        [Parallelizable]
        public void WSBMainPage_ChatBot_CheckProperlyOpenedChatBotWithWelcomeMessage()
        {
            _mainPageActions.NavigateToWSBMainPage();
            _commonElementsActions.ClickAcceptCookieButton();
            _cookiesHandler.DeleteAllCookies();
            _driver.Navigate().Refresh();
            _chatBot.SwitchToChatBotButtonFrame();
            _chatBot.ClickChatBotButton();
            _chatBot.SwitchToChatBotFrame();
            _chatBot.CheckChatBotHeadline();
            _chatBot.CheckWelcomeMessage();
        }

        [Test]
        [Category("ChatBot")]
        [Description("ChatBot - Check ChatBot without received answer from user")]
        [Parallelizable]
        public void WSBMainPage_ChatBot_CheckChatBotWithNoReceivedUserAnswer()
        {
            _mainPageActions.NavigateToWSBMainPage();
            _commonElementsActions.ClickAcceptCookieButton();
            _cookiesHandler.DeleteAllCookies();
            _driver.Navigate().Refresh();
            _chatBot.SwitchToChatBotButtonFrame();
            _chatBot.ClickChatBotButton();
            _chatBot.SwitchToChatBotFrame();
            _chatBot.CheckWelcomeMessage();
            _chatBot.CheckNotReceivedUserAnswerMessage();
        }

        [Test]
        [Category("ChatBot")]
        [Description("ChatBot - Check ChatBot without received answer from user and sended E-mail in correct format")]
        [Parallelizable]
        public void WSBMainPage_ChatBot_CheckChatBotWithNoReceivedUserAnswerAndSendedCorrectEmailFormat()
        {
            _mainPageActions.NavigateToWSBMainPage();
            _commonElementsActions.ClickAcceptCookieButton();
            _cookiesHandler.DeleteAllCookies();
            _driver.Navigate().Refresh();
            _chatBot.SwitchToChatBotButtonFrame();
            _chatBot.ClickChatBotButton();
            _chatBot.SwitchToChatBotFrame();
            _chatBot.CheckWelcomeMessage();
            _chatBot.CheckNotReceivedUserAnswerMessage();
            _chatBot.SendMessage("test@test.com");
            _chatBot.CheckReceivedEmailMessage();
        }

        [Test]
        [Category("ChatBot")]
        [Description("ChatBot - Check ChatBot without received answer from user and sended E-mail in incorrect format")]
        [Parallelizable]
        public void WSBMainPage_ChatBot_CheckChatBotWithNoReceivedUserAnswerAndSendedIncorrectEmailFormat()
        {
            _mainPageActions.NavigateToWSBMainPage();
            _commonElementsActions.ClickAcceptCookieButton();
            _cookiesHandler.DeleteAllCookies();
            _driver.Navigate().Refresh();
            _chatBot.SwitchToChatBotButtonFrame();
            _chatBot.ClickChatBotButton();
            _chatBot.SwitchToChatBotFrame();
            _chatBot.CheckWelcomeMessage();
            _chatBot.ClickChatBotNoButton();
            _chatBot.CheckDeclinedContactMessage();
            _chatBot.SendMessage("IncorrectEmailFormat");
            _chatBot.CheckWrongEmailFormatInformation();
        }

        [Test]
        [Category("ChatBot")]
        [Description(@"ChatBot - Check ChatBot with received confirmed messages and information about Virtual University")]
        [Parallelizable]
        public void WSBMainPage_ChatBot_CheckChatBotWithReceivedConfirmedMessagesWithInfoAboutVirtualUniversity()
        {
            _mainPageActions.NavigateToWSBMainPage();
            _commonElementsActions.ClickAcceptCookieButton();
            _cookiesHandler.DeleteAllCookies();
            _driver.Navigate().Refresh();
            _chatBot.SwitchToChatBotButtonFrame();
            _chatBot.ClickChatBotButton();
            _chatBot.SwitchToChatBotFrame();
            _chatBot.CheckWelcomeMessage();
            _chatBot.ClickChatBotYesButton();
            _chatBot.CheckAcceptedContactMessage();
            _chatBot.ClickChatBotYesButton();
            _chatBot.CheckSelectInformationCategoryMessage();
            _chatBot.ClickChatBotVirtualUniversityButton();
            _chatBot.CheckRedirectToVirtualUniversityMessage();
        }

        [Test]
        [Category("ChatBot")]
        [Description(@"ChatBot - Check ChatBot redirecting to Virtual University with correct URL")]
        [Parallelizable]
        public void WSBMainPage_ChatBot_CheckChatBotWithReceivedConfirmedMessagesWithInfoAboutVirtualUniversityAndRedirectToProperUrl()
        {
            var loginPageActions = new VirtualUniversityLoginPageActions(_driver);
            _mainPageActions.NavigateToWSBMainPage();
            _commonElementsActions.ClickAcceptCookieButton();
            _cookiesHandler.DeleteAllCookies();
            _driver.Navigate().Refresh();
            _chatBot.SwitchToChatBotButtonFrame();
            _chatBot.ClickChatBotButton();
            _chatBot.SwitchToChatBotFrame();
            _chatBot.CheckWelcomeMessage();
            _chatBot.ClickChatBotYesButton();
            _chatBot.CheckAcceptedContactMessage();
            _chatBot.ClickChatBotYesButton();
            _chatBot.CheckSelectInformationCategoryMessage();
            _chatBot.ClickChatBotVirtualUniversityButton();
            _chatBot.CheckRedirectToVirtualUniversityMessage();
            _chatBot.ClickChatBotRedirectToVirtualUniversityLink();
            loginPageActions.CheckLoginPageUrl();
        }

        [Test]
        [Category("ChatBot")]
        [Description(@"ChatBot - Check ChatBot with received answer 'No'")]
        [Parallelizable]
        public void WSBMainPage_ChatBot_CheckChatBotWithReceivedAnswerNo()
        {
            _mainPageActions.NavigateToWSBMainPage();
            _commonElementsActions.ClickAcceptCookieButton();
            _cookiesHandler.DeleteAllCookies();
            _driver.Navigate().Refresh();
            _chatBot.SwitchToChatBotButtonFrame();
            _chatBot.ClickChatBotButton();
            _chatBot.SwitchToChatBotFrame();
            _chatBot.CheckWelcomeMessage();
            _chatBot.ClickChatBotNoButton();
            _chatBot.CheckDeclinedContactMessage();
        }

        [TearDown]
        public void TearDownMainPageTestFixture()
        {
            _driver.Quit();
        }
    }
}
