using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesFeedBackInfrasturcture.Commond
{
    public class XMLHelper
    {
        public static T Read<T>(string path, string xmlRootName) where T : new()
        {
            T data = ReadFromXml<T>(path);

            if (data == null)
            {
                data = new T();
                SaveToXml(data, path, xmlRootName);
            }

            return data;
        }

        public static void Write<T>(T info, string path, string xmlRootName)
        {
            SaveToXml(info, path);
        }

        protected static void SaveToXml(object sourceObj, string path, string xmlRootName = "xml")
        {
            xmlRootName = null;
            try
            {
                if (!string.IsNullOrWhiteSpace(path) && sourceObj != null)
                {
                    string dir = System.IO.Path.GetDirectoryName(path);
                    if (!System.IO.Directory.Exists(dir))
                        System.IO.Directory.CreateDirectory(dir);

                    Type type = sourceObj.GetType();

                    using (System.IO.StreamWriter writer = new System.IO.StreamWriter(path))
                    {
                        System.Xml.Serialization.XmlSerializer xmlSerializer = string.IsNullOrWhiteSpace(xmlRootName) ?
                            new System.Xml.Serialization.XmlSerializer(type) :
                            new System.Xml.Serialization.XmlSerializer(type, new System.Xml.Serialization.XmlRootAttribute(xmlRootName));
                        xmlSerializer.Serialize(writer, sourceObj);
                    }
                }
            }
            catch
            { }
        }

        protected static T ReadFromXml<T>(string path)
        {
            try
            {
                object result = null;

                if (System.IO.File.Exists(path))
                {
                    using (System.IO.StreamReader reader = new System.IO.StreamReader(path))
                    {
                        System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
                        result = xmlSerializer.Deserialize(reader);
                    }
                }

                return (T)result;
            }
            catch
            {
                return default(T);
            }
        }
    }
}