using AutomationLogic.Handlers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TestSuite.PageObjects.CommonElements;

namespace BDDSpecFlowTestSuite.Steps
{
    [Binding]
    public class CommonSteps
    {
        IWebDriver _driver;
        CookiesHandler _cookiesHandler;
        CommonElementsActions _commonElementsActions;

        public CommonSteps(IWebDriver driver, CommonElementsActions commonElementsActions, CookiesHandler cookiesHandler)
        {
            _driver = driver;
            _cookiesHandler = cookiesHandler;
            _commonElementsActions = commonElementsActions;
        }

        [Given(@"Page is refreshed")]
        public void RefreshPage()
        {
            _driver.Navigate().Refresh();
        }

        [Given(@"Cookies are deleted")]
        public void DeleteAllCookies()
        {
            _cookiesHandler.DeleteAllCookies();
        }

        [Given(@"Cookies are accepted by button clicking")]
        [When(@"I click Accept Cookie button")]
        public void ClickAcceptCookieButton()
        {
            _commonElementsActions.ClickAcceptCookieButton();
        }

        [Given(@"Notifications are agreed by button clicking")]
        [When(@"I click Agree Notification button")]
        public void ClickAgreeNotificationButton()
        {
            _commonElementsActions.ClickAgreeNotificationButton();
        }
    }
}
