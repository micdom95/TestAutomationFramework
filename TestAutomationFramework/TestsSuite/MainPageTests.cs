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
        [Category("Main Panel Translation Test with Polish language")]
        public void WSBMainPage_OpeningWSBMainPage_WSBMainPageOpenedProperly()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--disable-notifications");
            Languages languages = Languages.Polish;
            var driverSetup = new DriverSetup();
            using (IWebDriver _driver = driverSetup.ReturnDriver(DriverType.Chrome))
            {
                var mainPageActions = new MainPageActions(_driver, languages);
                var commonElementsActions = new CommonElementsActions(_driver);
                mainPageActions.NavigateToWSBMainPage();
                commonElementsActions.ClickAcceptCookieButton();
                mainPageActions.CheckMainPanelTranslations();
            }
        }
    }
}
