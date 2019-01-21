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
            string chnum = stepParameters[0], calibrationKitType = stepParameters[1];
            uint calibrationKitNum;
            switch (calibrationKitType.ToUpper())
            {
                case "85033E":      calibrationKitNum =  1;     break;
                case "85033D":      calibrationKitNum =  2;     break;
                case "85052D":      calibrationKitNum =  3;     break;
                case "85032F":      calibrationKitNum =  4;     break;
                case "85032B/E":    calibrationKitNum =  5;     break;
                case "85036B/E":    calibrationKitNum =  6;     break;
                case "85031B":      calibrationKitNum =  7;     break;
                case "85050C/D":    calibrationKitNum =  8;     break;
                case "85052C":      calibrationKitNum =  9;     break;
                case "85038A/F/M":  calibrationKitNum = 10;     break;
                case "85054D":      calibrationKitNum = 11;     break;
                case "85056D":      calibrationKitNum = 12;     break;
                case "85056K":      calibrationKitNum = 13;     break;
                case "85039B":      calibrationKitNum = 14;     break;
                case "X11644A":     calibrationKitNum = 15;     break;
                case "P11644A":     calibrationKitNum = 16;     break;
                case "K11644A":     calibrationKitNum = 17;     break;
                case "85050B":      calibrationKitNum = 18;     break;
                case "85052B":      calibrationKitNum = 19;     break;
                case "85054B":      calibrationKitNum = 20;     break;
                case "85056A":      calibrationKitNum = 21;     break;
                case "USER":        calibrationKitNum = 22;     break;
                default:            calibrationKitNum =  1;     break;
            }
            int successFlag = networkAnalyzer.SelectCalibrationKitType(Convert.ToUInt32(chnum), calibrationKitNum);
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

        private static bool GetNetworkAnalyzerCalibrationKitName(List<string> stepParameters,
                                                                 out string stepResult,
                                                                 out string stepStatus,
                                                                 out string stepErrorCode,
                                                                 out string stepErrorDesc)
        {
            uint channelnum = Convert.ToUInt32(stepParameters[0]);
            int successFlag = networkAnalyzer.QueryCalibrationKitName(channelnum, out stepResult);
            if (successFlag == 0)
            {
                stepStatus = "Pass";
                stepErrorCode = string.Empty;
                stepErrorDesc = string.Empty;
            }
            else
            {
                stepStatus = "Fail";
                stepErrorCode = "CKITNAME";
                stepErrorDesc = "Failed to retrieve the calibration kit name";
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
            successFlag = networkAnalyzer.CalculateCalibrationCoefficientsForResponseType(Convert.ToUInt32(channelNum));
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

        private static bool SaveCalibrationCoefficientsAndTakeEffect(List<string> stepParameters,
                                                                     out string stepResult,
                                                                     out string stepStatus,
                                                                     out string stepErrorCode,
                                                                     out string stepErrorDesc)
        {
            string channelNum = stepParameters[0], 
                calibrationCoefficientDataFile = stepParameters[1],
                calibrationCoefficientType = stepParameters[2],
                responsePortNum = stepParameters[3],
                stimulusPortNum = stepParameters[4];

            int successFlag = networkAnalyzer.SaveCalibrationCoefficientsToFile(calibrationCoefficientDataFile);
            Amphenol.Instruments.Keysight.NetworkAnalyzer_E5071C.CalibrationCoefficientDataType type;
            switch (calibrationCoefficientType)
            {
                case "ES":      type = Instruments.Keysight.NetworkAnalyzer_E5071C.CalibrationCoefficientDataType.ES;   break;
                case "ER":      type = Instruments.Keysight.NetworkAnalyzer_E5071C.CalibrationCoefficientDataType.ER;   break;
                case "ED":      type = Instruments.Keysight.NetworkAnalyzer_E5071C.CalibrationCoefficientDataType.ED;   break;
                case "EL":      type = Instruments.Keysight.NetworkAnalyzer_E5071C.CalibrationCoefficientDataType.EL;   break;
                case "ET":      type = Instruments.Keysight.NetworkAnalyzer_E5071C.CalibrationCoefficientDataType.ET;   break;
                case "EX":      type = Instruments.Keysight.NetworkAnalyzer_E5071C.CalibrationCoefficientDataType.EX;   break;
                default:        type = Instruments.Keysight.NetworkAnalyzer_E5071C.CalibrationCoefficientDataType.ER;   break;
            }
            double[] coefficientRealPart, coefficientImagPart;
            successFlag = networkAnalyzer.ReadOutCalibrationCoefficientData(Convert.ToUInt32(channelNum), 
                                                                            type, 
                                                                            Convert.ToUInt32(responsePortNum), 
                                                                            Convert.ToUInt32(stimulusPortNum), 
                                                                            out coefficientRealPart,
                                                                            out coefficientImagPart);
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
                stepErrorCode = "CALICOEF";
                stepErrorDesc = "Failed to read out the calibration coefficient.";
            }
            return (successFlag == 0);
        }

        private static bool PerformECalFull4PortAutoCalibration(List<string> stepParameters,
                                                                out string stepResult,
                                                                out string stepStatus,
                                                                out string stepErrorCode,
                                                                out string stepErrorDesc)
        {
            uint channelnum = Convert.ToUInt32(stepParameters[0]);
            int successFlag = networkAnalyzer.ECalExecuteFull4PortAutoCalibration(channelnum);
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
                stepErrorCode = "ECAL4PORT";
                stepErrorDesc = "Failed to perform the ECal Full 4-port auto calibration.";
            }
            return (successFlag == 0);
        }

        private static bool VerifyECalAppliedCalibration(List<string> stepParameters,
                                                         List<string> stepLimits,
                                                         out string stepResult,
                                                         out string stepStatus,
                                                         out string stepErrorCode,
                                                         out string stepErrorDesc)
        {
            uint channelnum = Convert.ToUInt32(stepParameters[0]), tracenum = Convert.ToUInt32(stepParameters[1]);
            string[] calibrationType;
            int successFlag = networkAnalyzer.CheckAppliedCalibrationType(channelnum, tracenum, out calibrationType);
            stepResult = calibrationType[0];

            if ((successFlag == 0) && (stepResult == stepLimits[0].ToUpper()))
            {
                stepStatus = "Pass";
                stepErrorCode = string.Empty;
                stepErrorDesc = string.Empty;
            }
            else
            {
                stepStatus = "Fail";
                stepErrorCode = "CALITYPE";
                stepErrorDesc = "Failed to verify the calibration type.";
            }
            return (successFlag == 0);
        }
        #endregion
    }
}