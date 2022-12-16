using Automation_Logic.Handlers;
using FluentAssertions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSuite.PageObjects.CommonElements
{
    public class CommonElementsActions : CommonElementsLocators
    {
        IWebDriver _driver;

        public CommonElementsActions(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public void ClickAcceptCookieButton()
        {
            AcceptCookieButton.Displayed.Should().BeTrue();
            AcceptCookieButton.Click();
        }

        public void ClickAgreeNotificationButton()
        {
            AgreeNotificationButton.Click();
        }
    }
}
