using System;
using System.Collections.Generic;

namespace Amphenol.Project.X577
{
    partial class TestItems
    {
        private static Amphenol.Instruments.Keysight.NetworkAnalyzer_E5071C networkAnalyzer;

        private static bool InitializeNetworkAnalyzer(List<string> stepParameters,
                                                      out string stepResult,
                                                      out string stepStatus,
                                                      out string stepErrorCode,
                                                      out string stepErrorDesc)
        {
            int successFlag;
            string networkAnalyzerVisaAddress = stepParameters[0];

            networkAnalyzer = new Instruments.Keysight.NetworkAnalyzer_E5071C();
            successFlag = networkAnalyzer.Open(networkAnalyzerVisaAddress);
            successFlag = networkAnalyzer.GetInstrumentIdentifier(out stepResult);

            if (successFlag == 0)
            {
                stepStatus = "Pass";
                stepErrorCode = string.Empty;
                stepErrorDesc = string.Empty;
            }
            else
            {
                stepStatus = "Fail";
                stepErrorCode = "NETAN01";
                stepErrorDesc = "Fail to initialize the Keysight network analyzer E5071C.";
            }
            return (successFlag == 0);
        }

        private static bool CloseNetworkAnalyzer(out string stepResult,
                                                 out string stepStatus,
                                                 out string stepErrorCode,
                                                 out string stepErrorDesc)
        {
            int successFlag = networkAnalyzer.Close();
            if (successFlag == 0)
            {
                stepResult = "OK";
                stepStatus = "Pass";
                stepErrorCode = "";
                stepErrorDesc = "";
            }
            else
            {
                stepResult = "NOK";
                stepStatus = "Fail";
                stepErrorCode = "NETAN02";
                stepErrorDesc = "Fail to close the network analyzer.";
            }
            return (successFlag == 0);
        }
    }
}                     