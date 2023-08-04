using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OrangeHRMDotNet6TestProject.Utilities.GetElements;


namespace OrangeHRMDotNet6TestProject.Utilities
{
    public static class SelectElements
    {
       
        /// <summary>
        /// Waits for a given element to be clickable and then clicks on it.
        /// </summary>
        /// <param name="elementLocator">Used to locate the element, e.g. By.Id("xyz")</param>
        public static void ClickOnElement(By elementLocator)
        {
            GetClickablElement(elementLocator).Click();
        }

        /// <summary>
        /// Will select item in normal dropdown by visible text
        /// </summary>
        /// <param name="element">dropdown element</param>
        /// <param name="visibleText">text in dropdown</param>
        public static void SelectDropDownByVisibleText(IWebElement element, string visibleText)
        { 
            SelectElement selectDropDown = new SelectElement(element);
            selectDropDown.SelectByText(visibleText);   
        }

        

    }
}
