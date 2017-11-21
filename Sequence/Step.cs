using System.Collections.Generic;
using System.Xml;

namespace Amphenol.Seq
{
    public class Step
    {
        private string stepNum;
        private string stepName;
        private string stepDescription;
        private string stepFunctionName;
        private ParameterList parameterList;
        private string limitType;
        private Spec limitList;

        public Step(XmlNode stepNode)
        {
            stepNum = stepNode.SelectSingleNode("stepnum").InnerText;
            stepName = stepNode.SelectSingleNode("stepname").InnerText;
            stepDescription = stepNode.SelectSingleNode("stepdescription").InnerText;

            stepFunctionName = stepNode.SelectSingleNode("functionname").InnerText;
            parameterList = new ParameterList(stepNode.SelectSingleNode("parameterlist"));
            limitType = stepNode.SelectSingleNode("limittype").InnerText;
            limitList = new Spec(stepNode.SelectSingleNode("spec"));
        }

        public string StepNum
        {
            get
            {
                return stepNum;
            }
            set
            {
                stepNum = value;
            }
        }
        public string StepName
        {
            get
            {
                return stepName;
            }
            set
            {
                stepName = value;
            }
        }
        public string StepDescription
        {
            get
            {
                return stepDescription;
            }
            set
            {
                stepDescription = value;
            }
        }
        public string StepFunctionName
        {
            get
            {
                return stepFunctionName;
            }
            set
            {
                stepFunctionName = value;
            }
        }
        public IList<string> Parameters
        {
            get
            {
                return parameterList.Parameters;
            }
        }
        public ParameterList ParamList
        {
            get
            {
                return parameterList;
            }
        }
        public string LimitType
        {
            get
            {
                return limitType;
            }
            set
            {
                limitType = value;
            }
        }
        public IList<string> Limits
        {
            get
            {
                return limitList.Limits;
            }
        }
        public Spec LimitList
        {
            get
            {
                return limitList;
            }
        }
    }
}
