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
            if (Convert.ToUInt32(Encoding.ASCII.GetString(response, 0, count-1)) == 0)
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
        #endregion
    }
}