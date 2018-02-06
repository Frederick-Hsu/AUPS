using System;
using System.Xml;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Amphenol.SequenceLib
{
    [DataContract(Name = "Specification", Namespace = "www.amphenol.com")]
    [KnownType(typeof(XmlNode))]
    [KnownType(typeof(XmlElement))]
    public class Spec
    {
        [DataMember]
        private XmlNode currentSpecNode;
        [DataMember]
        private List<string> limits;

        /******************************************************************************************/
        public XmlNode CurrentSpecNode
        {
            get
            {
                return currentSpecNode;
            }
        }
        public IList<string> Limits
        {
            get
            {
                return limits;
            }
        }

        /******************************************************************************************/
        public Spec(XmlNode specNode)
        {
            currentSpecNode = specNode;

            limits = new List<string>();
            /* Only focus on the <limit> nodes */
            XmlNodeList limitNodes = specNode.SelectNodes("limit");
            if (limitNodes != null)
            {
                foreach (XmlNode limitNode in limitNodes)
                {
                    string limitStr = limitNode.InnerText;
                    limits.Add(limitStr);
                }
            }
        }

        public Spec(int arrayCount, string[] limitArray, XmlDocument doc)
        {
            currentSpecNode = doc.CreateElement("spec");    /* new <spec> node */

            limits = new List<string>();
            for (int index = 0; index < arrayCount; index++)
            {
                limits.Add(limitArray[index]);
                /* each <limit> node */
                XmlElement limitNode = doc.CreateElement("limit");
                limitNode.InnerText = limitArray[index];
                /* Append each <limit> child node under the <spec> parent node */
                currentSpecNode.AppendChild(limitNode);
            }
        }

        public Spec(List<string> limits, XmlDocument doc)
        {
            this.limits = new List<string>();

            currentSpecNode = doc.CreateElement("spec");
            foreach (string singleItem in limits)
            {
                this.limits.Add(singleItem);    /* Assign the limits list */
                /* each <limit> node */
                XmlElement limitNode = doc.CreateElement("limit");
                limitNode.InnerText = singleItem;
                /* Appen each <limit> node into <spec> node */
                currentSpecNode.AppendChild(limitNode);
            }
        }

        public void UpdateCurrentSpecContentFor(List<string> limits,/* [NOTE] : limits count must be 3(corresponding to "Numerical") 
                                                                     *          or 1(corresponding to "String"). 
                                                                     *          That is the mandatory requirement.
                                                                     */
                                                XmlDocument doc)
        {
            /* In this scenario, it indicates that user has changed the limit type. */
            if (this.limits.Count != limits.Count)
            {
                /* We need to completely change the limits. */
                this.limits.Clear();    /* Erase all items */
                currentSpecNode.RemoveAll();    /* Discard previous <limit> nodes */
                foreach (string singleItem in limits)
                {
                    this.limits.Add(singleItem);
                    /* Rebuild each <limit> node, and append them into <spec> node again */
                    XmlElement limitNode = doc.CreateElement("limit");
                    limitNode.InnerText = singleItem;
                    currentSpecNode.AppendChild(limitNode);
                }
            }
            /* Scenario : limit type not changed. */
            else if (this.limits.Count == limits.Count)
            {
                XmlNodeList limitNodeList = currentSpecNode.ChildNodes;
                for (int index = 0; index < limits.Count; index++)
                {
                    this.limits[index] = limits[index];
                    /* Change the inner text of each <limit> node. */
                    limitNodeList[index].InnerText = limits[index];
                }
            }
        }
    }
}
