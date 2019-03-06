using System;
using System.Collections.Generic;
using System.Text;

namespace Amphenol.Instruments.Keysight
{
    partial class NetworkAnalyzer_E5071C
    {
        #region Chapter 9 Saving and Recalling (File Management)
        /* :MMEMory:STORe:STYPe CDSTate */
        public int SelectInstrumentStateContentTypeToSave(string instrumentStateContentType = "CSTate")
        {
            /* [NOTICE] : For the instrument state content type, only 4 options are available.
             *            STATe     - Instrument Status only
             *            CSTate    - Instrument status and calibration coefficient array
             *            DSTate    - Instrument status, corrected data / memory array (measurement data)
             *            CDSTate   - Instrument status, calibration coefficient array, and corrected data / memory array (measurement data)
             */
            int error = 0, count = 0;
            string command = ":MMEMory:STORe:STYPe " + instrumentStateContentType + "\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            string response;
            return QueryErrorStatus(out response);
        }

        /* :MMEMory:STORe:STYPe? */
        public int QueryWhichInstrumentStateContentTypeToSave(out string instrumentStateContentType)
        {
            int error = 0, count = 0;
            string command = ":MMEMory:STORe:STYPe?\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            byte[] response = new byte[64];
            error = visa32.viRead(analyzerSession, response, 64, out count);
            instrumentStateContentType = Encoding.ASCII.GetString(response, 0, count - 1);
            return error;
        }

        /* :MMEMory:STORe:SALL OFF */
        public int SelectWhichSettingsOfChannelsTracesToSave(string onOff = "OFF")
        {
            /* [NOTICE] : select whether to save the settings of all channels / traces or that of the 
             *            displayed channels / traces only as the instrument state to be saved.
             *            
             *            ON    - specify the settings of all channels / traces as the target to be saved.
             *            OFF   - specify the settings of displayed channels / traces only as the target to be saved.
             *            
             */
            int error = 0, count = 0;
            string command = ":MMEMory:STORe:SALL " + onOff + "\n", response;
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }
        #endregion
    }
}