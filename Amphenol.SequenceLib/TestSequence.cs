using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Amphenol.SequenceLib
{
    public class TestSequence
    {
        private XmlDocument seqXmlDoc;
        private XmlNode currentSequenceNode;
        private List<TestBlock> testBlockList;

        public void Load(string sequenceXmlFile)
        {
            seqXmlDoc = new XmlDocument();
            seqXmlDoc.Load(sequenceXmlFile);

            /* Locate the <sequence> node, namely the root node. */
            currentSequenceNode = seqXmlDoc.SelectSingleNode("sequence");
            if (currentSequenceNode == null)
                return;
            /* Acquire the <block> node list under <sequence> node. */
            XmlNodeList blockNodeList = currentSequenceNode.ChildNodes;
            /* Initialize testblocks list. */
            testBlockList = new List<TestBlock>();
            foreach (XmlNode blockNode in blockNodeList)
            {
                TestBlock testBlock = new TestBlock(blockNode);
                testBlockList.Add(testBlock);
            }
        }

        public XmlDocument SeqXmlDoc
        {
            get { return seqXmlDoc; }
        }
        public List<TestBlock> TestBlockList
        {
            get { return testBlockList; }
        }
        public XmlNode CurrentSequenceNode
        {
            get { return currentSequenceNode; }
        }

        public void SaveAsTestRecord(string recordXmlFile)
        {
            seqXmlDoc.Save(recordXmlFile);
        }
    }
}
