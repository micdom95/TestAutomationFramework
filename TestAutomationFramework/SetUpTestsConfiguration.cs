using Automation_Logic.Setup.DriverSetup;
using NUnit.Framework;

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
