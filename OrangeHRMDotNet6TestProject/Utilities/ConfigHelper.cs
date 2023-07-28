using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;

namespace OrangeHRMDotNet6TestProject.Utilities
{
    public class ConfigHelper
    {
        private static string configFile = "appsettings.json";
                                            
        //Constructor - does not need one, just use default


        /*
         * Allows us to read the specified config file
         * Make sure that you have optional: false,
            This means that it will alert you if it cannot find the config file. Helpful if you have a type or forgot to set to Copy Always. 
            Otherwise it will keep returning null and you won’t know why!
         */
        public static IConfiguration GetConfig()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(configFile, optional: false, reloadOnChange: true);
            return builder.Build();
        }

        
    }
}
