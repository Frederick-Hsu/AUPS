using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

// using SequenceLib;
using Amphenol.SequenceLib;

namespace Amphenol.ManipulateXML
{
    class Program
    {
        static void Main(string[] args)
        {
            Test.TestSequence();
            // Test.TestDeepCopy();
            Console.ReadLine();
        }
    }

    public class Test
    {
        public static void TestSequence()
        {
            DirectoryInfo myDirInfo = Directory.GetParent(Directory.GetCurrentDirectory());
            FileInfo sequenceFileInfo = new FileInfo(myDirInfo + @"\project_test_sequence.xml");
            sequenceFileInfo.CopyTo(Directory.GetCurrentDirectory() + @"\project_test_sequence.xml", true);

            Sequence seq = new Sequence();
            seq.Load("project_test_sequence.xml");

            XmlDocument seqXml = seq.SeqXml;

            string[] parms = { "PRIM:23", "SECN:12" };
            ParameterList paramlist = new ParameterList(2, parms, seqXml);

            string[] limits = { "100", "200", "300" };
            Spec spec = new Spec(3, limits, seqXml);

            Step myStep = new Step("S10", 
                                   "Configuration", 
                                   "Configure all your settings", 
                                   "ProjectTestItem.Configure",
                                   paramlist,
                                   "Numerical",
                                   spec,
                                   seqXml);

            string[] yourParams = { "BenchID:13", "Connectivity", "Calibration", "RefValue:-30dBm" };
            ParameterList yourParamList = new ParameterList(4, yourParams, seqXml);

            string[] yourLimits = { "OK" };
            Spec yourSpec = new Spec(1, yourLimits, seqXml);

            Step yourStep = new Step("S32", 
                                     "Checking status", 
                                     "Retrieve the status of tester", 
                                     "ProjectTestItem.CheckStatus", 
                                     yourParamList,
                                     "String", 
                                     yourSpec,
                                     seqXml);

            Step hisStep = new Step("S15", 
                                    "Control the fixture", 
                                    "Turn table rotates to move to next station", 
                                    "ProjectTestItem.RotateTurnTable", 
                                    yourParamList, 
                                    "Numerical", 
                                    spec, 
                                    seqXml);

            Console.WriteLine(string.Format("Now we have {0} blocks.", seq.TotalBlockCount()));

            Step[] stepArray = { myStep };
            Block myBlock = new Block("B3", "Instrument settings", 1, stepArray, seqXml);
            // myBlock.AddNewStep(hisStep);
            myBlock.SyncAddNewStep(hisStep, seq.SequenceNode);

            seq.AddNewBlock(myBlock);
            seq.SaveSequenceToXml();

            myBlock.SyncAddNewStep(yourStep, seq.SequenceNode);
            seq.SaveSequenceToXml();

            myBlock.RemoveStepAt(1);
            seq.SaveSequenceToXml();
            
            seq.Blocks[1].RemoveStepAt(1);
            seq.SaveSequenceToXml();

            seq.Blocks[seq.TotalBlockCount() - 1].RemoveStepAt(0);
            seq.SaveSequenceToXml();

            seq.Blocks[0].InsertStepAt(1, hisStep);
            seq.SaveSequenceToXml();
            // seq.Blocks[0].RemoveStepAt(1);
            // seq.SaveSequenceToXml();

            seq.Blocks[seq.TotalBlockCount() - 1].InsertStepAt(0, seq.Blocks[1].Steps[0]);
            seq.SaveSequenceToXml();

            myBlock.InsertStepAt(1, seq.Blocks[2].Steps[0]);
            seq.SaveSequenceToXml();

            myBlock.InsertStepAt(1, myStep);
            seq.SaveSequenceToXml();

            seq.Blocks[2].InsertStepAt(0, hisStep);
            seq.SaveSequenceToXml();

            seq.Blocks[0].RemoveSpecifiedStep(hisStep);
            seq.SaveSequenceToXml();

            myBlock.RemoveSpecifiedStep(myStep);
            seq.SaveSequenceToXml();

            Step[] steps = { myStep, yourStep, hisStep };
            Block yourBlock = new Block("B10", "CAN communication testing", 3, steps, seq.SeqXml);
            seq.AddNewBlock(yourBlock);
            seq.SaveSequenceToXml();

            yourBlock.InsertStepAt(2, seq.Blocks[2].Steps[1]);
            seq.SaveSequenceToXml();

            Block emptyBlock = new Block("B20", "Testing block", seq.SeqXml);

            seq.InsertBlockAt(1, emptyBlock);
            seq.SaveSequenceToXml();

            yourBlock.RemoveStepAt(1);
            seq.SaveSequenceToXml();

            emptyBlock.AddNewStep(seq.Blocks[0].Steps[0]);
            seq.SaveSequenceToXml();

            seq.RemoveSpecifiedBlock(yourBlock);
            seq.SaveSequenceToXml();
        }

        public static void TestDeepCopy()
        {
            Team team = new Team();
            team.AddMember(new Employee("Anders", "Developer", 26));
            team.AddMember(new Employee("Bill", "Developer", 46));
            team.AddMember(new Employee("Steve", "CEO", 36));

            Team clone = (team.Clone() as Team);

            /* Display the original team */
            Console.WriteLine("Original Team : ");
            Console.WriteLine(team.ToString());

            /* Display the cloned team */
            Console.WriteLine("Clone Team : ");
            Console.WriteLine(clone);

            /* Make changes */
            Console.WriteLine("Make a change to original team");
            Console.WriteLine(Environment.NewLine);

            team.TeamMembers[0].Title = "PM";
            team.TeamMembers[1].Age = 30;
            /* Display the original team after changing */
            Console.WriteLine("Original Team after changing : ");
            Console.WriteLine(team.ToString());

            Console.WriteLine("Check whether clone team had been changed");
            Console.WriteLine(clone);

            /* Demonstrate how to realize the shallow copy and deep copy 
             * over serialization and deserialization.
             */

            Console.WriteLine();
            Console.WriteLine(Environment.NewLine);

            Demo myDemo = new Demo("Frederick Hsu", "Software engineer", 34);
            Console.WriteLine("My Demo : " + myDemo.ToString());

            Demo yourDemo = myDemo.ShallowCopy();
            Console.WriteLine("Your demo : " + yourDemo.ToString());

            Demo hisDemo = myDemo.DeepCopy();
            Console.WriteLine("His demo : " + hisDemo.ToString());

            Console.WriteLine("Change my demo");
            myDemo.Title = "CEO";

            Console.WriteLine("After changed, my demo is : " + myDemo.ToString());
            Console.WriteLine("But your demo is : " + yourDemo.ToString());
            Console.WriteLine("And his demo is : " + hisDemo.ToString());

            Console.WriteLine("Now changed his demo ");
            hisDemo.Name = "Tim Cook";
            hisDemo.Age = 56;

            Console.WriteLine("At present, his demo is : " + hisDemo.ToString());
            Console.WriteLine("your demo is : " + yourDemo.ToString());
            Console.WriteLine("and my demo is : " + myDemo.ToString());
        }
    }
}
