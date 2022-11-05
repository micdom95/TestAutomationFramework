using AutomationLogic.Common.Extensions;
using FluentAssertions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSuite.PageObjects.MainPage
{
    public class MainPageActions : MainPageLocators
    {
        IWebDriver _driver;

        public MainPageActions(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public Dictionary<string, string> languageDropdownDictionaryData = new Dictionary<string, string>()
        {
            ["PL"] = "https://wsb.edu.pl/",
            ["EN"] = "https://wsb.edu.pl/en",
            ["RU"] = "https://wsb.edu.pl/ru"
        };

        public Dictionary<string, string> departmentDropdownDictionaryData = new Dictionary<string, string>()
        {
            ["Dąbrowa Górnicza"] = "https://wsb.edu.pl/",
            ["Cieszyn"] = "https://wsb.edu.pl/cieszyn",
            ["Kraków"] = "https://wsb.edu.pl/krakow",
            ["Olkusz"] = "https://wsb.edu.pl/olkusz",
            ["Żywiec"] = "https://wsb.edu.pl/zywiec"
        };

        public void NavigateToWSBMainPage()
        {
            string wsbMainPageUrl = "https://wsb.edu.pl/";
            _driver.Navigate().GoToUrl(wsbMainPageUrl);
            WaitForActions.WaitForPageIsLoaded(_driver);
            _driver.Url.Should().Be(wsbMainPageUrl);
        }

        public void ClickSearchEngineButton()
        {
            SearchEngineButton.Displayed.Should().BeTrue();
            SearchEngineButton.Click();
        }

        public void EnterTextToSearchEngine(string text)
        {
            SearchEngineTextbox.Displayed.Should().BeTrue();
            //SearchEngineTextbox.Click();
            SearchEngineTextbox.SendKeys(text);
        }

        public void SearchTextInSearchEngine(string textToSearch)
        {
            ClickSearchEngineButton();
            EnterTextToSearchEngine(textToSearch);
            ClickSearchEngineButton();
            _driver.Url.Should().Be($"https://wsb.edu.pl/?gsearch={textToSearch}");
            SearchResultLabel.Text.Should().Be(textToSearch);
        }
    }
}
