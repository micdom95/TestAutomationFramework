using FluentAssertions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSuite.PageObjects.VirtualUniveristy
{
    public class VirtualUniversityPageActions : VirtualUniversityPageLocators
    {
        IWebDriver _driver;

        public VirtualUniversityPageActions(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public Dictionary<string, string> ErrorMessagesDictionary = new Dictionary<string, string>()
        {
            ["EmptyLogin"] = "Wprowadź identyfikator użytkownika w formacie „domena\użytkownik” lub „użytkownik@domena”.",
            ["EmptyPassword"] = "Wprowadź hasło.",
            ["WrongLogin"] = "Nieprawidłowy identyfikator użytkownika lub nieprawidłowe hasło. Wpisz prawidłowy identyfikator użytkownika i hasło, a następnie spróbuj ponownie",
            ["WrongPassword"] = "Nieprawidłowy identyfikator użytkownika lub nieprawidłowe hasło. Wpisz prawidłowy identyfikator użytkownika i hasło, a następnie spróbuj ponownie"
        };

        public void NavigateToVirtualUniversityPage()
        {
            _driver.Navigate().GoToUrl("https://wu.wsb.edu.pl");
            _driver.Url.Should().Contain("https://sts.wsb.edu.pl/adfs/ls/?SAMLRequest=");
        }

        public void ClickLoginButton()
        {
            LoginButton.Displayed.Should().BeTrue();
            LoginButton.Text.Should().Be("Zaloguj");
            LoginButton.Click();
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
