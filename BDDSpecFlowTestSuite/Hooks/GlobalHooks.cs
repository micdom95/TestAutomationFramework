using Automation_Logic.Setup.DriverSetup;
using AutomationLogic.Handlers;
using AutomationLogic.Setup;
using BoDi;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace BDDSpecFlowTestSuite.Hooks
{
    [Binding]
    public class GlobalHooks
    {
        IWebDriver _driver;
        IObjectContainer _objectContainer;
        DriverSetup _driverSetup;
        CookiesHandler _cookiesHandler;

        public GlobalHooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void InitializeDriver()
        {
            _driverSetup = new DriverSetup();
            _driver = _driverSetup.ReturnDriver(DriverType.Chrome);
            _objectContainer.RegisterInstanceAs<IWebDriver>(_driver);
        }

        [AfterScenario]
        public void CleanUpData()
        {
            _cookiesHandler = new CookiesHandler(_driver);
            _cookiesHandler.DeleteAllCookies();
            _driver.Quit();
        }
    }
}
