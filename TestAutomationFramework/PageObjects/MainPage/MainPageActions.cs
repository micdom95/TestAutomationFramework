using AutomationLogic.Common.Extensions;
using FluentAssertions;
using OpenQA.Selenium;
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
        private Languages _languages;
        private readonly MainPageTranslations _mainPageTranslationsRepository = new MainPageTranslations();

        public MainPageActions(IWebDriver driver, Languages language) : base(driver)
        {
            _driver = driver;
            _languages = language;
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
            SearchEngineTextbox.SendKeys(text);
        }

        public void SearchTextInSearchEngine(string textToSearch)
        {
            ClickSearchEngineButton();
            EnterTextToSearchEngine(textToSearch);
            ClickSearchEngineButton();
            string formatedText = textToSearch.Replace(" ", "+");
            string mainPageUrl = _languages == Languages.Polish ? $"https://wsb.edu.pl/?gsearch={formatedText}" : $"https://wsb.edu.pl/en?gsearch={formatedText}";
            _driver.Url.Should().Be(mainPageUrl);
            SearchResultLabel.Text.Should().Be(textToSearch);
        }

        public void CheckMainPanelTranslations()
        {
            StudentButton.CheckIfTextCoitainsTranslation("Student", _mainPageTranslationsRepository);
            AdmissionsButton.CheckIfTextCoitainsTranslation("Admissions", _mainPageTranslationsRepository);
            ResearchButton.CheckIfTextCoitainsTranslation("Research", _mainPageTranslationsRepository);
            UniversityButton.CheckIfTextCoitainsTranslation("University", _mainPageTranslationsRepository);
        }
    }
}
