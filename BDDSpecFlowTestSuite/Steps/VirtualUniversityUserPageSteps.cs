using Automation_Logic.Setup.SecretsConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TestSuite.Enums;
using TestSuite.PageObjects.VirtualUniveristy;

namespace BDDSpecFlowTestSuite.Steps
{
    [Binding]
    public class VirtualUniversityUserPageSteps
    {
        VirtualUniversityUserPageActions _virtualUniversityUserPageActions;

        public VirtualUniversityUserPageSteps(VirtualUniversityUserPageActions virtualUniversityUserPageActions)
        {
            _virtualUniversityUserPageActions = virtualUniversityUserPageActions;
        }

        [When(@"I wait for Page is loaded and accept alert if exist")]
        public void WaitForPageIsLoadedAndAcceptAlertIfExist()
        {
            _virtualUniversityUserPageActions.WaitForUserPageIsLoaded();
        }

        [When(@"I switch language options dropdown to (.*)")]
        public void SwitchLanguageOptionsDropdownToEnglish(string language)
        {
            Languages languageEnum = (Languages)Enum.Parse(typeof(Languages), language);
            _virtualUniversityUserPageActions.SwitchLanguageOptions(languageEnum);
        }

        [When(@"I select semester numer (.*) in dropdown")]
        public void SelectSemesterNumerInDropdown(string semesterNumer)
        {
            _virtualUniversityUserPageActions.SwitchSemesterNumer(semesterNumer);
        }

        [When(@"I click filter button")]
        public void ClickFilterButton()
        {
            _virtualUniversityUserPageActions.ClickFilterButton();
        }

        [Then(@"I can see default URL Address")]
        public void AssertDefaultURLAddress()
        {
            _virtualUniversityUserPageActions.CheckDefaultUrlAddressAfterLogIn();
        }

        [Then(@"I can see correct User Info")]
        public void AssertCorrectUserInfo()
        {
            _virtualUniversityUserPageActions.CheckUserInfoLabel(SecretsConfiguration.Instance.UsernameInfo);
        }

        [Then(@"I can see correct User Album Number")]
        public void AssertCorrectUserAlbumNumber()
        {
            _virtualUniversityUserPageActions.CheckUserAlbumNumberUserInfoLabel(SecretsConfiguration.Instance.UserAlbumNumber);
        }

        [Then(@"I can see correct (.*) translation on Announcements Page")]
        public void AssertCorrectPolishLanguageTranslationOnUserPage(string language)
        {
            Languages languageEnum = (Languages)Enum.Parse(typeof(Languages), language);
            _virtualUniversityUserPageActions.CheckAnnouncementsPageTranslations(languageEnum);
        }

        [Then(@"I can see correct semester numer (.*) on Announcements Header with (.*) translation")]
        public void AssertCorrectSemesterNumerOnAnnouncementsHeaderWithSelectedTranslation(string semesterNumer, string language)
        {
            Languages languageEnum = (Languages)Enum.Parse(typeof(Languages), language);
            _virtualUniversityUserPageActions.CheckSelectedSemesterNumberOnAnnouncemetsHeader(semesterNumer, languageEnum);
        }

        [Then(@"I can see correct Academic start year (.*) and Academic end year (.*) on Announcements Header with (.*) translation")]
        public void AssertCorrectAcademicStartYearAndAcademicEndYearOnAnnouncementsHeaderWithSpecifiedTranslation(string startAcademicYear, string endAcademicYear, string language)
        {
            Languages languageEnum = (Languages)Enum.Parse(typeof(Languages), language);
            _virtualUniversityUserPageActions.CheckSelectedAcademicYearOnAnnouncemetsHeader(startAcademicYear, endAcademicYear, languageEnum);
        }
    }
}
