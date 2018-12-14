using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Amphenol.Project.X577
{
    public partial class TestItems
    {
        public static bool Execute(string dutSerialNum,                 /* Argument IN */
                                   string stepFuncname,                 /* Argument IN */
                                   List<string> stepParameters,         /* Argument IN */
                                   List<string> stepLimits,             /* Argument IN */
                                   out string stepResult,                   /* Argument OUT */
                                   out string stepStatus,                   /* Argument OUT */
                                   out string stepErrorCode,                /* Argument OUT */
                                   out string stepErrorDesc)                /* Argument OUT */
        {
            bool success = false;
            string result = "", status = "", errorCode = "", errorDesc = "";
            switch (stepFuncname)
            {
#if false
                #region DMM Test Items section
                case "InitializeDigitalMultimeter":
                    success = InitializeDigitalMultimeter(stepParameters, 
                                                          out result, 
                                                          out status, 
                                                          out errorCode, 
                                                          out errorDesc);
                    break;
                case "CloseDMM":
                    success = CloseDMM(out result,
                                       out status,
                                       out errorCode,
                                       out errorDesc);
                    break;
                case "MeasureResistorOver2Wires":
                    success = MeasureResistorOver2Wires(stepLimits,
                                                        out result,
                                                        out status,
                                                        out errorCode,
                                                        out errorDesc);
                    break;
                case "MeasureResistorOver4Wires":
                    success = MeasureResistorOver4Wires(stepLimits,
                                                        out result,
                                                        out status,
                                                        out errorCode,
                                                        out errorDesc);
                    break;
                #endregion
#endif
                #region Network Analyzer Test Items section
                case "InitializeNetworkAnalyzer":
                    success = InitializeNetworkAnalyzer(stepParameters, out result, out status, out errorCode, out errorDesc);
                    break;
                case "CloseNetworkAnalyzer":
                    success = CloseNetworkAnalyzer(out result, out status, out errorCode, out errorDesc);
                    break;
                case "PresetNetworkAnalyzer":
                    success = PresetNetworkAnalyzer(out result, out status, out errorCode, out errorDesc);
                    break;
                case "SetNetAnalyzerWindowLayout":
                    success = SetNetAnalyzerWindowLayout(stepParameters, out result, out status, out errorCode, out errorDesc);
                    break;
                case "SetNetAnalyzerGraphLayout":
                    success = SetNetAnalyzerGraphLayout(stepParameters, out result, out status, out errorCode, out errorDesc);
                    break;
                case "ConfigureTraceCount":
                    success = ConfigureTraceCount(stepParameters, out result, out status, out errorCode, out errorDesc);
                    break;
                case "GetTraceCount":
                    success = GetTraceCount(stepParameters, stepLimits, out result, out status, out errorCode, out errorDesc);
                    break;
                case "SelectActiveChannel":
                    success = SelectActiveChannel(stepParameters, out result, out status, out errorCode, out errorDesc);
                    break;
                case "SelectActiveTrace":
                    success = SelectActiveTrace(stepParameters, out result, out status, out errorCode, out errorDesc);
                    break;
                case "SelectMeasurementParameter":
                    success = SelectMeasurementParameter(stepParameters, out result, out status, out errorCode, out errorDesc);
                    break;
                case "QueryMeasurementParameter":
                    success = QueryMeasurementParameter(stepParameters, stepLimits, out result, out status, out errorCode, out errorDesc);
                    break;
                case "SelectDataFormat":
                    success = SelectDataFormat(stepParameters, out result, out status, out errorCode, out errorDesc);
                    break;
                case "QueryDataFormat":
                    success = QueryDataFormat(stepParameters, stepLimits, out result, out status, out errorCode, out errorDesc);
                    break;
                case "SetSweepType":
                    success = SetSweepType(stepParameters, out result, out status, out errorCode, out errorDesc);
                    break;
                case "ExecuteNetworkAnalyzerCommand":
                    success = ExecuteNetworkAnalyzerCommand(stepParameters, out result, out status, out errorCode, out errorDesc);
                    break;
                case "SetTraceScalePerDivision":
                    success = SetTraceScalePerDivision(stepParameters, out result, out status, out errorCode, out errorDesc);
                    break;
                case "SetTraceGraticuleLineNumber":
                    success = SetTraceGraticuleLineNumber(stepParameters, out result, out status, out errorCode, out errorDesc);
                    break;
                case "SetTraceGraticuleLineLevel":
                    success = SetTraceGraticuleLineLevel(stepParameters, out result, out status, out errorCode, out errorDesc);
                    break;
                case "SetSweepCenterFrequency":
                    success = SetSweepCenterFrequency(stepParameters, out result, out status, out errorCode, out errorDesc);
                    break;
                case "SetSweepSpanFrequency":
                    success = SetSweepSpanFrequency(stepParameters, out result, out status, out errorCode, out errorDesc);
                    break;
                case "SetSweepPointNumber":
                    success = SetSweepPointNumber(stepParameters, out result, out status, out errorCode, out errorDesc);
                    break;
                case "SetIFBandwidth":
                    success = SetIFBandwidth(stepParameters, out result, out status, out errorCode, out errorDesc);
                    break;
                case "SetPowerLevel":
                    success = SetPowerLevel(stepParameters, out result, out status, out errorCode, out errorDesc);
                    break;
                case "SaveInstrumentState":
                    success = SaveInstrumentState(stepParameters, out result, out status, out errorCode, out errorDesc);
                    break;
                case "SelectNetworkAnalyzerCalibrationKit":
                    success = SelectNetworkAnalyzerCalibrationKit(stepParameters, out result, out status, out errorCode, out errorDesc);
                    break;
                case "QueryNetworkAnalyzerCalibrationKitNumber":
                    success = QueryNetworkAnalyzerCalibrationKitNumber(stepParameters, stepLimits, out result, out status, out errorCode, out errorDesc);
                    break;
                case "PerformOpenCalibration":
                    success = PerformOpenCalibration(stepParameters, out result, out status, out errorCode, out errorDesc);
                    break;
                #endregion
#if false
                #region Power Supply Test Items section
                case "InitializeDCPowerSupply":
                    success = InitializeDCPowerSupply(stepParameters,
                                                      out result,
                                                      out status,
                                                      out errorCode,
                                                      out errorDesc);
                    break;
                case "CloseDCPowerSupply":
                    success = CloseDCPowerSupply(out result,
                                                 out status,
                                                 out errorCode,
                                                 out errorDesc);
                    break;
                case "InitializePowerSupply":
                    success = InitializePowerSupply(stepParameters, 
                                                    out result, 
                                                    out status, 
                                                    out errorCode, 
                                                    out errorDesc);
                    break;
                case "ClosePowerSupply":
                    success = ClosePowerSupply(out result,
                                               out status,
                                               out errorCode,
                                               out errorDesc);
                    break;
                #endregion
#endif
                default:
                    DummyStep();
                    break;
            }
            stepResult = result;
            stepStatus = status;
            stepErrorCode = errorCode;
            stepErrorDesc = errorDesc;
            return success;
        }

        public static List<string> GatherTestFunctionsList()
        {
            List<string> functionsList = new List<string>();
            #region DMM Test Functions
            functionsList.Add("InitializeDigitalMultimeter");
            functionsList.Add("CloseDMM");
            functionsList.Add("MeasureResistorOver2Wires");
            functionsList.Add("MeasureResistorOver4Wires");
            #endregion

            #region Network Analyzer Test Functions
            functionsList.Add("InitializeNetworkAnalyzer");
            functionsList.Add("CloseNetworkAnalyzer");
            functionsList.Add("PresetNetworkAnalyzer");
            functionsList.Add("SetNetAnalyzerWindowLayout");
            functionsList.Add("SetNetAnalyzerGraphLayout");
            functionsList.Add("ConfigureTraceCount");
            functionsList.Add("GetTraceCount");
            functionsList.Add("SelectActiveChannel");
            functionsList.Add("SelectActiveTrace");
            functionsList.Add("SelectMeasurementParameter");
            functionsList.Add("QueryMeasurementParameter");
            functionsList.Add("SelectDataFormat");
            functionsList.Add("QueryDataFormat");
            functionsList.Add("SetSweepType");
            functionsList.Add("ExecuteNetworkAnalyzerCommand");
            functionsList.Add("SetTraceScalePerDivision");
            functionsList.Add("SetTraceGraticuleLineNumber");
            functionsList.Add("SetTraceGraticuleLineLevel");
            functionsList.Add("SetSweepCenterFrequency");
            functionsList.Add("SetSweepSpanFrequency");
            functionsList.Add("SetSweepPointNumber");
            functionsList.Add("SetIFBandwidth");
            functionsList.Add("SetPowerLevel");
            functionsList.Add("SaveInstrumentState");
            functionsList.Add("SelectNetworkAnalyzerCalibrationKit");
            functionsList.Add("QueryNetworkAnalyzerCalibrationKitNumber");
            functionsList.Add("PerformOpenCalibration");
            #endregion

            #region Power Supply Test Functions
            functionsList.Add("InitializeDCPowerSupply");
            functionsList.Add("CloseDCPowerSupply");
            functionsList.Add("InitializePowerSupply");
            functionsList.Add("ClosePowerSupply");
            #endregion
            return functionsList;
        }

        private static void DummyStep()
        {
        }
    }
}
