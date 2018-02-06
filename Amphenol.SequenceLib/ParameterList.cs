using System;
using System.Xml;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Amphenol.SequenceLib
{
    [DataContract(Name = "Parameters", Namespace = "www.amphenol.com")]
    [KnownType(typeof(XmlNode))]
    [KnownType(typeof(XmlElement))]
    public class ParameterList
    {
        [DataMember]
        private XmlNode currentParameterListNode;
        [DataMember]
        private List<string> parameters;

        /******************************************************************************************/
        public XmlNode CurrentParameterListNode
        {
            get
            {
                return currentParameterListNode;
            }
        }
        public IList<string> Parameters
        {
            get
            {
                return parameters;
            }
        }

        /******************************************************************************************/
        public ParameterList(XmlNode paramListNode)
        {
            currentParameterListNode = paramListNode;

            parameters = new List<string>();
            XmlNodeList parameterNodeList = paramListNode.ChildNodes;
            if (parameterNodeList.Count >= 1)
            {
                foreach (XmlNode paramNode in parameterNodeList)
                {
                    string paramStr = paramNode.InnerText;
                    parameters.Add(paramStr);
                }
            }
        }

        public ParameterList(int arrayCount, string[] parameterArray, XmlDocument doc)
        {
            /* new <parameterlist> node */
            currentParameterListNode = doc.CreateElement("parameterlist");

            parameters = new List<string>();
            for (int index = 0; index < arrayCount; index++)
            {
                parameters.Add(parameterArray[index]);
                /* each <parameter> node */
                XmlElement parameterNode = doc.CreateElement("parameter");
                parameterNode.InnerText = parameterArray[index];
                /* Append each <parameter> child node under the <parameterlist> parent node */
                currentParameterListNode.AppendChild(parameterNode);
            }
        }

        public ParameterList(List<string> paramList, XmlDocument doc)
        {
            parameters = new List<string>();    /* Initialize the parameters */

            /* Create the new <parameterlist> node */
            currentParameterListNode = doc.CreateElement("parameterlist");
            foreach (string singleItem in paramList)
            {
                parameters.Add(singleItem);     /* Assign each item of parameters */
                /* each <parameter> node */
                XmlElement parameterNode = doc.CreateElement("parameter");
                parameterNode.InnerText = singleItem;
                /* And append each <parameter> node into the <parameterlist> node */
                currentParameterListNode.AppendChild(parameterNode);
            }
        }

        public void UpdateCurrentParameterListContentFor(List<string> parameters, XmlDocument doc)
        {
            /* Scenario : indicate that user increased or decreased the count of parameters */
            if (this.parameters.Count != parameters.Count)
            {
                /* Destroy parameters list */
                this.parameters.Clear();
                this.currentParameterListNode.RemoveAll();

                for (int index = 0; index < parameters.Count; index++)
                {
                    this.parameters.Add(parameters[index]);     /* Reconstruct the entire list */
                    /* Rebuild each <parameter> node, and append them into <parameterlist> node */
                    XmlElement parameterNode = doc.CreateElement("parameter");
                    parameterNode.InnerText = parameters[index];
                    currentParameterListNode.AppendChild(parameterNode);
                }
            }
            /* Scenario : indicate that user did not changed the count of parameters, only changed some values. */
            else if (this.parameters.Count == parameters.Count)
            {
                XmlNodeList parameterNodeList = currentParameterListNode.ChildNodes;
                for (int index = 0; index < parameters.Count; index++)
                {
                    /* Only need to change the values for the parameters */
                    this.parameters[index] = parameters[index];
                    parameterNodeList[index].InnerText = parameters[index];
                }
            }
        }
    }
}
