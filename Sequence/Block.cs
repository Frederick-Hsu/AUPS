using System.Collections.Generic;

namespace Amphenol.Seq
{
    public class Block
    {
        private string blockNum;
        private string blockName;
        private List<Step> steps;

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

        public Block(System.Xml.XmlNode blockNode)
        {
            blockNum = blockNode.SelectSingleNode("blocknum").InnerText;
            blockName = blockNode.SelectSingleNode("blockname").InnerText;

            steps = new List<Step>();
            System.Xml.XmlNodeList stepNodes = blockNode.SelectNodes("step");
            foreach (System.Xml.XmlNode stepNode in stepNodes)
            {
                Step step = new Step(stepNode);
                steps.Add(step);
            }
        }
    }
}
