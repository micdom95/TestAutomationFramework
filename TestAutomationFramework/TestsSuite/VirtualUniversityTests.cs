using Automation_Logic.Setup.SecretsConfiguration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSuite.PageObjects.CommonElements;
using TestSuite.PageObjects.VirtualUniveristy;

namespace TestSuite.TestsSuite
{
    [TestFixture]
    public class VirtualUniversityTests
    {
        [Test]
        public void VirtualUniversityLogin_LoginWithEmptyUserNameAndEmptyPassword_DisplayedErrorMessage()
        {
            using (IWebDriver _driver = new ChromeDriver())
            {
                var virtualUniversityLoginPageActions = new VirtualUniversityLoginPageActions(_driver);
                var commonElementsActions = new CommonElementsActions(_driver);
                virtualUniversityLoginPageActions.NavigateToVirtualUniversityPage();
                virtualUniversityLoginPageActions.EnterTextToUsernameTextbox("");
                virtualUniversityLoginPageActions.EnterTextToPasswordTextbox("");
                virtualUniversityLoginPageActions.ClickLoginButton();
                virtualUniversityLoginPageActions.CheckEmptyLoginErrorMessage();

                _driver.Close();
            }
        }

        [Test]
        public void VirtualUniversityLogin_LoginWithUserNameAndEmptyPassword_DisplayedErrorMessage()
        {
            using (IWebDriver _driver = new ChromeDriver())
            {
                var virtualUniversityLoginPageActions = new VirtualUniversityLoginPageActions(_driver);
                var commonElementsActions = new CommonElementsActions(_driver);
                virtualUniversityLoginPageActions.NavigateToVirtualUniversityPage();
                virtualUniversityLoginPageActions.EnterTextToUsernameTextbox("SomeFakeUserName@FakeDomain");
                virtualUniversityLoginPageActions.EnterTextToPasswordTextbox("");
                virtualUniversityLoginPageActions.ClickLoginButton();
                virtualUniversityLoginPageActions.CheckEmptyPasswordErrorMessage();
            }
        }

        [Test]
        public void VirtualUniversityLogin_LoginWithIncorrectUserNameAndIncorrectPassword_DisplayedErrorMessage()
        {
            using (IWebDriver _driver = new ChromeDriver())
            {

                var virtualUniversityLoginPageActions = new VirtualUniversityLoginPageActions(_driver);
                var commonElementsActions = new CommonElementsActions(_driver);
                virtualUniversityLoginPageActions.NavigateToVirtualUniversityPage();
                virtualUniversityLoginPageActions.EnterTextToUsernameTextbox("SomeFakeUserName@FakeDomain");
                virtualUniversityLoginPageActions.EnterTextToPasswordTextbox("SomeFakePassword");
                virtualUniversityLoginPageActions.ClickLoginButton();
                virtualUniversityLoginPageActions.CheckWrongLoginErrorMessage();
            }
        }

        [Test]
        public void VirtualUniversityLogin_LoginWithCorrectCredentials_CorrectLogging()
        {
            using (IWebDriver _driver = new ChromeDriver())
            {
                var virtualUniversityLoginPageActions = new VirtualUniversityLoginPageActions(_driver);
                var commonElementsActions = new CommonElementsActions(_driver);
                var virtualUniversityUserPageActions = new VirtualUniversityUserPageActions(_driver);

                virtualUniversityLoginPageActions.NavigateToVirtualUniversityPage();
                virtualUniversityLoginPageActions.EnterTextToUsernameTextbox(SecretsConfiguration.Instance.UserNameLoginEmail);
                virtualUniversityLoginPageActions.EnterTextToPasswordTextbox(SecretsConfiguration.Instance.UserLoginPassword);
                virtualUniversityLoginPageActions.ClickLoginButton();
                virtualUniversityUserPageActions.CheckDefaultUrlAddressAfterLogIn();
                virtualUniversityUserPageActions.CheckUserInfoLabel(SecretsConfiguration.Instance.UsernameInfo);
                virtualUniversityUserPageActions.CheckUserAlbumNumberUserInfoLabel(SecretsConfiguration.Instance.UserAlbumNumber);
            }
        }

        [Test]
        [Category("Translations - User Page - Polish Language")]
        [Description("This Test will start from Logging Page because we can't do HTTP Request with authorization")]
        public void VirtualUniversityUserPageTranslation_PolishTranslations_CorrectTranslation()
        {
            using (IWebDriver _driver = new ChromeDriver())
            {
                var virtualUniversityLoginPageActions = new VirtualUniversityLoginPageActions(_driver);
                var commonElementsActions = new CommonElementsActions(_driver);
                var virtualUniversityUserPageActions = new VirtualUniversityUserPageActions(_driver);

                virtualUniversityLoginPageActions.NavigateToVirtualUniversityPage();
                virtualUniversityLoginPageActions.EnterTextToUsernameTextbox(SecretsConfiguration.Instance.UserNameLoginEmail);
                virtualUniversityLoginPageActions.EnterTextToPasswordTextbox(SecretsConfiguration.Instance.UserLoginPassword);
                virtualUniversityLoginPageActions.ClickLoginButton();
                virtualUniversityUserPageActions.CheckDefaultUrlAddressAfterLogIn();
                virtualUniversityUserPageActions.CheckUserInfoLabel(SecretsConfiguration.Instance.UsernameInfo);
                virtualUniversityUserPageActions.CheckUserAlbumNumberUserInfoLabel(SecretsConfiguration.Instance.UserAlbumNumber);
                virtualUniversityUserPageActions.CheckAnnouncementsPageTranslations();
            }
        }
    }
}
