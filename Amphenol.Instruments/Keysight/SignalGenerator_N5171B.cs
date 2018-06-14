using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Amphenol.Instruments.Keysight
{
    public class SignalGenerator_N5171B
    {
        private int resourceMgr;
        private int session;

        public SignalGenerator_N5171B()
        {
            resourceMgr = 0;
            session = 0;
        }

        public int Open(string visaAddress)
        {
            int viError = visa32.viOpenDefaultRM(out resourceMgr);
            if (viError != visa32.VI_SUCCESS)
            {
                return viError;
            }
            viError = visa32.viOpen(resourceMgr, visaAddress, visa32.VI_NO_LOCK, visa32.VI_TMO_IMMEDIATE, out session);
            if (viError != visa32.VI_SUCCESS)
            {
                return viError;
            }
            return viError;
        }

        public int Close()
        {
            int viError = visa32.viClose(session);
            session = 0;
            viError = visa32.viClose(resourceMgr);
            resourceMgr = 0;
            return viError;
        }

        public int GetInstrumentIdentifier(out string idn)
        {
            int error, count;
            string command = "*IDN?", response;
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, out response, 256);
            idn = response;
            return error;
        }
    }
}
