using System;
using System.Collections.Generic;
using System.Xml;

namespace Amphenol.SequenceLib
{
    public class Sequence
    {
        private XmlDocument seqXml;
        private string seqFileName;
        private XmlNode sequenceNode;

        private List<Block> blocks;
        private List<XmlNode> blockXmlNodes;

        /******************************************************************************************/
        public IList<Block> Blocks
        {
            get
            {
                return blocks;
            }
        }
        public IList<XmlNode> BlockXmlNodes
        {
            get
            {
                return blockXmlNodes;
            }
        }
        public XmlDocument SeqXml
        {
            get
            {
                return seqXml;
            }
        }
        public XmlNode SequenceNode
        {
            get
            {
                return sequenceNode;
            }
        }

        /******************************************************************************************/
        public void Load(string sequenceFileName)
        {
            seqFileName = sequenceFileName;

            seqXml = new XmlDocument();
            seqXml.Load(sequenceFileName);

            sequenceNode = seqXml.SelectSingleNode("sequence");
            XmlNodeList blockNodes = sequenceNode.ChildNodes;       /* <block> node list */

            blocks = new List<Block>();
            blockXmlNodes = new List<XmlNode>();
            foreach (XmlNode blockNode in blockNodes)       /* Traverse each <block> node */
            {
                Block block = new Block(blockNode);
                blocks.Add(block);

                blockXmlNodes.Add(blockNode);
            }
        }

        public void CreateNewSequence(string sequenceXmlFile)
        {
            seqFileName = sequenceXmlFile;
            blocks = new List<Block>();
            blockXmlNodes = new List<XmlNode>();

            seqXml = new XmlDocument();
            XmlDeclaration declaration = seqXml.CreateXmlDeclaration("1.0", "UTF-8", "");
            seqXml.AppendChild(declaration);

            /* Create the <sequence> root node */
            sequenceNode = seqXml.CreateElement("sequence");
            seqXml.AppendChild(sequenceNode);

            /* Create the <parameterlist> node */
            List<string> parameterList = new List<string>();
            parameterList.Add("");
            ParameterList parameters = new ParameterList(parameterList, SeqXml);
            XmlNode parameterlistNode = parameters.CurrentParameterListNode;

            /* Create the <spec> node */
            List<string> limits = new List<string>();
            limits.Add("OK");
            Spec spec = new Spec(limits, seqXml);
            XmlNode specNode = spec.CurrentSpecNode;

            /* Create a dummy <step> node */
            Step dummyStep = new Step("1.1",
                                      "First step, please edit your step name",
                                      "This is a new step",
                                      "", 
                                      parameters,
                                      "String",
                                      spec,
                                      SeqXml);
            XmlNode stepNode = dummyStep.CurrentStepNode;

            /* Create a new <block> node */
            Block newBlock = new Block("B1", 
                                       "First block, please edit your block name", 
                                       seqXml);
            newBlock.AddNewStep(dummyStep);
            blocks.Add(newBlock);

            XmlNode blockNode = newBlock.CurrentBlockNode;
            blockXmlNodes.Add(newBlock.CurrentBlockNode);

            /* Append the <block> node under <sequence> node */
            sequenceNode.AppendChild(blockNode);

            /* Save the new created sequence.xml file */
            seqXml.Save(seqFileName);
        }
        /******************************************************************************************/
        public void SaveSequenceToXml()
        {
            seqXml.Save(seqFileName);
        }

        public void SaveAsSequenceToXml(string anotherXmlFileName)
        {
            seqXml.Save(anotherXmlFileName);
            /* Remember to change the file name when "Save as".*/
            seqFileName = anotherXmlFileName;
        }

        /******************************************************************************************/
        public bool AddNewBlock(Block newBlock)
        {
            // Block newBlock = ObjectCopier.DeepCopy<Block>(oneBlock);
            if ((blocks == null) || (blockXmlNodes == null))    /* NOT initialized */
            {
                return false;
            }

            blocks.Add(newBlock);
            blockXmlNodes.Add(newBlock.CurrentBlockNode);

            /* Append the new <block> child node under <sequence> parent node */
            sequenceNode.AppendChild(newBlock.CurrentBlockNode);
            return true;
        }

        public bool InsertNewBlockAfter(int index, Block newBlock)
        {
            /* [NOTE] : 
             * Because in the "Sequence Editor" UI, the index value of current Block tree node user selected 
             * will not exceed the total blocks count, namely "index <= (existedBlockCount - 1)" always succeeds.
             * 
             * So directly insert the "newBlock" into the list[index+1] position.
             */
            int existedBlockCount = blocks.Count;

            blocks.Insert(index + 1, newBlock);
            blockXmlNodes.Insert(index + 1, newBlock.CurrentBlockNode);

            XmlNodeList blockNodeList = sequenceNode.ChildNodes;
            XmlNode refBlockNode = blockNodeList[index];
            sequenceNode.InsertAfter(newBlock.CurrentBlockNode, refBlockNode);
            return true;
        }

        public bool InsertNewBlockBefore(int index, Block newBlock)
        {
            /* [NOTE] :
             * Because there must be more than 1 block tree node in the "Sequence Editor" UI, so inserting a
             * new block node at position "index" always succeeds.
             */
            int existedBlockCount = blocks.Count;
            blocks.Insert(index, newBlock);
            blockXmlNodes.Insert(index, newBlock.CurrentBlockNode);

            XmlNodeList blockNodeList = sequenceNode.ChildNodes;
            XmlNode refBlockNode = blockNodeList[index];
            sequenceNode.InsertBefore(newBlock.CurrentBlockNode, refBlockNode);
            return true;
        }

        public bool RemoveBlockAt(int index)
        {
            int count = blocks.Count;
            if ((index < 0) || (index >= count))
            {
                return false;
            }

            blocks.RemoveAt(index);
            blockXmlNodes.RemoveAt(index);

            /* Remove the <block> child node at "index" position from <sequence> parent node */
            XmlNode blockNodeToRemove = sequenceNode.ChildNodes[index];
            sequenceNode.RemoveChild(blockNodeToRemove);
            return true;
        }

        public bool InsertBlockAt(int index, Block oneBlock)
        {
            int count = blocks.Count;
            if ((index < 0) || (index >= count))
            {
                return false;
            }
            blocks.Insert(index, oneBlock);
            blockXmlNodes.Insert(index, oneBlock.CurrentBlockNode);

            XmlNodeList blockNodeList = sequenceNode.ChildNodes;
            if ((blockNodeList.Count == 0) && (index != 0))
            {
                return false;
            }
            else if (index > (blockNodeList.Count - 1))
            {
                return false;
            }
            XmlNode refBlockNode = blockNodeList[index];
            /* Insert a new <block> node into the <sequence> node list. */
            sequenceNode.InsertBefore(oneBlock.CurrentBlockNode, refBlockNode);
            return true;
        }

        public bool RemoveSpecifiedBlock(Block specifiedBlock)
        {
            XmlNodeList blockNodeList = sequenceNode.ChildNodes;
            if (blockNodeList.Count == 0)
            {
                return false;
            }
            foreach (XmlNode blockNode in blockNodeList)
            {
                if (blockNode.OuterXml == specifiedBlock.CurrentBlockNode.OuterXml)
                {
                    blocks.Remove(specifiedBlock);
                    blockXmlNodes.Remove(specifiedBlock.CurrentBlockNode);
                    sequenceNode.RemoveChild(blockNode);
                    return true;
                }
            }
            return false;
        }

        public int TotalBlockCount()
        {
            return blocks.Count;
        }
    }
}
