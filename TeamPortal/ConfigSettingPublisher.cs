using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace TeamPortal
{
    public class ConfigSettingPublisher
    {
        public static string GetSettingValue(string key)
        {
            return ConfigurationManager.AppSettings.Get(key);
        } 
    }
}