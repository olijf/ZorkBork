using System;
using System.Configuration;
using System.IO;
using System.Xml.Serialization;

namespace ZorkBork
{
    public class Settings
    {
        internal static string GetValue(string v)
        {
            return ConfigurationManager.AppSettings[v];
        }
        public static T LeesXML<T>(string fileName)
        {
            T result = default(T);
            var serializer = new XmlSerializer(typeof(T));
            using (var streamReader = new StreamReader(fileName))
            {
                result = (T)serializer.Deserialize(streamReader);
            };
            return result;
        }
    }
}