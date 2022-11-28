using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSuite.PageObjects.VirtualUniveristy
{
    public class VirtualUniversityLoginPageLocators
    {
        IWebDriver _driver;

        public VirtualUniversityLoginPageLocators(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement UsernameTextbox => _driver.FindElement(By.Id("userNameInput"));

        public IWebElement PasswordTextbox => _driver.FindElement(By.Name("Password"));

        public IWebElement LoginButton => _driver.FindElement(By.Id("submitButton"));

        public IWebElement ErrorMessage => _driver.FindElement(By.XPath("//span[contains(@id,'errorText')]"));
    }
}
