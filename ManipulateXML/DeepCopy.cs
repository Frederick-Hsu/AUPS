using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Amphenol.ManipulateXML
{
    public class Employee : ICloneable
    {
        private string name;
        private string title;
        private int age;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }

        public Employee(string name, string title, int age)
        {
            this.name = name;
            this.title = title;
            this.age = age;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public override string ToString()
        {
            return string.Format("Name : {0}, Title : {1} - Age : {2}", name, title, age);
        }
    }

    public class Team : ICloneable
    {
        private List<Employee> teamMembers = new List<Employee>();

        public IList<Employee> TeamMembers
        {
            get
            {
                return teamMembers;
            }
        }

        public Team()
        {
        }

        private Team(List<Employee> members)
        {
            foreach (Employee e in members)
            {
                teamMembers.Add(e.Clone() as Employee);
            }
        }

        public void AddMember(Employee member)
        {
            teamMembers.Add(member);
        }

        public object Clone()
        {
            return (new Team(this.teamMembers));
        }

        public override string ToString()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (Employee e in TeamMembers)
            {
                sb.AppendFormat("{0}\r\n", e);
            }
            return sb.ToString();
        }
    }

    [Serializable]
    public class Demo
    {
        private string name;
        private string title;
        private int age;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }

        public Demo(string name, string title, int age)
        {
            this.name = name;
            this.title = title;
            this.age = age;
        }

        public Demo ShallowCopy()
        {
            return (this.MemberwiseClone() as Demo);
        }

        public override string ToString()
        {
            return string.Format("Name : {0}, Title : {1}, Age : {2}", name, title, age);
        }

        public Demo DeepCopy()
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formater = new BinaryFormatter();
            formater.Serialize(stream, this);
            stream.Position = 0;
            return (formater.Deserialize(stream) as Demo);
        }
    }
}