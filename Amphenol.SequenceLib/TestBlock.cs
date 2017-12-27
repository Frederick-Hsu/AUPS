using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Amphenol.SequenceLib
{
    public class TestBlock
    {
        private XmlNode currentBlockNode;
        private string blockNum;
        private string blockName;
        private List<TestStep> testStepList;

        public TestBlock(XmlNode blockNode)
        {
            currentBlockNode = blockNode;
            /* Retrieve the <blocknum> node */
            XmlNode blockNumNode = blockNode.SelectSingleNode("blocknum");
            if (blockNumNode != null)
                blockNum = blockNumNode.InnerText;
            /* Retrieve the <blockname> node */
            XmlNode blockNameNode = blockNode.SelectSingleNode("blockname");
            if (blockNameNode != null)
                blockName = blockNameNode.InnerText;

            /* Initialize testStep list */
            testStepList = new List<TestStep>();
            /* Acquire the <ste> node list under current <block> node */
            XmlNodeList stepNodeList = blockNode.SelectNodes("step");
            foreach (XmlNode stepNode in stepNodeList)
            {
                TestStep testStep = new TestStep(stepNode);
                testStepList.Add(testStep);
            }
        }

        public XmlNode CurrentBlockNode
        {
            get { return currentBlockNode; }
        }
        public string BlockNum
        {
            get { return blockNum; }
            set { blockNum = value; }
        }
        public string BlockName
        {
            get { return blockName; }
            set { blockName = value; }
        }
        public List<TestStep> TestStepList
        {
            get { return testStepList; }
        }
    }
}
