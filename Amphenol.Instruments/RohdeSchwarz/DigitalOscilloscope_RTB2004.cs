using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Amphenol.Instruments.RohdeSchwarz
{
    public class DigitalOscilloscope_RTB2004
    {
        private int resourceMgr;
        private int session;

        public DigitalOscilloscope_RTB2004()
        {
            resourceMgr = 0;
            session = 0;
        }

        public int Open(string visaAddress)
        {
            int error = visa32.viOpenDefaultRM(out resourceMgr);
            if (error != visa32.VI_SUCCESS)
            {
                return error;
            }
            error = visa32.viOpen(resourceMgr, visaAddress, visa32.VI_NO_LOCK, visa32.VI_TMO_IMMEDIATE, out session);
            if (error != visa32.VI_SUCCESS)
            {
                return error;
            }

            byte resourceClass, type, ioport;
            error = visa32.viGetAttribute(session, visa32.VI_ATTR_RSRC_CLASS, out resourceClass);
            error = visa32.viGetAttribute(session, visa32.VI_ATTR_INTF_TYPE, out type);
            error = visa32.viGetAttribute(session, visa32.VI_ATTR_IO_PROT, out ioport);
            error = visa32.viSetAttribute(session, visa32.VI_ATTR_TERMCHAR_EN, 1);
            error = visa32.viSetAttribute(session, visa32.VI_ATTR_TMO_VALUE, 1000);
            return error;
        }

        public int Close()
        {
            int error = visa32.viClose(session);
            session = 0;
            error = visa32.viClose(resourceMgr);
            resourceMgr = 0;
            return error;
        }

        public int GetInstrumentIdentifier(out string idn)
        {
            int error, count;
            string command = "*IDN?\n";
            byte[] response = new byte[256];

            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, response, 256, out count);
            idn = Encoding.ASCII.GetString(response, 0, count);
            return error;
        }
    }
}
