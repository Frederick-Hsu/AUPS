using System;
using System.Xml;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Amphenol.SequenceLib
{
    [DataContract(Name = "Step", Namespace = "www.amphenol.com")]
    [KnownType(typeof(XmlNode))]
    [KnownType(typeof(XmlElement))]
    public class Step
    {
        [DataMember]
        private XmlNode currentStepNode;
        [DataMember]
        private string stepNum;
        [DataMember]
        private string stepName;
        [DataMember]
        private string stepDescription;
        [DataMember]
        private string stepFunctionName;
        [DataMember]
        private ParameterList parameterList;
        [DataMember]
        private string limitType;
        [DataMember]
        private Spec limitList;

        /******************************************************************************************/
        public Step(XmlNode stepNode)
        {
            currentStepNode = stepNode;

            XmlNode stepnumNode = stepNode.SelectSingleNode("stepnum");
            if (stepnumNode != null)
                stepNum = stepnumNode.InnerText;

            XmlNode stepnameNode = stepNode.SelectSingleNode("stepname");
            if (stepnameNode != null)
                stepName = stepnameNode.InnerText;

            XmlNode stepdescriptionNode = stepNode.SelectSingleNode("stepdescription");
            if (stepdescriptionNode != null)
                stepDescription = stepdescriptionNode.InnerText;

            XmlNode stepFunctionNameNode = stepNode.SelectSingleNode("functionname");
            if (stepFunctionNameNode != null)
                stepFunctionName = stepFunctionNameNode.InnerText;

            XmlNode parameterlistNode = stepNode.SelectSingleNode("parameterlist");
            if (parameterlistNode != null)
                parameterList = new ParameterList(parameterlistNode);

            XmlNode limittypeNode = stepNode.SelectSingleNode("limittype");
            if (limittypeNode != null)
                limitType = limittypeNode.InnerText;

            XmlNode specNode = stepNode.SelectSingleNode("spec");
            if (specNode != null)
                limitList = new Spec(specNode);
        }

        /******************************************************************************************/
        public XmlNode CurrentStepNode
        {
            get
            {
                return currentStepNode;
            }
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

        /******************************************************************************************/
        public Step(string stepnum,
                    string stepname,
                    string stepdescription,
                    string stepfunctionname,
                    ParameterList paramlist,
                    string limittype,
                    Spec limitlist,
                    XmlDocument doc)
        {
            stepNum = stepnum;
            stepName = stepname;
            stepDescription = stepdescription;
            stepFunctionName = stepfunctionname;
            parameterList = paramlist;
            limitType = limittype;
            limitList = limitlist;

            /* new <step> node */
            currentStepNode = doc.CreateElement("step");

            /* <stepnum> node */
            XmlElement stepnumNode = doc.CreateElement("stepnum");
            stepnumNode.InnerText = stepnum;
            /* <stepname> node */
            XmlElement stepnameNode = doc.CreateElement("stepname");
            stepnameNode.InnerText = stepname;
            /* <stepdescription> node */
            XmlElement stepdescriptionNode = doc.CreateElement("stepdescription");
            stepdescriptionNode.InnerText = stepdescription;
            /* <functionname> node */
            XmlElement functionnameNode = doc.CreateElement("functionname");
            functionnameNode.InnerText = stepfunctionname;
            /* <parameterlist> node */
            XmlNode parameterlistNode = paramlist.CurrentParameterListNode.CloneNode(true);
            /* <limittype> node */
            XmlElement limittypeNode = doc.CreateElement("limittype");
            limittypeNode.InnerText = limittype;
            /* <spec> node */
            XmlNode specNode = limitlist.CurrentSpecNode.CloneNode(true);

            currentStepNode.AppendChild(stepnumNode);
            currentStepNode.AppendChild(stepnameNode);
            currentStepNode.AppendChild(stepdescriptionNode);
            currentStepNode.AppendChild(functionnameNode);
            currentStepNode.AppendChild(parameterlistNode);
            currentStepNode.AppendChild(limittypeNode);
            currentStepNode.AppendChild(specNode);
        }

#if false
        public Step(string stepnum, 
                    string stepname, 
                    string stepdescription, 
                    XmlDocument doc)
        {
            this.stepNum = stepnum;
            this.stepName = stepname;
            this.stepDescription = stepdescription;

            /* new <step> node */
            currentStepNode = doc.CreateElement("step");

            /* <stepnum> node */
            XmlElement stepnumNode = doc.CreateElement("stepnum");
            stepnumNode.InnerText = stepnum;
            /* <stepname> node */
            XmlElement stepnameNode = doc.CreateElement("stepname");
            stepnameNode.InnerText = stepname;
            /* <stepdescription> node */
            XmlElement stepdescriptionNode = doc.CreateElement("stepdescription");
            stepdescriptionNode.InnerText = stepdescription;

            /* At current condition, <functionname>, <parameterlist>, <limittype> and <spec>
             * XML nodes are empty, we will append them later.
             */
            currentStepNode.AppendChild(stepnumNode);
            currentStepNode.AppendChild(stepnameNode);
            currentStepNode.AppendChild(stepdescriptionNode);
        }

        public void UpdateCurrentStepContentForItems(string stepNumValueChanged,
                                                     string stepNameValueChanged,
                                                     string stepDescriptionValueChanged,
                                                     string stepFunctionNameValueChanged,
                                                     string limitTypeValueChanged,
                                                     XmlDocument doc)
        {
            this.stepNum = stepNumValueChanged;
            this.stepName = stepNameValueChanged;
            this.stepDescription = stepDescriptionValueChanged;
            this.stepFunctionName = stepFunctionNameValueChanged;
            this.limitType = limitTypeValueChanged;

            /* Change the inner text values for <stepnum>, <stepname>, <stepdescription>, 
             * <functionname>, <limittype> XML nodes.
             */
            XmlNode stepnumNode = currentStepNode.SelectSingleNode("stepnum");      /* <stepnum> node */
            if (stepnumNode == null)
            {   /* If <step> node does not contain <stepnum> node, then create it. */
                stepnumNode = doc.CreateElement("stepnum");
                stepnumNode.InnerText = stepNumValueChanged;
                currentStepNode.AppendChild(stepnumNode);
            }
            else
            {
                stepnumNode.InnerText = stepNumValueChanged;
            }

            XmlNode stepnameNode = currentStepNode.SelectSingleNode("stepname");    /* <stepname> node */
            if (stepnameNode == null)
            {
                stepnameNode = doc.CreateElement("stepname");
                stepnameNode.InnerText = stepNameValueChanged;
                currentStepNode.AppendChild(stepnameNode);
            }
            else
            {
                stepnameNode.InnerText = stepNameValueChanged;
            }

            XmlNode stepdescriptionNode = currentStepNode.SelectSingleNode("stepdescription");      /* <stepdescription> node */
            if (stepdescriptionNode == null)
            {
                stepdescriptionNode = doc.CreateElement("stepdescription");
                stepdescriptionNode.InnerText = stepDescriptionValueChanged;
                currentStepNode.AppendChild(stepdescriptionNode);
            }
            else
            {
                stepdescriptionNode.InnerText = stepDescriptionValueChanged;
            }

            XmlNode functionnameNode = currentStepNode.SelectSingleNode("functionname");    /* <functionname> node */
            if (functionnameNode == null)
            {
                functionnameNode = doc.CreateElement("functionname");
                functionnameNode.InnerText = stepFunctionNameValueChanged;
                currentStepNode.AppendChild(functionnameNode);
            }
            else
            {
                functionnameNode.InnerText = stepFunctionNameValueChanged;
            }

            XmlNode limittypeNode = currentStepNode.SelectSingleNode("limittype");      /* <limittype> node */
            if (limittypeNode == null)
            {
                limittypeNode = doc.CreateElement("limittype");
                limittypeNode.InnerText = limitTypeValueChanged;
                currentStepNode.AppendChild(limittypeNode);
            }
            else
            {
                limittypeNode.InnerText = limitTypeValueChanged;
            }
        }

        public void UpdateCurrentStepParameters(ParameterList paramList)
        {
            this.parameterList = paramList;      /* Change the value of parameterList object */
            /* Check the <parameterlist> XmlNode */
            XmlNode parameterlistNode = currentStepNode.SelectSingleNode("parameterlist");
            if (parameterlistNode == null)
            {
                parameterlistNode = paramList.CurrentParameterListNode.CloneNode(true);
                currentStepNode.AppendChild(parameterlistNode);
            }
            else
            {
                parameterlistNode = paramList.CurrentParameterListNode.CloneNode(true);
            }
        }

        public void UpdateCurrentStepSpec(Spec limits)
        {
            this.limitList = limits;
            /* Check the <spec> XmlNode */
            XmlNode specNode = currentStepNode.SelectSingleNode("spec");
            if (specNode == null)
            {
                specNode = limits.CurrentSpecNode.CloneNode(true);
                currentStepNode.AppendChild(specNode);
            }
            else
            {
                specNode = limits.CurrentSpecNode.CloneNode(true);
            }
        }
#endif

        public void ModifyCurrentStep(string stepNumValue, 
                                      string stepNameValue, 
                                      string stepDesriptionValue,
                                      string stepFunctionNameValue,
                                      ParameterList stepParamListValue,
                                      string stepLimitTypeValue,
                                      Spec   stepSpecValue)
        {
            this.stepNum = stepNumValue;
            this.stepName = stepNameValue;
            this.stepDescription = stepDesriptionValue;
            this.stepFunctionName = stepFunctionNameValue;
            this.parameterList = stepParamListValue;
            this.limitType = stepLimitTypeValue;
            this.limitList = stepSpecValue;

            /* Change <stepnum> node */
            XmlNode stepnumNode = currentStepNode.SelectSingleNode("stepnum");
            stepnumNode.InnerText = stepNumValue;
            /* Change <stepname> node */
            XmlNode stepnameNode = currentStepNode.SelectSingleNode("stepname");
            stepnameNode.InnerText = stepNameValue;
            /* Change <stepdescription> node */
            XmlNode stepdescriptionNode = currentStepNode.SelectSingleNode("stepdescription");
            stepdescriptionNode.InnerText = stepDesriptionValue;
            /* Change <functionname> node */
            XmlNode functionnameNode = currentStepNode.SelectSingleNode("functionname");
            functionnameNode.InnerText = stepFunctionNameValue;
            /* Replace <parameterlist> node */
            XmlNode parameterlistNode = currentStepNode.SelectSingleNode("parameterlist");
            currentStepNode.ReplaceChild(stepParamListValue.CurrentParameterListNode, parameterlistNode);
            /* Change <limittype> node */
            XmlNode limittypeNode = currentStepNode.SelectSingleNode("limittype");
            limittypeNode.InnerText = stepLimitTypeValue;
            /* Replace <spec> node */
            XmlNode specNode = currentStepNode.SelectSingleNode("spec");
            currentStepNode.ReplaceChild(stepSpecValue.CurrentSpecNode, specNode);
        }
    }
}
