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

        /* TRIG */
        public int TriggerMeasurement()
        {
            int errorno, count;
            string command = ":TRIGger:IMMediate\n", response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :TRIG:SING */
        public int SingleTriggerMeasurement()
        {
            int errorno, count;
            string command = ":TRIGger:SINGle\n", response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
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