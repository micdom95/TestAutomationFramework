using OpenQA.Selenium;
using System.Linq;

namespace Automation_Logic.Handlers
{
    public class FrameHandler
    {
        IWebDriver driver;

        public FrameHandler(IWebDriver driver)
        {
            this.driver = driver;
        }

        public int GetFramesCount()
        {
            int framesCount = driver.FindElements(By.TagName("ifame")).Count();
            return framesCount;
        }

        public void SwitchToFrameByIndex(int index)
        {
            driver.SwitchTo().Frame(index);
        }

        public void SwitchToFrameByID(string id)
        {
            driver.SwitchTo().Frame(id);
        }

        public void SwitchToFrameByWebElement(IWebElement webElement)
        {
            driver.SwitchTo().Frame(webElement);
        }

        public void SwitchToDefaultContent()
        {
            driver.SwitchTo().DefaultContent();
        }

        public void FindFrameForWebElement(By webElementLocation)
        {
            int framesCount = GetFramesCount();

            for (int i = 0; i < framesCount; i++)
            {
                driver.SwitchTo().Frame(i);
                int totalCount = driver.FindElements(webElementLocation).Count();
                SwitchToDefaultContent();
            }
        }
    }
}
