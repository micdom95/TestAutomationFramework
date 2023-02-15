using FluentAssertions;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace TestSuite.PageObjects.VirtualUniveristy
{
    public class VirtualUniversityLoginPageActions : VirtualUniversityLoginPageLocators
    {
        IWebDriver _driver;

        public VirtualUniversityLoginPageActions(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public Dictionary<string, string> ErrorMessagesDictionary = new Dictionary<string, string>()
        {
            ["EmptyLogin"] = @"Wprowadź identyfikator użytkownika w formacie „domena\użytkownik” lub „użytkownik@domena”.",
            ["EmptyPassword"] = "Wprowadź hasło.",
            ["WrongLogin"] = "Nieprawidłowy identyfikator użytkownika lub nieprawidłowe hasło. Wpisz prawidłowy identyfikator użytkownika i hasło, a następnie spróbuj ponownie.",
            ["WrongPassword"] = "Nieprawidłowy identyfikator użytkownika lub nieprawidłowe hasło. Wpisz prawidłowy identyfikator użytkownika i hasło, a następnie spróbuj ponownie."
        };

        public void NavigateToVirtualUniversityPage()
        {
            _driver.Navigate().GoToUrl("https://wu.wsb.edu.pl");
            CheckLoginPageUrl();
        }

        public void EnterTextToUsernameTextbox(string userName)
        {
            UsernameTextbox.Displayed.Should().BeTrue();
            UsernameTextbox.SendKeys(userName);
        }

        public void EnterTextToPasswordTextbox(string password)
        {
            PasswordTextbox.Displayed.Should().BeTrue();
            PasswordTextbox.SendKeys(password);
        }

        public void ClickLoginButton()
        {
            LoginButton.Displayed.Should().BeTrue();
            LoginButton.Text.Should().Be("Zaloguj");
            LoginButton.Click();
        }

        public void CheckLoginPageUrl()
        {
            _driver.Url.Should().Contain("https://sts.wsb.edu.pl/adfs/ls/?SAMLRequest=");
        }

        public void CheckEmptyLoginErrorMessage()
        {
            ErrorMessage.Text.Should().Be(ErrorMessagesDictionary["EmptyLogin"]);
        }

        public void CheckEmptyPasswordErrorMessage()
        {
            ErrorMessage.Text.Should().Be(ErrorMessagesDictionary["EmptyPassword"]);
        }

        public void CheckWrongLoginErrorMessage()
        {
            ErrorMessage.Text.Should().Be(ErrorMessagesDictionary["WrongLogin"]);
        }

        public void CheckWrongPasswordErrorMessage()
        {
            ErrorMessage.Text.Should().Be(ErrorMessagesDictionary["WrongPassword"]);
        }
    }
}
