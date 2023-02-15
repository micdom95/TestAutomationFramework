using Automation_Logic.Setup.SecretsConfiguration;
using AutomationLogic.Common.Extensions;
using AutomationLogic.Handlers;
using FluentAssertions;
using OpenQA.Selenium;
using PageObjects.Extensions;
using System.Linq;
using TestSuite.Enums;
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

        public void ClickFilterButton()
        {
            FilterButton.Displayed.Should().BeTrue();
            IJavaScriptExecutor javaScriptExecutor = ((IJavaScriptExecutor)_driver);
            javaScriptExecutor.ExecuteScript("arguments[0].click();", FilterButton);
            CustomVirtualUniversityWaiter.WaitUntilElementVisible(_driver, By.XPath("//div[@id='ctl00_ctl00_ContentPlaceHolder_RightContentPlaceHolder_appLoadingPanelctl00_ctl00_ContentPlaceHolder_RightContentPlaceHolder_ctl00']"));
            CustomVirtualUniversityWaiter.WaitElementDisspear(_driver, By.XPath("//div[@id='ctl00_ctl00_ContentPlaceHolder_RightContentPlaceHolder_appLoadingPanelctl00_ctl00_ContentPlaceHolder_RightContentPlaceHolder_ctl00']"));
        }

        public void CheckDisplayingAlertAndAcceptIfExist()
        {
            WaitForActions.CheckIfAlertIsDisplayedAndAccept(_driver);
        }

        public void WaitForUserPageIsLoaded()
        {
            CheckDisplayingAlertAndAcceptIfExist();
            WaitForActions.WaitForPageIsLoaded(_driver);
        }

        public void CheckDefaultUrlAddressAfterLogIn()
        {
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

        public void SwitchSemesterNumer(string semesterNumer)
        {
            SemesterNumerOptionsDropdown.Displayed.Should().BeTrue();
            SemesterNumerOptionsDropdown.Click();
            var dropdownHandler = new DropdownHandler(_driver, SemesterNumerOptions);
            dropdownHandler.SelectElementByValue(semesterNumer);
            WaitForActions.WaitUntilElementClickable(_driver, FilterButton);
        }

        public void CheckSelectedSemesterNumberOnAnnouncemetsHeader(string semesterNumer, Languages language)
        {
            if (language.Equals(Languages.Polish))
            {
                AcademicYearAndSemesterNumerLabel.Text.Should().Contain($"semestr {semesterNumer}");
            }
            else if (language.Equals(Languages.English))
            {
                AcademicYearAndSemesterNumerLabel.Text.Should().BeNull();
            }
        }

        public void CheckSelectedAcademicYearOnAnnouncemetsHeader(string startAcademicYear, string endAcademicYear, Languages language)
        {
            if (language.Equals(Languages.Polish))
            {
                AcademicYearAndSemesterNumerLabel.Text.Should().Contain($"Rok akademicki {startAcademicYear}/{endAcademicYear}");
            }
            else if (language.Equals(Languages.English))
            {
                AcademicYearAndSemesterNumerLabel.Text.Should().BeNull();
            }
        }

        public void SwitchLanguageOptions(Languages language)
        {
            LanguageOptionsDropdown.Displayed.Should().BeTrue();
            LanguageOptionsDropdown.Click();

            if (language.Equals(Languages.Polish))
            {
                LanguageOptions.FirstOrDefault(languageOption => languageOption.Text == "PL").Click();
            }
            else if (language.Equals(Languages.English))
            {
                LanguageOptions.FirstOrDefault(languageOption => languageOption.Text == "EN").Click();
            }
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
