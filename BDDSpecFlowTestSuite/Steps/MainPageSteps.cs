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
        MainPageActions _mainPageActions;
        ChatBot _chatBot;

        public MainPageSteps(MainPageActions mainPageActions, ChatBot chatBot)
        {
            _mainPageActions = mainPageActions;
            _chatBot = chatBot;
        }

        [Given(@"Opened WSB Academy Main Page")]
        [When(@"I navigate to WSB Academy Main Page")]
        public void GivenOpenedWSBAcademyMainPage()
        {
            _mainPageActions.NavigateToWSBMainPage();
        }

        [When(@"I typed phrase (.*) in Search Engine and click search button")]
        public void TypedPhraseInSearchEngineAndClickSearchButton(string phrase)
        {
            _mainPageActions.EnterTextToSearchEngine(phrase);
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
