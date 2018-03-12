using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Amphenol.Instruments.Keysight
{
    public class NetworkAnalyzer_E5071C
    {
        private int resourceMgr;
        private int analyzerSession;

        public NetworkAnalyzer_E5071C()
        {
            resourceMgr = 0;
            analyzerSession = 0;
        }

        public int Open(string visaAddress)
        {
            int viError;

            viError = visa32.viOpenDefaultRM(out resourceMgr);
            if (viError != visa32.VI_SUCCESS)
            {
                return viError;
            }
            viError = visa32.viOpen(resourceMgr, visaAddress, visa32.VI_NO_LOCK, visa32.VI_TMO_IMMEDIATE, out analyzerSession);
            if (viError != visa32.VI_SUCCESS)
            {
                return viError;
            }
            return viError;
        }

        public int Close()
        {
            int viError = visa32.viClose(analyzerSession);
            analyzerSession = 0;

            viError = visa32.viClose(resourceMgr);
            resourceMgr = 0;
            return viError;
        }

        public int GetInstrumentIdentifier(out string idn)
        {
            int viError;
            int count = 0;
            string command = "*IDN?", response;

            viError = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            if (viError != visa32.VI_SUCCESS)
            {
                idn = string.Empty;
                return viError;
            }
            viError = visa32.viRead(analyzerSession, out response, 256);
            if (viError != visa32.VI_SUCCESS)
            {
                idn = string.Empty;
                return viError;
            }

            idn = response;
            return viError;
        }
    }
}
