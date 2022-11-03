using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSuite.PageObjects.MainPage
{
    public class MainPageLocators
    {
        private IWebDriver _driver;
        public MainPageLocators(IWebDriver driver)
        {
            _driver = driver;
        }

        IWebElement LanguageOptionsDropdown => _driver.FindElement(By.XPath("//div[@class='header-container']//div[@class='lang-menu']"));

        IList<IWebElement> LanguageOptions => LanguageOptionsDropdown.FindElements(By.XPath("/ul/li/a"));

        IWebElement DepartmentMenuDropdown => _driver.FindElement(By.XPath("//div[@class='header-container']//div[contains(@class,'department-menu')]"));

        IList<IWebElement> DepartmentOptions => DepartmentMenuDropdown.FindElements(By.XPath("//div[@class='header-container']//div[contains(@class,'department-menu')]/ul/li/a"));
    }
}
