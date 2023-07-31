using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TechTalk.SpecFlow;
using OrangeHRMDotNet6TestProject.Pages; //Namespace for your page objects
using OrangeHRMDotNet6TestProject.Utilities; //Location of the Driver class


namespace OrangeHRMDotNet6TestProject.Steps
{
    [Binding]
    public class LoginSteps
    {
        private readonly LoginPage _theLoginPage;
        private readonly DashboardPage _theDashboardPage;

        public LoginSteps()
        {
            _theLoginPage = new LoginPage();
            _theDashboardPage = new DashboardPage();

        }


        [Given(@"I navigate to the Login page")]
        public void GivenINavigateToTheLoginPage()
        {
            _theLoginPage.GotoLoginPage();

            //Pause so we can see the page
            Driver.Pause(2000);
        }

        [When(@"I enter username ""([^""]*)"" and password ""([^""]*)""")]
        public void WhenWhenIEnterUsernameAndPassword(string username, string password)
        {
            _theLoginPage.EnterUserName(username);
            _theLoginPage.EnterPassword(password);
            
            System.Diagnostics.Debug.WriteLine("IN LOGIN PAGE");

            _theLoginPage.ClickOnLoginButton();
        }

        [Then(@"the dashboard page is displayed")]
        public void ThenTheDashboardPageIsDisplayed()
        {
            _theDashboardPage.CheckTitle();
            
            //Pause so we can see the page
            Driver.Pause(2000);

        }

        [Then(@"I click on Leave from the menu")]
        public void ThenIClickOnLeaveFromTheMenu()
        {
            _theDashboardPage.ClickOnNthListElement(2);
            //Pause so we can see the page
            Driver.Pause(2000);
        }

    }
}
