using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static OrangeHRMDotNet6TestProject.Utilities.GetElements;

namespace OrangeHRMDotNet6TestProject.Utilities
{
    public static class InterrogateElement
    {
        public static int webDriverTimeout = Driver.GetTimeoutSeconds();

        /// <summary>
        /// Checks if an element is visible on the page. Visibility means that the element
        /// is not only displayed but also has a height and width that is greater than 0.
        /// </summary>
        /// <param name="elementLocator">Used to locate the element, e.g. By.Id("xyz")</param>
        /// <returns>boolean</returns>
        public static bool IsElementDisplayed(By elementLocator, int? waitSeconds = null)
        {
            try
            {
                IWebElement ele = GetVisibleElement(elementLocator);
                return ele.Displayed;

            }
            catch (NoSuchElementException) //If this is not a suitable exception, than can just catch Exception 
            {
                //If element is not present on the DOM at all (instead of being present but not displayed) then will get
                // this element. So, the element is not displayed.
                return false;
            }

        }
    }
}
