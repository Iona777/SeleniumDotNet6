using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.DevTools.V112.DOM;
using System.Collections.ObjectModel;
using OpenQA.Selenium.DevTools.V112.Debugger;
using System.Linq.Expressions;

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


        public static ReadOnlyCollection<IWebElement> GetAllVisibleElements(By by, int minCount = 1, bool retry = true, int? waitSeconds = null)
        {
            int seconds = waitSeconds ?? webDriverTimeout;
            WebDriverWait wait = new WebDriverWait(Driver.driver,TimeSpan.FromSeconds(seconds));

            ReadOnlyCollection<IWebElement> elementList;

            try
            {
                elementList = wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(by));

                if (elementList.Count < minCount) 
                {
                    //Sometimes it will just not get all the elements in time, so  give it another chance.
                    Driver.Pause(5000);
                    elementList = wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(by));
                }

                return elementList;
                
            }
            catch (Exception e)
            {

                if (retry) 
                {
                    try
                    {
                        elementList = wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(by));

                        if (elementList.Count < minCount)
                        {
                            //Sometimes it will just not get all the elements in time, so  give it another chance.
                            Driver.Pause(5000);
                            elementList = wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(by));
                        }

                        return elementList;
                    }
                    catch (Exception)
                    {
                        //Failed again, throw original error
                        throw new Exception($"Cannot find element via: {by}");
                    }
                }
                else { throw; };
            }


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


        public static IWebElement GetElementByHref(string href, int? waitSeconds)
        {
            int seconds = waitSeconds ?? webDriverTimeout;
            WebDriverWait wait = new WebDriverWait(Driver.driver, TimeSpan.FromSeconds(seconds));

            return wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("[href*='" + href + "']")));
        }

        public static IWebElement GetElementByVisibleTextAdmin(string searchText, int? waitSeconds)
        {
            int seconds = waitSeconds ?? webDriverTimeout;
            WebDriverWait wait = new WebDriverWait(Driver.driver, TimeSpan.FromSeconds(seconds));

            string xpath1 = ".//*[contains(text(),'" + searchText + "')]";
            string xpath2 = "//*[contains(., 'Admin')]";

            //return wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(".//*[contains(text(),'" + searchText + "')]")));
            //return wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(., 'searchText')]")));
            return wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(., 'Admin')]")));

            
        }

        public static IWebElement GetElementByVisibleTextCEO(string searchText, int? waitSeconds)
        {
            int seconds = waitSeconds ?? webDriverTimeout;
            WebDriverWait wait = new WebDriverWait(Driver.driver, TimeSpan.FromSeconds(seconds));

            string xpath1 = ".//*[contains(text(),'" + searchText + "')]";
            string xpath2 = "//*[contains(., 'Admin')]";

            //return wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(".//*[contains(text(),'" + searchText + "')]")));
            //return wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(., 'searchText')]")));
            return wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(., 'Chief Executive Officer')]")));


        }

    }
}
