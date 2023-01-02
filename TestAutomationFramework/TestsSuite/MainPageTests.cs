using Automation_Logic.Handlers;
using Automation_Logic.Setup.DriverSetup;
using AutomationLogic.Common.Extensions;
using AutomationLogic.Handlers;
using AutomationLogic.Setup;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
        [Description("ChatBot - Check IFrame for ChatBot")]
        [Parallelizable]
        public void WSBMainPage_ChatBot_CheckChatBotIFrame()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--disable-notifications");
            
            var driverSetup = new DriverSetup();
            using (IWebDriver _driver = driverSetup.ReturnDriver(DriverType.Chrome))
            {
                var mainPageActions = new MainPageActions(_driver);
                var commonElementsActions = new CommonElementsActions(_driver);
                var cookiesHanlder = new CookiesHandler(_driver);


                mainPageActions.NavigateToWSBMainPage();
                commonElementsActions.ClickAcceptCookieButton();
                cookiesHanlder.DeleteAllCookies();
                _driver.Navigate().Refresh();
                //Thread.Sleep(50000); //TODO: Custom Waiter for ChatBot.
                //mainPageActions.ClickChatBotLauncherButton(); //TODO: Check if button is clicked.
                
                frameHandler.FindFrameForWebElement(By.XPath("//div[@class='usercom-launcher-dot']")); //TODO: 7 IFrame found. After finding WebElement in Frame, method failing(WebElement in Frame Index 2, fail in index 3).
                WaitForActions.WaitUntilElementVisible(_driver, By.XPath("//div[@class='usercom-launcher-dot']"), 60);
            }
        }
    }
}
