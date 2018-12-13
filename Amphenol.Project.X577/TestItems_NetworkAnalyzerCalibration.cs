using System;
using System.Collections.Generic;

namespace Amphenol.Project.X577
{
    partial class TestItems
    {
        #region Network analyzer E5071C calibration procedure
        private static bool SelectNetworkAnalyzerCalibrationKit(List<string> stepParameters,
                                                                out string stepResult,
                                                                out string stepStatus,
                                                                out string stepErrorCode,
                                                                out string stepErrorDesc)
        {
            string chnum = stepParameters[0], calibrationKitNum = stepParameters[1];
            int successFlag = networkAnalyzer.SelectCalibrationKit(Convert.ToUInt32(chnum), Convert.ToUInt32(calibrationKitNum));
            if (successFlag == 0)
            {
                stepResult = "OK";
                stepStatus = "Pass";
                stepErrorCode = string.Empty;
                stepErrorDesc = string.Empty;
            }
            else
            {
                stepResult = "NG";
                stepStatus = "Fail";
                stepErrorCode = "CKITERR";
                stepErrorDesc = "Failed to select the calibration kit number";
            }
            return (successFlag == 0);
        }
        #endregion
    }
}