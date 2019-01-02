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

        #region RF Block, Frequency
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

        /* :SOUR:FREQ:STEP:MODE USER
         * :SOUR:FREQ:STEP:INCR 50KHz
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

            command = ":SOURce:FREQuency:STEP:INCRement " + userDefinedStepWidth.ToUpper() + "\n";
            state = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            string response;
            return QuerySystemError(out response);
        }

        /* :SOUR:FREQ:STEP:MODE?
         * :SOUR:FREQ:STEP:INCR?
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

            command = ":SOURce:FREQuency:STEP:INCRement?\n";
            state = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            state = visa32.viRead(session, response, 256, out count);
            stepWidth = Convert.ToInt64(Encoding.ASCII.GetString(response, 0, count - 1));
            return state;
        }

        /* :SOURCE:PHASE 120 DEG */
        public int SetPhaseVariationRelativeToCurrentPhase(double phaseVariation /* range : [-720, 720]deg */)
        {
            int state = 0, count = 0;
            string command = ":SOURce:PHAse " + phaseVariation + " DEG\n", response;
            state = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* :SOURCE:PHASE:REF */
        public int ResetDeltaPhaseDisplay()
        {
            int state = 0, count = 0;
            string command = ":SOURce:PHAse:REFerence\n", response;
            state = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* :SOURCE:RSOCillator:SOURce INTernal */
        public int SelectReferenceFrequencySource(string source /* only 2 options can be chosen: INTernal, EXTernal */)
        {
            int state = 0, count = 0;
            string command = ":SOURce:ROSCillator:SOURce " + source + "\n", response;
            state = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* :SOUR:ROSC:EXT:FREQ 10MHZ */
        public int SelectExternalReferenceFrequency(string freq /* format as "5MHz" */)
        {
            int state = 0, count = 0;
            string command = ":SOURce:ROSCillator:SOURce EXTernal\n", response;
            state = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":SOURce:ROSCillator:EXTernal:FREQuency " + freq + "\n";
            state = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* :SOURCE:ROSCillator:EXT:SBANdwith WIDE */
        public int SelectSyncBandwidthForExternalReferenceSignal(string bandwidthType /* only 2 options available: WIDE, NARRow */)
        {
            int state = 0, count = 0;
            string command = ":SOURce:ROSCillator:EXTernal:SBANdwidth " + bandwidthType + "\n", response;
            state = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* :SOURce:ROSCillator:INTernal:ADJust:STATe ON 
         * :SOURce:ROSCillator:INTernal:ADJust:VALUE 500
         */
        public int EnableAdjustmentModeAndSpecifyFreqCorrectionValue(State adjustmentMode, int freqCorrectionValue)
        {
            int state = 0, count = 0;
            string command = ":SOURce:ROSCillator:INTernal:ADJust:STATe " + adjustmentMode + "\n", response;
            state = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);

            if (adjustmentMode == State.OFF)
            {
                return QuerySystemError(out response);
            }
            else    /* Corresponding to ADJUST:STATE ON scenario */
            {
                command = ":SOURce:ROSCillator:INTernal:ADJust:VALue " + freqCorrectionValue + "\n";
                state = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
                return QuerySystemError(out response);
            }
        }
        #endregion

        #region RF Block, Level
        /* :SOUR:POW:LEV:IMM:AMPL -10 */
        public int SetRFLevelAppliedOntoDUT(double level /* unit : dBm */)
        {
            int state = 0, count = 0;
            string command = ":SOURce:POWer:LEVel:IMMediate:AMPLitude " + level + "\n", response;
            state = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* :SOUR:POW:LEV:IMM:AMPL? */
        public int RetrieveRFLevelAppliedOntoDUT(out double level)
        {
            int state = 0, count = 0;
            string command = ":SOURce:POWer:LEVel:IMMediate:AMPLitude?\n";
            byte[] response = new byte[64];
            state = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            state = visa32.viRead(session, response, 64, out count);
            level = Convert.ToDouble(Encoding.ASCII.GetString(response, 0, count - 1));
            return state;
        }

        public enum RFLevelMode
        {
            NORMal = 0,
            LOWNoise = 1,
            LOWDistortion = 2
        }
        /* :SOUR:POW:LMOD NORMal */
        public int SetRFLevelMode(RFLevelMode mode)
        {
            int state = 0, count = 0;
            string command = ":SOURce:POWer:LMODe ", response;
            if (mode == RFLevelMode.NORMal)
            {
                command += "NORMal\n";
            }
            else if (mode == RFLevelMode.LOWNoise)
            {
                command += "LOWNoise\n";
            }
            else
            {
                command += "LOWDistortion\n";
            }
            state = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* :SOUR:POW:LEV:IMM:OFFS -10 */
        public int SpecifyLevelOffsetForDownstreamAttenuatorAmplifier(double levelOffset /* range = [-100, 100]dB */)
        {
            int state = 0, count = 0;
            string command = ":SOURce:POWer:LEVel:IMMediate:OFFSet " + levelOffset + "\n", response;
            state = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* :SOUR:POW:LEV:IMM:OFFS? */
        public int QueryLevelOffsetForDownstreamAttenuatorAmplifier(out double levelOffset /* unit : dB */)
        {
            int state = 0, count = 0;
            string command = ":SOURce:POWer:LEVel:IMMediate:OFFSet?\n";
            byte[] response = new byte[256];
            state = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            state = visa32.viRead(session, response, 256, out count);
            levelOffset = Convert.ToDouble(Encoding.ASCII.GetString(response, 0, count - 1));
            return state;
        }
        
        /* :SOUR:POW:LIM:AMPL 30 */
        public int LimitMaxRFOutputLevel(double upperLimit /* unit : dBm */)
        {
            int state = 0, count = 0;
            string command = ":SOURce:POWer:LIMit:AMPLitude " + upperLimit + "\n", response;
            state = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* :OUTP:AMODe AUTO */
        public int SelectAttenuatorModeAtRFOutput(string attenuatorMode = "AUTO" /* only 2 options available : "AUTO" and "FIXed" */)
        {
            int state = 0, count = 0;
            string command = ":OUTPut:AMODe " + attenuatorMode.ToUpper() + "\n", response;
            state = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* :OUTP:AFIX:RANG:UPPER?
         * :OUTP:AFIX:RANG:LOWER?
         */
        public int QueryLevelRangeInFixedAttenuatorMode(out double lower, out double upper /* unit : dBm */)
        {
            int state = 0, count = 0;
            string command = ":OUTPut:AMODe FIXed\n";
            state = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":OUTPut:AFIXed:RANGe:LOWer?\n";
            byte[] response = new byte[256];
            state = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            state = visa32.viRead(session, response, 256, out count);
            lower = Convert.ToDouble(Encoding.ASCII.GetString(response, 0, count - 1));

            command = ":OUTPut:AFIXed:RANGe:UPPer?\n";
            state = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            state = visa32.viRead(session, response, 256, out count);
            upper = Convert.ToDouble(Encoding.ASCII.GetString(response, 0, count - 1));
            return state;
        }

        /* :SOUR:PWE:ALC:STAT AUTO */
        public int ActivateAutomaticLevelControl(string state = "AUTO" /* only 3 options available : "AUTO", "ON", "OFF" */)
        {
            int error = 0, count = 0;
            string command = ":SOURce:POWer:ALC:STATe " + state + "\n", response;
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* :SOUR:POW:ALC:STAT? */
        public int QueryAutomaticLevelControlState(out string state)
        {
            int error = 0, count = 0;
            string command = ":SOURce:POWer:ALC:STATe?\n";
            byte[] response = new byte[256];
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, response, 256, out count);
            string result = Encoding.ASCII.GetString(response, 0, count - 1);
            if (result.ToUpper() == "AUTO")
            {
                state = "AUTO";
            }
            else if (result == "1")
            {
                state = "ON";
            }
            else
            {
                state = "OFF";
            }
            return error;
        }
        #endregion

        #region Power sensor : NRP-Z22
        /* :SENS:POW:TYPE? */
        public int QueryPowerSensorType(out string type)
        {
            int state = 0, count = 0;
            string command = ":SENS:POW:TYPE?\n";
            byte[] response = new byte[256];
            state = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            state = visa32.viRead(session, response, 256, out count);
            type = Encoding.ASCII.GetString(response, 0, count - 1);
            return state;
        }

        /* :SENS:POW:STATus:DEV? */
        public int QueryPowerSensorConnectionStatus(out string status)
        {
            int error = 0, count = 0;
            string command = ":SENSe:POWer:STATus:DEVice?\n";
            byte[] response = new byte[256];
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, response, 256, out count);
            status = Encoding.ASCII.GetString(response, 0, count - 1);
            return error;
        }

        /* SENS:POW:SNUM? */
        public int QueryConnectedPowerSensorSerialNumber(out string serialNumber)
        {
            int state = 0, count = 0;
            string command = ":SENSe:POWer:SNUMer?\n";
            byte[] response = new byte[256];
            state = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            state = visa32.viRead(session, response, 256, out count);
            serialNumber = Encoding.ASCII.GetString(response, 0, count - 1);
            return state;
        }

        /* :INIT:POW:CONT ON */
        public int SwitchOnOffLocalStateOfContinuousPowerMeasurement(State state)
        {
            int error = 0, count = 0;
            string command = ":INITiate:POWer:CONTinuous " + state + "\n", response;
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* :INIT:POW:CONT? */
        public int QueryLocalStateOfContinuousPowerMeasurement(out string state)
        {
            int error = 0, count = 0;
            string command = ":INITiate:POWer:CONTinuous?\n";
            byte[] response = new byte[256];
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, response, 256, out count);
            state = Encoding.ASCII.GetString(response, 0, count - 1);
            return error;
        }

        /* SENS:UNIT:POW DNM */
        public int SelectUnitForPowerSensorMeasurement(string unit /* only 3 options available : dBm, dBuV, Watt */)
        {
            int state = 0, count = 0;
            string command = ":SENSe:UNIT:POWer " + unit.ToUpper() + "\n", response;
            state = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* :READ:POW? */
        public int RetrievePowerSensorMeasurementValues(out double peakLevel, out double averageLevel)
        {
            int error = 0, count = 0;
            string command = ":READ:POWer?\n";
            byte[] response = new byte[256];
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, response, 256, out count);

            string[] values = Encoding.ASCII.GetString(response, 0, count - 1).Split(',');
            averageLevel = Convert.ToDouble(values[0]);
            peakLevel = Convert.ToDouble(values[1]);
            return error;
        }

        /* :SENS:POW:DISP:PERM:STAT ON */
        public int ActivatePermanentIndicationForPowerSensorMeasurement(State state)
        {
            int error = 0, count = 0;
            string command = ":SENSe:POWer:DISPlay:PERManent:STATe " + state + "\n", response;
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* :SENS:POW:DISP:PERM:PRI AVER */
        public int SelectPowerSensorMeasurementDisplayPriority(string priority /* only 2 priorities available : PEAK, AVERage */)
        {
            int error = 0, count = 0;
            string command = ":SENSe:POWer:DISPlay:PERManent:PRIority " + priority.ToUpper() + "\n", response;
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }
        #endregion
    }
}