using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSuite.PageObjects.CommonElements
{
    public class CommonElementsLocators
    {
        public IWebDriver _driver;

        public CommonElementsLocators(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement CookieInfoBar => _driver.FindElement(By.XPath("//div[@class='cookieinfo active']"));

        public IWebElement AcceptCookieButton => CookieInfoBar.FindElement(By.XPath("//a[contains(@class,'accept-link')]"));

        public IWebElement PrivacyPolicyButton => CookieInfoBar.FindElement(By.XPath("//a[contains(@class,'more-info')]"));

        public IWebElement NotificationPopUp => _driver.FindElement(By.XPath("//div[@id='ue_push_dialog']"));

        public IWebElement AgreeNotificationButton => NotificationPopUp.FindElement(By.XPath("//button[contains(text(),'Nie,dziękuję')]"));

        public IWebElement DisagreeNotificationButton => NotificationPopUp.FindElement(By.XPath("//button[contains(text(),'Jak najbardziej!')]"));

    }
}
