﻿using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.DevTools.V112.DOM;
using System.Collections.ObjectModel;

namespace OrangeHRMDotNet6TestProject.Utilities
{
    public static class GetElements
    {
        public static int webDriverTimeout = Driver.GetTimeoutSeconds();
        
        /// <summary>
        /// Waits for then returns a clickable web element
        /// </summary>
        /// <param name="elementLocator">Used to locate the element, e.g. By.Id("xyz")</param>
        /// <param name="waitSeconds">Time to wait before timeout</param>
        /// <returns>IWebElement</returns>
        public static IWebElement GetClickablElement(By elementLocator, int? waitSeconds = null)
        {
            //Sets the seconds parameter used in creating the WebDriverWait to the value of waitSeconds
            //if supplied, or defaults to webDriverTimout value if not supplied. 
            int seconds = waitSeconds ?? webDriverTimeout;
            WebDriverWait wait = new WebDriverWait(Driver.driver, TimeSpan.FromSeconds(seconds));

            return wait.Until(ExpectedConditions.ElementToBeClickable(elementLocator));
        }

        // <summary>
        /// Waits for, then returns, a visible element
        /// </summary>
        /// <param name="elementLocator">Used to locate the element, e.g. By.Id("xyz")</param>
        /// <returns>IWebElement</returns>
        public static IWebElement GetVisibleElement(By elementLocator, int? waitSeconds = null)
        {
            int seconds = waitSeconds ?? webDriverTimeout;
            WebDriverWait wait = new WebDriverWait(Driver.driver, TimeSpan.FromSeconds(seconds));

            return wait.Until(ExpectedConditions.ElementIsVisible(elementLocator));
        }

        /// <summary>
        /// Will return the element of the list of items by given element locator and index
        /// </summary>
        /// <param name="elementLocator">Used to locate the element, e.g. By.Id("xyz")</param>
        /// /// <param name="index">Index in the list</param>
        /// <returns></returns>
        public static IWebElement GetListItemByIndex(By elementLocator, int index)
        {
            //Could just call this var and let C# workout what sort of variable type it needs to be
            ReadOnlyCollection<IWebElement> listItems = Driver.driver.FindElements(elementLocator);

            //Just a check to see if we found them- can be removed later
            foreach (IWebElement element in listItems)
            {

                System.Diagnostics.Debug.WriteLine(element.Text);
                string elementText = element.Text;
            }

            return listItems[index];
        }

    }
}
