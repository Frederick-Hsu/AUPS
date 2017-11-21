using System;
using System.Collections.Generic;
using System.Xml;

namespace Amphenol.Seq
{
    public class Sequence
    {
        private List<Block> blocks;

        public IList<Block> Blocks
        {
            get
            {
                return blocks;
            }
        }

        public void Load(string sequenceFileName)
        {
            XmlDocument seqXml = new XmlDocument();
            seqXml.Load(sequenceFileName);

            XmlNode seqNode = seqXml.SelectSingleNode("sequence");
            XmlNodeList blockNodes = seqNode.ChildNodes;

            blocks = new List<Block>();
            foreach (XmlNode blockNode in blockNodes)
            {
                Block block = new Block(blockNode);
                blocks.Add(block);
            }
        }
    }
}
