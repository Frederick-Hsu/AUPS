using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Amphenol.SequenceLib
{
    public class TestSpec
    {
        private XmlNode currentSpecNode;
        private List<string> limits;
        private string result;

        public TestSpec(XmlNode specNode)
        {
            currentSpecNode = specNode;

            /* Retrieve all <limit> nodes under <spec> node */
            XmlNodeList limitNodeList = specNode.SelectNodes("limit");
            if (limitNodeList.Count >= 1)
            {
                limits = new List<string>();
                foreach (XmlNode limitNode in limitNodeList)
                {
                    string limitStr = limitNode.InnerText;
                    limits.Add(limitStr);
                }
            }
            /* Retrieve the <result> node under <spec> node */
            XmlNode resultNode = specNode.SelectSingleNode("result");
            if (resultNode != null)
            {
                result = resultNode.InnerText;
            }
        }

        public XmlNode CurrentSpecNode
        {
            get { return currentSpecNode; }
        }
        public List<string> Limits
        {
            get { return limits; }
        }
        public string Result
        {
            get { return result; }
            set { result = value; }
        }
    }
}
