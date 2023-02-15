using FluentAssertions;
using OpenQA.Selenium;

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
