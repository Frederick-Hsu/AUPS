using System.IO;
using System.Xml;
using System.Runtime.Serialization;

namespace Amphenol.SequenceLib
{
    public class ObjectCopier
    {
        public static T DeepCopy<T>(T obj)
        {
            WriteObject<T>(obj);
            return ReadObject<T>();
        }

        private static void WriteObject<T>(T obj)
        {
            FileStream writer = new FileStream("data.xml", FileMode.Create);
            // XmlDictionaryWriter writer = XmlDictionaryWriter.CreateTextWriter(stream);
            DataContractSerializer ser = new DataContractSerializer(typeof(T));
            ser.WriteObject(writer, obj);
            writer.Close();
        }

        private static T ReadObject<T>()
        {
            FileStream stream = new FileStream("data.xml", FileMode.Open);
            XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(stream, new XmlDictionaryReaderQuotas());
            DataContractSerializer ser = new DataContractSerializer(typeof(T));
            T obj = (T)ser.ReadObject(reader, true);
            reader.Close();
            stream.Close();

            return obj;
        }
    }
}
