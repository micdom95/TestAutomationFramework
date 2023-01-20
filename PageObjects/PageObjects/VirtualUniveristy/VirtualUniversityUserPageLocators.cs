using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSuite.PageObjects.VirtualUniveristy
{
    public class VirtualUniversityUserPageLocators
    {
        IWebDriver _driver;

        public VirtualUniversityUserPageLocators(IWebDriver driver)
        {
            _driver = driver;
        }

        #region Announcements
        public IWebElement UsernameUserInfoLabel => _driver.FindElement(By.XPath("//span[contains(@class,'nav-top2-user-info-content')]//span[contains(@class,'nav-top2 nav-top2-name')]"));

        public IWebElement UserAlbumUserInfoLabel => _driver.FindElement(By.XPath("//span[contains(@class,'nav-top2-user-info-content')]//span[contains(@class,'nav-top2 nav-top2-number-value')]"));

        public IWebElement AccouncementsTitleLabel => _driver.FindElement(By.XPath("//span[contains(@id,'RightContentPlaceHolder_lblTitle')]"));

        public IWebElement LanguageOptionsDropdown => _driver.FindElement(By.XPath("//div[contains(@class,'pcg-languages-list pcg-dropdown')]"));

        public IList<IWebElement> LanguageOptions => LanguageOptionsDropdown.FindElements(By.XPath("//div[@class='pcg-languages-list pcg-dropdown show']/div[contains(@class,'pcg-lang-option')]/a/div[@class='language-name']"));

        public IWebElement SemesterNumerOptionsDropdown => _driver.FindElement(By.XPath("//label[contains(@id,'lblSemesterNr')]//following-sibling::div"));

        public IWebElement SemesterNumerOptions => SemesterNumerOptionsDropdown.FindElement(By.XPath("//label[contains(@id,'lblSemesterNr')]//following-sibling::div//select"));

        public IWebElement AcademicYearAndSemesterNumerLabel => _driver.FindElement(By.XPath("//table[@class='rgMasterTable']//tbody/tr//span[@id='ctl00_ctl00_ContentPlaceHolder_RightContentPlaceHolder_rgData_ctl00_ctl04_lblHeader']"));

        public IWebElement ClearFilterButton => _driver.FindElement(By.XPath("//input[contains(@id,'RightContentPlaceHolder_btnClear')]"));

        public IWebElement FilterButton => _driver.FindElement(By.XPath("//input[contains(@id,'RightContentPlaceHolder_btnFilter')]"));

        public IWebElement BluredLoadingScreen => _driver.FindElement(By.XPath("//div[@id='ctl00_ctl00_ContentPlaceHolder_RightContentPlaceHolder_appLoadingPanelctl00_ctl00_ContentPlaceHolder_RightContentPlaceHolder_ctl00']"));
        #endregion
    }
}
