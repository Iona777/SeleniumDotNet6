using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI; //Need this for WebDriverWait
using OrangeHRMDotNet6TestProject.Utilities; //Location of DriverClass
using SeleniumExtras.WaitHelpers; //Need this for ExpectedConditions
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRMDotNet6TestProject.Pages
{
    public class BasePage
    {
        private int webDriverTimeout;

        public BasePage() 
        {
            webDriverTimeout = Driver.GetTimeoutSeconds();
        }

        /// <summary>
        /// Waits for then returns a clickable web element
        /// </summary>
        /// <param name="elementLocator">Used to locate the element, e.g. By.Id("xyz")</param>
        /// <param name="waitSeconds">Time to wait before timeout</param>
        /// <returns>IWebElement</returns>
        public IWebElement GetClickablElement(By elementLocator, int? waitSeconds = null)
        {
            int seconds = waitSeconds ?? webDriverTimeout;

            WebDriverWait wait = new WebDriverWait(Driver.driver, TimeSpan.FromSeconds(seconds));

            return wait.Until(ExpectedConditions.ElementToBeClickable(elementLocator));
        }

        /// <summary>
        /// Waits for a given element to be clickable and then clicks on it.
        /// </summary>
        /// <param name="elementLocator">Used to locate the element, e.g. By.Id("xyz")</param>
        public void ClickOnElement(By elementLocator)
        {
            GetClickablElement(elementLocator).Click();
        }

        /// <summary>
        /// Waits for a given element to be clickable and then sends the given inputText
        /// </summary>
        /// <param name="elementLocator">Used to locate the element, e.g. By.Id("xyz")</param>
        /// <param name="inputText">Text to enter</param>
        /// <param name="waitSeconds">Time to wait before timeout</param>
        public void EnterText(By elementLocator, string inputText, int? waitSeconds = null)
        {
            GetClickablElement(elementLocator).SendKeys(inputText);
        }

        /// <summary>
        /// Returns URL to currently displayed page
        /// </summary>
        /// <returns>String</returns>
        public string PageUrl()
        {
            return Driver.driver.Url;
        }
    }
}
