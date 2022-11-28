using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSuite.PageObjects.VirtualUniveristy
{
    public class VirtualUniversityUserPageLocators
    {
        IWebDriver _driver;

        public VirtualUniversityUserPageLocators(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement UsernameUserInfoLabel => _driver.FindElement(By.XPath("//span[contains(@class,'nav-top2-user-info-content')]//span[contains(@class,'nav-top2 nav-top2-name')]"));

        public IWebElement UserAlbumUserInfoLabel => _driver.FindElement(By.XPath("//span[contains(@class,'nav-top2-user-info-content')]//span[contains(@class,'nav-top2 nav-top2-number-value')]"));
    }
}
