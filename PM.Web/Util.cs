using PM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Xml.Serialization;

namespace PM.Web
{
    public class Util
    {
        public static void Serialize(object list, Type list_type)
        {
            try
            {
                string filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory) + "\\menu.xml";

                // Creates XmlSerializer of the List<User> type
                XmlSerializer serializer = new XmlSerializer(list_type);

                // An alternative syntax could also be:
                //XmlSerializer serializer = new XmlSerializer(typeof(List<User>));

                // Creates a stream using which we'll serialize
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    // We call the Serialize() method and pass the stream created above as the first parameter
                    // The second parameter is the object which we want to serialize
                    serializer.Serialize(sw, list);
                }
            }
            catch (Exception ex)
            {
            }
        }

        public static object DeserializeMenu(Type list_type)
        {
            object list;

            try
            {
                string filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory) + "\\menu.xml";

                if (File.Exists(filePath))
                {
                    XmlSerializer serializer = new XmlSerializer(list_type);
                    using (StreamReader sr = new StreamReader(filePath))
                    {
                        list = (List<MenuSistema>)serializer.Deserialize(sr);
                    }

                    return list;
                }
                else throw new FileNotFoundException("File not found");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}