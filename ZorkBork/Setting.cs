using System;
using System.Configuration;

namespace ZorkBork
{
    public class Settings
    {
        internal static int GetValueAsInt(string v)
        {
            int.TryParse(ConfigurationManager.AppSettings[v], out int result);
            return result;
        }
        internal static string GetValue(string v)
        {
            return ConfigurationManager.AppSettings[v];
        }
    }
}