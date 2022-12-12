using Automation_Logic.Setup.DriverSetup;
using AutomationLogic.Setup;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public void WSBMainpage_SearchEngineTest_SearchEngineFindsProperPhrase(string searchText)
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
    }
}
