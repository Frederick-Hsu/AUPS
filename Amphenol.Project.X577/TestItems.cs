using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Amphenol.Project.X577
{
    public partial class TestItems
    {
        public static bool Execute(string dutSerialNum, 
                                   string stepFuncname,                 /* Argument IN */
                                   List<string> stepParameters,         /* Argument IN */
                                   List<string> limits,                 /* Argument IN */
                                   out string stepResult,                   /* Argument OUT */
                                   out string stepStatus,                   /* Argument OUT */
                                   out string stepErrorCode,                /* Argument OUT */
                                   out string stepErrorDesc)                /* Argument OUT */
        {
            bool success = false;

            string result = "", status = "", errorCode = "", errorDesc = "";

            switch (stepFuncname)
            {
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
                    success = MeasureResistorOver2Wires(limits,
                                                        out result,
                                                        out status,
                                                        out errorCode,
                                                        out errorDesc);
                    break;
                case "MeasureResistorOver4Wires":
                    success = MeasureResistorOver4Wires(limits,
                                                        out result,
                                                        out status,
                                                        out errorCode,
                                                        out errorDesc);
                    break;
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

        private static void DummyStep()
        {
        }
    }
}
