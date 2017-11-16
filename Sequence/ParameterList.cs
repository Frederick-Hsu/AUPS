using System.Collections.Generic;

namespace Amphenol.Seq
{
    public class ParameterList
    {
        private List<string> parameters;

        public IList<string> Parameters
        {
            get
            {
                return parameters;
            }
        }

        public ParameterList(System.Xml.XmlNode paramListNode)
        {
            parameters = new List<string>();
            foreach (System.Xml.XmlNode paramNode in paramListNode.ChildNodes)
            {
                string paramStr = paramNode.InnerText;
                parameters.Add(paramStr);
            }
        }
    }
}
