using AutomationLogic.Common.Extensions;
using AutomationLogic.Handlers;
using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSuite.Enums;
using TestSuite.Translations;
using TestSuite.Translations.Assertions;

namespace TestSuite.PageObjects.MainPage
{
    public class MainPageActions : MainPageLocators
    {
        private IWebDriver _driver;
        private readonly MainPageTranslations _mainPageTranslationsRepository = new MainPageTranslations();

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
        #region MainPanel
        public void SelectCityFromDropdown()
        {
            DropdownHandler dropdownHandler = new DropdownHandler(_driver, LanguageOptionsDropdown);
            dropdownHandler.SelectElementByIndex(1);
        }

        public void ClickSearchEngineButton()
        {
            SearchEngineButton.Displayed.Should().BeTrue();
            SearchEngineButton.Click();
        }

        public void EnterTextToSearchEngine(string text)
        {
            SearchEngineTextbox.Displayed.Should().BeTrue();
            SearchEngineTextbox.SendKeys(text);
        }

        public void SearchTextInSearchEngine(string textToSearch, Languages languages)
        {
            ClickSearchEngineButton();
            EnterTextToSearchEngine(textToSearch);
            ClickSearchEngineButton();
            string formatedText = textToSearch.Replace(" ", "+");
            string mainPageUrl = languages == Languages.Polish ? $"https://wsb.edu.pl/?gsearch={formatedText}" : $"https://wsb.edu.pl/en?gsearch={formatedText}";
            _driver.Url.Should().Be(mainPageUrl);
        }

        public void CheckSearchResultLabel(string expectedSearchResult)
        {
            SearchResultLabel.Text.Should().Be(expectedSearchResult);
        }

        public void CheckMainPanelTranslations(Languages language)
        {
            StudentButton.CheckIfTextCoitainsTranslation("Student", _mainPageTranslationsRepository, language);
            AdmissionsButton.CheckIfTextCoitainsTranslation("Admissions", _mainPageTranslationsRepository, language);
            ResearchButton.CheckIfTextCoitainsTranslation("Research", _mainPageTranslationsRepository, language);
            UniversityButton.CheckIfTextCoitainsTranslation("University", _mainPageTranslationsRepository, language);
        }
        #endregion
    }
}
