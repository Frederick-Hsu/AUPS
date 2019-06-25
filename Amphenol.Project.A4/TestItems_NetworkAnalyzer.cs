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

        private static bool PresetNetworkAnalyzerWindowLayoutDisplay(out string stepResult,
                                                                     out string stepStatus,
                                                                     out string stepErrorCode,
                                                                     out string stepErrorDesc)
        {
            string errorMesg;
            int successFlag = networkAnalyzer.ClearAllErrorQueue();
            successFlag = networkAnalyzer.QueryErrorStatus(out errorMesg);
            successFlag = networkAnalyzer.Preset();
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
                stepErrorCode = "PSETERR";
                stepErrorDesc = "Failed in presetting the window layout and display";
            }
            return (successFlag == 0);
        }

        private static bool ConfigWindowDisplayLayout(List<string> stepParameters,
                                                      out string stepResult,
                                                      out string stepStatus,
                                                      out string stepErrorCode,
                                                      out string stepErrorDesc)
        {
            string windowLayout = stepParameters[0];
            int successFlag = networkAnalyzer.SelectChannelDisplayMode(windowLayout);
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
                stepErrorCode = "WINDISP";
                stepErrorDesc = "Popup an error while configuring the window display format.";
            }
            return (successFlag == 0);
        }

        private static bool AllocateTraceAmountForChannel(List<string> stepParameters,
                                                          out string stepResult,
                                                          out string stepStatus,
                                                          out string stepErrorCode,
                                                          out string stepErrorDesc)
        {
            uint channelNum = Convert.ToUInt32(stepParameters[0]),
                 numberOfTraces = Convert.ToUInt32(stepParameters[1]);
            int successFlag = networkAnalyzer.ConfigTraceNumInChannel(channelNum, numberOfTraces);
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
                stepErrorCode = "TRACENO";
                stepErrorDesc = "Failed to allocate the number of traces in the specific channel.";
            }
            return (successFlag == 0);
        }

        private static bool ConfigTraceDisplayModeInChannel(List<string> stepParameters,
                                                            out string stepResult,
                                                            out string stepStatus,
                                                            out string stepErrorCode,
                                                            out string stepErrorDesc)
        {
            int channelNum = Convert.ToInt32(stepParameters[0]);
            string traceDisplayMode = stepParameters[1];
            int successFlag = networkAnalyzer.SelectTraceDisplayMode(channelNum, traceDisplayMode);
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
                stepErrorCode = "TRCDISP";
                stepErrorDesc = "Failed to set up the trace display mode in the specific channel.";
            }
            return (successFlag == 0);
        }

        private static bool ConfigureMeasurementSParameterAndFormat(List<string> stepParameters,
                                                                    out string stepResult,
                                                                    out string stepStatus,
                                                                    out string stepErrorCode,
                                                                    out string stepErrorDesc)
        {
            int channelNr = Convert.ToInt32(stepParameters[0]);
            int traceNr = Convert.ToInt32(stepParameters[1]);
            string measurementSParameter = stepParameters[2];
            string traceDataFormat = stepParameters[3];

            int successFlag = networkAnalyzer.ActivateChannelAt(channelNr);
            successFlag = networkAnalyzer.ActivateTraceAt(channelNr, traceNr);
            successFlag = networkAnalyzer.SelectMeasurementSParameterFor(channelNr, traceNr, measurementSParameter);
            successFlag = networkAnalyzer.SelectDataFormatForActiveTraceOfChannel(channelNr, traceNr, traceDataFormat);
            successFlag = networkAnalyzer.DisplayOnOffDataTrace((uint)channelNr, (uint)traceNr);

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
                stepErrorCode = "SPARAFRMt";
                stepErrorDesc = "Network analyzer had failed to configure the S-Parameter and data format for the trace you specified."; ;
            }
            return (successFlag == 0);
        }
        private static bool ConfigSweepFreqRange(List<string> stepParameters,
                                                 out string stepResult,
                                                 out string stepStatus,
                                                 out string stepErrorCode,
                                                 out string stepErrorDesc)
        {
            int channelNr = Convert.ToInt32(stepParameters[0]);
            string startFreq = stepParameters[1], stopFreq = stepParameters[2];

            int successFlag = networkAnalyzer.SetSweepStartFreqValueForChannel(channelNr, startFreq);
            successFlag = networkAnalyzer.SetSweepStopFreqValueForChannel(channelNr, stopFreq);
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
                stepErrorCode = "SWPFREQ";
                stepErrorDesc = "Failed in setting up the sweep frequency range.";
            }
            return (successFlag == 0);
        }
    }
}