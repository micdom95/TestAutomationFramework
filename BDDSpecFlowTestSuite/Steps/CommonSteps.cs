using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TestSuite.PageObjects.CommonElements;

namespace BDDSpecFlowTestSuite.Steps
{
    [Binding]
    public class CommonSteps
    {
        CommonElementsActions _commonElementsActions;

        public CommonSteps(CommonElementsActions commonElementsActions)
        {
            _commonElementsActions = commonElementsActions;
        }

        [Given(@"Cookies are accepted by button clicking")]
        [When(@"I click Accept Cookie button")]
        public void ClickAcceptCookieButton()
        {
            _commonElementsActions.ClickAcceptCookieButton();
        }

        [Given(@"Notifications are agreed by button clicking")]
        [When(@"I click Agree Notification button")]
        public void ClickAgreeNotificationButton()
        {
            _commonElementsActions.ClickAgreeNotificationButton();
        }
    }
}
