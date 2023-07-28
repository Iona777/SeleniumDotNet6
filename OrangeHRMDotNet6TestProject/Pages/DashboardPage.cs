using OrangeHRMDotNet6TestProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRMDotNet6TestProject.Pages
{
    public class DashboardPage: BasePage
    {
        //Constructor
        //Don't need one as inheriting from Basepage.
        //May need an empty one (NoArgConstructor, does that exist in C#?) when refactoring without Base page

        string DashboardTitle = "OrangeHRM";

        //Webelemnt locators

        //Methods
        public void CheckTitle()
        {

            Assert.AreEqual(Driver.driver.Title,DashboardTitle);
        }
    }
}
