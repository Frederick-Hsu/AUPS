using System;
using System.Text;

namespace Amphenol.Instruments.Keysight
{
    partial class NetworkAnalyzer_E5071C
    {
        #region Performing calibration
        /* :SENSe1:CORRection:COLLect:CKIT:SELect 1 */
        public int SelectCalibrationKitType(uint chnum, uint calibrationKitNumber = 1)
        {
            /* Select the calibration kit type :
             * 
             * Kit number       | Kit type
             * =================+==================================================
             *      1           |   85033E
             * =================+==================================================
             *      2           |   85033D
             * =================+==================================================
             *      3           |   85052D
             * =================+==================================================
             *      4           |   85032F
             * =================+==================================================
             *      5           |   85032B/E
             * =================+==================================================
             *      6           |   85036B/E
             * =================+==================================================
             *      7           |   85031B
             * =================+==================================================
             *      8           |   85050C/D
             * =================+==================================================
             *      9           |   85052C
             * =================+==================================================
             *      10          |   85038A/F/M
             * =================+==================================================
             *      11          |   85054D
             * =================+==================================================
             *      12          |   85056D
             * =================+==================================================
             *      13          |   85056K
             * =================+==================================================
             *      14          |   85039B
             * =================+==================================================
             *      15          |   X11644A
             * =================+==================================================
             *      16          |   P11644A
             * =================+==================================================
             *      17          |   K11644A
             * =================+==================================================
             *      18          |   85050B
             * =================+==================================================
             *      19          |   85052B
             * =================+==================================================
             *      20          |   85054B
             * =================+==================================================
             *      21          |   85056A
             * =================+==================================================
             *      22          |   User
             * =================+==================================================  
             */
            int error = 0, count = 0;
            string command = ":SENSe" + chnum + ":CORRection:COLLect:CKIT:SELect " + calibrationKitNumber + "\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            string response;
            return QueryErrorStatus(out response);
        }

        /* :SENSe1:CORRection:COLLect:CKIT:SELect? */
        public int QueryCalibrationKitNumber(uint chnum, out uint calibrationKitNumber)
        {
            int error = 0, count = 0;
            string command = ":SENSe" + chnum + ":CORRection:COLLect:CKIT:SELect?\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            byte[] response = new byte[256];
            error = visa32.viRead(analyzerSession, response, 256, out count);
            calibrationKitNumber = Convert.ToUInt32(Encoding.ASCII.GetString(response, 0, count));
            return error;
        }

        /* :SENSe1:CORRection:COLLect:METHod:RESPonse:OPEN 1 */
        public int SetCalibrationTypeOpen(uint chnum, uint responsePortNumber)
        {
            int error = 0, cout = 0;
            string command = ":SENSe" + chnum + ":CORRection:COLLect:METHod:RESPonse:OPEN " + responsePortNumber + "\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out cout);
            string response;
            return QueryErrorStatus(out response);
        }

        /* :SENSe1:CORRection:COLLect:METHod:RESPonse:SHORt 1 */
        public int SetCalibrationTypeShort(uint chnum, uint responsePortNumber)
        {
            int error = 0, count = 0;
            string command = ":SENSe" + chnum + ":CORRection:COLLect:METHod:RESPonse:SHORt " + responsePortNumber + "\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            string response;
            return QueryErrorStatus(out response);
        }

        /* :SENSe2:CORRection:COLLect:METHod:RESPonse:THRU 1,2 */
        public int SetCalibrationTypeThrough(uint chnum, uint fromPort, uint toPort)
        {
            int error = 0, count = 0;
            if (fromPort == toPort)
                return (-1);
            string command = ":SENSe" + chnum + ":CORRection:COLLect:METHod:RESPonse:THRU " + fromPort + "," + toPort + "\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            string response;
            return QueryErrorStatus(out response);
        }

