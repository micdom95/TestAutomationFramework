using Automation_Logic.Setup.SecretsConfiguration;
using AutomationLogic.Common.Extensions;
using FluentAssertions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSuite.Enums;
using TestSuite.Model;
using TestSuite.Translations;
using TestSuite.Translations.Assertions;

namespace TestSuite.PageObjects.VirtualUniveristy
{
    public class VirtualUniversityUserPageActions : VirtualUniversityUserPageLocators
    {
        IWebDriver _driver;
        private readonly VirtualUniversityUserPageTranslations _virtualUniversityUserPageTranslations = new VirtualUniversityUserPageTranslations();

        public VirtualUniversityUserPageActions(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public void CheckDefaultUrlAddressAfterLogIn()
        {
            WaitForActions.CheckIfAlertIsDisplayedAndAccept(_driver);
            _driver.Url.Should().Be(SecretsConfiguration.Instance.DefaultLogInUrl);
        }

        public void CheckUserInfoLabel(string username)
        {
            UsernameUserInfoLabel.Displayed.Should().BeTrue();
            UsernameUserInfoLabel.Text.Should().Be(username);
        }

        public void CheckUserAlbumNumberUserInfoLabel(string userAlbumNumber)
        {
            UserAlbumUserInfoLabel.Displayed.Should().BeTrue();
            UserAlbumUserInfoLabel.Text.Should().Be(userAlbumNumber);
        }

        public void CheckAnnouncementsPageTranslations(Languages language)
        {
            AccouncementsTitleLabel.CheckIfTextCoitainsTranslation("AccouncementsTitleLabel", _virtualUniversityUserPageTranslations, language);
            if (language.Equals(Languages.Polish))
            {
                ClearFilterButton.GetAttribute("value").Should().Be("Wyczyść");
                FilterButton.GetAttribute("value").Should().Be("Filtruj");
            }
            else if(language.Equals(Languages.English))
            {
                ClearFilterButton.GetAttribute("value").Should().Be("Clear");
                FilterButton.GetAttribute("value").Should().Be("Filter");
            }
        }
    }
}
