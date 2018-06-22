using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.NetworkInformation;

namespace Amphenol.Instruments.Keysight
{
    public class DigitalMultiMeter_34461A
    {
        private int resourceMgr;
        private int dmmSession;

        public DigitalMultiMeter_34461A()
        {
            resourceMgr = 0;
            dmmSession = 0;
        }

        public int Open(string dmmVisaAddress)
        {
            int viError;

            /* Open the default resource manager */
            viError = visa32.viOpenDefaultRM(out resourceMgr);
            if (viError != visa32.VI_SUCCESS)
                return viError;
            /* Open the seesion for current Keysight 34461A DMM. */
            viError = visa32.viOpen(resourceMgr, dmmVisaAddress, visa32.VI_NO_LOCK, visa32.VI_TMO_IMMEDIATE, out dmmSession);
            if (viError != visa32.VI_SUCCESS)
                return viError;

            return viError;
        }

        public int Close()
        {
            int viError;
            viError = visa32.viClose(dmmSession);
            dmmSession = 0;

            viError = visa32.viClose(resourceMgr);
            resourceMgr = 0;
            return viError;
        }

        public int GetInstrumentIdentifier(out string idn)
        {
            int viError;
            int actualCount;
            string command = "*IDN?\n";
            byte[] response = new byte[256];

            viError = visa32.viWrite(dmmSession, Encoding.ASCII.GetBytes(command), command.Length, out actualCount);
            if (viError != visa32.VI_SUCCESS)
            {
                idn = "";
                return viError;
            }

            viError = visa32.viRead(dmmSession, response, 256, out actualCount);
            if (viError != visa32.VI_SUCCESS)
            {
                idn = string.Empty;
                return viError;
            }

            idn = Encoding.ASCII.GetString(response, 0, actualCount);
            return viError;
        }

        public int MeasureResistorVia2Wires(out float resistance)
        {
            int viError;
            int actualCount;
            byte[] response = new byte[256];

            string command = "CONFigure:RESistance\n";
            viError = visa32.viWrite(dmmSession, Encoding.ASCII.GetBytes(command), command.Length, out actualCount);
            if (viError != visa32.VI_SUCCESS)
            {
                resistance = 0.00F;
                return viError;
            }

            command = "READ?\n";
            viError = visa32.viWrite(dmmSession, Encoding.ASCII.GetBytes(command), command.Length, out actualCount);
            viError = visa32.viRead(dmmSession, response, 256, out actualCount);
            if (viError != visa32.VI_SUCCESS)
            {
                resistance = 0.00F;
                return viError;
            }

            resistance = Convert.ToSingle(Encoding.ASCII.GetString(response, 0, actualCount));
            return viError;
        }

        public int MeasureResistorVia4Wires(out float resistance)
        {
            int viError;
            int actualCount;
            byte[] response = new byte[512];
            string[] valueArray = new string[3];
            float[] resistanceArray = new float[3];

            string command = "CONFigure:FRESistance\n";
            viError = visa32.viWrite(dmmSession, Encoding.ASCII.GetBytes(command), command.Length, out actualCount);
            if (viError != visa32.VI_SUCCESS)
            {
                resistance = 0.00F;
                return viError;
            }

            command = "SAMP:COUNt 3\n";
            viError = visa32.viWrite(dmmSession, Encoding.ASCII.GetBytes(command), command.Length, out actualCount);
            command = "READ?\n";
            viError = visa32.viWrite(dmmSession, Encoding.ASCII.GetBytes(command), command.Length, out actualCount);
            viError = visa32.viRead(dmmSession, response, 512, out actualCount);
            if (viError != visa32.VI_SUCCESS)
            {
                resistance = 0.00F;
                return viError;
            }

            valueArray = Encoding.ASCII.GetString(response, 0, actualCount).Split(',');
            for (int index = 0; index < 3; index++)
            {
                resistanceArray[index] = Convert.ToSingle(valueArray[index]);
            }
            resistance = (resistanceArray[0] + resistanceArray[1] + resistanceArray[2]) / 3;
            return viError;
        }
    }
}
