using Automation_Logic.Setup.SecretsConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
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

        [Then(@"I can see correct (.*) language translation on Announcements Page")]
        public void AssertCorrectPolishLanguageTranslationOnUserPage(string language)
        {
            _virtualUniversityUserPageActions.CheckAnnouncementsPageTranslations(language);
        }
    }
}
