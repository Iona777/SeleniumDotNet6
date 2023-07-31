using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRMDotNet6TestProject.Utilities
{
    public class GetElements
    {
        public static int webDriverTimeout;
        
        public GetElements()
        {
            webDriverTimeout = Driver.GetTimeoutSeconds();
        }

        /// <summary>
        /// Waits for then returns a clickable web element
        /// </summary>
        /// <param name="elementLocator">Used to locate the element, e.g. By.Id("xyz")</param>
        /// <param name="waitSeconds">Time to wait before timeout</param>
        /// <returns>IWebElement</returns>
        public static IWebElement GetClickablElement(By elementLocator, int? waitSeconds = null)
        {
            int seconds = waitSeconds ?? webDriverTimeout;

            WebDriverWait wait = new WebDriverWait(Driver.driver, TimeSpan.FromSeconds(seconds));

            return wait.Until(ExpectedConditions.ElementToBeClickable(elementLocator));
        }

     
    }
}
