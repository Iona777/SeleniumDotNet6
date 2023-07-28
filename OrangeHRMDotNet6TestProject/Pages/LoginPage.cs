using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium; //Need this for By to work
using OrangeHRMDotNet6TestProject.Utilities; //Need this to access Driver class

namespace OrangeHRMDotNet6TestProject.Pages
{
    public class LoginPage: BasePage
    {
        //Constructor
        //It will just use the one from BasePage unless it needs something extra.


        //WebElements
        private readonly By _userNameLocator = By.CssSelector("[name='username']");
        private readonly By _passwordLocator = By.CssSelector("[name='password']");
        private readonly By _loginbButtonLocator = By.CssSelector("button[type='submit']");


        //Methods
        public void GotoLoginPage()
        {
            Driver.NavigateTo(Driver.RootURL);
        }

        public void EnterUserName(string userName)
        {
            EnterText(_userNameLocator, userName,10);
        }

        public void EnterPassword(string password)
        {
            EnterText(_passwordLocator,password, 5);
        }

        public void ClickOnLoginButton()
        {
            ClickOnElement(_loginbButtonLocator);
        }

    }
}
