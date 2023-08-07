using OrangeHRMDotNet6TestProject.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

using OrangeHRMDotNet6TestProject.Utilities; //Location of the Driver class
using OpenQA.Selenium;

namespace OrangeHRMDotNet6TestProject.Steps
{
    [Binding]

    public class DashboardSteps
    {
        private readonly DashboardPage _theDashboardPage;
        private readonly PimPage _thePimPage;

        public DashboardSteps() 
        {
            _theDashboardPage = new DashboardPage();
            _thePimPage = new PimPage();
        }

        [When(@"I select the the Admin menu item")]
        public void WhenISelectTheTheAdminMenuItem()
        {
            _theDashboardPage.ClickOnAdminMenuItem();

            
        }

        [When(@"I filter on username ""([^""]*)""")]
        public void WhenIFilterOnUsername(string username)
        {
            _theDashboardPage.EnterUsername(username);
            _theDashboardPage.ClickOnSearchButton();
            Driver.Pause(2000);
        }


        [Then(@"the Username column in all the return rows equal ""([^""]*)""")]
        public void ThenTheUsernameColumnInAllTheReturnRowsEqual(string expectedValue)
        {
            Assert.IsTrue(_theDashboardPage.userNameColumnContainsExpectedValue(expectedValue), "Username column value not as expected");
            
        }

        [When(@"I select the the PIM menu item")]
        public void WhenISelectTheThePIMMenuItem()
        {
            _theDashboardPage.ClickOnPimMenuItem();
        }


    }



}
