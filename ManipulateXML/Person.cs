using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Amphenol.ManipulateXML
{
    [Serializable]      /* Indicates that this class can be serialized */
    class Person
    {
        private string name;
        [NonSerialized]     /* Indicates that this field age will not be serialized */
        private int age;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public Person()
        {
        }
        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public void SayHello()
        {
            Console.WriteLine("This is {0}, I am {1}-year-old this year.", name, age);
        }
    }

    public class BinarySerializer
    {
        string filePath = Directory.GetCurrentDirectory() + "/binaryFile.txt";
        List<Person> persons;

        public void Start()
        {
            persons = new List<Person>();
            Person per1 = new Person("Frederick Hsu", 34);
            Person per2 = new Person("Bjorn Cederberg", 45);
            persons.Add(per1);
            persons.Add(per2);

            SerializeMethod(persons);
            DeserializeMethod();
            Console.WriteLine("Done!");
        }

        void SerializeMethod(List<Person> pers)
        {
            FileStream fs = new FileStream(filePath, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, persons);
            fs.Close();
        }

        void DeserializeMethod()
        {
            FileStream fs = new FileStream(filePath, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            List<Person> personList = (formatter.Deserialize(fs) as List<Person>);

            if (personList != null)
            {
                foreach (Person per in personList)
                {
                    per.SayHello();
                }
            }
            fs.Close();
        }
    }
}
