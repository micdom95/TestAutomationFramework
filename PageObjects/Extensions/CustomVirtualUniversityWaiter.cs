using OpenQA.Selenium;
using System;

namespace PageObjects.Extensions
{
    public static class CustomVirtualUniversityWaiter
    {
        public static void WaitUntilElementVisible(this IWebDriver driver, By by, int timeout = 5000)
        {
            while (!IsElement(driver, by) && timeout > 0)
            {
                timeout -= 10;
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(10);
            }
        }

        public static void WaitElementDisspear(this IWebDriver driver, By by, int timeout = 5000)
        {
            while (IsElement(driver, by) && timeout > 0)
            {
                timeout -= 10;
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(10);
            }
        }

        public static bool IsElement(this IWebDriver driver, By by)
        {
            try { return driver.FindElement(by) != null; }
            catch { return false; }
        }
    }
}