        /* :SENSe1:CORRection:COLLect:METHod:ERESponse 2,3 */
        public int SetCalibrationTypeEnhancedResponse(uint chnum, uint responsePortNumber, uint stimulusPortNumber)
        {
            int error = 0, count = 0;
            if (responsePortNumber == stimulusPortNumber)
                return (-1);
            string command = ":SENSe" + chnum + ":CORRection:COLLect:METHod:ERESponse " + responsePortNumber + "," + stimulusPortNumber + "\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            string response;
            return QueryErrorStatus(out response);
        }

        /* :SENSe1:CORRection:TRIGger:FREE:STATe ON */
        public int SetCalibrationTriggerSource(uint channelNumber, string on_off = "ON")
        {
            int error = 0, count = 0;
            string command = ":SENSe" + channelNumber + ":CORRection:TRIGger:FREE:STATe " + on_off.ToUpper() + "\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            string response;
            return QueryErrorStatus(out response);
        }

        /* :SENSe1:CORRection:TRIGger:FREE:STATe? */
        public int QueryCalibrationTriggerSource(uint channelNumber, out string triggerSource)
        {
            int error = 0, count = 0;
            string command = ":SENSe" + channelNumber + ":CORRection:TRIGger:FREE:STATe?\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            byte[] response = new byte[64];
            error = visa32.viRead(analyzerSession, response, 64, out count);
            int stateNumber = Convert.ToInt32(Encoding.ASCII.GetString(response, 0, count));
            if (stateNumber == 1)
            {
                triggerSource = "Internal";
            }
            else if (stateNumber == 0)
            {
                triggerSource = "System";
            }
            else
            {
                triggerSource = "Internal";
            }
            return error;
        }

        /* :SENSe1:CORRection:COLLect:METHod:TYPE? */
        public int QuerySelectedCalibrationType(uint chnum, out string calibrationType)
        {
            int error = 0, count = 0;
            string command = ":SENSe" + chnum + ":CORRection:COLLect:METHod:TYPE?\n";
            byte[] response = new byte[256];
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(analyzerSession, response, 256, out count);
            calibrationType = Encoding.ASCII.GetString(response, 0, count);
            return error;
        }

        /* :SENSe1:CORRection:COLLect:ACQuire:OPEN 1 */
        public int MeasureOpenCalibrationData(uint channelNumber, uint portNumber)
        {
            int error = 0, count = 0;
            string command = ":SENSe" + channelNumber + ":CORRection:COLLect:ACQuire:OPEN " + portNumber + "\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = "*OPC?\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            byte[] response = new byte[64];
            error = visa32.viRead(analyzerSession, response, 64, out count);
            // string retval = Encoding.ASCII.GetString(response, 0, count);
            if (1 == Convert.ToInt32(Encoding.ASCII.GetString(response, 0, count-1)))
            {
                return 0;
            }
            else
            {
                return (-1);
            }
        }

        /* :SENSe1:CORRection:COLLect:ACQuire:SHORt 1 */
        public int MeasureShortCalibrationData(uint channelNumber, uint portNumber)
        {
            int error = 0, count = 0;
            string command = ":SENSe" + channelNumber + ":CORRection:COLLect:ACQuire:SHORt " + portNumber + "\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            command = "*OPC?\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            byte[] response = new byte[64];
            error = visa32.viRead(analyzerSession, response, 64, out count);

            if (Convert.ToInt32(Encoding.ASCII.GetString(response, 0, count-1)) == 1)
            {
                return 0;
            }
            else
            {
                return (-2);
            }
        }

        /* :SENSe1:CORRection:COLLect:ACQuire:LOAD 1 */
        public int MeasureLoadCalibrationData(uint channelNumber, uint portNumber)
        {
            int error = 0, count = 0;
            string command = ":SENSe" + channelNumber + ":CORRection:COLLect:ACQuire:LOAD " + portNumber + "\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            command = "*OPC?\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            byte[] response = new byte[64];
            error = visa32.viRead(analyzerSession, response, 64, out count);
            if (Convert.ToUInt32(Encoding.ASCII.GetString(response, 0, count-1)) == 1)
            {
                return 0;
            }
            else
            {
                return (-3);
            }
        }

