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

        private static bool ShowHideSoftkeyLabel(List<string> stepParameters,
                                                 out string stepResult,
                                                 out string stepStatus,
                                                 out string stepErrorCode,
                                                 out string stepErrorDesc)
        {
            string state = stepParameters[0];
            int successFlag = networkAnalyzer.ShowHideSoftkeyLabels(state);
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
                stepErrorCode = "SOFTKEY";
                stepErrorDesc = "Failed to turn ON/OFF the soft key labels.";
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
            successFlag = networkAnalyzer.TurnOnOffContinuousInitiationModeForChannel(channelNr, "ON");
            successFlag = networkAnalyzer.AutoScaleTraceDisplay(channelNr, traceNr);

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

        private static bool AutoScallTraceDisplay(List<string> stepParameters,
                                                  out string stepResult,
                                                  out string stepStatus,
                                                  out string stepErrorCode,
                                                  out string stepErrorDesc)
        {
            int channelNr = Convert.ToInt32(stepParameters[0]),
                traceNr = Convert.ToInt32(stepParameters[1]);
            int successFlag = networkAnalyzer.ActivateChannelAt(channelNr);
            successFlag = networkAnalyzer.ActivateTraceAt(channelNr, traceNr);
            successFlag = networkAnalyzer.AutoScaleTraceDisplay(channelNr, traceNr);
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
                stepErrorCode = "AUTOSCL";
                stepErrorDesc = "Failed in auto-scalling the trace display.";
            }
            return (successFlag == 0);
        }

        private static bool ConfigureChannelTraceDisplayScale(List<string> stepParameters,
                                                              out string stepResult,
                                                              out string stepStatus,
                                                              out string stepErrorCode,
                                                              out string stepErrorDesc)
        {
            int channelNr = Convert.ToInt32(stepParameters[0]),
                traceNr = Convert.ToInt32(stepParameters[1]),
                numOfDivisions = Convert.ToInt32(stepParameters[2]);
            string scalePerDivision = stepParameters[3];
            int graticuleLineNr = Convert.ToInt32(stepParameters[4]);
            string graticuleLineValue = stepParameters[5];

            int successFlag = networkAnalyzer.ActivateChannelAt(channelNr);
            successFlag = networkAnalyzer.ActivateTraceAt(channelNr, traceNr);

            string traceDataFormat;
            successFlag = networkAnalyzer.QueryDataFormatForActiveTraceOfChannel(channelNr, traceNr, out traceDataFormat);
            switch (traceDataFormat)
            {
                case "MLOG\n":    // Log Mag
                case "PHAS\n":    // Phase
                case "GDEL\n":    // Group Delay
                case "MLIN\n":    // Lin Mag
                case "SWR\n":     // SWR
                case "REAL\n":    // Real
                case "IMAG\n":    // Imaginary
                case "UPH\n":     // Expanded Phase
                case "PPH\n":     // Positive Phase
                    successFlag = networkAnalyzer.SetTraceDivisionNumberForChannel(channelNr, numOfDivisions);
                    successFlag = networkAnalyzer.SetScalePerDivisionForChannelTrace(channelNr, traceNr, scalePerDivision);
                    successFlag = networkAnalyzer.SetReferenceGraticuleLineNumber(channelNr, traceNr, graticuleLineNr);
                    successFlag = networkAnalyzer.SetReferenceGraticuleLineLevel(channelNr, traceNr, graticuleLineValue);
                    break;
                case "SLIN\n":    // Smith Lin/Phase
                case "SLOG\n":    // Smith Log/Phase
                case "SCOM\n":    // Smith Real/Imag
                case "SMIT\n":    // Smith R + jX
                case "SADM\n":    // Smith G + jB
                case "PLIN\n":    // Polar Lin/Phase
                case "PLOG\n":    // Polar Log/Phase
                case "POL\n":     // Polar Real/Imag
                    successFlag = networkAnalyzer.SetScalePerDivisionForChannelTrace(channelNr, traceNr, scalePerDivision);
                    break;
            }
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
                stepErrorCode = "DISPSCL";
                stepErrorDesc = "Failed in configuring the trace display scale";
            }
            return (successFlag == 0);
        }

        private static bool MaximizeOnOffChannelTraceDisplay(List<string> stepParameters,
                                                             out string stepResult,
                                                             out string stepStatus,
                                                             out string stepErrorCode,
                                                             out string stepErrorDesc)
        {
            int channelNr = Convert.ToInt32(stepParameters[0]);
            string channelMaxOnOff = stepParameters[1];
            int traceNr = Convert.ToInt32(stepParameters[2]);
            string traceMaxOnOff = stepParameters[3];

            int successFlag = networkAnalyzer.ActivateChannelAt(channelNr);
            successFlag = networkAnalyzer.MaximizeOnOffActiveChannel(channelMaxOnOff);

            successFlag = networkAnalyzer.ActivateTraceAt(channelNr, traceNr);
            successFlag = networkAnalyzer.MaximizeOnOffActiveTraceForChannel(channelNr, traceMaxOnOff);
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
                stepErrorCode = "MAXONOFF";
                stepErrorDesc = "Failed to setup the MAX ON/OFF display";
            }
            return (successFlag == 0);
        }

        #region Marker Search
        private static bool ShowHideRegularMarker(List<string> stepParameters,
                                                  out string stepResult,
                                                  out string stepStatus,
                                                  out string stepErrorCode,
                                                  out string stepErrorDesc)
        {
            int channelNr = Convert.ToInt32(stepParameters[0]);
            int traceNr = Convert.ToInt32(stepParameters[1]);
            int markerNr = Convert.ToInt32(stepParameters[2]);
            string onOffState = stepParameters[3];
            int successFlag = networkAnalyzer.MarkerSearchShowHideRegularMarkerForActiveTrace(channelNr, traceNr, markerNr, onOffState);
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
                stepErrorCode = "MARKONF";
                stepErrorDesc = "Failed to turn ON/OFF the regular marker display.";
            }
            return (successFlag == 0);
        }

        private static bool ShowHideReferenceMarker(List<string> stepParameters,
                                                    out string stepResult,
                                                    out string stepStatus,
                                                    out string stepErrorCode,
                                                    out string stepErrorDesc)
        {
            int channelNr = Convert.ToInt32(stepParameters[0]);
            int traceNr = Convert.ToInt32(stepParameters[1]);
            string onOffState = stepParameters[2];
            int successFlag = networkAnalyzer.MarkerSearchShowOnOffReferenceMarkerMode(channelNr, traceNr, onOffState);
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
                stepErrorCode = "REFMARK";
                stepErrorDesc = "Turning ON/OFF the reference marker failed.";
            }
            return (successFlag == 0);
        }

        private static bool SelectMarkerSearchType(List<string> stepParameters,
                                                   out string stepResult,
                                                   out string stepStatus,
                                                   out string stepErrorCode,
                                                   out string stepErrorDesc)
        {
            int channelNr = Convert.ToInt32(stepParameters[0]),
                traceNr = Convert.ToInt32(stepParameters[1]),
                markerNr = Convert.ToInt32(stepParameters[2]);
            string searchType = stepParameters[3];
            int successFlag = networkAnalyzer.MarkerSearchSelectSearchType(channelNr, traceNr, markerNr, searchType);
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
                stepErrorCode = "SRCHTYP";
                stepErrorDesc = "Failed to set the marker search type";
            }
            return (successFlag == 0);
        }

        private static bool TargetMarkerSearch(List<string> stepParameters,
                                               out string stepResult,
                                               out string stepStatus,
                                               out string stepErrorCode,
                                               out string stepErrorDesc)
        {
            int channelNr = Convert.ToInt32(stepParameters[0]);
            int traceNr = Convert.ToInt32(stepParameters[1]);
            int markerNr = Convert.ToInt32(stepParameters[2]);
            string markerSearchType = stepParameters[3];
            string targetResponseValue = stepParameters[4];
            string searchDirection = stepParameters[5];

            int successFlag = networkAnalyzer.ActivateChannelAt(channelNr);
            successFlag = networkAnalyzer.ActivateTraceAt(channelNr, traceNr);
            successFlag = networkAnalyzer.MarkerSearchSelectSearchType(channelNr, traceNr, markerNr, markerSearchType);
            successFlag = networkAnalyzer.MarkerSearchDefineTarget(channelNr, traceNr, markerNr, targetResponseValue, searchDirection);

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
                stepErrorCode = "TARSRCH";
                stepErrorDesc = "Failed to set the target marker search.";
            }
            return (successFlag == 0);
        }

        private static bool TurnOnOffMarkerSearchTrackingFeature(List<string> stepParameters,
                                                                 out string stepResult,
                                                                 out string stepStatus,
                                                                 out string stepErrorCode,
                                                                 out string stepErrorDesc)
        {
            int channelNr = Convert.ToInt32(stepParameters[0]);
            int traceNr = Convert.ToInt32(stepParameters[1]);
            int markerNr = Convert.ToInt32(stepParameters[2]);
            string onOff = stepParameters[3];

            int successFlag = networkAnalyzer.MarkerSearchTurnOnOffSearchTrackingFeature(channelNr, traceNr, markerNr, onOff);
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
                stepErrorCode = "MARKTRK";
                stepErrorDesc = "Failed to turn ON or OFF the marker search tracking feature.";
            }
            return (successFlag == 0);
        }

        private static bool PerformMarkerSearch(List<string> stepParameters,
                                                out string stepResult,
                                                out string stepStatus,
                                                out string stepErrorCode,
                                                out string stepErrorDesc)
        {
            int channelNr = Convert.ToInt32(stepParameters[0]);
            int traceNr = Convert.ToInt32(stepParameters[1]);
            int markerNr = Convert.ToInt32(stepParameters[2]);
            string errormesg;
            int successFlag = networkAnalyzer.MarkerSearchPerformSearchWithMarker(channelNr, traceNr, markerNr, out errormesg);
            if (successFlag == 0)
            {
                stepResult = "OK";
                stepStatus = "Pass";
                stepErrorCode = "";
                stepErrorDesc = "";
                return true;
            }
            else
            {
                stepResult = "NG";
                stepStatus = "Fail";
                stepErrorCode = "PERFMRK";
                stepErrorDesc = errormesg;
                return false;
            }
        }

        private static bool RetrieveMarkerSearchResults(List<string> stepParameters,
                                                        List<string> stepLimits,
                                                        out string stepResult,
                                                        out string stepStatus,
                                                        out string stepErrorCode,
                                                        out string stepErrorDesc)
        {
            int channelNr = Convert.ToInt32(stepParameters[0]),
                traceNr = Convert.ToInt32(stepParameters[1]),
                markerNr = Convert.ToInt32(stepParameters[2]);
            double freq;
            List<double> magnitudes;
            int successFlag = networkAnalyzer.MarkerSearchRetrieveStimulusValueAtMarkerPosition(channelNr, traceNr, markerNr, out freq);
            successFlag = networkAnalyzer.MarkerSearchRetrieveResponseValueAtMarkerPosition(channelNr, traceNr, markerNr, out magnitudes);

            string dataFormat;
            successFlag = networkAnalyzer.QueryDataFormatForActiveTraceOfChannel(channelNr, traceNr, out dataFormat);
            switch (dataFormat)
            {
                case "MLOG\n":    // Log Mag
                case "PHAS\n":    // Phase
                case "GDEL\n":    // Group Delay
                case "MLIN\n":    // Lin Mag
                case "SWR\n":     // SWR
                case "REAL\n":    // Real
                case "IMAG\n":    // Imaginary
                case "UPH\n":     // Expanded Phase
                case "PPH\n":     // Positive Phase
                    stepResult = magnitudes[0].ToString();
                    break;
                case "SLIN\n":    // Smith Lin/Phase
                case "SLOG\n":    // Smith Log/Phase
                case "SCOM\n":    // Smith Real/Imag
                case "SMIT\n":    // Smith R + jX
                case "SADM\n":    // Smith G + jB
                case "PLIN\n":    // Polar Lin/Phase
                case "PLOG\n":    // Polar Log/Phase
                case "POL\n":     // Polar Real/Imag
                    stepResult = magnitudes[0].ToString() + ", " + magnitudes[1].ToString();
                    break;
                default:
                    stepResult = "";
                    break;
            }
            double lower = Convert.ToDouble(stepLimits[0]), 
                   typical = Convert.ToDouble(stepLimits[1]), 
                   upper = Convert.ToDouble(stepLimits[2]);
            if ((lower < magnitudes[0]) && (magnitudes[0] < upper))
            {
                stepStatus = "Pass";
                stepErrorCode = "";
                stepErrorDesc = "";
                return true;
            }
            else
            {
                stepStatus = "Fail";
                stepErrorCode = "MARKRES";
                stepErrorDesc = "The result retrieved by marker search is out of range.";
                return false;
            }
        }
        #endregion

        private static bool PlotMaskLineForA4(List<string> stepParameters,
                                              out string stepResult,
                                              out string stepStatus,
                                              out string stepErrorCode,
                                              out string stepErrorDesc)
        {
            int channelNo = Convert.ToInt32(stepParameters[0]),
                traceNo = Convert.ToInt32(stepParameters[1]),
                markerNo = Convert.ToInt32(stepParameters[2]);
            string targetType = stepParameters[3];      /* Marker search type : TARGet */
            string targetValueIndB = stepParameters[4];

            int successFlag = networkAnalyzer.MarkerSearchActivateRegularMarkerNo(channelNo, traceNo, markerNo);
            successFlag = networkAnalyzer.MarkerSearchSetStimulusValueAtMarkerPosition(channelNo, traceNo, markerNo, "1.0E9");

            /* Store the trace data to memory */
            successFlag = networkAnalyzer.CopyMeasurementDateToMemoryTrace((uint)channelNo);
            successFlag = networkAnalyzer.DisplayOnOffDataTrace((uint)channelNo, (uint)traceNo, "OFF");
            successFlag = networkAnalyzer.DisplayOnOffMemoryTrace((uint)channelNo, (uint)traceNo, "ON");

            List<double> freqValues = new List<double>();
            List<double> magnitudes = new List<double>();
            string errorMesg;
            do
            {
                successFlag = networkAnalyzer.MarkerSearchSelectSearchType(channelNo, traceNo, markerNo, targetType);
                successFlag = networkAnalyzer.MarkerSearchDefineTarget(channelNo, traceNo, markerNo, targetValueIndB, "BOTH");
                successFlag = networkAnalyzer.MarkerSearchPerformSearchWithMarker(channelNo, traceNo, markerNo, out errorMesg);
                if ((successFlag != 0))    /* If no target value searched */
                {
                    break;
                }
                double freq;
                List<double> magnitude;
                successFlag = networkAnalyzer.MarkerSearchRetrieveResponseValueAtMarkerPosition(channelNo, traceNo, markerNo, out magnitude);
                if ((-10.02 < magnitude[0]) && (magnitude[0] < -9.98))    /* Filter the points whose magnitude is not -10.0dB */
                {
                    magnitudes.Add(magnitude[0]);
                    successFlag = networkAnalyzer.MarkerSearchRetrieveStimulusValueAtMarkerPosition(channelNo, traceNo, markerNo, out freq);
                    freqValues.Add(freq);
                }
            }
            while (successFlag == 0);

            /* Plot the mask line, according to the 6 marker points captured */
            NetworkAnalyzer_E5071C.LimitLineSegment maskLineSegm1, 
                                                    maskLineSegm2, 
                                                    maskLineSegm3, 
                                                    maskLineSegm4, 
                                                    maskLineSegm5,
                                                    maskLineSegm6,
                                                    maskLineSegm7;
            {
                maskLineSegm1.type = 1;
                maskLineSegm1.startPointHaxisValue  = (freqValues[0] - Convert.ToDouble("500e6")).ToString();
                maskLineSegm1.endPointHaxisValue    = (freqValues[0] - Convert.ToDouble("20e6")).ToString();
                maskLineSegm1.startPointVaxisValue  = "-10.0";
                maskLineSegm1.endPointVaxisValue    = "-10.0";
            }
            {
                maskLineSegm2.type = 1;
                maskLineSegm2.startPointHaxisValue  = (freqValues[0] + Convert.ToDouble("20e6")).ToString();
                maskLineSegm2.endPointHaxisValue    = (freqValues[1] - Convert.ToDouble("20e6")).ToString();
                maskLineSegm2.startPointVaxisValue  = "-10.0";
                maskLineSegm2.endPointVaxisValue    = "-10.0";
            }
            {
                maskLineSegm3.type = 1;
                maskLineSegm3.startPointHaxisValue  = (freqValues[1] + Convert.ToDouble("20e6")).ToString();
                maskLineSegm3.endPointHaxisValue    = (freqValues[2] - Convert.ToDouble("20e6")).ToString();
                maskLineSegm3.startPointVaxisValue  = "-10.0";
                maskLineSegm3.endPointVaxisValue    = "-10.0";
            }
            {
                maskLineSegm4.type = 1;
                maskLineSegm4.startPointHaxisValue  = (freqValues[2] + Convert.ToDouble("20e6")).ToString();
                maskLineSegm4.endPointHaxisValue    = (freqValues[3] - Convert.ToDouble("10e6")).ToString();
                maskLineSegm4.startPointVaxisValue  = "-10.0";
                maskLineSegm4.endPointVaxisValue    = "-10.0";
            }
            {
                maskLineSegm5.type = 1;
                maskLineSegm5.startPointHaxisValue  = (freqValues[3] + Convert.ToDouble("10e6")).ToString();
                maskLineSegm5.endPointHaxisValue    = (freqValues[4] - Convert.ToDouble("10e6")).ToString();
                maskLineSegm5.startPointVaxisValue  = "-10.0";
                maskLineSegm5.endPointVaxisValue    = "-10.0";
            }
            {
                maskLineSegm6.type = 1;
                maskLineSegm6.startPointHaxisValue  = (freqValues[4] + Convert.ToDouble("10e6")).ToString();
                maskLineSegm6.endPointHaxisValue    = (freqValues[5] - Convert.ToDouble("10e6")).ToString();
                maskLineSegm6.startPointVaxisValue  = "-10.0";
                maskLineSegm6.endPointVaxisValue    = "-10.0";
            }
            {
                maskLineSegm7.type = 1;
                maskLineSegm7.startPointHaxisValue  = (freqValues[5] + Convert.ToDouble("10e6")).ToString();
                maskLineSegm7.endPointHaxisValue    = (freqValues[5] + Convert.ToDouble("500e6")).ToString();
                maskLineSegm7.startPointVaxisValue  = "-10.0";
                maskLineSegm7.endPointVaxisValue    = "-10.0";
            }
            List<NetworkAnalyzer_E5071C.LimitLineSegment> maskLineSegments = new List<NetworkAnalyzer_E5071C.LimitLineSegment>();
            maskLineSegments.Add(maskLineSegm1);
            maskLineSegments.Add(maskLineSegm2);
            maskLineSegments.Add(maskLineSegm3);
            maskLineSegments.Add(maskLineSegm4);
            maskLineSegments.Add(maskLineSegm5);
            maskLineSegments.Add(maskLineSegm6);
            maskLineSegments.Add(maskLineSegm7);

            successFlag = networkAnalyzer.TurnOnOffLimitLineDisplay((uint)channelNo, "ON");
            successFlag = networkAnalyzer.SetLimitTable((uint)channelNo, (uint)maskLineSegments.Count, maskLineSegments);
            
            successFlag = networkAnalyzer.DisplayOnOffMemoryTrace((uint)channelNo, (uint)traceNo, "OFF");
            successFlag = networkAnalyzer.DisplayOnOffDataTrace((uint)channelNo, (uint)traceNo, "ON");
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
                stepErrorCode = "PLOTMSK";
                stepErrorDesc = errorMesg;
            }
            return (successFlag == 0);
        }

        private static bool DisplayOnOffMaskLimitLine(List<string> stepParameters,
                                                      out string stepResult,
                                                      out string stepStatus,
                                                      out string stepErrorCode,
                                                      out string stepErrorDesc)
        {
            uint channelNo = Convert.ToUInt32(stepParameters[0]);
            string state = stepParameters[1];
            int successFlag = networkAnalyzer.TurnOnOffLimitLineDisplay(channelNo, state);
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
                stepErrorCode = "MASKLIN";
                stepErrorDesc = "Failed to display ON/OFF the mask limit line";
            }
            return (successFlag == 0);
        }
    }
}