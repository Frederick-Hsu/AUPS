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
            return testFnctInfo;
        }
    }
}
