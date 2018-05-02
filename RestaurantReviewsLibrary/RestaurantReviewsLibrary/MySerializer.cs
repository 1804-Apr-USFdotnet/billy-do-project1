using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RestaurantReviewsLibrary
{
    class MySerializer
    {
        private static string xmlFilename = @"RestaurantsInfo.xml";

        public static void Serialize<T>(ref T obj)
        {
            // serialize to Xml File
            if (!File.Exists(xmlFilename))
            {
                XmlSerializer x = new XmlSerializer(obj.GetType());
                TextWriter writer = new StreamWriter(xmlFilename);
                x.Serialize(writer, obj);

                writer.Close();
            }
        }

        public static void Deserialize<T>(ref T obj)
        {
            if (File.Exists(xmlFilename))
            {
                TextReader txtReader = new StreamReader(xmlFilename);
                XmlSerializer x = new XmlSerializer(obj.GetType());
                obj = (T)x.Deserialize(txtReader);

                txtReader.Close();
            }
        }
    }
}
