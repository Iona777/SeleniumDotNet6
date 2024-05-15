using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OrangeHRMDotNet6TestProject.Utilities; //Location of Driver class
using TechTalk.SpecFlow;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Model;
using Gherkin.CucumberMessages.Types;


namespace OrangeHRMDotNet6TestProject.Steps.Shared
{
    [Binding]
    public class Hooks
    {
        private static ExtentReports _extent;
        private static ExtentTest _test;

        [BeforeTestRun]
        private static void InitialiseReport()
        {
            ExtentSparkReporter spark = new ExtentSparkReporter(@"..\..\Reports\testReport.html");

            _extent = new ExtentReports();
            _extent.AttachReporter(spark);

        }
        [AfterTestRun]
        public static void AfterTestRun()
        {
            //Instructs ExtentReports write the test information to a destination
            //You will not get any report without this line!
            _extent.Flush();
        }
        
        [BeforeScenario()]
        public static void StartBrowser()
        {
            Driver.RootURL = Driver.GetBaseURL();
            Driver.OpenBrowser(Driver.GetBrowser());

            _test = _extent.CreateTest(ScenarioContext.Current.ScenarioInfo.Title);
        }

        [AfterScenario()]
        public static void ShutDown()
        {

            // Logic to capture test result and add it to the report
            if (ScenarioContext.Current.TestError != null)
            {
                _test.Fail(ScenarioContext.Current.TestError.Message);
            }
            else
            {
                _test.Pass("Test passed!");
             }

            Driver.ShutDown();
        }
    }
}
