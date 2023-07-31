using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium; //Need this for By to work
using OrangeHRMDotNet6TestProject.Utilities; //Need this to access Driver class amd the other Utilities classes
//Or Can use something like this, and will not have to include the class name when calling the method
using static OrangeHRMDotNet6TestProject.Utilities.SelectElements;
using static OrangeHRMDotNet6TestProject.Utilities.ManipulateElements;
using static OrangeHRMDotNet6TestProject.Utilities.Driver;

namespace OrangeHRMDotNet6TestProject.Pages
{
    public class LoginPage
    {
        //Constructor
        public LoginPage() 
        {}


        //WebElements
        private readonly By _userNameLocator = By.CssSelector("[name='username']");
        private readonly By _passwordLocator = By.CssSelector("[name='password']");
        private readonly By _loginbButtonLocator = By.CssSelector("button[type='submit']");


        //Methods
        public void GotoLoginPage()
        {
            NavigateTo(Driver.RootURL);
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
