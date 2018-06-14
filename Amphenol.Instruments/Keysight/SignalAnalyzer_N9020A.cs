using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Amphenol.Instruments.Keysight
{
    public class SignalAnalyzer_N9020A
    {
        private int resourceMrg;
        private int session;

        public SignalAnalyzer_N9020A()
        {
            resourceMrg = 0;
            session = 0;
        }

        public int Open(string visaAddress)
        {
            int viError = visa32.viOpenDefaultRM(out resourceMrg);
            if (viError != visa32.VI_SUCCESS)
            {
                return viError;
            }
            viError = visa32.viOpen(resourceMrg, visaAddress, visa32.VI_NO_LOCK, visa32.VI_TMO_IMMEDIATE, out session);
            if (viError != visa32.VI_SUCCESS)
                return viError;
            return viError;
        }

        public int Close()
        {
            int viError = visa32.viClose(session);
            session = 0;
            viError = visa32.viClose(resourceMrg);
            resourceMrg = 0;
            return viError;
        }

        /* *IDN? */
        public int GetInstrumentIdentifier(out string idn)
        {
            int error;
            int count;
            string command = "*IDN?", response;
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            if (error != visa32.VI_SUCCESS)
            {
                idn = "";
                return error;
            }
            error = visa32.viRead(session, out response, 256);
            if (error != visa32.VI_SUCCESS)
            {
                idn = "";
                return error;
            }
            idn = response;
            return error;
        }

        /* :DISP:WIND:FORM:ZOOM */
        public int SetWindowZoom()
        {
            int error;
            string command = ":DISPlay:WINDow:FORMat:ZOOM", response;
            int count;

            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            if (error != visa32.VI_SUCCESS)
                return error;
            command = "SYSTem:ERRor?";
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, out response, 128);
            if (error != visa32.VI_SUCCESS)
                return error;

            string[] array = response.Split(',');
            return Convert.ToInt32(array[0]);
        }

        /* :DISP:WIND:FORM:TILE */
        public int SetWindowTiled()
        {
            int error, count;
            string command = ":DISPlay:WINDow:FORMat:TILE", response;

            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            command = "SYSTem:ERRor?";
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, out response, 128);
            string[] array = response.Split(',');
            return Convert.ToInt32(array[0]);
        }

        /* :DISP:WIND:SEL 2 */
        public int SelectActiveWindowAt(int windowNo)
        {
            int error, count;
            string command = ":DISPlay:WINDow:SELect " + windowNo, response;

            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            command = "SYSTem:ERRor?";
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, out response, 128);
            string[] array = response.Split(',');
            return Convert.ToInt32(array[0]);
        }

        /* SYSTem:ERRor? */
        public int QuerySystemError(out string errorMesg)
        {
            int error, count;
            string command = "SYSTem:ERRor?", response;
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, out response, 256);

            string[] array = response.Split(',');
            errorMesg = array[1];
            return Convert.ToInt32(array[0]);
        }
    }
}
