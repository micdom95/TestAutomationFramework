using FluentAssertions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSuite.PageObjects.MainPage
{
    public class MainPageActions : MainPageLocators
    {
        IWebDriver _driver;

        public MainPageActions(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public void NavigateToWSBMainPage()
        {
            _driver.Navigate().GoToUrl("https://wsb.edu.pl/");
            _driver.Url.Should().Be("https://wsb.edu.pl/");
        }
    }
}
