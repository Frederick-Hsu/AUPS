using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Amphenol.Instruments.Keysight
{
    public partial class SignalAnalyzer_N9020A
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

            StringBuilder attrValue = new StringBuilder();
            viError = visa32.viGetAttribute(session, visa32.VI_ATTR_RSRC_CLASS, attrValue);
            viError = visa32.viSetAttribute(session, visa32.VI_ATTR_TERMCHAR_EN, visa32.VI_TRUE);
            viError = visa32.viSetAttribute(session, visa32.VI_ATTR_TMO_VALUE, 20000);
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

        #region Properties
        public enum State
        {
            OFF = 0,
            ON = 1
        }
        public enum Impedance
        {
            IMPEDANCE_50Ohms = 50,
            IMPEDANCE_75Ohms = 75
        }
        public enum RFCoupling
        {
            AC = 0,
            DC = 1
        }
        #endregion

        #region SCPI Command Functions
        /* *IDN? */
        public int GetInstrumentIdentifier(out string idn)
        {
#if false
            int error;
            int count;
            string command = "*IDN?\n", response;
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
#else
            int error, count;
            string command = "*IDN?\n";     /* [NOTICE]!!!!!! [TOP CRITICAL AND IMPORTANT]
                                             * every command MUST contain the "\n" at the end of line.
                                             * otherwise it won't work in the condition of socket VISA address like 
                                             * "TCPIP0::192.168.1.142::5025::SOCKET"
                                             * 
                                             * NEVER FORGET!
                                             */
            byte[] response = new byte[256];

            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, response, 256, out count);
            // idn = new string(Encoding.ASCII.GetChars(response), 0, count);
            idn = Encoding.ASCII.GetString(response, 0, count);
            return error;
#endif
        }

        /* :DISP:WIND:FORM:ZOOM */
        public int SetWindowZoom()
        {
            int error;
            string command = ":DISPlay:WINDow:FORMat:ZOOM\n";
            byte[] result = new byte[128];
            int count;

            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            if (error != visa32.VI_SUCCESS)
                return error;
            command = "SYSTem:ERRor?\n";
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, result, 128, out count);
            string response = new string(Encoding.ASCII.GetChars(result), 0, count);

            if (error != visa32.VI_SUCCESS)
                return error;

            string[] array = response.Split(',');
            return Convert.ToInt32(array[0]);
        }

        /* :DISP:WIND:FORM:TILE */
        public int SetWindowTiled()
        {
            int error, count;
            string command = ":DISPlay:WINDow:FORMat:TILE\n";
            byte[] result = new byte[128];

            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            command = "SYSTem:ERRor?\n";
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, result, 128, out count);

            string response = new string(Encoding.ASCII.GetChars(result), 0, count);
            string[] array = response.Split(',');
            return Convert.ToInt32(array[0]);
        }

        /* :DISP:WIND:SEL 2 */
        public int SelectActiveWindowAt(int windowNo)
        {
            int error, count;
            string command = ":DISPlay:WINDow:SELect " + windowNo + "\n";
            byte[] result = new byte[128];

            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            command = "SYSTem:ERRor?\n";
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, result, 128, out count);

            string response = new string(Encoding.ASCII.GetChars(result), 0, count);
            string[] array = response.Split(',');
            return Convert.ToInt32(array[0]);
        }

        /* SYSTem:ERRor? */
        public int QuerySystemError(out string errorMesg)
        {
            int error, count;
            string command = "SYSTem:ERRor?\n";
            byte[] result = new byte[256];
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, result, 256, out count);

            string response = new string(Encoding.ASCII.GetChars(result), 0, count);
            string[] array = response.Split(',');
            errorMesg = array[1];
            return Convert.ToInt32(array[0]);
        }

        /* :DISP:WIND:SEL? */
        public int QueryWhichWindowToBeSelected(out int windowNo)
        {
            int error, count;
            string command = ":DISPlay:WINDow:SELect?\n";
            byte[] result = new byte[64];
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, result, 64, out count);

            string response = new string(Encoding.ASCII.GetChars(result), 0, count);
            windowNo = Convert.ToInt32(response);
            return error;
        }

        /* :DISP:FSCR:STAT ON */
        public int TurnOnOffFullDisplay(State state)
        {
            int error, count;
            string command = ":DISPlay:FSCReen:STATe " + state + "\n", response;
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = QuerySystemError(out response);
            return error;
        }

        /* *CLS */
        public int ClearStatusAndErrorQueue()
        {
            int error, count;
            string command = "*CLS\n", response;
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = QuerySystemError(out response);
            return error;
        }                

        /* :CAL:ALL? */
        public int AlignEntireSystem()
        {
            int error, count;
            string command = ":CALibration:ALL\n";
            byte[] result = new byte[64];
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = "*OPC?\n";
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, result, 64, out count);

            string response = new string(Encoding.ASCII.GetChars(result), 0, count);
            if (error == visa32.VI_SUCCESS_TERM_CHAR)
            {
                return Convert.ToInt32(response);
            }
            return error;
        }

        /* *TST? */
        public int SelfTestQuery(out int result)
        {
            int error, count;
            string command = "*TST?\n";
            byte[] resp = new byte[256];
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, resp, 256, out count);

            string response = new string(Encoding.ASCII.GetChars(resp), 0, count);
            result = Convert.ToInt32(response);
            return error;
        }
        #endregion
    }
}
