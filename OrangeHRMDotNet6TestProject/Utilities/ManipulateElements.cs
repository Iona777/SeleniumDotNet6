using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static OrangeHRMDotNet6TestProject.Utilities.GetElements;

namespace OrangeHRMDotNet6TestProject.Utilities
{
    public static class ManipulateElements
    {

        /// <summary>
        /// Waits for a given element to be clickable and then sends the given inputText
        /// </summary>
        /// <param name="elementLocator">Used to locate the element, e.g. By.Id("xyz")</param>
        /// <param name="inputText">Text to enter</param>
        /// <param name="waitSeconds">Time to wait before timeout</param>
        public static void EnterText(By elementLocator, string inputText, int? waitSeconds = null)
        {
            GetClickablElement(elementLocator).SendKeys(inputText);
        }
    }
}
