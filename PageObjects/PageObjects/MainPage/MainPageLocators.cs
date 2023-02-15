using OpenQA.Selenium;
using System.Collections.Generic;

namespace TestSuite.PageObjects.MainPage
{
    public class MainPageLocators
    {
        private IWebDriver _driver;

        public MainPageLocators(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement LanguageOptionsDropdown => _driver.FindElement(By.XPath("//div[@class='header-container']//div[@class='lang-menu']"));

        public IList<IWebElement> LanguageOptions => LanguageOptionsDropdown.FindElements(By.XPath("/ul/li/a"));

        public IWebElement DepartmentMenuDropdown => _driver.FindElement(By.XPath("//div[@class='header-container']//div[contains(@class,'department-menu')]"));

        public IList<IWebElement> DepartmentOptions => DepartmentMenuDropdown.FindElements(By.XPath("//div[@class='header-container']//div[contains(@class,'department-menu')]/ul/li/a"));

        public IWebElement SearchEngineButton => _driver.FindElement(By.XPath("//div[contains(@class,'header-container')]//div[@class='search-overlay']"));

        public IWebElement SearchEngineTextbox => _driver.FindElement(By.XPath("//div[contains(@class,'header-container')]//input[contains(@data-name,'gsearch')]"));

        public IWebElement SearchResultLabel => _driver.FindElement(By.XPath("//div[@class='search-header clearfix']//span//b"));

        public IWebElement UniversityLogo => _driver.FindElement(By.XPath("//div[@class='header-container']//div/div//a[@class='logo']//*[@id='logo']//*[text()='WSB University']"));

        public IWebElement StudentButton => _driver.FindElement(By.XPath("//div[@class='header-container']//div[@class='main-menu']//li[@data-id='589']"));

        public IWebElement AdmissionsButton => _driver.FindElement(By.XPath("//div[@class='header-container']//div[@class='main-menu']//li[@data-id='590']"));

        public IWebElement ResearchButton => _driver.FindElement(By.XPath("//div[@class='header-container']//div[@class='main-menu']//li[@data-id='591']"));

        public IWebElement UniversityButton => _driver.FindElement(By.XPath("//div[@class='header-container']//div[@class='main-menu']//li[@data-id='592']"));

        #region ChatBot

        public IWebElement ChatBotLauncherButtonFrame => _driver.FindElement(By.XPath("//iframe[@id='usercom-launcher-dot-frame']"));

        public IWebElement ChatBotLauncherButton => _driver.FindElement(By.XPath("//div[@class='usercom-launcher-dot']"));

        public IWebElement ChatBotUserBoardFrame => _driver.FindElement(By.XPath("//iframe[@id='usercom-board-frame']"));

        public IWebElement ChatBotGlobalContainer => _driver.FindElement(By.XPath("//div[@class='usercom-current-view']"));

        #endregion
    }
}
