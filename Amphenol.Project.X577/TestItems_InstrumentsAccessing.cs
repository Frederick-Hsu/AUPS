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

        private static bool PresetNetworkAnalyzer(out string stepResult,
                                                  out string stepStatus,
                                                  out string stepErrorCode,
                                                  out string stepErrorDesc)
        {
            int successFlag = networkAnalyzer.Preset();
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
                stepErrorCode = "PRESE";
                stepErrorDesc = "Fail to reset the network analyzer.";
            }
            return (successFlag == 0);
        }

        private static bool SetNetAnalyzerWindowLayout(List<string> stepParameters,
                                                       out string stepResult,
                                                       out string stepStatus,
                                                       out string stepErrorCode,
                                                       out string stepErrorDesc)
        {
            int successFlag; 

            if ((stepParameters.Count == 0) || (stepParameters[0].Length == 0))
            {
                successFlag = networkAnalyzer.SelectChannelDisplayMode();
            }
            else
            {
                string windowLayout = stepParameters[0];
                successFlag = networkAnalyzer.SelectChannelDisplayMode(windowLayout);
            }

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
                stepErrorCode = "WINDLE";
                stepErrorDesc = "Fail in setting up the window layout.";
            }
            return (successFlag == 0);
        }

        private static bool SetNetAnalyzerGraphLayout(List<string> stepParameters,
                                                      out string stepResult,
                                                      out string stepStatus,
                                                      out string stepErrorCode,
                                                      out string stepErrorDesc)
        {
            int successFlag;
            int windowNum;
            string graphLayut;
            if (stepParameters.Count == 0)
            {
                successFlag = networkAnalyzer.SelectTraceDisplayMode();
            }
            else if (stepParameters.Count == 1)
            {
                windowNum = Convert.ToInt32(stepParameters[0]);
                successFlag = networkAnalyzer.SelectTraceDisplayMode(windowNum);
            }
            else
            {
                windowNum = Convert.ToInt32(stepParameters[0]);
                graphLayut = stepParameters[1];
                successFlag = networkAnalyzer.SelectTraceDisplayMode(windowNum, graphLayut);
            }

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
                stepErrorCode = "TRALYT";
                stepErrorDesc = "Fail in setting up the trace layout";
            }
            return (successFlag == 0);
        }

        private static bool ConfigureTraceCount(List<string> stepParameters,
                                                out string stepResult,
                                                out string stepStatus,
                                                out string stepErrorCode,
                                                out string stepErrorDesc)
        {
            int successFlag;
            uint channelNum, traceNum;
            if (stepParameters.Count == 0)
            {
                successFlag = networkAnalyzer.ConfigTraceNumInChannel();
            }
            else if (stepParameters.Count == 1)
            {
                channelNum = Convert.ToUInt32(stepParameters[0]);
                successFlag = networkAnalyzer.ConfigTraceNumInChannel(channelNum);
            }
            else
            {
                channelNum = Convert.ToUInt32(stepParameters[0]);
                traceNum = Convert.ToUInt32(stepParameters[1]);
                successFlag = networkAnalyzer.ConfigTraceNumInChannel(channelNum, traceNum);
            }

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
                stepErrorCode = "TRACNT";
                stepErrorDesc = "Fail in configuring the trace number.";
            }
            return (successFlag == 0);
        }

        private static bool GetTraceCount(List<string> stepParameters,
                                          out string stepResult,
                                          out string stepStatus,
                                          out string stepErrorCode,
                                          out string stepErrorDesc)
        {
            int successFlag;
            int channelNum = Convert.ToInt32(stepParameters[0]);
            uint traceNum;
            successFlag = networkAnalyzer.QueryTraceNumberInChannel((uint)channelNum, out traceNum);

            stepResult = traceNum.ToString();
            if (successFlag == 0)
            {
                stepStatus = "Pass";
                stepErrorCode = "";
                stepErrorDesc = "";
            }
            else
            {
                stepStatus = "Fail";
                stepErrorCode = "QTRACNT";
                stepErrorDesc = "Fail in query the trace number.";
            }
            return (successFlag == 0);
        }
    }

    partial class TestItems
    {
        private static Amphenol.Instruments.Keysight.DCPowerSupply_E3646A powerSupply;

        private static bool InitializeDCPowerSupply(List<string> stepParameters,
                                                    out string stepResult,
                                                    out string stepStatus,
                                                    out string stepErrorCode,
                                                    out string stepErrorDesc)
        {
            string visaAddress = stepParameters[0];

            powerSupply = new Instruments.Keysight.DCPowerSupply_E3646A();
            int successFlag = powerSupply.Open(visaAddress);

            successFlag = powerSupply.GetInstrumentIdentifier(out stepResult);

            if (successFlag == 0)
            {
                stepStatus = "Pass";
                stepErrorCode = "";
                stepErrorDesc = "";
            }
            else
            {
                stepStatus = "Fail";
                stepErrorCode = "PWRSU01";
                stepErrorDesc = "Fail to initialize the Keysight DC power supply E3646A.";
            }
            return (successFlag == 0);
        }

        private static bool CloseDCPowerSupply(out string stepResult,
                                               out string stepStatus,
                                               out string stepErrorCode,
                                               out string stepErrorDesc)
        {
            int successFlag = powerSupply.Close();
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
                stepErrorCode = "PWRSU02";
                stepErrorDesc = "Fail to close this DC power supply.";
            }
            return (successFlag == 0);
        }
    }
}                     