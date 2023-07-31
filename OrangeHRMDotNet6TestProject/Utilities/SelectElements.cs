using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OrangeHRMDotNet6TestProject.Utilities
{
    public class SelectElements
    {
        public SelectElements() { }

        /// <summary>
        /// Waits for a given element to be clickable and then clicks on it.
        /// </summary>
        /// <param name="elementLocator">Used to locate the element, e.g. By.Id("xyz")</param>
        public static void ClickOnElement(By elementLocator)
        {
            GetElements.GetClickablElement(elementLocator).Click();
        }

        /// <summary>
        /// Waits for a given element to be clickable and then sends the given inputText
        /// </summary>
        /// <param name="elementLocator">Used to locate the element, e.g. By.Id("xyz")</param>
        /// <param name="inputText">Text to enter</param>
        /// <param name="waitSeconds">Time to wait before timeout</param>
        public static void EnterText(By elementLocator, string inputText, int? waitSeconds = null)
        {
            GetElements.GetClickablElement(elementLocator).SendKeys(inputText);
        }
    }
}
