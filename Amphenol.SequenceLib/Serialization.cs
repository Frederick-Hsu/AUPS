using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Amphenol.SequenceLib
{
#if false
    public class Serialization<T>
    {
        private string xmlFile = Directory.GetCurrentDirectory() + "/sequence.txt";

        public T DeepCopy(T obj)
        {
            // MemoryStream stream = new MemoryStream();
            FileStream stream = new FileStream(xmlFile, FileMode.Create);
            XmlSerializer formatter = new XmlSerializer(typeof(T));
            formatter.Serialize(stream, obj);
            // stream.Position = 0;
            return ((T)formatter.Deserialize(stream));
        }
    }
#elif false
    public class Serialization<T>
    {
        public static T DeepCopy(T obj)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, obj);
            stream.Position = 0;
            return ((T)formatter.Deserialize(stream));
        }
    }
#endif

    public class Serializer
    {
        public static T DeepCopy<T>(T obj)
        {
            object ret;
            using (MemoryStream stream = new MemoryStream())
            {
                Type[] knowTypes = { typeof(XmlNode), typeof(List<string>) };
                DataContractSerializer ser = new DataContractSerializer(typeof(T), knowTypes);
                ser.WriteObject(stream, obj);
                stream.Seek(0, SeekOrigin.Begin);
                ret = ser.ReadObject(stream);
                stream.Close();
            }
            return (T)ret;
        }
    }
}
