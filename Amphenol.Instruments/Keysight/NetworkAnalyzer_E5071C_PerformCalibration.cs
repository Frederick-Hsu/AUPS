using System;
using System.Text;

namespace Amphenol.Instruments.Keysight
{
    partial class NetworkAnalyzer_E5071C
    {
        #region Performing calibration
        /* :SENSe1:CORRection:COLLect:CKIT:SELect 1 */
        public int SelectCalibrationKit(uint chnum, uint calibrationKitNumber = 1)
        {
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
        #endregion
    }
}