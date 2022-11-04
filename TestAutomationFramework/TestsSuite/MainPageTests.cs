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
using TestSuite.PageObjects.CommonElements;
using TestSuite.PageObjects.MainPage;

namespace TestSuite.TestsSuite
{
    [TestFixture]
    public class MainPageTests
    {
        [Test]
        [Category("SmokeTest")]
        public void WSBMainPage_OpeningWSBMainPage_WSBMainPageOpenedProperly()
        {
            using (IWebDriver _driver = new ChromeDriver())
            {
                var mainPageActions = new MainPageActions(_driver);
                CommonElementsActions commonElementsActions = new CommonElementsActions(_driver);
                mainPageActions.NavigateToWSBMainPage();
                commonElementsActions.ClickAcceptCookieButton();
            }
        }
    }
}
