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
            string command = "*IDN?";
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
            string command = ":DISPlay:WINDow:FORMat:ZOOM";
            byte[] result = new byte[128];
            int count;

            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            if (error != visa32.VI_SUCCESS)
                return error;
            command = "SYSTem:ERRor?";
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
            string command = ":DISPlay:WINDow:FORMat:TILE";
            byte[] result = new byte[128];

            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            command = "SYSTem:ERRor?";
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
            string command = ":DISPlay:WINDow:SELect " + windowNo;
            byte[] result = new byte[128];

            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            command = "SYSTem:ERRor?";
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
            string command = "SYSTem:ERRor?";
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
            string command = ":DISPlay:WINDow:SELect?";
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
            string command = ":DISPlay:FSCReen:STATe " + state, response;
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = QuerySystemError(out response);
            return error;
        }

        /* *CLS */
        public int ClearStatusAndErrorQueue()
        {
            int error, count;
            string command = "*CLS", response;
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = QuerySystemError(out response);
            return error;
        }                

        /* :CAL:ALL? */
        public int AlignEntireSystem()
        {
            int error, count;
            string command = ":CALibration:ALL";
            byte[] result = new byte[64];
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = "*OPC?";
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

        /* :SENSe:CORRection:IMPedance:INPut:MAGNitude 50 */
        public int SetRFInputImpedanceCorrection(Impedance imp)
        {
            int error, count;
            string command = ":SENSe:CORRection:IMPedance:INPut:MAGNitude " + imp, response;
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* :SENSe:CORRection:IMPedance:INPut:MAGNitude? */
        public int GetRFInputImpedanceCorrection(out Impedance imp)
        {
            int error, count;
            string command = ":SENSe:CORRection:IMPedance:MAGNitude?";
            byte[] response = new byte[256];
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, response, 256, out count);
            imp = (Impedance)Convert.ToInt32(new string(Encoding.ASCII.GetChars(response), 0, count));
            return error;
        }

        /* :INP:COUP AC */
        public int SelectRFInputCoupling(RFCoupling coupling)
        {
            int error, count;
            string coup = (coupling == RFCoupling.AC) ? "AC" : "DC";
            string command = ":INPut:COUPling " + coup, response;

            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* :INP:COUP? */
        public int QueryRFInputCoupling(out string coupling)
        {
            int error, count;
            string command = ":INPut:COUPling?";
            byte[] response = new byte[64];

            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, response, 64, out count);
            coupling = Encoding.ASCII.GetString(response, 0, count);
            return error;
        }
#endregion
    }
}
