using System.Collections.Generic;
using System.Xml;

namespace Amphenol.Seq
{
    public class Spec
    {
        private List<string> limits;

        public IList<string> Limits
        {
            get
            {
                return limits;
            }
        }

        public Spec(XmlNode specNode)
        {
            limits = new List<string>();
            XmlNodeList limitNodes = specNode.ChildNodes;
            foreach (XmlNode limitNode in limitNodes)
            {
                string limitStr = limitNode.InnerText;
                limits.Add(limitStr);
            }
        }
    }
}
