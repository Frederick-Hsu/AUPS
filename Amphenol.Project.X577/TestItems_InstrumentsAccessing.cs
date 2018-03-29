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
                                          List<string> stepLimits,
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

            int lower = Convert.ToInt32(stepLimits[0]),
                typical = Convert.ToInt32(stepLimits[1]),
                upper = Convert.ToInt32(stepLimits[2]);

            if (successFlag == 0)
            {
                if ((traceNum == lower) && (traceNum == typical) && (traceNum == upper))
                {
                    stepStatus = "Pass";
                    stepErrorCode = "";
                    stepErrorDesc = "";
                    return true;
                }
                else
                {
                    stepStatus = "Fail";
                    stepErrorCode = "OUTSPEC";
                    stepErrorDesc = "Trace count is out of spec.";
                    return false;
                }
            }
            else
            {
                stepStatus = "Fail";
                stepErrorCode = "TRACNT";
                stepErrorDesc = "Failed in get the trace number";
                return false;
            }
        }

        private static bool SelectActiveChannel(List<string> stepParameters,
                                                out string stepResult,
                                                out string stepStatus,
                                                out string stepErrorCode,
                                                out string stepErrorDesc)
        {
            int channelNum = Convert.ToInt32(stepParameters[0]);
            int successFlag = networkAnalyzer.ActivateChannelAt(channelNum);
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
                stepErrorCode = "CHACTI";
                stepErrorDesc = "Failed in activate user-specified channel.";
            }
            return (successFlag == 0);
        }

        private static bool SelectActiveTrace(List<string> stepParameters,
                                              out string stepResult,
                                              out string stepStatus,
                                              out string stepErrorCode,
                                              out string stepErrorDesc)
        {
            int channelNum = Convert.ToInt32(stepParameters[0]), traceNum = Convert.ToInt32(stepParameters[1]);
            int successFlag = networkAnalyzer.ActivateTraceAt(channelNum, traceNum);
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
                stepErrorCode = "TRACTI";
                stepErrorDesc = "Failed in activate user-specified trace";
            }
            return (successFlag == 0);
        }

        private static bool SelectMeasurementParameter(List<string> stepParameters,
                                                       out string stepResult,
                                                       out string stepStatus,
                                                       out string stepErrorCode,
                                                       out string stepErrorDesc)
        {
            int channelNum = Convert.ToInt32(stepParameters[0]), traceNum = Convert.ToInt32(stepParameters[1]);
            string measParam = stepParameters[2];
            int successFlag = networkAnalyzer.SelectMeasurementParameterFor(channelNum, traceNum, measParam);
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
                stepErrorCode = "SPARAM";
                stepErrorDesc = "Failed in selecting the S parameter for user-specified trace.";
            }
            return (successFlag == 0);
        }

        private static bool QueryMeasurementParameter(List<string> stepParameters,
                                                      List<string> stepLimits,
                                                      out string stepResult,
                                                      out string stepStatus,
                                                      out string stepErrorCode,
                                                      out string stepErrorDesc)
        {
            int channelNum = Convert.ToInt32(stepParameters[0]), traceNum = Convert.ToInt32(stepParameters[1]);
            string expected = stepLimits[0];

            int successFlag = networkAnalyzer.QueryMeasurementParameterFor(channelNum, traceNum, out stepResult);
            if (successFlag == 0)
            {
                if (stepResult.Contains(expected))
                {
                    stepStatus = "Pass";
                    stepErrorCode = "";
                    stepErrorDesc = "";
                    return true;
                }
                else
                {
                    stepStatus = "Fail";
                    stepErrorCode = "OUTSPEC";
                    stepErrorDesc = "The queried S parameter for Channel" + channelNum + ":Trace" + traceNum + " is out of spec.";
                    return false; 
                }
            }
            else
            {
                stepStatus = "Fail";
                stepErrorCode = "ERRSPAR";
                stepErrorDesc = "Failed in querying the S parameter.";
                return false;
            }
        }

        private static bool SelectDataFormat(List<string> stepParameters,
                                             out string stepResult,
                                             out string stepStatus,
                                             out string stepErrorCode,
                                             out string stepErrorDesc)
        {
            int channelNum = Convert.ToInt32(stepParameters[0]), traceNum = Convert.ToInt32(stepParameters[1]);
            string format = stepParameters[2];

            int successFlag = networkAnalyzer.SelectDataFormatForActiveTraceOfChannel(channelNum, traceNum, format);
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
                stepErrorCode = "FORMERR";
                stepErrorDesc = "Failed in setting up the data format.";
            }
            return (successFlag == 0);
        }

        private static bool QueryDataFormat(List<string> stepParameters,
                                            List<string> stepLimits,
                                            out string stepResult,
                                            out string stepStatus,
                                            out string stepErrorCode,
                                            out string stepErrorDesc)
        {
            int channelNum = Convert.ToInt32(stepParameters[0]), traceNum = Convert.ToInt32(stepParameters[1]);
            string expected = stepLimits[0];

            int successFlag = networkAnalyzer.QueryDataFormatForActiveTraceOfChannel(channelNum, traceNum, out stepResult);
            if (successFlag == 0)
            {
                if (stepResult.Contains(expected))
                {
                    stepStatus = "Pass";
                    stepErrorCode = "";
                    stepErrorDesc = "";
                    return true;
                }
                else
                {
                    stepStatus = "Fail";
                    stepErrorCode = "FORMOUT";
                    stepErrorDesc = "The queried data format is different from spec.";
                    return false;
                }
            }
            else
            {
                stepStatus = "Fail";
                stepErrorCode = "QFORMERR";
                stepErrorDesc = "Failed in querying the data format.";
                return false;
            }
        }

        private static bool SetSweepType(List<string> stepParameters,
                                         out string stepResult,
                                         out string stepStatus,
                                         out string stepErrorCode,
                                         out string stepErrorDesc)
        {
            int channel = Convert.ToInt32(stepParameters[0]);
            string sweepType = stepParameters[1];

            int successFlag = networkAnalyzer.SetSweepTypeForChannel(channel, sweepType);
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
                stepErrorCode = "SWETYPE";
                stepErrorDesc = "Failed in set the sweep type.";
            }
            return (successFlag == 0);
        }

        private static bool ExecuteNetworkAnalyzerCommand(List<string> stepParameters,
                                                          out string stepResult,
                                                          out string stepStatus,
                                                          out string stepErrorCode,
                                                          out string stepErrorDesc)
        {
            string command = stepParameters[0];
            int successFlag = networkAnalyzer.ExecuteCommand(command);
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
                stepErrorCode = "EXECMD";
                stepErrorDesc = "Failed in executing the command of network analyzer.";
            }
            return (successFlag == 0);
        }

        private static bool SetTraceScalePerDivision(List<string> stepParameters,
                                                     out string stepResult,
                                                     out string stepStatus,
                                                     out string stepErrorCode,
                                                     out string stepErrorDesc)
        {
            int channel = Convert.ToInt32(stepParameters[0]), trace = Convert.ToInt32(stepParameters[1]);
            string scale = stepParameters[2];

            int successFlag = networkAnalyzer.SetScalePerDivisionForChannelTrace(channel, trace, scale);
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
                stepErrorCode = "SCALPDIV";
                stepErrorDesc = "Failed in setting the scale per division for trace.";
            }
            return (successFlag == 0);
        }

        private static bool SetTraceGraticuleLineNumber(List<string> stepParameters,
                                                        out string stepResult,
                                                        out string stepStatus,
                                                        out string stepErrorCode,
                                                        out string stepErrorDesc)
        {
            int channel = Convert.ToInt32(stepParameters[0]),
                trace = Convert.ToInt32(stepParameters[1]),
                graticuleLineNumber = Convert.ToInt32(stepParameters[2]);

            int successFlag = networkAnalyzer.SetReferenceGraticuleLineNumber(channel, trace, graticuleLineNumber);
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
                stepErrorCode = "GRATNUM";
                stepErrorDesc = "Failed in setting the graticule line number for trace.";
            }
            return (successFlag == 0);
        }

        private static bool SetTraceGraticuleLineLevel(List<string> stepParameters,
                                                       out string stepResult,
                                                       out string stepStatus,
                                                       out string stepErrorCode,
                                                       out string stepErrorDesc)
        {
            int channel = Convert.ToInt32(stepParameters[0]), trace = Convert.ToInt32(stepParameters[1]);
            string graticuleLineValue = stepParameters[2];

            int successFlag = networkAnalyzer.SetReferenceGraticuleLineLevel(channel, trace, graticuleLineValue);
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
                stepErrorCode = "GRATVAL";
                stepErrorDesc = "Failed in setting the graticule line value for trace";
            }
            return (successFlag == 0);
        }

        private static bool SetSweepCenterFrequency(List<string> stepParameters,
                                                    out string stepResult,
                                                    out string stepStatus,
                                                    out string stepErrorCode,
                                                    out string stepErrorDesc)
        {
            int channel = Convert.ToInt32(stepParameters[0]);
            string freq = stepParameters[1];

            int successFlag = networkAnalyzer.SetSweepCenterFreqValueForChannel(channel, freq);
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
                stepErrorCode = "CENTFREQ";
                stepErrorDesc = "Failed in setting the sweep center frequency.";
            }
            return (successFlag == 0);
        }

        private static bool SetSweepSpanFrequency(List<string> stepParameters,
                                                  out string stepResult,
                                                  out string stepStatus,
                                                  out string stepErrorCode,
                                                  out string stepErrorDesc)
        {
            int channel = Convert.ToInt32(stepParameters[0]);
            string freq = stepParameters[1];

            int successFlag = networkAnalyzer.SetSweepSpanFreqValueForChannel(channel, freq);
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
                stepErrorCode = "SPANFREQ";
                stepErrorDesc = "Failed in setting the sweep span frequency.";
            }
            return (successFlag == 0);
        }

        private static bool SetSweepPointNumber(List<string> stepParameters,
                                                out string stepResult,
                                                out string stepStatus,
                                                out string stepErrorCode,
                                                out string stepErrorDesc)
        {
            int channel = Convert.ToInt32(stepParameters[0]), points = Convert.ToInt32(stepParameters[1]);
            int successFlag = networkAnalyzer.SetSweepMeasurementPoints(channel, points);
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
                stepErrorCode = "SWEPOIN";
                stepErrorDesc = "Failed in setting the sweep points";
            }
            return (successFlag == 0);
        }

        private static bool SetIFBandwidth(List<string> stepParameters,
                                           out string stepResult,
                                           out string stepStatus,
                                           out string stepErrorCode,
                                           out string stepErrorDesc)
        {
            int channel = Convert.ToInt32(stepParameters[0]);
            string bandwidth = stepParameters[1];

            int successFlag = networkAnalyzer.SetIFBandwidthForChannel(channel, bandwidth);
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
                stepErrorCode = "IFBAND";
                stepErrorDesc = "Failed in setting the IF bandwidth.";
            }
            return (successFlag == 0);
        }

        private static bool SetPowerLevel(List<string> stepParameters,
                                          out string stepResult,
                                          out string stepStatus,
                                          out string stepErrorCode,
                                          out string stepErrorDesc)
        {
            int channel = Convert.ToInt32(stepParameters[0]);
            double power = Convert.ToDouble(stepParameters[1]);
            int successFlag = networkAnalyzer.SetPowerLevelForChannel(channel, power);
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
                stepErrorCode = "POWLEV";
                stepErrorDesc = "Failed in setting the power level.";
            }
            return (successFlag == 0);
        }

        private static bool SaveInstrumentState(List<string> stepParameters,
                                                out string stepResult,
                                                out string stepStatus,
                                                out string stepErrorCode,
                                                out string stepErrorDesc)
        {
            string fileName = stepParameters[0];
            int successFlag = networkAnalyzer.SaveInstrumentStateIntoFile(fileName);
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
                stepErrorCode = "STATEFILE";
                stepErrorDesc = "Failed in saving the instrument state file.";
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