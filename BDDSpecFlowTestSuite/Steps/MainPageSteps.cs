using OpenQA.Selenium;
using PageObjects.Functionalities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TestSuite.Enums;
using TestSuite.PageObjects.MainPage;

namespace BDDSpecFlowTestSuite.Steps
{
    [Binding]
    public class MainPageSteps
    {
        IWebDriver _driver;
        MainPageActions _mainPageActions;
        ChatBot _chatBot;

        public MainPageSteps(IWebDriver driver)
        {
            _driver = driver;
            _mainPageActions = new MainPageActions(_driver);
            _chatBot = new ChatBot(_driver);
        }

        [Given(@"Opened WSB Academy Main Page")]
        [When(@"I navigate to WSB Academy Main Page")]
        public void GivenOpenedWSBAcademyMainPage()
        {
            _mainPageActions.NavigateToWSBMainPage();
        }

        [When(@"I typed phrase (.*) in Search Engine and click search button with selected (.*) page language")]
        public void TypedPhraseInSearchEngineAndClickSearchButton(string phrase, string language)
        {
            Languages languageEnum = (Languages)Enum.Parse(typeof(Languages), language);
            _mainPageActions.SearchTextInSearchEngine(phrase, languageEnum);
        }

        [Then(@"I can see correct default (.*) translation on Main Panel")]
        public void AssertCorrectDefaultTranslationOnMainPanel(string language)
        {
            Languages languageEnum = (Languages)Enum.Parse(typeof(Languages), language);
            _mainPageActions.CheckMainPanelTranslations(languageEnum);
        }

        [Then(@"I can see label with searched phrase (.*)")]
        public void ThenICanSeeLabelWithSearchedPhrase(string expectedSearchResult)
        {
            _mainPageActions.CheckSearchResultLabel(expectedSearchResult);
        }
    }
}
