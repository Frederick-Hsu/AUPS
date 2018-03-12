using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace Amphenol.Instruments.Keysight
{
    public class DCPowerSupply_E3646A
    {
        private int resourceMgr;
        private int powerSupplySession;

        public DCPowerSupply_E3646A()
        {
            resourceMgr = 0;
            powerSupplySession = 0;
        }

        public int Open(string visaAddress)
        {
            int viError = visa32.viOpenDefaultRM(out resourceMgr);
            if (viError != visa32.VI_SUCCESS)
            {
                return viError;
            }
            viError = visa32.viOpen(resourceMgr, visaAddress, visa32.VI_NO_LOCK, visa32.VI_TMO_IMMEDIATE, out powerSupplySession);
            if (viError != visa32.VI_SUCCESS)
            {
                return viError;
            }

            byte resourceClass, type, ioport;
            viError = visa32.viGetAttribute(powerSupplySession, visa32.VI_ATTR_RSRC_CLASS, out resourceClass);
            viError = visa32.viGetAttribute(powerSupplySession, visa32.VI_ATTR_INTF_TYPE, out type);
            viError = visa32.viGetAttribute(powerSupplySession, visa32.VI_ATTR_IO_PROT, out ioport);

            viError = visa32.viSetAttribute(powerSupplySession, visa32.VI_ATTR_TERMCHAR_EN, 1);
            viError = visa32.viSetAttribute(powerSupplySession, visa32.VI_ATTR_TMO_VALUE, 1000);
            return viError;
        }

        public int Close()
        {
            int viError = visa32.viClose(powerSupplySession);
            powerSupplySession = 0;

            viError = visa32.viClose(resourceMgr);
            resourceMgr = 0;
            return viError;
        }

        public int GetInstrumentIdentifier(out string idn)
        {
            int count = 0;
            int error = 0;
            string command = "*IDN?\n", response;

                error = visa32.viWrite(powerSupplySession, Encoding.ASCII.GetBytes(command), command.Length, out count);
                if (error != visa32.VI_SUCCESS)
                {
                    idn = string.Empty;
                    return error;
                }
                error = visa32.viRead(powerSupplySession, out response, 256);
                if (error != visa32.VI_SUCCESS)
                {
                    idn = string.Empty;
                    return error;
                }
                idn = response;

            return error;
        }
    }
}
