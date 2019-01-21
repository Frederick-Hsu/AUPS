using System;
using System.Text;

namespace Amphenol.Instruments.Keysight
{
    partial class NetworkAnalyzer_E5071C
    {
        #region Makeing a Measurement
        /* :TRIG:SOUR BUS */
        public int SelectTriggerSource(string triggerSource /* 4 types : INTernal, EXTernal, MANual, BUS */ )
        {
            int errorno, count;
            string command = ":TRIGger:SOURce " + triggerSource + "\n", response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :TRIG:SCOP ACT */
        public int SelectActiveChannelToTrigger(string activeChannel = "ALL" /* only 2 kinds : "ALL" or "ACT" */)
        {
            int errorno, count;
            string command = ":TRIGger:SEQuence:SCOPe " + activeChannel + "\n", response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :TRIGger:SEQuence:IMMediate */
        public int TriggerAndExecuteMeasurement()
        {
            int errorno, count;
            string command = ":TRIGger:SEQuence:IMMediate\n", response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :TRIGger:SEQuence:SINGle */
        public int SingleTriggerMeasurement()
        {
            int errorno, count;
            string command = ":TRIGger:SEQuence:SINGle\n", response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* *TRG */
        public int AutomateTriggerToMeasure()
        {
            int error = 0, count = 0;
            string command = ":TRIGger:SOURce BUS\n", response;
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = "*TRG\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :INIT1 */
        public int SwitchToStartupStateForChannel(int channelNum)
        {
            int errorno, count;
            string command = ":INITiate" + channelNum + ":IMMediate\n", response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :INIT1:CONT OFF */
        public int TurnOnOffContinuousInitiationModeForChannel(int channelNum = 1, string on_off = "ON")
        {
            int errorno, count;
            string command = ":INITiate" + channelNum + ":CONTinuous " + on_off + "\n", response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :INITiate1:CONTinuous? */
        public int QueryContinuousInitiationMode(int channelNum, out int mode)
        {
            int error = 0, count = 0;
            string command = ":INITiate" + channelNum + ":CONTinuous?\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            byte[] response = new byte[64];
            error = visa32.viRead(analyzerSession, response, 64, out count);
            mode = Convert.ToInt32(Encoding.ASCII.GetString(response, 0, count - 1));
            return error;
        }

        /* :TRIGger:SEQuence:SCOPe ALL|ACTive */
        public int TriggerOnlySpecifiedChannel(string scope = "ALL"  /* only "ALL" and "ACTive" are allowed */)
        {
            int error = 0, count = 0;
            string command = ":TRIGger:SEQuence:SCOPe " + scope + "\n", response;
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :TRIGger:SEQuence:SCOPe? */
        public int QueryWhichSpecifiedChannelTriggered(out string scope)
        {
            int error = 0, count = 0;
            string command = ":TRIGger:SEQuence:SCOPe?\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            byte[] response = new byte[64];
            error = visa32.viRead(analyzerSession, response, 64, out count);
            scope = Encoding.ASCII.GetString(response, 0, count - 1);
            return error;
        }

        /* *SRE 128 */
        public int SetServiceRequestEnableRegister(byte registerValue = 0x80 /* range : [0x00, 0xFF] */)
        {
            int errorno, count;
            string command = "*SRE " + registerValue + "\n", response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* *ESE 16 */
        public int SetStandardEventStatusEnableRegister(byte registerValue)
        {
            int errorno, count;
            string command = "*ESE " + registerValue + "\n", response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :STAT:OPER:ENAB 16 */
        public int SetOperationStatusEnableRegister(ushort registerValue = 0x0010 /* range : [0x00, 0xFFFF] */ )
        {
            int errorno, count;
            string command = ":STATus:OPERation:ENABle " + registerValue + "\n", response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :STAT:OPE:ENAB? */
        public int QueryOperationRegisterStatus(out ushort registerValue)
        {
            int errorno, count;
            string command = ":STATus:OPERation:ENABle?\n";
            byte[] response = new byte[256];
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            errorno = visa32.viRead(analyzerSession, response, 256, out count);
            registerValue = Convert.ToUInt16(Encoding.ASCII.GetString(response, 0, count));
            return errorno;
        }

        /* :STAT:OPER:PTR 16 */
        public int SetPositiveTransitionFilterOfOperationStatusRegister(ushort positiveTransitionFilterValue = 0x4030 /* range : [0, 0xFFFF] */)
        {
            int errorno, count;
            string command = ":STATus:OPERation:PTRansition " + positiveTransitionFilterValue + "\n", response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* STAT:OPER:PTR? */
        public int QueryPositiveTransitionFilterOperationStatus(out ushort operationStatusValue)
        {
            int errorno, count;
            string command = ":STATus:OPERation:PTRansition?\n";
            byte[] response = new byte[256];
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            errorno = visa32.viRead(analyzerSession, response, 256, out count);
            operationStatusValue = Convert.ToUInt16(Encoding.ASCII.GetString(response, 0, count));
            return errorno;
        }

        /* :STAT:OPER:NTR 16 */
        public int SetNegativeTransitionFilterOfOperationStatusRegister(ushort negativeTransitionFilterValue = 0x0000)
        {
            int errorno, count;
            string command = ":STATus:OPERation:NTRansition " + negativeTransitionFilterValue + "\n", response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :STAT:OPER:NTR? */
        public int QueryNegativeTransitionFilterOperationStatus(out ushort operationStatusValue)
        {
            int errorno, count;
            string command = ":STATus:OPERation:NTRansition?\n";
            byte[] response = new byte[256];
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            errorno = visa32.viRead(analyzerSession, response, 256, out count);
            operationStatusValue = Convert.ToUInt16(Encoding.ASCII.GetString(response, 0, count));
            return errorno;
        }
        #endregion

        #region Point Trigger Function
        /* :TRIG:POIN ON */
        public int TurnOnOffPointTrigger(string on_off = "OFF" /* Only "ON" and "OFF" can be chosen. */)
        {
            int errorno, count;
            string command = ":TRIGger:SEQuence:POINt " + on_off.ToUpper() + "\n", response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :TRIG:EXT:LLAT ON */
        public int ToggleOnOffLowLatencyExternalTrigger(string on_off = "OFF")
        {
            int errorno, count;
            string command = ":TRIGger:SEQuence:EXTernal:LLATency:STATe " + on_off.ToUpper() + "\n", response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :TRIG:EXT:DEL 0.05 */
        public int SetExternalTriggerDelayTime(double delayTime = 0.00 /* range : [0, 1]second, unit : second, resolution : 10us */)
        {
            int errorno, count;
            string command = ":TRIGger:SEQuence:EXTernal:DELay " + delayTime + "\n", response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :TRIG:AVER ON */
        public int ToggleOnOffAveragingTrigger(string on_off = "OFF")
        {
            int errorno, count;
            string command = ":TRIGger:SEQuence:AVERage " + on_off.ToUpper() + "\n", response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }
        #endregion
    }
}