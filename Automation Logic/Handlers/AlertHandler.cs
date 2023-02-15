using FluentAssertions;
using OpenQA.Selenium;

namespace Automation_Logic.Handlers
{
    public class AlertHandler
    {
        IWebDriver driver;

        public AlertHandler(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IAlert SwitchToAlert()
        {
            IAlert alert = driver.SwitchTo().Alert();
            return alert;
        }

        public void AcceptAlert()
        {
            SwitchToAlert().Accept();
        }

        public void DismissAlert()
        {
            SwitchToAlert().Dismiss();
        }

        public string GetAlertMessage()
        {
            var alert = SwitchToAlert();
            var alertMessage = alert.Text;
            return alertMessage;
        }

        public void AssertAlertMessage(string message)
        {
            SwitchToAlert();
            var alertMessage = GetAlertMessage();
            alertMessage.Should().Be(alertMessage);
        }

        public void SendKeysToAlert(string text)
        {
            var alert = SwitchToAlert();
            alert.SendKeys(text);
        }
    }
}
