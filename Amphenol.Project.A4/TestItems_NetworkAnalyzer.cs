using System;
using System.Collections;
using System.Collections.Generic;
using Amphenol.Instruments.Keysight;

namespace Amphenol.Project.A4
{
    partial class TestItems
    {
        private static NetworkAnalyzer_E5071C networkAnalyzer;

        private static bool InitializeNetworkAnalyzerE5071C(List<string> stepParameters,
                                                             out string stepResult,
                                                             out string stepStatus,
                                                             out string stepErrorCode,
                                                             out string stepErrorDesc)
        {
            int successFlag;
            string visaAddress = stepParameters[0];

            networkAnalyzer = new NetworkAnalyzer_E5071C();
            successFlag = networkAnalyzer.Open(visaAddress);
            successFlag = networkAnalyzer.GetInstrumentIdentifier(out stepResult);

            if (successFlag == 0)
            {
                stepStatus = "PASS";
                stepErrorCode = "";
                stepErrorDesc = "";
            }
            else
            {
                stepStatus = "FAIL";
                stepErrorCode = "NETINIT";
                stepErrorDesc = "Failed to initialize the network analyzer E5071C";
            }
            return (successFlag == 0);
        }

        private static bool CloseNetworkAnalyzerE5071C(out string stepResult, 
                                                       out string stepStatus, 
                                                       out string stepErrorCode, 
                                                       out string stepErrorDesc)
        {
            int successFlag = networkAnalyzer.Close();
            if (successFlag == 0)
            {
                stepResult = "OK";
                stepStatus = "PASS";
                stepErrorCode = "";
                stepErrorDesc = "";
            }
            else
            {
                stepResult = "NG";
                stepStatus = "FAIL";
                stepErrorCode = "NETCLSE";
                stepErrorDesc = "Failed to close the network analyzer E5071C.";
            }
            return (successFlag == 0);
        }
    }
}