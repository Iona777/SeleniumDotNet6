using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OrangeHRMDotNet6TestProject.Utilities; //Location of Driver class
using TechTalk.SpecFlow;


namespace OrangeHRMDotNet6TestProject.Steps.Shared
{
    [Binding]
    public class Hooks
    {
        [BeforeScenario()]
        public static void StartBrowser()
        {
            Driver.RootURL = Driver.GetBaseURL();
            Driver.OpenBrowser(Driver.GetBrowser());
        }

        [AfterScenario()]
        public static void ShutDown()
        {
            Driver.ShutDown();
        }
    }
}
