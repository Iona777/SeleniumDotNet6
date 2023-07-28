using System;
using System.Configuration.Internal;
using System.Diagnostics;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace OrangeHRMDotNet6TestProject.Utilities
{
    internal class Driver
    {



        //Not sure which of these to use. My notes have IWebDriver, VS auto suggests WebDriver
        //public static WebDriver driver;
        public static IWebDriver driver;
        

        //This value comes from the .runsettings file, set via WebHooks (explained later)
        public static string RootURL;


        /**
         * This method needs to be included as a minimum. It should also maximise the window and create 
         * an instance of the WebDriverWait.
         * We will see alternative versions of this method later, when we come to the Configuration files
         */
        public static void OpenBrowser(string selectedBrowser)
        {
            switch (selectedBrowser.ToUpper())
            {
                case "CHROME": 
                    driver = new ChromeDriver();
                    driver.Manage().Window.Maximize();
                    break;
                case "IE":
                    driver = new InternetExplorerDriver();
                    driver.Manage().Window.Maximize();
                    break;
                    default: throw new ArgumentException("Unknown Browser Selected"+ selectedBrowser.ToUpper());
                    break;
            }
        }

        /// <summary>
        /// Waits for the specified number of milliseconds. Used for debugging only.
        /// </summary>
        /// <param name="time"></param>
        public static void Pause(int time)
        {
            Thread.Sleep(time);
        }


        public static void NavigateTo(string targetURL)
        { 
            driver.Navigate().GoToUrl(targetURL);
        }


        /*
         *
         *The NewQuoteTool project uses RunSettings, which is a bit of a mind bender, so will just use 
         *appSettings and ConfigHelper here.
        */

        public static string GetValueFromConfigKey(string key)
        {
            var settings = ConfigHelper.GetConfig();
            return settings[key];
        }

        public static int GetTimeoutSeconds()
        {
            var time = GetValueFromConfigKey("DefaultTimeoutSeconds");
            return int.Parse(time);
        }

        public static string GetBrowser()
        {
            var browser = GetValueFromConfigKey("Browser");
            return browser;
        }


        public static string GetBaseURL()
        {
            var baseURL = GetValueFromConfigKey("BaseURL");
            return baseURL;
        }

        /*
         * Don’t call it Quit() as you could end up calling it in an endless loop if you call 
         * Driver.Quit() instead of driver.Quit() !
         */
        public static void ShutDown()
        {
            driver.Quit();
        }
           

    }
}
