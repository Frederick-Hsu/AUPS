using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amphenol.Project.A4
{
    public partial class TestItems
    {
        public static bool Execute(string dutSerialNum,
                                   string stepFnctname,
                                   List<string> stepParameters,
                                   List<string> stepLimits,
                                   out string stepResult,
                                   out string stepStatus,
                                   out string stepErrorCode,
                                   out string stepErrorDesc)
        {
            bool success = false;
            string result = "", status = "", errorCode = "", errorDesc = "";
            switch (stepFnctname)
            {
                case "InitializeNetworkAnalyzerE5071C":
                    success = InitializeNetworkAnalyzerE5071C(stepParameters, out result, out status, out errorCode, out errorDesc);
                    break;
                case "CloseNetworkAnalyzerE5071C":
                    success = CloseNetworkAnalyzerE5071C(out result, out status, out errorCode, out errorDesc);
                    break;
                case "PresetNetworkAnalyzerWindowLayoutDisplay":
                    success = PresetNetworkAnalyzerWindowLayoutDisplay(out result, out status, out errorCode, out errorDesc);
                    break;
                case "ConfigWindowDisplayLayout":
                    success = ConfigWindowDisplayLayout(stepParameters, out result, out status, out errorCode, out errorDesc);
                    break;
                case "AllocateTraceAmountForChannel":
                    success = AllocateTraceAmountForChannel(stepParameters, out result, out status, out errorCode, out errorDesc);
                    break;
                case "ConfigTraceDisplayModeInChannel":
                    success = ConfigTraceDisplayModeInChannel(stepParameters, out result, out status, out errorCode, out errorDesc);
                    break;
                case "ConfigureMeasurementSParameterAndFormat":
                    success = ConfigureMeasurementSParameterAndFormat(stepParameters, out result, out status, out errorCode, out errorDesc);
                    break;
                case "ConfigSweepFreqRange":
                    success = ConfigSweepFreqRange(stepParameters, out result, out status, out errorCode, out errorDesc);
                    break;
                case "AutoScallTraceDisplay":
                    success = AutoScallTraceDisplay(stepParameters, out result, out status, out errorCode, out errorDesc);
                    break;
                case "ConfigureChannelTraceDisplayScale":
                    success = ConfigureChannelTraceDisplayScale(stepParameters, out result, out status, out errorCode, out errorDesc);
                    break;
                case "MaximizeOnOffChannelTraceDisplay":
                    success = MaximizeOnOffChannelTraceDisplay(stepParameters, out result, out status, out errorCode, out errorDesc);
                    break;
                case "ShowHideRegularMarker":
                    success = ShowHideRegularMarker(stepParameters, out result, out status, out errorCode, out errorDesc);
                    break;
                case "TargetMarkerSearch":
                    success = TargetMarkerSearch(stepParameters, out result, out status, out errorCode, out errorDesc);
                    break;
                case "TurnOnOffMarkerSearchTrackingFeature":
                    success = TurnOnOffMarkerSearchTrackingFeature(stepParameters, out result, out status, out errorCode, out errorDesc);
                    break;
                case "PerformMarkerSearch":
                    success = PerformMarkerSearch(stepParameters, out result, out status, out errorCode, out errorDesc);
                    break;
            }
            stepResult = result;
            stepStatus = status;
            stepErrorCode = errorCode;
            stepErrorDesc = errorDesc;
            return success;
        }

        public static Dictionary<string, List<string>> GatherTestFunctionsInfo()
        {
            Dictionary<string, List<string>> testFnctInfo = new Dictionary<string, List<string>>();
            testFnctInfo.Add("", new List<string>());
            testFnctInfo.Add("InitializeNetworkAnalyzerE5071C", new List<string>(new string[]
            {
                "Initialize the network analyzer Keysight E5071C over the Ethernet connection, \n" +
                "and open/connect to network analyzer E5071C.",
                "VISA address, please retrieve the address string from Keysight Connection Expert tool, \n" +
                "[NOTE] Please choose the VISA address with suffix '::INSTR'."
            }));
            testFnctInfo.Add("CloseNetworkAnalyzerE5071C", new List<string>(new string[]
            {
                "Close the connection between host PC and network analyzer Keysight E5071C."
            }));
            testFnctInfo.Add("PresetNetworkAnalyzerWindowLayoutDisplay", new List<string>(new string[]
            {
                "Preset the window layout and display for network analyzer Keysight E5071C."
            }));
            testFnctInfo.Add("ConfigWindowDisplayLayout", new List<string>(new string[] 
            {
                "Select the window layout (i.e. channel display mode) for network analyzer front panel",
                "Window layout codename, such as D1, D12, D1_2, D12_34, ..., etc. \n" +
                "For more details of window layout, please refer to the programming guide of Keysight E5071C."
            }));
            testFnctInfo.Add("AllocateTraceAmountForChannel", new List<string>(new string[]
            {
                "Allocate how many traces you want to accommondate in the specific channel",
                "The channel number you want to specify, range : 1 ~ 9",
                "The amount of traces, range : 1 ~ 9"
            }));
            testFnctInfo.Add("ConfigTraceDisplayModeInChannel", new List<string>(new string[]
            {
                "Configure the trace display mode (i.e. the trace graph layout) in the channel you specified",
                "Channel number you specified, range : 1 ~ 9",
                "Trace display mode, such as D1, D12, D1_2, D12_34, ..., etc., \n" +
                "for more details, please refer to the programming guide of Keysight E5071C."
            }));
            testFnctInfo.Add("ConfigureMeasurementSParameterAndFormat", new List<string>(new string[]
            {
                "Configure and select the measurement S-Parameter on the trace you specified, \n" +
                "select the data format for trace, and show the data trace.",
                "Channel number you selected, range : 1 ~ 9",
                "Trace number in the channel you specified, range : 1 ~ 9",
                "S-Parameter for the trace, such as S11, S12, S22, S33, S34, ..., etc.",
                "Trace data format, \n" +
                "such as MLOGarithmic, PHASe, GDELay, SLINear, SLOG, SCOMplex, SMITh, SADMittance, PLINear, \n" +
                "PLOGarithmic, POLar, MLINear, SWR, REAL, IMAGinary, UPHase, PPHase."
            }));
            testFnctInfo.Add("ConfigSweepFreqRange", new List<string>(new string[]
            {
                "Configure the sweep frequency range, from start frequency to stop frequency",
                "Channel number, range : 1 ~ 9",
                "Sweep start frequency (unit : Hertz), you can directly enter the " +
                "frequency value e.g. 500E6 as scientific notation",
                "Sweep stop frequency (unit : Hertz), directly enter the frequency value" +
                "e.g. 3.15E9 as scientific notation"
            }));
            testFnctInfo.Add("AutoScallTraceDisplay", new List<string>(new string[]
            {
                "Auto-scall the trace display at the trace number of channel number you specified",
                "Channel number, range : 1 ~ 9",
                "Trace number , range : 1 ~ 9"
            }));
            testFnctInfo.Add("ConfigureChannelTraceDisplayScale", new List<string>(new string[] 
            {
                /* test function name description */
                "Configure the display scale of the user-specified trace inside one certain channel",
                /* parameter 1 description */
                "Channel number, range : 1 ~ 9",
                /* parameter 2 description */
                "Trace number inside the channel you specify, range : 1 ~ 9",
                "Number of divisions for the graticule, it is a channel-wide setting, \n" +
                "shared among all traces inside one certain channel, \n" +
                "Range : 4 to 30 \n" +
                "Preset value : 10 \n" +
                "Resolution : 2",
                /* parameter 3 description */
                "The scale per division, when you use the rectangular display format, or \n" +
                "the full scale value (i.e. the value of outermost circle), when Smith chart / Polar formats \n" +
                "Range : 1e-18 to 1e8\n" +
                "Preset value : Varies depending on the data format as follows: \n" +
                "               Logarithmic Magnitude : 10\n" +
                "               Phase, Expand Phase, Positive Phase : 90\n" +
                "               Group Delay : 1e-8\n" +
                "               Smith, Polar, SWR : 1\n" +
                "               Linear Magnitude : 0.1\n" +
                "               Real, Imaginary : 0.2\n" +
                "Unit : Varies depending on the data format as follows:\n" +
                "       Logarithmic Magnitude : dB(decibel)\n" +
                "       Phase, Expand Phase, Positive Phase : degree\n" +
                "       Group Delay : second\n" +
                "       Others : No unit",
                /* parameter 4 description */
                "Number of graticule line\n" +
                "Range : 0 to number of divisions\n" +
                "Preset value : 5 (when the data format is \"Linear Magnitude\" or \"SWR\", the preset value is 1.)\n" +
                "Resolution : 1",
                /* parameter 5 description */
                "Value of reference graticule line\n" +
                "Range : -5e8 to 5e8\n" +
                "Preset value : 0 (When the data format is \"SWR\", the preset value is 1.)\n" +
                "Unit : Varies depending on the data format as follows:\n" +
                "       Logarithmic Magnitude : dB(decibel)\n" +
                "       Phase, Expand Phase, Positive Phase : degree\n" +
                "       Group Delay : second\n" +
                "       Others : No unit"
            }));
            testFnctInfo.Add("MaximizeOnOffChannelTraceDisplay", new List<string>(new string[]
            {
                "Maximize ON/OFF the channel or trace display",
                "Channel number you want to choose, range : 1 ~ 9",
                "Channel max display ON/OFF, range : \"ON\" or \"OFF\"",
                "Trace number you want to choose, range : 1 ~ 9",
                "Trace max ON/OFF display, range : \"ON\" or \"OFF\""
            }));
            testFnctInfo.Add("ShowHideRegularMarker", new List<string>(new string[]
            {
                "Turn ON/OFF the regular marker display",
                "Channel number, range : 1 ~ 9",
                "Trace number, range : 1 ~ 9",
                "Marker number, range : 1 ~ 9",
                "Marker display status, ON or OFF"
            }));
            testFnctInfo.Add("TargetMarkerSearch", new List<string>(new string[]
            {
                /* test function name description */
                "Define the marker target search by specifying the target value (response value) \n" +
                "and transitional direction (positive or negative value change).",
                /* parameter 1 description */
                "Channel number, range : 1 ~ 9",
                /* parameter 2 description */
                "Trace number, range : 1 ~ 9",
                /* parameter 3 description */
                "Regular marker number, range : 1 ~ 9",
                /* parameter 4 description */
                "Marker search type, by default TARGet, \n" +
                "MINimum\n" +
                "MAXimum\n" +
                "PEAK\n" +
                "LPEak\n" +
                "RPEak\n" +
                "TARGet\n" +
                "LTARget\n" +
                "RTARget",
                /* parameter 5 description */
                "Target response value for target search, " +
                "range : -5e8 to 5e8\n" +
                "unit : varies depending on the data format as follows:\n" +
                "       Logarithmic Magnitude : dB\n" +
                "       Phase, Expand Phase, Positive Phase : degree\n" +
                "       Group Delay : second\n" +
                "       Others : no unit",
                /* parameter 6 description */
                "Target search transitional direction, range : POSitive, NEGative, BOTH by default."
            }));
            testFnctInfo.Add("TurnOnOffMarkerSearchTrackingFeature", new List<string>(new string[] 
            {
                "Turn ON or OFF the marker search tracking feature for the active trace of channel, \n" +
                "which performs the marker search every time the trace is updated.",
                "Channel number, range : 1 ~ 9",
                "Trace number, range : 1 ~ 9",
                "Marker number, range : 1 ~ 9",
                "ON or OFF"
            }));
            testFnctInfo.Add("PerformMarkerSearch", new List<string>(new string[]
            {
                "Perform the marker search",
                "Channel number, range : 1 ~ 9",
                "Trace number, range : 1 ~ 9",
                "Marker number, range : 1 ~ 9"
            }));
            return testFnctInfo;
        }
    }
}
