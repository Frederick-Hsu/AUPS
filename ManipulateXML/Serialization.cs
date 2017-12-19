using System;

namespace Amphenol.ManipulateXML
{
    public class Serialization
    {
        public static void DemonstrateSerialization()
        {
            BinarySerializer bs = new BinarySerializer();
            bs.Start();
        }

        public static void DemonstrateXmlSerialization()
        {
            XmlSerialize xs = new XmlSerialize();
            xs.Start();
        }
    }
}