        /* :SENSe1CORRection:COLLect:ACQuire:THRU 1,4 */
        public int MeasureThroughCalibrationData(uint channelNumber, uint responsePortNumber, uint stimulusPortNumber)
        {
            int error = 0, count = 0;
            if (responsePortNumber == stimulusPortNumber)
            {
                return (-1);
            }
            string command = ":SENSe" + channelNumber + ":CORRection:COLLect:ACQuire:THRU " + responsePortNumber + "," + stimulusPortNumber + "\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            command = "*OPC?\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            byte[] response = new byte[32];
            error = visa32.viRead(analyzerSession, response, 32, out count);
            if (Convert.ToUInt32(Encoding.ASCII.GetString(response, 0, count-1)) == 1)
            {
                return 0;
            }
            else
            {
                return (-4);
            }
        }

        /* :SENSe1:CORRection:COLLect:ACQuire:ISOLation 1,2 */
        public int MeasureIsolationCalibrationData(uint channelNumber, uint responsePortNumber, uint stimulusPortNumber)
        {
            int error = 0, count = 0;
            if (responsePortNumber == stimulusPortNumber)
            {
                return (-1);
            }
            string command = ":SENSe" + channelNumber + ":CORRection:COLLect:ACQuire:ISOLation " + responsePortNumber + "," + stimulusPortNumber + ";\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            command = "*OPC?\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            byte[] response = new byte[32];
            error = visa32.viRead(analyzerSession, response, 32, out count);
            if (Convert.ToUInt32(Encoding.ASCII.GetString(response, 0, count-1)) == 1)
            {
                return 0;
            }
            else
            {
                return (-5);
            }
        }

        /* :SENSe1:CORRection:COLLect:ACQuire:TRLThru 2,3 */
        public int ExecuteThroughMeasurementForTRLCalibration(uint channelNumber, uint responsePortNumber, uint stimulusPortNumber)
        {
            int error = 0, count = 0;
            if (responsePortNumber == stimulusPortNumber)
            {
                return (-1);
            }
            string command = ":SENSe" + channelNumber + ":CORRection:COLLect:ACQuire:TRLThru " + responsePortNumber + ", " + stimulusPortNumber + "\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            command = "*OPC?\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            byte[] response = new byte[64];
            error = visa32.viRead(analyzerSession, response, 64, out count);
            if (Convert.ToUInt32(Encoding.ASCII.GetString(response, 0, count-1)) == 1)
            {
                return 0;
            }
            else
            {
                return (-6);
            }
        }

        /* :SENSe1:CORRection:COLLect:ACQuire:TRLReflect 1 */
        public int ExecuteReflectionMeasurementForTRLCalibration(uint channelNumber, uint portNumber)
        {
            int error = 0, count = 0;
            string command = ":SENSe" + channelNumber + ":CORRection:COLLect:ACQuire:TRLReflect " + portNumber + "\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            command = "*OPC?\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            byte[] response = new byte[64];
            error = visa32.viRead(analyzerSession, response, 64, out count);
            if (Convert.ToUInt32(Encoding.ASCII.GetString(response, 0, count-1)) == 1)
            {
                return 0;
            }
            else
            {
                return (-7);
            }
        }

        /* :SENSe1:CORRection:COLLect:ACQuire:TRLLine 1, 2 */
        public int ExecuteLineMatchMeasurementForTRLCalibration(uint channelNumber, uint responsePortNumber, uint stimulusPortNumber)
        {
            int error = 0, count = 0;
            if (responsePortNumber == stimulusPortNumber)
            {
                return (-1);
            }
            string command = ":SENSe" + channelNumber + ":CORRection:COLLect:ACQuire:TRLLine " + responsePortNumber + ", " + stimulusPortNumber + "\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            command = "*OPC?\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            byte[] response = new byte[64];
            error = visa32.viRead(analyzerSession, response, 64, out count);
            if (Convert.ToUInt32(Encoding.ASCII.GetString(response, 0, count-1)) == 1)
            {
                return 0;
            }
            else
            {
                return (-8);
            }
        }

