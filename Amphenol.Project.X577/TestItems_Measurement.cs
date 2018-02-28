using System;
using System.Collections;
using System.Collections.Generic;
using Amphenol.Instruments.Keysight;

namespace Amphenol.Project.X577
{
    partial class TestItems
    {
        private static DigitalMultiMeter_34461A dmm;

        private static bool InitializeDigitalMultimeter(List<string> stepParameters,
                                                        out string stepResult,
                                                        out string stepStatus,
                                                        out string stepErrorCode,
                                                        out string stepErrorDesc)
        {
            int successFlag;
            string dmmVisaAddress = stepParameters[0];

            dmm = new DigitalMultiMeter_34461A();
            successFlag = dmm.Open(dmmVisaAddress);
            successFlag = dmm.GetInstrumentIdentifier(out stepResult);

            if (successFlag == 0)
            {
                stepStatus = "Pass";
                stepErrorCode = "";
                stepErrorDesc = "";
            }
            else
            {
                stepStatus = "Fail";
                stepErrorCode = "DMM01";
                stepErrorDesc = "Fail to initialize the DMM.";
            }
            return (successFlag == 0);
        }

        private static bool CloseDMM(out string stepResult,
                                     out string stepStatus,
                                     out string stepErrorCode,
                                     out string stepErrorDesc)
        {
            int successFlag = dmm.Close();
            if (successFlag == 0)
            {
                stepResult = "OK";
                stepStatus = "Pass";
                stepErrorCode = string.Empty;
                stepErrorDesc = string.Empty;
            }
            else
            {
                stepResult = "NG";
                stepStatus = "Fail";
                stepErrorCode = "DMMCL";
                stepErrorDesc = "Fail to close the DMM.";
            }
            return (successFlag == 0);
        }

        private static bool MeasureResistorOver2Wires(List<string> limits,
                                                      out string stepResult,
                                                      out string stepStatus,
                                                      out string stepErrorCode,
                                                      out string stepErrorDesc)
        {
            float resistor;
            float lowerLimit = Convert.ToSingle(limits[0]),
                  expectedLimit = Convert.ToSingle(limits[1]),
                  upperLimit = Convert.ToSingle(limits[2]);

            int successFlag = dmm.MeasureResistorVia2Wires(out resistor);
            stepResult = resistor.ToString();

            if ((resistor > lowerLimit) && (resistor < upperLimit))
            {
                stepStatus = "Pass";
                stepErrorCode = "";
                stepErrorDesc = "";
                return true;
            }
            else
            {
                stepStatus = "Fail";
                stepErrorCode = "RES01";
                stepErrorDesc = "Resistance value is out of the range.";
                return false;
            }
        }
    }
}