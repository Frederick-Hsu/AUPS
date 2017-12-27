using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Amphenol.SequenceLib
{
    public class TestStep
    {
        private XmlNode currentStepNode;
        private string stepNum;
        private string stepName;
        private string stepDescription;
        private string stepFunctionName;
        private TestParameterList stepParamList;
        private string stepLimitType;
        private TestSpec stepSpec;
        private TestConclusion stepConclusion;

        public TestStep(XmlNode stepNode)
        {
            currentStepNode = stepNode;
            /* Retrieve the <stepnum> node */
            XmlNode stepnumNode = stepNode.SelectSingleNode("stepnum");
            if (stepnumNode != null)
                stepNum = stepnumNode.InnerText;
            /* Retrieve the <stepname> node */
            XmlNode stepNameNode = stepNode.SelectSingleNode("stepname");
            if (stepNameNode != null)
                stepName = stepNameNode.InnerText;
            /* Retrieve the <stepdescription> node */
            XmlNode stepDescriptionNode = stepNode.SelectSingleNode("stepdescription");
            if (stepDescriptionNode != null)
                stepDescription = stepDescriptionNode.InnerText;
            /* Retrieve the <functionname> node */
            XmlNode stepFunctionNameNode = stepNode.SelectSingleNode("functionname");
            if (stepFunctionNameNode != null)
                stepFunctionName = stepFunctionNameNode.InnerText;
            /* Retrieve the <parameterlist> node */
            XmlNode stepParameterListNode = stepNode.SelectSingleNode("parameterlist");
            if (stepParameterListNode != null)
                stepParamList = new TestParameterList(stepParameterListNode);
            /* Retrieve the <limittype> node */
            XmlNode stepLimitTypeNode = stepNode.SelectSingleNode("limittype");
            if (stepLimitTypeNode != null)
                stepLimitType = stepLimitTypeNode.InnerText;
            /*Retrieve the <spec> node */
            XmlNode stepSpecNode = stepNode.SelectSingleNode("spec");
            if (stepSpecNode != null)
                stepSpec = new TestSpec(stepSpecNode);
            /* Retrieve the <conclusion> node */
            XmlNode stepConclusionNode = stepNode.SelectSingleNode("conclusion");
            if (stepConclusionNode != null)
                stepConclusion = new TestConclusion(stepConclusionNode);
        }

        public XmlNode CurrentStepNode
        {
            get { return currentStepNode; }
        }
        public string StepNum
        {
            get { return stepNum; }
            set { stepNum = value; }
        }
        public string StepName
        {
            get { return stepName; }
            set { stepName = value; }
        }
        public string StepDescription
        {
            get { return stepDescription; }
            set { stepDescription = value; }
        }
        public string StepFunctionName
        {
            get { return stepFunctionName; }
            set { stepFunctionName = value; }
        }
        public TestParameterList StepParamList
        {
            get { return stepParamList; }
        }
        public string StepLimitType
        {
            get { return stepLimitType; }
            set { stepLimitType = value; }
        }
        public TestSpec StepSpec
        {
            get { return stepSpec; }
        }
        public TestConclusion StepConclusion
        {
            get { return stepConclusion; }
        }
    }
}