        /* :SENSe1:CORRection:COLLect:SAVE */
        public int CalculateCalibrationCoefficientsForResponseType(uint channelNumber)
        {
            int error = 0, count = 0;
            string command = ":SENSe" + channelNumber + ":CORRection:COLLect:SAVE\n", response;
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :SENSe1:CORRection:COLLect:SIMPlified:SAVE */
        public int CalculateCalibrationCoefficientsForSimplifiedType(uint channelNumber)
        {
            int error = 0, count = 0;
            string command = ":SENSe" + channelNumber + ":CORRection:COLLect:SIMPlified:SAVE\n", response;
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :MMEMory:STORe:STATe "Calibration_Coefficients.sta" */
        public int SaveCalibrationCoefficientsToFile(string calibrationCoefficientsDataFileName /* NOTE : file extension must be .sta */)
        {
            int error = 0, count = 0;
            string command = ":MMEMory:STORe:STATe \"" + calibrationCoefficientsDataFileName + "\"\n", response;
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response); 
        }

        /* :MMEMory:LOAD:STATe "Calibration_Coefficients.sta" */
        public int LoadCalibrationCoefficientsFromFile(string calibrationCoefficientsDataFileName /* NOTE : file name can include path, but must contain .sta extension */ )
        {
            int error = 0, count = 0;
            string command = ":MMEMory:LOAD:STATe \"" + calibrationCoefficientsDataFileName + "\"\n", response;
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :SENSe1:CORRection:COEFficient:DATA? ER, 1, 1 */
        public enum CalibrationCoefficientDataType
        {
            ES = 1,     /* Source match */
            ER = 2,     /* Reflection tracking */
            ED = 3,     /* Directivity */
            EL = 4,     /* Load match */
            ET = 5,     /* Transmission tracking */
            EX = 6      /* Isolation */
        }
        public int ReadOutCalibrationCoefficientData(uint channelNumber, 
                                                     CalibrationCoefficientDataType caliType,
                                                     uint responsePortNumber,
                                                     uint stimulusPortNumber,
                                                     out double[] dataRealPart,
                                                     out double[] dataImagPart)
        {
            int error = 0, count = 0;
            string type, errorMesg;
            switch (caliType)
            {
                case CalibrationCoefficientDataType.ES:     type = "ES";    break;
                case CalibrationCoefficientDataType.ER:     type = "ER";    break;
                case CalibrationCoefficientDataType.ED:     type = "ED";    break;
                case CalibrationCoefficientDataType.EL:     type = "EL";    break;
                case CalibrationCoefficientDataType.ET:     type = "ET";    break;
                case CalibrationCoefficientDataType.EX:     type = "EX";    break;
                default:                                    type = "ER";    break;
            }

            switch (caliType)
            {
                case CalibrationCoefficientDataType.ES:
                case CalibrationCoefficientDataType.ER:
                case CalibrationCoefficientDataType.ED:
                    if (responsePortNumber != stimulusPortNumber)
                        error = (-1);
                    break;
                case CalibrationCoefficientDataType.EL:
                case CalibrationCoefficientDataType.ET:
                case CalibrationCoefficientDataType.EX:
                    if (responsePortNumber == stimulusPortNumber)
                        error = (-2);
                    break;
                default:
                    error = 0;
                    break;
            }
            if (error == 0)
            {
                string command = ":SENSe" + channelNumber + ":CORRection:COEFficient:DATA? " + type + ", " + responsePortNumber + ", " + stimulusPortNumber + "\n";
                error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
                // error = QueryErrorStatus(out errorMesg);
                if (error == 0)
                {
                    byte[] response = new byte[100 * 1024];
                    error = visa32.viRead(analyzerSession, response, (100 * 1024), out count);
                    string[] dataArray = Encoding.ASCII.GetString(response, 0, count).Split(new char[] { ',', '\n', ' '});
                    int length = dataArray.Length;
                    dataRealPart = new double[length / 2];
                    dataImagPart = new double[length / 2];
                    for (int index = 0; index < length - 2; index += 2)
                    {
                        dataRealPart[index / 2] = Convert.ToDouble(dataArray[index]);
                        dataImagPart[index / 2] = Convert.ToDouble(dataArray[index + 1]);
                    }
                    return QueryErrorStatus(out errorMesg);
                }
                else
                {
                    dataRealPart = new double[0];
                    dataImagPart = new double[0];
                    return error;
                }
            }
            else
            {
                dataRealPart = new double[0];
                dataImagPart = new double[0];
                return error;
            }
        }

        /* :SENSe1:CORRection:OFFSet:COLLect:CLEar */
        public int ClearMechanicalCalKitMeasurementValues(uint channelNumber)
        {
            int error = 0, count = 0;
            string command = ":SENSe" + channelNumber + ":CORRection:OFFSet:COLLect:CLEar\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            string response;
            return QueryErrorStatus(out response);
        }

        /* :SENSe1:OFFSet:STATe ON */
        public int TurnOnOffFrequencyOffsetMode(uint channelNumber, int status /* 1: ON, 0: OFF */)
        {
            int error = 0, count = 0;
            string command = ":SENSe" + channelNumber + ":OFFSet:STATe " + status + "\n", response;
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :SENSe1:OFFSet:STATe? */
        public int QueryFrequencyOffsetModeStatus(uint channelNumber, out int status)
        {
            int error = 0, count = 0;
            string command = ":SENSe" + channelNumber + ":OFFSet:STATe?\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            byte response = new byte[64];
            error = visa32.viRead(analyzerSession, response, 64, out count);
            status = Convert.ToInt32(Encoding.ASCII.GetString(response, 0, count-1));
            return error;
        }

        /* :SENSe1:CORRection:OFFSet:CLEar */
        public int ClearCalibrationErrorCoefficients(uint channelNumber)
        {
            int error = 0, count = 0;
            string command = ":SENSe" + channelNumber + ":CORRection:OFFSet:CLEar\n", response;
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }
        #endregion

        #region ECal auto calibration
        /* :SENSe1:CORRection:COLLect:ECAL:SOLT1 1 */
        public int ECalExecute1PortAutoCalibration(uint channelNumber, uint portNumber)
        {
            int error = 0, count;
            string command = ":SENSe" + channelNumber + ":CORRection:COLLect:ECAL:SOLT1 " + portNumber + "\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = "*OPC?\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            byte[] response = new byte[64];
            error = visa32.viRead(analyzerSession, response, 64, out count);
            if (Convert.ToInt32(Encoding.ASCII.GetString(response, 0, count-1)) == 1)
            {
                return 0;
            }
            else
            {
                return (-9);
            }
        }

        /* :SENSe1:CORRection:COLLect:ECAL:SOLT2 1, 2 */
        public int ECalExecuteFull2PortAutoCalibration(uint channelNumber, uint portNumber1, uint portNumber2)
        {
            int error = 0, count = 0;
            if (portNumber1 == portNumber2)
            {
                return (-1);
            }
            string command = ":SENSe" + channelNumber + ":CORRection:COLLect:ECAL:SOLT2 " + portNumber1 + ", " + portNumber2 + "\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = "*OPC?\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            byte[] response = new byte[64];
            error = visa32.viRead(analyzerSession, response, 64, out count);
            if (Convert.ToInt32(Encoding.ASCII.GetString(response, 0, count-1)) == 1)
            {
                return 0;
            }
            else
            {
                return (-10);
            }
        }

        /* :SENSe1:CORRection:COLLect:ECAL:SOLT3 1, 2, 3 */
        public int ECalExecuteFull3PortAutoCalibration(uint channelNumber, uint portNumber1, uint portNumber2, uint portNumber3)
        {
            int error = 0, count = 0;
            if ((portNumber1 == portNumber2) || (portNumber2 == portNumber3) || (portNumber1 == portNumber3))
            {
                return (-1);
            }
            string command = ":SENSe" + channelNumber + ":CORRection:COLLect:ECAL:SOLT3 " + portNumber1 + ", " + portNumber2 + ", " + portNumber3 + "\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = "*OPC?\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            byte[] response = new byte[64];
            error = visa32.viRead(analyzerSession, response, 64, out count);
            if (Convert.ToInt32(Encoding.ASCII.GetString(response, 0, count-1)) == 1)
            {
                return 0;
            }
            else
            {
                return (-11);
            }
        }

        /* :SENSe1:CORRection:COLLect:ECAL:SOLT4 1, 2, 3, 4 */
        public int ECalExecuteFull4PortAutoCalibration(uint channelNumber)
        {
            int error = 0, count = 0;
            string command = ":SENSe" + channelNumber + ":CORRection:COLLect:ECAL:SOLT4 1, 2, 3, 4\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = "*OPC?\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            byte[] response = new byte[64];
            error = visa32.viRead(analyzerSession, response, 64, out count);
            // string result = Encoding.ASCII.GetString(response, 0, count - 1);
            if (Convert.ToInt32(Encoding.ASCII.GetString(response, 0, count-1)) == 1)
            {
                return 0;
            }
            else
            {
                return (-12);
            }
        }

        /* :SENSe1:CORRection:COLL:ecal:ERESponse 1, 2 */
        public int ECalExecuteEnhancedResponseAutoCalibration(uint channelNumber, uint portNumber1, uint portNumber2)
        {
            int error = 0, count = 0;
            if (portNumber1 == portNumber2)
            {
                return (-1);
            }
            string command = ":SENSe" + channelNumber + ":CORRection:COLLect:ECAL:ERESponse " + portNumber1 + ", " + portNumber2 + "\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = "*OPC?\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            byte[] response = new byte[64];
            error = visa32.viRead(analyzerSession, response, 64, out count);
            if (Convert.ToInt32(Encoding.ASCII.GetString(response, 0, count-1)) == 1)
            {
                return 0;
            }
            else
            {
                return (-13);
            }
        }

        /* :SENSe1:CORRection:COLLect:ECAL:THRU 1, 2 */
        public int ECalExecuteResponseThruAutoCalibration(uint channelNumber, uint responsePortNumber, uint stimulusPortNumber)
        {
            int error = 0, count = 0;
            if (responsePortNumber == stimulusPortNumber)
            {
                return (-1);
            }
            string command = ":SENSe" + channelNumber + ":CORRection:COLLect:ECAL:THRU " + responsePortNumber + ", " + stimulusPortNumber + "\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = "*OPC?\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            byte[] response = new byte[64];
            error = visa32.viRead(analyzerSession, response, 64, out count);
            if (Convert.ToInt32(Encoding.ASCII.GetString(response, 0, count-1)) == 1)
            {
                return 0;
            }
            else
            {
                return (-14);
            }
        }

        /* :SENSe1:CORRection:TYPE1? */
        public int CheckAppliedCalibrationType(uint channelNumber, uint traceNumber, out string[] type)
        {
            int error = 0, count = 0;
            string command = ":SENSe" + channelNumber + ":CORRection:TYPE" + traceNumber + "?\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            byte[] response = new byte[512];
            error = visa32.viRead(analyzerSession, response, 512, out count);
            type = Encoding.ASCII.GetString(response, 0, count - 1).Split(new char[] { ',', ' ', '\n' });
            return error;
        }
        #endregion
    }
}