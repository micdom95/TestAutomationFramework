using Automation_Logic.Setup.DriverSetup;
using AutomationLogic.Setup;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSuite
{
    [SetUpFixture]
    public class SetUpTestsConfiguration
    {
        DriverType _driverType;
        IWebDriver _driver;
        DriverSetup _driverSetup;

        public SetUpTestsConfiguration()
        {

        }

        public SetUpTestsConfiguration(DriverType driverType)
        {
            _driverType = driverType;
        }

        [OneTimeSetUp]
        public void TestConfigurationSetUp()
        {
            _driverSetup = new DriverSetup();
            _driver = _driverSetup.ReturnDriver(_driverType);
        }

        [OneTimeTearDown]
        public void TestConfigurationTearDown()
        {
            _driver.Quit();
        }
    }
}
