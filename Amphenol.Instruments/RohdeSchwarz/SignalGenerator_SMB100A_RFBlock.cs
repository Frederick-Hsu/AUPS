using System;
using System.Text;

namespace Amphenol.Instruments.RohdeSchwarz
{
    partial class SignalGenerator_SMB100A
    {
        public enum Freq_Step_Mode
        {
            USER = 0,
            DECimal = 1,
            UNDEFINED = -100
        }

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

        /* :SOUR:FREQ 2.4GHz */
        public int SetRFOutputSignalFrequency(string freq /* format as "2.45GHz" */)
        {
            int state = 0, count = 0;
            string command = ":SOURce:FREQuency " + freq.ToUpper() + "\n", response;
            state = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* :SOUR:FREQ? */
        public int RetrieveRFOutputSignalFrequency(out long freqInHz)
        {
            int state = 0, count = 0;
            string command = ":SOURce:FREQuency?\n";
            byte[] response = new byte[256];
            state = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            state = visa32.viRead(session, response, 256, out count);
            freqInHz = Convert.ToInt64(Encoding.ASCII.GetString(response, 0, count - 1));
            return state;
        }

        /* :SOUR:FREQ:OFFS 500Hz 
         * 
         * Sets the frequency offset of a downstream instrument, for example a mixer
         * If you have specified an OFFSet and/or MULTiplier factor, the actual frequency at the 
         * RF output does not change, but rather the value queried with [:SOUR:FREQ?] according to this
         * formula :
         * 
         * f_FREQ = f_RFout * f_MULTiplier + f_OFFSet
         */
        public int SetFrequencyOffsetForDownstreamInstrument(string offset /* format as "500KHZ" */)
        {
            int state = 0, count = 0;
            string command = ":SOURce:FREQuency:OFFSet " + offset.ToUpper() + "\n", response;
            state = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* :SOUR:FREQ:OFFS? */
        public int RetrieveFrequencyOffset(out long offsetInHz)
        {
            int state = 0, count = 0;
            string command = ":SOURce:FREQuency:OFFSet?\n";
            byte[] response = new byte[256];
            state = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            state = visa32.viRead(session, response, 256, out count);
            offsetInHz = Convert.ToInt64(Encoding.ASCII.GetString(response, 0, count - 1));
            return state;
        }

        /* :SOUR:FREQ:STEP MODE USER
         * FREQ:STEP 50KHz
         */
        public int SetFrequencyVariationModeAndStepWidth(Freq_Step_Mode mode, string userDefinedStepWidth /* format as "50KHz" */)
        {
            int state = 0, count = 0;
            string command = ":SOURce:FREQuency:STEP:MODE ";
            if (mode == Freq_Step_Mode.USER)
            {
                command += "USER\n";
            }
            else
            {
                command += "DECimal\n";
            }
            state = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":FREQ:STEP " + userDefinedStepWidth.ToUpper() + "\n";
            state = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            string response;
            return QuerySystemError(out response);
        }

        /* :SOUR:FREQ:STEP:MODE?
         * :FREQ:STEP?
         */
        public int QueryFrequencyVariationModeAndStepWidth(out Freq_Step_Mode mode, out long stepWidth)
        {
            int state = 0, count = 0;
            string command = ":SOURce:FREQuency:STEP:MODE?\n";
            byte[] response = new byte[256];
            state = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            state = visa32.viRead(session, response, 256, out count);
            string variationActive = Encoding.ASCII.GetString(response, 0, count - 1);
            if (variationActive == "USER")
            {
                mode = Freq_Step_Mode.USER;
            }
            else if (variationActive == "DEC")
            {
                mode = Freq_Step_Mode.DECimal;
            }
            else
            {
                mode = Freq_Step_Mode.UNDEFINED;
            }

            command = ":FREQuency:MODE?\n";
            state = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            state = visa32.viRead(session, response, 256, out count);
            stepWidth = Convert.ToInt64(Encoding.ASCII.GetString(response, 0, count - 1));
            return state;
        }
        #endregion
    }
}