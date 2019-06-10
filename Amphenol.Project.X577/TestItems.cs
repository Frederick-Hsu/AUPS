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
                case "GetNetworkAnalyzerCalibrationKitName":
                    success = GetNetworkAnalyzerCalibrationKitName(stepParameters, out result, out status, out errorCode, out errorDesc);
                    break;
                case "PerformOpenCalibration":
                    success = PerformOpenCalibration(stepParameters, out result, out status, out errorCode, out errorDesc);
                    break;
                case "SaveCalibrationCoefficientsAndTakeEffect":
                    success = SaveCalibrationCoefficientsAndTakeEffect(stepParameters, out result, out status, out errorCode, out errorDesc);
                    break;
                case "PerformECalFull4PortAutoCalibration":
                    success = PerformECalFull4PortAutoCalibration(stepParameters, out result, out status, out errorCode, out errorDesc);
                    break;
                case "VerifyECalAppliedCalibration":
                    success = VerifyECalAppliedCalibration(stepParameters, stepLimits, out result, out status, out errorCode, out errorDesc);
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
            functionsList.Add("GetNetworkAnalyzerCalibrationKitName");
            functionsList.Add("PerformOpenCalibration");
            functionsList.Add("SaveCalibrationCoefficientsAndTakeEffect");
            functionsList.Add("PerformECalFull4PortAutoCalibration");
            functionsList.Add("VerifyECalAppliedCalibration");
            #endregion

            #region Power Supply Test Functions
            functionsList.Add("InitializeDCPowerSupply");
            functionsList.Add("CloseDCPowerSupply");
            functionsList.Add("InitializePowerSupply");
            functionsList.Add("ClosePowerSupply");
            #endregion
            return functionsList;
        }

        public static Dictionary<string, List<string>> GatherTestFunctionsInfo()
        {
            Dictionary<string, List<string>> testFnctInfo = new Dictionary<string, List<string>>();
            /* How to add the hints for each test function and its parameters? 
             * 
             * Dictionary<string,               // the key (string type) represents the test function name
             *            List<string>          // the value (List<string> type) represents hints for test function and 
             *                                  // parameter1, parameter2 ... according one-by-one.
             *           >
             */

            // List<string> hints = new List<string>(IEnumerable<string> collection);
            testFnctInfo.Add("InitializeNetworkAnalyzer", new List<string>(new string[] 
            {
                "Initialize the Keysight network analyzer E5071C \nover the connection between instrument and host computer",
                "VISA address string of instrument, \nplease retrieve the string on the application \"Keysight Connection Expert\". " +
                "You'd better select the string with \"::INSTR\" suffix.",
            }));
            testFnctInfo.Add("CloseNetworkAnalyzer", new List<string>(new string[]
            {
                "Close the connection with network analyzer instrument"
            }));
            testFnctInfo.Add("PresetNetworkAnalyzer", new List<string>(new string[]
            {
                "Preset the Keysight network analyzer E5071C"
            }));
            testFnctInfo.Add("SetNetAnalyzerWindowLayout", new List<string>(new string[] 
            {
                "Set the window display layout for network analyzer",
                "the code name of window display layout, such as D1, D1_2, D12, D12_34, ... etc."
            }));
            testFnctInfo.Add("SetNetAnalyzerGraphLayout", new List<string>(new string[] 
            {
                "Configure the trace display mode for network analyzer",
                "How many windows do you want to display?",
                "Trace display layout, such as D1, D12, D1_2, D123, D12_34, ..., etc."
            }));
            testFnctInfo.Add("ConfigureTraceCount", new List<string>(new string[]
            {
                "Configure how many traces do you want to display in which window.",
                "The window number you want to select",
                "How many traces do you want to display in this window?"
            }));
            testFnctInfo.Add("GetTraceCount", new List<string>(new string[] 
            {
                "Retrieve the trace count from the window you specified",
                "The window number you specified, e.g. 1, 2, ... "
            }));
            testFnctInfo.Add("SelectActiveChannel", new List<string>(new string[] 
            {
                "Select which channel/window you want to activate",
                "The no. of active channel/window"
            }));
            testFnctInfo.Add("SelectActiveTrace", new List<string>(new string[] 
            {
                "Select which trace you want to activate in which channel/window",
                "The no. of channel/window you specified",
                "The no. of active trace, such as 1, 2, 3, ..."
            }));
            testFnctInfo.Add("SelectMeasurementParameter", new List<string>(new string[] 
            {
                "Select the measurement parameter (S-parameter) for each trace",
                "Channel numer from 1 to 16",
                "Trace number from 1 to 16",
                "S-parameter, such as S11, S21, S22, S23, S34, S44, etc."
            }));
            testFnctInfo.Add("QueryMeasurementParameter", new List<string>(new string[] 
            {
                "Query the S-parameter type for the trace you specified",
                "Channel number from 1 to 16",
                "Trace number from 1 to 16"
            }));
            testFnctInfo.Add("SelectDataFormat", new List<string>(new string[] 
            {
                "Select the data format for the active trace number in channel number",
                "Channel number from 1 to 16",
                "Trace number from 1 to 16",
                "Data format, select one from MLOG, PHASe, GDELay, SLINear, SLOG, SCOMplex, \n" +
                "SMITh, SAMDittance, PLINear, PLOG, POLar, MLINear, SWR, REAL, IMAGinary, UPHase, PPHase"
            }));
            testFnctInfo.Add("QueryDataFormat", new List<string>(new string[] 
            {
                "Query the data format for active trace number in channel number",
                "Channel number from 1 to 16",
                "Trace number from 1 to 16"
            }));
            testFnctInfo.Add("SetSweepType", new List<string>(new string[] 
            {
                "Set the sweep type of channel number",
                "Channel number from 1 to 16",
                "Sweep type, such as LINear, LOGarithmic, SEGMent, POWer"
            }));
            testFnctInfo.Add("ExecuteNetworkAnalyzerCommand", new List<string>(new string[] 
            {
                "Execute the SCPI command of the instrument you are using",
                "Please enter the completed SCPI command that your instrument supports"
            }));
            testFnctInfo.Add("SetTraceScalePerDivision", new List<string>(new string[] 
            {
                "Set the scale per division of Y axis for the nth trace of nth channel",
                "Channel number from 1 to 16",
                "Trace number from 1 to 16",
                "Scale value, range : 1e-18 to 1e8 \n" +
                "Preset value varies depending on the data formats as follows : \n" +
                "Logarithmic Magnitude : 10 \n" +
                "Phase, Expand Phase, Positive Phase : 90 \n" +
                "Group Delay : 1e-8 \n" +
                "Smith, Polar, SWR : 1 \n" +
                "Linear Magnitude : 0.1 \n" +
                "Real, Imaginary : 0.2 \n" +
                "Unit varies depending on the data format as follows: \n" +
                "Logarithmic Magnitude : dB \n" +
                "Phase, Expand Phase, Positive Phase : degree \n" +
                "Group Delay : second \n" +
                "Others : No unit"
            }));
            testFnctInfo.Add("SetTraceGraticuleLineNumber", new List<string>(new string[] 
            {
                "Specify a reference graticule line with integer number for nth trace of nth channel",
                "Channel number from 1 to 16",
                "Trace number from 1 to 16",
                "Integer number of graticule line for Y axis"
            }));
            testFnctInfo.Add("SetTraceGraticuleLineLevel", new List<string>(new string[] 
            {
                "Set the level value of Y axis reference graticule line for nth trace of nth channel",
                "Channel number from 1 to 16",
                "Trace number from 1 to 16",
                "Level value of reference graticule line in Y axis, from -5e8 to 5e8"
            }));
            testFnctInfo.Add("SetSweepCenterFrequency", new List<string>(new string[] 
            {
                "Set the center frequence value of sweep range for the nth channel",
                "Channel number from 1 to 16",
                "Center frequency value, range : 3e5 to 8.5e9, unit : Hertz"
            }));
            testFnctInfo.Add("SetSweepSpanFrequency", new List<string>(new string[] 
            {
                "Set the frequency span value of sweep range for the nth channel",
                "Channel numer from 1 to 16",
                "Frequency span value, range : 0 to 8.4997e9, unit : Hertz"
            }));
            testFnctInfo.Add("SetSweepPointNumber", new List<string>(new string[] 
            {
                "Set the number of sweep measurement points for the nth channel",
                "Channel number,  from 1 to 16",
                "Number of measurement points, from 2 to 1601, 201 by default"
            }));
            testFnctInfo.Add("SetIFBandwidth", new List<string>(new string[] 
            {
                "Set the IF bandwidth for the nth channel",
                "Channel number from 1 to 16",
                "IF bandwidth, range : 10 to 1e5, unit : Hertz"
            }));
            testFnctInfo.Add("SetPowerLevel", new List<string>(new string[] 
            {
                "Set the power level for the nth channel",
                "Channel number, from 1 to 16",
                "Power level value in dBm"
            }));
            testFnctInfo.Add("SaveInstrumentState", new List<string>(new string[] 
            {
                "Save the instrument state into a file",
                "File name (.sta) in which you want to save the instrument state"
            }));
            testFnctInfo.Add("SelectNetworkAnalyzerCalibrationKit", new List<string>(new string[] 
            {
                "Select the calibration kit type for the channel you specified",
                "Channel number from 1 to 16",
                "Calibration kit type, please find the calibration kit type name on the instrument screen."
            }));
            testFnctInfo.Add("QueryNetworkAnalyzerCalibrationKitNumber", new List<string>(new string[] 
            {
                "Query the calibration kit type number for the nth channel",
                "Channel number, from 1 to 16",
            }));
            testFnctInfo.Add("PerformOpenCalibration", new List<string>(new string[] 
            {
                "Perform the OPEN calibration on the port you specified",
                "Channel number from 1 to 16",
                "Port number from 1 to 4"
            }));
            testFnctInfo.Add("SaveCalibrationCoefficientsAndTakeEffect", new List<string>(new string[] 
            {
                "After performed calibration, save calibration coefficients and take effect.",
                "Channel number from 1 to 16",
                "The data file name of calibration coefficients",
                "Calibration coefficient type, such as : ES, ER, ED, EL, ET, EX",
                "Response port number from 1 to 4",
                "Stimulus port number from 1 to 4"
            }));
            testFnctInfo.Add("PerformECalFull4PortAutoCalibration", new List<string>(new string[] 
            {
                "Execute full 4-port auto calibration for the nth channel, using ECal kit module",
                "Channel number from 1 to 16"
            }));
            testFnctInfo.Add("VerifyECalAppliedCalibration", new List<string>(new string[] 
            {
                "Read out the information (calibration type, port number) of the applied \n" +
                "calibration coefficients for the actual error correction, for the nth trace \n" +
                "of nth channel.",
                "Channel number from 1 to 16",
                "Trace number from 1 to 16"
            }));

            return testFnctInfo;
        }

        private static void DummyStep()
        {
        }
    }
}
