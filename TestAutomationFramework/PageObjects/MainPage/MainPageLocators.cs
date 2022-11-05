﻿using OpenQA.Selenium;
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

        public IWebElement LanguageOptionsDropdown => _driver.FindElement(By.XPath("//div[@class='header-container']//div[@class='lang-menu']"));

        public IList<IWebElement> LanguageOptions => LanguageOptionsDropdown.FindElements(By.XPath("/ul/li/a"));

        public IWebElement DepartmentMenuDropdown => _driver.FindElement(By.XPath("//div[@class='header-container']//div[contains(@class,'department-menu')]"));

        public IList<IWebElement> DepartmentOptions => DepartmentMenuDropdown.FindElements(By.XPath("//div[@class='header-container']//div[contains(@class,'department-menu')]/ul/li/a"));

        public IWebElement SearchEngineButton => _driver.FindElement(By.XPath("//div[contains(@class,'header-container')]//div[@class='search-overlay']"));

        public IWebElement SearchEngineTextbox => _driver.FindElement(By.XPath("//div[contains(@class,'header-container')]//input[contains(@data-name,'gsearch')]"));

        public IWebElement SearchResultLabel => _driver.FindElement(By.XPath("//div[@class='search-header clearfix']//span//b"));
    }
}
