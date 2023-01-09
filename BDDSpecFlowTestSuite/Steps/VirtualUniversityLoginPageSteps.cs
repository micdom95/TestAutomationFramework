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
    public class VirtualUniversityLoginPageSteps
    {
        VirtualUniversityLoginPageActions _virtualUniversityLoginPageActions;

        public VirtualUniversityLoginPageSteps(VirtualUniversityLoginPageActions virtualUniversityLoginPageActions)
        {
            _virtualUniversityLoginPageActions = virtualUniversityLoginPageActions;
        }

        [Given(@"Opened Virtual University Login Page")]
        public void OpenVirtualUniversityLoginPage()
        {
            _virtualUniversityLoginPageActions.NavigateToVirtualUniversityPage();
        }

        [When(@"I enter text (.*) to Username field")]
        public void EnterLoginLoginToUserNameField(string userName)
        {
            _virtualUniversityLoginPageActions.EnterTextToUsernameTextbox(userName);
        }

        [When(@"I enter correct Username to Username field")]
        public void WhenIEnterCorrectUserNameToUserNameField()
        {
            _virtualUniversityLoginPageActions.EnterTextToUsernameTextbox(SecretsConfiguration.Instance.UserNameLoginEmail);
        }

        [When(@"I enter text (.*) to Password field")]
        public void EnterTextToPasswordField()
        {
            _virtualUniversityLoginPageActions.CheckWrongPasswordErrorMessage();
        }

        [When(@"I enter correct Password to Password field")]
        public void WhenIEnterCorrectPasswordToPasswordField()
        {
            _virtualUniversityLoginPageActions.EnterTextToPasswordTextbox(SecretsConfiguration.Instance.UserLoginPassword);
        }


        [When(@"I click login button")]
        public void ClickLoginButton()
        {
            _virtualUniversityLoginPageActions.ClickLoginButton();
        }

        [Then(@"I can see Empty Login Error Message")]
        public void AssertEmptyLoginErrorMessage()
        {
            _virtualUniversityLoginPageActions.CheckEmptyLoginErrorMessage();
        }

        [Then(@"I can see Empty Password Error Message")]
        public void AssertEmptyPasswordErrorMessage()
        {
            _virtualUniversityLoginPageActions.CheckEmptyPasswordErrorMessage();
        }

        [Then(@"I can see Wrong Login Error Message")]
        public void AssertyWrongLoginErrorMessage()
        {
            _virtualUniversityLoginPageActions.CheckWrongLoginErrorMessage();
        }

    }
}
