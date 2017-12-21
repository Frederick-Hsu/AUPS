using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Amphenol.ManipulateXML
{
    [Serializable]
    [XmlRoot("AAA")]        /* Specify the element of XML root node */
    public class People
    {
        private string name;
        private int age;

        // [XmlAttribute("abc")]
        public int abc = 1000;      /* public field can be serialized */
        // [XmlAttribute("Name")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        // [XmlElement("Age")]
        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public People()
        {
        }
        public People(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
        public void SayHello()
        {
            Console.WriteLine("This is {0}, I am {1}-year-old.", name, age);
        }
    }

    public class XmlSerialize
    {
        string xmlFilePath = System.IO.Directory.GetCurrentDirectory() + "/XmlFile.txt";
        string xmlClassFilePath = System.IO.Directory.GetCurrentDirectory() + "/XmlClassFile.txt";

        public XmlSerialize()
        {
        }

        public void Start()
        {
            List<People> peopleList = new List<People>();
            People peo1 = new People("Frederick Hsu", 34);
            People peo2 = new People("Bjorn Cederberg", 45);
            peopleList.Add(peo1);
            peopleList.Add(peo2);

            SerializeMethod(peopleList);
            DeserializeMethod();

            SerializeClassMethod(peo1);
            DeserializeClassMethod();

            Console.WriteLine("Done!");
        }
        /* XML instance class serialization */
        private void SerializeClassMethod(People p)
        {
            FileStream fs = new FileStream(xmlClassFilePath, FileMode.Create);
            XmlSerializer xs = new XmlSerializer(typeof(People));
            xs.Serialize(fs, p);
            fs.Close();
        }
        /* XML instance class deserialization */
        private void DeserializeClassMethod()
        {
            FileStream fs = new FileStream(xmlClassFilePath, FileMode.Open);
            XmlSerializer xs = new XmlSerializer(typeof(People));
            People p = (xs.Deserialize(fs) as People);

            if (p != null)
            {
                p.SayHello();
            }
            fs.Close();
        }
        /* XML list serialization */
        private void SerializeMethod(List<People> peoList)
        {
            // MemoryStream stream = new MemoryStream();
            FileStream stream = new FileStream(xmlFilePath, FileMode.Create);
            XmlSerializer xs = new XmlSerializer(typeof(List<People>));
            xs.Serialize(stream, peoList);
            stream.Close();
        }
        /* XML list deserialization */
        private void DeserializeMethod()
        {
            // MemoryStream stream = new MemoryStream();
            FileStream stream = new FileStream(xmlFilePath, FileMode.Open);
            XmlSerializer xs = new XmlSerializer(typeof(List<People>));
            List<People> peoplelist = (xs.Deserialize(stream) as List<People>);

            if (peoplelist != null)
            {
                foreach (People peo in peoplelist)
                {
                    peo.SayHello();
                }
            }
            stream.Close();
        }
    }
}