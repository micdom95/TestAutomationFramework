using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationLogic.Handlers
{
    public class DropdownHandler
    {
        public IWebDriver driver { get; set; }
        public SelectElement select { get; set; }

        public DropdownHandler(IWebDriver driver, SelectElement select)
        {
            this.driver = driver;
            this.select = select;
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
