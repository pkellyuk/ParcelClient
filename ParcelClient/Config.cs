using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelClient
{
    public static class Config
    {
        public static string ApiEndpoint = string.Empty;
        public static string ApiClientId = string.Empty;
        public static string ApiSecret = string.Empty;
        public static string ApiScope = string.Empty;

        public static void InitSettings()
        {
            ApiEndpoint = GetSetting("ApiEndpoint");
            ApiClientId = GetSetting("ApiClientId");
            ApiSecret = GetSetting("ApiSecret");
            ApiScope = GetSetting("ApiScope");
        }

        public static string GetSetting(string settingKey)
        {
            try
            {
                IConfigurationBuilder builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

                IConfigurationRoot configuration = builder.Build();
                IConfigurationSection configurationSection = configuration.GetSection("AppConfig").GetSection(settingKey);
                return configurationSection.Value;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
