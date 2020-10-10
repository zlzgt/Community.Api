using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Community.Infrastructure
{
    public class ConfigurationManagerHelper
    {
        public readonly static IConfiguration Configuration;
        static ConfigurationManagerHelper()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                .Build();
        }

        public static string conn
        {
            get { return Configuration.GetConnectionString("Default"); }
        }


    }
}
