using Automation_Logic.Setup.DriverSetup;
using Automation_Logic.Setup.SecretsConfiguration;
using AutomationLogic.Setup;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSuite.Enums;
using TestSuite.PageObjects.CommonElements;
using TestSuite.PageObjects.VirtualUniveristy;

namespace TestSuite.TestsSuite
{
    using static SetUpTestsConfiguration;
    
    [TestFixture]
    public class VirtualUniversityTests
    {
        DriverSetup _driverSetup;
        IWebDriver _driver;
        VirtualUniversityLoginPageActions _virtualUniversityLoginPageActions;

        [SetUp]
        public void SetUpVirtualUniversityTestsFixture()
        {
            _driverSetup = new DriverSetup();
            _driver = _driverSetup.ReturnDriver(_driverType);
            _virtualUniversityLoginPageActions = new VirtualUniversityLoginPageActions(_driver);
        }

        [Test]
        [Category("Login Page")]
        [Parallelizable]
        public void VirtualUniversityLogin_LogInWithEmptyUserNameAndEmptyPassword_DisplayedErrorMessage()
        {
            _virtualUniversityLoginPageActions.NavigateToVirtualUniversityPage();
            _virtualUniversityLoginPageActions.EnterTextToUsernameTextbox("");
            _virtualUniversityLoginPageActions.EnterTextToPasswordTextbox("");
            _virtualUniversityLoginPageActions.ClickLoginButton();
            _virtualUniversityLoginPageActions.CheckEmptyLoginErrorMessage();
        }

        [Test]
        [Category("Login Page")]
        [Parallelizable]
        public void VirtualUniversityLogin_LoginWithUserNameAndEmptyPassword_DisplayedErrorMessage()
        {
            _virtualUniversityLoginPageActions.NavigateToVirtualUniversityPage();
            _virtualUniversityLoginPageActions.EnterTextToUsernameTextbox("SomeFakeUserName@FakeDomain");
            _virtualUniversityLoginPageActions.EnterTextToPasswordTextbox("");
            _virtualUniversityLoginPageActions.ClickLoginButton();
            _virtualUniversityLoginPageActions.CheckEmptyPasswordErrorMessage();
        }

        [Test]
        [Category("Login Page")]
        [Parallelizable]
        public void VirtualUniversityLogin_LoginWithIncorrectUserNameAndIncorrectPassword_DisplayedErrorMessage()
        {
            _virtualUniversityLoginPageActions.NavigateToVirtualUniversityPage();
            _virtualUniversityLoginPageActions.EnterTextToUsernameTextbox("SomeFakeUserName@FakeDomain");
            _virtualUniversityLoginPageActions.EnterTextToPasswordTextbox("SomeFakePassword");
            _virtualUniversityLoginPageActions.ClickLoginButton();
            _virtualUniversityLoginPageActions.CheckWrongLoginErrorMessage();
        }

        [Test]
        [Category("Login Page")]
        [Parallelizable]
        public void VirtualUniversityLogin_LoginWithCorrectCredentials_CorrectLogging()
        {

            var virtualUniversityUserPageActions = new VirtualUniversityUserPageActions(_driver);

            _virtualUniversityLoginPageActions.NavigateToVirtualUniversityPage();
            _virtualUniversityLoginPageActions.EnterTextToUsernameTextbox(SecretsConfiguration.Instance.UserNameLoginEmail);
            _virtualUniversityLoginPageActions.EnterTextToPasswordTextbox(SecretsConfiguration.Instance.UserLoginPassword);
            _virtualUniversityLoginPageActions.ClickLoginButton();
            virtualUniversityUserPageActions.CheckDefaultUrlAddressAfterLogIn();
            virtualUniversityUserPageActions.CheckUserInfoLabel(SecretsConfiguration.Instance.UsernameInfo);
            virtualUniversityUserPageActions.CheckUserAlbumNumberUserInfoLabel(SecretsConfiguration.Instance.UserAlbumNumber);
        }

        [Test]
        [Category("Translations - User Page - Polish Language")]
        [Description("This Test will start from Logging Page because we can't do HTTP Request with authorization")]
        [Parallelizable]
        public void VirtualUniversityUserPageTranslation_PolishTranslations_CorrectTranslation()
        {
            var virtualUniversityUserPageActions = new VirtualUniversityUserPageActions(_driver);

            _virtualUniversityLoginPageActions.NavigateToVirtualUniversityPage();
            _virtualUniversityLoginPageActions.EnterTextToUsernameTextbox(SecretsConfiguration.Instance.UserNameLoginEmail);
            _virtualUniversityLoginPageActions.EnterTextToPasswordTextbox(SecretsConfiguration.Instance.UserLoginPassword);
            _virtualUniversityLoginPageActions.ClickLoginButton();
            virtualUniversityUserPageActions.CheckDefaultUrlAddressAfterLogIn();
            virtualUniversityUserPageActions.CheckUserInfoLabel(SecretsConfiguration.Instance.UsernameInfo);
            virtualUniversityUserPageActions.CheckUserAlbumNumberUserInfoLabel(SecretsConfiguration.Instance.UserAlbumNumber);
            virtualUniversityUserPageActions.CheckAnnouncementsPageTranslations(Languages.Polish);
        }

        [Test]
        [Category("Translations - User Page - English Language")]
        [Description("This Test will start from Logging Page because we can't do HTTP Request with authorization")]
        [Parallelizable]
        public void VirtualUniversityUserPageTranslation_EnglishTranslations_CorrectTranslation()
        {
            var virtualUniversityUserPageActions = new VirtualUniversityUserPageActions(_driver);

            _virtualUniversityLoginPageActions.NavigateToVirtualUniversityPage();
            _virtualUniversityLoginPageActions.EnterTextToUsernameTextbox(SecretsConfiguration.Instance.UserNameLoginEmail);
            _virtualUniversityLoginPageActions.EnterTextToPasswordTextbox(SecretsConfiguration.Instance.UserLoginPassword);
            _virtualUniversityLoginPageActions.ClickLoginButton();
            virtualUniversityUserPageActions.CheckDefaultUrlAddressAfterLogIn();
            virtualUniversityUserPageActions.CheckUserInfoLabel(SecretsConfiguration.Instance.UsernameInfo);
            virtualUniversityUserPageActions.CheckUserAlbumNumberUserInfoLabel(SecretsConfiguration.Instance.UserAlbumNumber);
            virtualUniversityUserPageActions.SwitchLanguageOptionsByText(Languages.English);
            virtualUniversityUserPageActions.CheckAnnouncementsPageTranslations(Languages.English);
        }

        [TearDown]
        public void TearDownVirtualUniversityTestFixture()
        {
            _driver.Quit();
        }
    }
}
