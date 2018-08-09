using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Amphenol.Instruments.RohdeSchwarz
{
    public class SignalGenerator_SMB100A
    {
        private int rsrcMgr;
        private int session;

        public SignalGenerator_SMB100A()
        {
            rsrcMgr = 0;
            session = 0;
        }

        public int Open(string visaAddress)
        {
            int error = visa32.viOpenDefaultRM(out rsrcMgr);
            error = visa32.viOpen(rsrcMgr, visaAddress, visa32.VI_NO_LOCK, visa32.VI_TMO_IMMEDIATE, out session);

            byte rsrcClass, type, ioport;
            error = visa32.viGetAttribute(session, visa32.VI_ATTR_RSRC_CLASS, out rsrcClass);
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
            error = visa32.viClose(rsrcMgr);
            rsrcMgr = 0;
            return error;
        }

        public enum State
        {
            UNDEFINED = -100,
            ON = 1,
            OFF = 0
        }

        #region General Instrument Settings
        /* *IDN? */
        public int GetInstrumentIdentifier(out string idn)
        {
            int error = 0, count = 0;
            string command = "*IDN?\n";
            byte[] response = new byte[256];

            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, response, 256, out count);
            idn = Encoding.ASCII.GetString(response, 0, count);
            return error;
        }

        /* :SYST:ERR:ALL? */
        public int ReadOutAllErrors(out int errorno, out string errormesg)
        {
            int state = 0, count = 0;
            string command = ":SYSTem:ERRor:ALL?\n";
            byte[] response = new byte[256];
            state = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            state = visa32.viRead(session, response, 256, out count);

            string result = Encoding.ASCII.GetString(response, 0, count - 1);
            string[] spliters = result.Split(',');
            errorno = Convert.ToInt32(spliters[0]);
            errormesg = spliters[1];
            return state;
        }

        /* :SYST:SERR? */
        public int ReadPermanentErrorMessages(out int errorno, out string permanentErrorMesg)
        {
            int state = 0, count = 0;
            string command = ":SYSTem:SERRor?\n";
            byte[] response = new byte[256];
            state = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            state = visa32.viRead(session, response, 256, out count);

            string result = Encoding.ASCII.GetString(response, 0, count - 1);
            string[] spliters = result.Split(',');
            errorno = Convert.ToInt32(spliters[0]);
            permanentErrorMesg = spliters[1];
            return state;
        }

        /* :SYST:ERR? */
        public int QuerySystemError(out string errormesg)
        {
            int state = 0, count = 0;
            string command = ":SYSTem:ERRor?\n";
            byte[] response = new byte[256];

            state = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            state = visa32.viRead(session, response, 256, out count);

            string[] spliters = Encoding.ASCII.GetString(response, 0, count - 1).Split(',');
            int errorno = Convert.ToInt32(spliters[0]);
            errormesg = spliters[1];
            return errorno;
        }

        /* *CLS */
        public int CleanAllErrorQueue()
        {
            int state = 0, count = 0;
            string command = "*CLS\n", response;
            state = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* *RST */
        public int PresetInstrument()
        {
            int state = 0, count = 0;
            string command = "*RST\n";
            byte[] response = new byte[256];
            state = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":SYSTem:ERRor?\n";
            state = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            state = visa32.viRead(session, response, 256, out count);
            string result = Encoding.ASCII.GetString(response, 0, count - 1);
            string[] spliters = result.Split(',');
            return Convert.ToInt32(spliters[0]);
        }

        /* CAL:ALL:MEAS? */
        public int StartAllInternalAdjustments(out string successMesg)
        {
            int state = 0, count = 0;
            string command = "CALibration:ALL:MEASure?\n";
            byte[] response = new byte[256];
            state = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            state = visa32.viRead(session, response, 256, out count);
            successMesg = Encoding.ASCII.GetString(response, 0, count - 1);
            return state;
        }

        /* :DIAGnostic:BGINfo? */
        public int QueryInstalledAssemblies(out string[] assemblies)
        {
            int state = 0, count = 0;
            string command = ":DIAGnostic:BGINfo?\n";
            byte[] response = new byte[2048];
            state = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            state = visa32.viRead(session, response, 2048, out count);

            assemblies = Encoding.ASCII.GetString(response, 0, count - 1).Split(',');
            return state;
        }

        /* :SYST:COMM:NETW:HOST? */
        public int QueryHostName(out string hostname)
        {
            int state = 0, count = 0;
            string command = ":SYSTem:COMMunicate:NETWork:HOSTname?\n";
            byte[] response = new byte[256];
            state = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            state = visa32.viRead(session, response, 256, out count);
            hostname = Encoding.ASCII.GetString(response, 0, count - 1);
            return state;
        }
        #endregion

        #region RF Block
        /* :OUTP:IMP? */
        public int QueryRFOutputImpedance(out int impedanceInOhm)
        {
            int state = 0, count = 0;
            string command = ":OUTPut:IMPedance?\n";
            byte[] response = new byte[64];
            state = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            state = visa32.viRead(session, response, 64, out count);

            string result = Encoding.ASCII.GetString(response, 0, count - 1);
            impedanceInOhm = Convert.ToInt32(result.Substring(1, result.Length - 1));
            return state;
        }

        /* :OUTP:STAT ON */
        public int RFSignalOutputOnOff(State on_off)
        {
            int state = 0, count = 0;
            string command = ":OUTPut:STATe " + on_off + "\n", response;
            state = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* :OUTP:STAT? */
        public int QueryRFSignalOutputState(out State state)
        {
            int error = 0, count = 0;
            string command = ":OUTPut:STATe?\n";
            byte[] response = new byte[256];
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, response, 256, out count);

            string result = Encoding.ASCII.GetString(response, 0, count - 1);
            if (result == "1")
            {
                state = State.ON;
            }
            else if (result == "0")
            {
                state = State.OFF;
            }
            else
            {
                state = State.UNDEFINED;
            }
            return error;
        }
        #endregion
    }
}
