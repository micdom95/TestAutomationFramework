using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
namespace AutomationLogic.Common.Extensions
{
    public static class WaitForActions
    {
        public static void WaitForPageIsLoaded(this IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until((x) =>
            {
                return ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete");
            });
        }

        public static IWebElement WaitUntilElementExists(this IWebDriver driver, By elementLocator, int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                return wait.Until(ExpectedConditions.ElementExists(elementLocator));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + elementLocator + "' was not found in current context page.");
                throw;
            }
        }

        public static IWebElement WaitUntilElementVisible(this IWebDriver driver, By elementLocator, int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                return wait.Until(ExpectedConditions.ElementIsVisible(elementLocator));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + elementLocator + "' was not found.");
                throw;
            }
        }

        public static bool WaitUntilElementDisapear(this IWebDriver driver, By elementLocator, int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                return wait.Until(ExpectedConditions.InvisibilityOfElementLocated(elementLocator));
            }
            catch
            {

            }
            return false;
        }

        public static IWebElement WaitUntilElementClickable(this IWebDriver driver, IWebElement webElement, int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                return wait.Until(ExpectedConditions.ElementToBeClickable(webElement));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + webElement.TagName + "' was not found in current context page.");
                throw;
            }
        }

        public static IWebDriver WaitUntilFrameIsAvailable(this IWebDriver driver, string frameLocator, int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                return wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(frameLocator));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Frame with locator: '" + frameLocator + "' was not found in current context page.");
                throw;
            }
        }

        public static IAlert WaitUntilAlertIsDisplayed(this IWebDriver driver, int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                return wait.Until(ExpectedConditions.AlertIsPresent());
            }
            catch (Exception)
            {
                Console.WriteLine("Alert is not displayed.");
                throw;
            }
        }

        public static void CheckIfAlertIsDisplayedAndAccept(this IWebDriver driver, int timeout = 10)
        {
            try
            {
                IAlert alert = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout)).Until(ExpectedConditions.AlertIsPresent());
                driver.SwitchTo().Alert().Accept();
            }
            catch
            {

            }
        }
    }
}
