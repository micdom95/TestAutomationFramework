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
        public static DriverType _driverType;

        public SetUpTestsConfiguration()
        {

        }

        public SetUpTestsConfiguration(DriverType driverType = DriverType.Chrome)
        {
            _driverType = driverType;
        }

        [OneTimeSetUp]
        public void TestConfigurationSetUp()
        {

        }

        [OneTimeTearDown]
        public void TestConfigurationTearDown()
        {

        }
    }
}
