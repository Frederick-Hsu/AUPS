using System;
using System.Collections.Generic;
using Amphenol.Instruments.Keysight;

namespace Amphenol.Project.X577
{
    partial class TestItems
    {
        private static DCPowerSupply_E3631A pwrSrc;

        private static bool InitializePowerSupply(List<string> stepParameters, 
                                                  out string stepResult, 
                                                  out string stepStatus, 
                                                  out string stepErrorCode, 
                                                  out string stepErrorDesc)
        {
            int successFlag;
            string visaAddress = stepParameters[0];

            pwrSrc = new DCPowerSupply_E3631A();
            successFlag = pwrSrc.Open(visaAddress);
            successFlag = pwrSrc.GetInstrumentIdentifier(out stepResult);
            if (successFlag == 0)
            {
                stepStatus = "Pass";
                stepErrorCode = "";
                stepErrorDesc = "";
            }
            else
            {
                stepStatus = "Fail";
                stepErrorCode = "PWRSUPP";
                stepErrorDesc = "Failed in initializing the Keysight DC power supply E3631A";
            }
            return (successFlag == 0);
        }

        private static bool ClosePowerSupply(out string stepResult,
                                             out string stepStatus,
                                             out string stepErrorCode,
                                             out string stepErrorDesc)
        {
            int successFlag = pwrSrc.Close();
            if (successFlag == 0)
            {
                stepResult = "OK";
                stepStatus = "Pass";
                stepErrorCode = "";
                stepErrorDesc = "";
            }
            else
            {
                stepResult = "NG";
                stepStatus = "Fail";
                stepErrorCode = "PWRCLOS";
                stepErrorDesc = "Failed to close the DC power supply E3631A.";
            }
            return (successFlag == 0);
        }
    }
}