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
            bool successFlag = false;
            string ipAddr = stepParameters[0];
            int portNum = Convert.ToInt32(stepParameters[1]);

            dmm = new DigitalMultiMeter_34461A(ipAddr, portNum);
            successFlag = dmm.PingDMM();
            if (successFlag == true)
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
                stepErrorCode = "PINGE";
                stepErrorDesc = "Fail to initalize and ping the DMM over ethernet.";
            }
            return successFlag;
        }
    }
}