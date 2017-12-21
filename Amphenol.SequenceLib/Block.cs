using System;
using System.Xml;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Amphenol.SequenceLib
{
    [DataContract(Name = "Block", Namespace = "www.amphenol.com")]
    [KnownType(typeof(XmlNode))]
    [KnownType(typeof(XmlElement))]
    public class Block
    {
        [DataMember]
        private XmlNode currentBlockNode;
        [DataMember]
        private string blockNum;
        [DataMember]
        private string blockName;
        [DataMember]
        private List<Step> steps;
        [DataMember]
        private List<XmlNode> stepXmlNodes;

        /******************************************************************************************/
        public XmlNode CurrentBlockNode
        {
            get
            {
                return currentBlockNode;
            }
        }

        public string BlockNum
        {
            get
            {
                return blockNum;
            }
            set
            {
                blockNum = value;
            }
        }
        public string BlockName
        {
            get
            {
                return blockName;
            }
            set
            {
                blockName = value;
            }
        }
        public IList<Step> Steps
        {
            get
            {
                return steps;
            }
        }
        public IList<XmlNode> StepXmlNodes
        {
            get
            {
                return stepXmlNodes;
            }
        }

        /******************************************************************************************/
        public Block(XmlNode blockNode)
        {
            currentBlockNode = blockNode;

            XmlNode blocknumNode = blockNode.SelectSingleNode("blocknum");
            if (blocknumNode != null)
                blockNum = blocknumNode.InnerText;

            XmlNode blocknameNode = blockNode.SelectSingleNode("blockname");
            if (blocknameNode != null)
                blockName = blocknameNode.InnerText;

            steps = new List<Step>();
            stepXmlNodes = new List<XmlNode>();

            XmlNodeList stepNodes = blockNode.SelectNodes("step");
            foreach (XmlNode stepNode in stepNodes)
            {
                Step step = new Step(stepNode);
                steps.Add(step);

                stepXmlNodes.Add(stepNode);
            }
        }

        public Block(string blocknum, string blockname, XmlDocument doc)
        {
            /* new <block> node */
            currentBlockNode = doc.CreateElement("block");

            /* <blocknum> node */
            XmlElement blocknumNode = doc.CreateElement("blocknum");
            blocknumNode.InnerText = blocknum;
            blockNum = blocknum;
            currentBlockNode.AppendChild(blocknumNode);     /* Append <blocknum> child node under <block> parent node */

            /* <blockname> node */
            XmlElement blocknameNode = doc.CreateElement("blockname");
            blocknameNode.InnerText = blockname;
            blockName = blockname;
            currentBlockNode.AppendChild(blocknameNode);

            steps = new List<Step>();       /* Initialize the step list */
            stepXmlNodes = new List<XmlNode>();     /* Initialize the stepNode list */
        }

        public Block(string blocknum, string blockname, int stepArrayCount, Step[] stepArray, XmlDocument doc)
        {
            currentBlockNode = doc.CreateElement("block");      /* new <block> node */

            /* <blocknum> node */
            XmlElement blocknumNode = doc.CreateElement("blocknum");
            blocknumNode.InnerText = blocknum;
            blockNum = blocknum;
            currentBlockNode.AppendChild(blocknumNode);     /* Append <blocknum> child node under <block> parent node */

            /* <blockname> node */
            XmlElement blocknameNode = doc.CreateElement("blockname");
            blocknameNode.InnerText = blockname;
            blockName = blockname;
            currentBlockNode.AppendChild(blocknameNode);    /* Append <blockname> child node under <block> parent node */

            /* many <step> nodes */
            steps = new List<Step>();
            stepXmlNodes = new List<XmlNode>();

            for (int index = 0; index < stepArrayCount; index++)
            {
                steps.Add(stepArray[index]);
                stepXmlNodes.Add(stepArray[index].CurrentStepNode);
                /* Append each <step> node under the <block> parent node */
                currentBlockNode.AppendChild(stepArray[index].CurrentStepNode.CloneNode(true));
            }
        }

        /******************************************************************************************/
        public bool AddNewStep(Step newStep)
        { 
            if ((steps == null) || (stepXmlNodes == null) || (currentBlockNode == null))
            {
                return false;
            }
            steps.Add(newStep);
            stepXmlNodes.Add(newStep.CurrentStepNode);
            
            /* Append <step> child node under the <block> parent node */
            currentBlockNode.AppendChild(newStep.CurrentStepNode.CloneNode(true));
            return true;
        }

        public bool SyncAddNewStep(Step newStep, XmlNode rootNode)
        {
            if ((steps == null) || (stepXmlNodes == null) || (currentBlockNode == null) || (rootNode == null))
            {
                return false;
            }
            steps.Add(newStep);
            stepXmlNodes.Add(newStep.CurrentStepNode);

            currentBlockNode.AppendChild(newStep.CurrentStepNode.CloneNode(true));
            rootNode.AppendChild(currentBlockNode);
            return true;
        }

        public bool RemoveStepAt(int index)
        {
            int count = steps.Count;
            if ((index < 0) || (index >= count))
            {
                return false;
            }

            steps.RemoveAt(index);
            stepXmlNodes.RemoveAt(index);

            /* Remove the <step> node at index position from the <block> parent node */
            XmlNodeList stepNodeList = currentBlockNode.SelectNodes("step");
            if ((stepNodeList.Count == 0) || (index > (stepNodeList.Count-1)))
            {
                return false;
            }
            XmlNode stepNodeToRemove = stepNodeList[index];
            currentBlockNode.RemoveChild(stepNodeToRemove);      
            return true;
        }

        public bool InsertStepAt(int index, Step oneStep)
        {
            int count = steps.Count;
            if ((index < 0) || (index > (count - 1)))
            {
                return false;
            }

            steps.Insert(index, oneStep);
            stepXmlNodes.Insert(index, oneStep.CurrentStepNode);

            /* Insert a new <step> node at the index position under <block> parent node */
            XmlNodeList stepNodeList = currentBlockNode.SelectNodes("step");
            if ((stepNodeList.Count == 0) && (index != 0))      /* [NOTE] : all index must start from 0. */
            {
                return false;
            }
            else if (index > (stepNodeList.Count - 1))
            {
                return false;
            }
            XmlNode refStepNode = stepNodeList[index];
            currentBlockNode.InsertBefore(oneStep.CurrentStepNode.CloneNode(true), refStepNode);

            return true;
        }

        public bool InsertNewStepAfter(int index, Step newStep)
        {
            int existedStepCount = steps.Count;

            steps.Insert(index+1, newStep);
            stepXmlNodes.Insert(index + 1, newStep.CurrentStepNode);

            XmlNodeList stepNodeList = currentBlockNode.SelectNodes("step");
            XmlNode refStepNode = stepNodeList[index];
            currentBlockNode.InsertAfter(newStep.CurrentStepNode.CloneNode(true), refStepNode);

            return true;
        }

        public bool InsertNewStepBefore(int index, Step newStep)
        {
            int existedStepCount = steps.Count;

            steps.Insert(index, newStep);
            stepXmlNodes.Insert(index, newStep.CurrentStepNode);

            XmlNodeList stepNodeList = currentBlockNode.SelectNodes("step");
            XmlNode refStepNode = stepNodeList[index];
            currentBlockNode.InsertBefore(newStep.CurrentStepNode.CloneNode(true), refStepNode);

            return true;
        }

        public bool RemoveSpecifiedStep(Step specifiedStep)
        {
            XmlNodeList stepNodeList = currentBlockNode.SelectNodes("step");
            if (stepNodeList.Count == 0)
            {
                return false;
            }
            foreach (XmlNode stepNode in stepNodeList)
            {
                if (stepNode.OuterXml == specifiedStep.CurrentStepNode.OuterXml)
                {
                    steps.Remove(specifiedStep);
                    stepXmlNodes.Remove(specifiedStep.CurrentStepNode);
                    currentBlockNode.RemoveChild(stepNode);
                    return true;
                }
            }
            return false;
        }

        public int TotalStepCount()
        {
            return steps.Count;
        }

        /******************************************************************************************/
        public void UpdateCurrentBlockContentForItems(string blockNumValueChanged, string blockNameValueChanged)
        {
            this.blockNum = blockNumValueChanged;
            this.blockName = blockNameValueChanged;

            /* Change the inner text of <blocknum> node in XML. */
            XmlNode blocknumNode = currentBlockNode.SelectSingleNode("blocknum");
            blocknumNode.InnerText = blockNumValueChanged;
            /* Change the inner text of <blockname> node in XML. */
            XmlNode blocknameNode = currentBlockNode.SelectSingleNode("blockname");
            blocknameNode.InnerText = blockNameValueChanged;
        }

        public void ModifyStepAt(int index, Step newStep)
        {
            XmlNode stepNodeToModify = (currentBlockNode.SelectNodes("step"))[index];
            /* Replace <step> node at index position with this newStep */
            currentBlockNode.ReplaceChild(newStep.CurrentStepNode, stepNodeToModify);

            /* Replace original Step object at index */
            steps.RemoveAt(index);
            steps.Insert(index, newStep);
            /* and Step XmlNode object */
            stepXmlNodes.RemoveAt(index);
            stepXmlNodes.Insert(index, newStep.CurrentStepNode);
        }
    }
}
