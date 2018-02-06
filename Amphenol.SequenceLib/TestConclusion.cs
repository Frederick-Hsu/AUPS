using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Amphenol.SequenceLib
{
    public class TestConclusion
    {
        private XmlNode currentConclusionNode;
        private string status;
        private string errorCode;
        private string errorDesc;

        public TestConclusion(XmlNode conclusionNode)
        {
            currentConclusionNode = conclusionNode;

            /* Retrieve the <status> node under <conclusion> node */
            XmlNode statusNode = conclusionNode.SelectSingleNode("status");
            if (statusNode != null)
                status = statusNode.InnerText;

            /* Retrieve the <errorcode> node under <conclusion> node */
            XmlNode errorcodeNode = conclusionNode.SelectSingleNode("errorcode");
            if (errorcodeNode != null)
                errorCode = errorcodeNode.InnerText;

            /* Retrieve the <errordescription> node under <conclusion> node */
            XmlNode errordescriptionNode = conclusionNode.SelectSingleNode("errordescription");
            if (errordescriptionNode != null)
                errorDesc = errordescriptionNode.InnerText;
        }

        public TestConclusion(string testStatus, string testErrorCode, string testErrorDesc, XmlDocument doc)
        {
            status = testStatus;
            errorCode = testErrorCode;
            errorDesc = testErrorDesc;

            /* Create the <conclusion> node */
            currentConclusionNode = doc.CreateElement("conclusion");
            /* <status> node */
            XmlElement statusNode = doc.CreateElement("status");
            statusNode.InnerText = testStatus;
            /* <errorcode> node */
            XmlElement errorcodeNode = doc.CreateElement("errorcode");
            errorcodeNode.InnerText = testErrorCode;
            /* <errordescription> node */
            XmlElement errordescriptionNode = doc.CreateElement("errordescription");
            errordescriptionNode.InnerText = testErrorDesc;

            currentConclusionNode.AppendChild(statusNode);
            currentConclusionNode.AppendChild(errorcodeNode);
            currentConclusionNode.AppendChild(errordescriptionNode);
        }

        public XmlNode CurrentConclusionNode
        {
            get { return currentConclusionNode; }
        }
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        public string ErrorCode
        {
            get { return errorCode; }
            set { errorCode = value; }
        }
        public string ErrorDesc
        {
            get { return errorDesc; }
            set { errorDesc = value; }
        }

        public void UpdateTestConclusion(string testStatus, string testErrorCode, string testErrorDesc, XmlDocument doc)
        {
            status = testStatus;
            errorCode = testErrorCode;
            errorDesc = testErrorDesc;

            /* <status> node */
            XmlNode statusNode = currentConclusionNode.SelectSingleNode("status");
            if (statusNode != null)
            {
                statusNode.InnerText = testStatus;
            }
            else
            {
                statusNode = doc.CreateElement("status");
                statusNode.InnerText = testStatus;
                currentConclusionNode.AppendChild(statusNode);
            }

            /* <errorcode> node */
            XmlNode errorcodeNode = currentConclusionNode.SelectSingleNode("errorcode");
            if (errorcodeNode != null)
            {
                errorcodeNode.InnerText = testErrorCode;
            }
            else
            {
                errorcodeNode = doc.CreateElement("errorcode");
                errorcodeNode.InnerText = testErrorCode;
                currentConclusionNode.AppendChild(errorcodeNode);
            }

            /* <errordescription> node */
            XmlNode errordescriptionNode = currentConclusionNode.SelectSingleNode("errordescription");
            if (errordescriptionNode != null)
            {
                errordescriptionNode.InnerText = testErrorDesc;
            }
            else
            {
                errordescriptionNode = doc.CreateElement("errordescription");
                errordescriptionNode.InnerText = testErrorDesc;
                currentConclusionNode.AppendChild(errordescriptionNode);
            }
        }
    }
}
