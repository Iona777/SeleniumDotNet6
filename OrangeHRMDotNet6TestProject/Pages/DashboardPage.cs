using OpenQA.Selenium;
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



    }
}
