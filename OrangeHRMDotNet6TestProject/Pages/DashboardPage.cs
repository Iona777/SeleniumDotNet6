using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V112.DOM;
using OrangeHRMDotNet6TestProject.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

using static OrangeHRMDotNet6TestProject.Utilities.GetElements;
using static OrangeHRMDotNet6TestProject.Utilities.ManipulateElements;
using static OrangeHRMDotNet6TestProject.Utilities.SelectElements;
using static OrangeHRMDotNet6TestProject.Utilities.Tables;

namespace OrangeHRMDotNet6TestProject.Pages
{
    public class DashboardPage
    {
        //Constructor
        public DashboardPage() { }
        //May need an empty one (NoArgConstructor, does that exist in C#?) when refactoring without Base page

        string DashboardTitle = "OrangeHRM";

        //WebElement locators
        private readonly By _listItemsLocator = By.CssSelector("li[class='oxd-main-menu-item-wrapper']");
        private readonly string _adminHref = "/web/index.php/admin/viewAdminModule";
        private readonly string _pinHref = "/web/index.php/pim/viewPimModule";

        //Looks like the element locators are badly written (perhaps on purpose), so have to use generated Xpath
        private readonly By _usernameLocator = By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div[1]/div[2]/form/div[1]/div/div[1]/div/div[2]/input");
        //*[@id="app"]/div[1]/div[2]/div[2]/div/div[1]/div[2]/form/div[1]/div/div[1]/div/div[2]/input
        //*[@id="app"]/div[1]/div[2]/div[2]/div/div[1]/div[2]/form/div[1]/div/div[1]/div/div[2]/input


        private readonly By _userRoleLocator = By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div[1]/div[2]/form/div[1]/div/div[2]/div/div[2]/div/div/div[2]/i");
                                                           //*[@id="app"]/div[1]/div[2]/div[2]/div/div[1]/div[2]/form/div[1]/div/div[2]/div/div[2]/div/div/div[1]

        private readonly By _userRoleEssValueLocator = By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div[1]/div[2]/form/div[1]/div/div[2]/div/div[2]/div/div/div[1]");

        private readonly By _adminTableLocator = By.CssSelector("[role='table']");
        private readonly By _columnLocator = By.CssSelector("[role='cell']");
        

        private readonly By _searchButtonLocator = By.CssSelector("button[type = 'submit']");

        //Methods
        public void CheckTitle()
        {
            Assert.AreEqual(Driver.driver.Title, DashboardTitle);
        }

       
        //Would probably more normal to click on the element by visible text. This is here as a demonstration of how to work with 
        //a list of elements.
        public void ClickOnNthListElement(int index)
        {
            IWebElement element =  GetListItemByIndex(_listItemsLocator, index);
            element.Click();
           
        }

        public void ClickOnAdminMenuItem()
        {
            IWebElement admin = GetElementByHref(_adminHref, 2);
            admin.Click();
        }

        public void ClickOnPimMenuItem()
        {
            IWebElement admin = GetElementByHref(_pinHref, 2);
            admin.Click();
        }

        public void EnterUsername(string username)
        {
            EnterText(_usernameLocator,username, 2);
        }


        public void SelectUserRole(string userRole)
        {
            IWebElement dropdownElement = GetClickablElement(_userRoleLocator,2);
            dropdownElement.Click();
            //IWebElement dropdownValue = GetClickablElement(_userRoleEssValueLocator, 2);

            EnterText(_userRoleEssValueLocator, "ESS");
            

            Driver.Pause(2000);
        }


        public void ClickOnSearchButton()
        {
            Driver.Pause(2000);

            ClickOnElement(_searchButtonLocator);
        }


        public bool userNameColumnContainsExpectedValue(string expectedValue)
        {
            int userNameColIndex = 1;
            return NthColumEqualsSpecifiedText(_adminTableLocator, _columnLocator,userNameColIndex,expectedValue);
        }

    }
}
