using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V112.Cast;
using OrangeHRMDotNet6TestProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static OrangeHRMDotNet6TestProject.Utilities.GetElements;
using static OrangeHRMDotNet6TestProject.Utilities.ManipulateElements;
using static OrangeHRMDotNet6TestProject.Utilities.SelectElements;
using static OrangeHRMDotNet6TestProject.Utilities.Tables;


namespace OrangeHRMDotNet6TestProject.Pages
{
    public class PimPage
    {

        //Constructor
        public PimPage() { }


        //WebElement Locators



        //Methods
        public void GetItems()
        {

            string jobTitledropDownXpath = "/html/body/div/div[1]/div[2]/div[2]/div/div[1]/div[2]/form/div[1]/div/div[6]/div/div[2]/div/div/div[1]";

            string jobDescriptionCSS = "[class='oxd-select-text-input']";

            String jobOptionsLocator = "div[class='oxd-select-text-input'][data-v-67d2aedf]";

            //first we have to click on dropdown
            //Does not find them all except on debub, would need to do some waits (perhaps with condition) if doing this properly
            var jobs = Driver.driver.FindElements(By.CssSelector(jobDescriptionCSS));
            int size = jobs.Count;
            jobs[2].Click();


           

            
           

            //Get the dropdown elmenet then do by css selector from there to get the options under it
            //var jobOptions =  jobs[2].FindElements(By.CssSelector(jobOptionsLocator));
            var jobOptions = GetElementByVisibleTextCEO("Chief Executive Officer",2);
            string optionText = jobOptions.Text;

            jobOptions.Click();

            //jobOptions[1].Click();


            Driver.Pause(2000);








        }

    }
}
