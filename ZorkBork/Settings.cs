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
        public static void SchrijfXML<T>(string fileName, T outPut)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var streamWriter = new StreamWriter(fileName))
            {
                serializer.Serialize(streamWriter, outPut);
            }
        }
    }

}