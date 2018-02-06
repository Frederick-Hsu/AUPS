using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Amphenol.SequenceLib
{
    public class TestParameterList
    {
        private XmlNode currentParameterListNode;
        private List<string> parameters;

        public TestParameterList(XmlNode parameterlistNode)
        {
            currentParameterListNode = parameterlistNode;
            /* Initialize the parameters list */
            parameters = new List<string>();
            /* Retrieve all <parameter> nodes under <parameterlist> node */
            XmlNodeList parameterNodeList = parameterlistNode.ChildNodes;
            
            /* There exists some certain test function needs no parameter. */
            if (parameterNodeList.Count >= 1)
            {
                foreach (XmlNode paramNode in parameterNodeList)
                {
                    string paramStr = paramNode.InnerText;
                    parameters.Add(paramStr);
                }
            }
        }

        public XmlNode CurrentParameterListNode
        {
            get { return currentParameterListNode; }
        }

        public List<string> Parameters
        {
            get { return parameters; }
        }
    }
}
