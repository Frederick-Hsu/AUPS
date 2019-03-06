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
        #endregion
    }
}