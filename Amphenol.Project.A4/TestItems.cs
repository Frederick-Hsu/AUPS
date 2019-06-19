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
            return testFnctInfo;
        }
    }
}
