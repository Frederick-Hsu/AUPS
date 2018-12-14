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

        private static bool QueryNetworkAnalyzerCalibrationKitNumber(List<string> stepParameters,
                                                                     List<string> stepLimits,
                                                                     out string stepResult,
                                                                     out string stepStatus,
                                                                     out string stepErrorCode,
                                                                     out string stepErrorDesc)
        {
            string chnum = stepParameters[0];
            uint calikitNumLimit = Convert.ToUInt32(stepLimits[0]);
            uint caliKitNum;
            int successFlag = networkAnalyzer.QueryCalibrationKitNumber(Convert.ToUInt32(chnum), out caliKitNum);
            stepResult = Convert.ToString(caliKitNum);
            if ((successFlag == 0) && (caliKitNum == calikitNumLimit))
            {
                stepStatus = "Pass";
                stepErrorCode = "";
                stepErrorDesc = "";
            }
            else
            {
                stepStatus = "Fail";
                stepErrorCode = "CKITNUM";
                stepErrorDesc = "Failed to query the calibration kit number.";
            }
            return (successFlag == 0);
        }

        private static bool PerformOpenCalibration(List<string> stepParameters,
                                                   out string stepResult,
                                                   out string stepStatus,
                                                   out string stepErrorCode,
                                                   out string stepErrorDesc)
        {
            string channelNum = stepParameters[0], portNumber = stepParameters[1];
            int successFlag = networkAnalyzer.SetCalibrationTypeOpen(Convert.ToUInt32(channelNum), Convert.ToUInt32(portNumber));
            successFlag = networkAnalyzer.MeasureOpenCalibrationData(Convert.ToUInt32(channelNum), Convert.ToUInt32(portNumber));
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
                stepErrorCode = "OPENCALI";
                stepErrorDesc = "Failed to perform the open calibration.";
            }
            return (successFlag == 0);
        }
        #endregion
    }
}