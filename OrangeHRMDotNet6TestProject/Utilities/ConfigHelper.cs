using System;
using Microsoft.Extensions.Configuration;


namespace OrangeHRMDotNet6TestProject.Utilities
{
    public static class ConfigHelper
    {
        private static IConfigurationRoot configuration;

      /*
        Constructor - it will build the config every time it is required. I think that is what 'reloadOnChange: true' is for.
        Allows us to read the specified config file
        Make sure that you have optional: false,
        This means that it will alert you if it cannot find the config file. Helpful if you have a type or forgot to set to Copy Always. 
        Otherwise it will keep returning null and you won’t know why!
        */

        	        
		    static ConfigHelper()
            {
                try 
                {

                    var builder = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory) // Set the base path to the directory containing your appsettings.json
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

                    configuration = builder.Build();
                }
                catch (IOException e) 
                {
                    throw e;
                }

            }
        
        

        public static string GetProperty(string key)
        {
            // Gets property from config file for the given key
            string fromConfigFile = configuration[key];

            // Checks for property in environment. If not found, returns config file value as default
            return Environment.GetEnvironmentVariable(key) ?? fromConfigFile;
        }
    }
}

