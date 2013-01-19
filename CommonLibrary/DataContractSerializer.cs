using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using System.Text;

namespace CommonLibrary
{
    public class Serializer
    {
        /// <summary>
        /// Serialized the object into a string
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string Serialize(object obj)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                DataContractSerializer serializer = new DataContractSerializer(obj.GetType());
                serializer.WriteObject(memoryStream, obj);
                return Encoding.UTF8.GetString(memoryStream.ToArray());
            }
        }

        /// <summary>
        /// Deserializes the object encoded in the string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static T Deserialize<T>(string xml)
            where T : class
        {
            using (MemoryStream memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
            {
                XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(memoryStream, Encoding.UTF8, new XmlDictionaryReaderQuotas(), null);
                DataContractSerializer serializer = new DataContractSerializer(typeof(T));
                return (T)serializer.ReadObject(reader);
            }
        }

        /// <summary>
        /// Serializes the object to the file location as a string
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="filePath"></param>
        public static void SerializeToFile(object obj, string filePath)
        {
            DataContractSerializer serializer = new DataContractSerializer(obj.GetType());
            
            var xmlSettings = new XmlWriterSettings() { Indent = true };
            using (var writer = XmlWriter.Create(filePath, xmlSettings))
            {
                serializer.WriteObject(writer, obj);
            }
        }

        /// <summary>
        /// Deserializes the object from the file string content
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static T DeserializeFromFile<T>(string filePath)
            where T : class
        {
            var xmlSettings = new XmlReaderSettings();
            using (var reader = XmlReader.Create(filePath, xmlSettings))
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(T));
                return (T)serializer.ReadObject(reader);
            }
        }
    }
}
