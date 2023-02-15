using OpenQA.Selenium;
using System.Collections.Generic;

namespace AutomationLogic.Handlers
{
    public class CookiesHandler
    {
        IWebDriver driver;

        public CookiesHandler(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void AddCookie(string key, string value)
        {
            var cookie = new Cookie(key, value);
            driver.Manage().Cookies.AddCookie(cookie);
        }

        public IList<Cookie> GetAllCookies()
        {
            var cookies = driver.Manage().Cookies.AllCookies;
            return cookies;
        }

        public void DeleteAllCookies()
        {
            driver.Manage().Cookies.DeleteAllCookies();
        }

        public void DeleteCookieByName(string cookieName)
        {
            driver.Manage().Cookies.DeleteCookieNamed(cookieName);
        }
    }
}
