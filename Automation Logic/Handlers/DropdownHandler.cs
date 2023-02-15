using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationLogic.Handlers
{
    public class DropdownHandler
    {
        private IWebDriver driver { get; set; }
        private SelectElement select { get; set; }

        public DropdownHandler(IWebDriver driver, IWebElement webElement)
        {
            this.driver = driver;
            select = new SelectElement(webElement);
        }

        public void SelectElementByIndex(int index)
        {
            select.SelectByIndex(index);
        }

        public void SelectElementByValue(string value)
        {
            select.SelectByValue(value);
        }

        public void SelectElementByText(string text)
        {
            select.SelectByText(text);
        }

        public void DeselectAllElements()
        {
            select.DeselectAll();
        }

        public void DeselectElementByIndex(int index)
        {
            select.DeselectByIndex(index);
        }

        public void DeselectElementByValue(string value)
        {
            select.DeselectByValue(value);
        }

        public void DeselectElementByText(string text)
        {
            select.DeselectByText(text);
        }
    }
}
