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
    }
}
