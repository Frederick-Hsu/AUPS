using System;
using System.Text;

namespace Amphenol.Instruments.Keysight
{
    partial class NetworkAnalyzer_E5071C
    {
        #region Configuing Measurement Conditions
        /* :CALC1:PAR:COUN 4 */
        public int ConfigTraceNumInChannel(uint channelNum = 1, uint traceNum = 1)
        {
            int errorno, count;
            string command = ":CALCulate" + channelNum + ":PARameter:COUNt " + traceNum + "\n";

            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            if (errorno != visa32.VI_SUCCESS)
                return errorno;

            string response;
            return QueryErrorStatus(out response);
        }

        /* :CALC1:PAR:COUN? */
        public int QueryTraceNumberInChannel(uint channelNum, out uint traceNum)
        {
            int errorno, count;
            string command = ":CALCulate" + channelNum + ":PARameter:COUNt?\n";
            byte[] response = new byte[256];

            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            errorno = visa32.viRead(analyzerSession, response, 256, out count);
            if (errorno != visa32.VI_SUCCESS)
            {
                traceNum = 0;
                return errorno;
            }
            traceNum = Convert.ToUInt32(Encoding.ASCII.GetString(response, 0, count));
            return errorno;
        }

        /* :CALC2:PAR3:DEF S12 */
        public int SelectMeasurementSParameterFor(int channelNum, int traceNum, string measurementSParameter = "S11")
        {
            int errorno, count;
            string command = ":CALCulate" + channelNum + ":PARameter" + traceNum + ":DEFine " + measurementSParameter + "\n";

            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            if (errorno != visa32.VI_SUCCESS)
            {
                return errorno;
            }
            string response;
            return QueryErrorStatus(out response);
        }

        /* :CAL2:PAR3:DEF? */
        public int QueryMeasurementSParameterFor(int channelNum, int traceNum, out string measurementParameter)
        {
            int errorno, count;
            string command = ":CALCulate" + channelNum + ":PARameter" + traceNum + ":DEFine?\n";
            byte[] response = new byte[256];

            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            errorno = visa32.viRead(analyzerSession, response, 256, out count);
            measurementParameter = Encoding.ASCII.GetString(response, 0, count);
            return errorno;
        }

        /* :SENS1:SWE:TYPE SEGM */
        public int SetSweepTypeForChannel(int channelNum, string sweepType)
        {
            int errorno, count;
            string command = ":SENSe" + channelNum + ":SWEep:TYPE " + sweepType + "\n";

            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            if (errorno != visa32.VI_SUCCESS)
            {
                return errorno;
            }
            string response;
            return QueryErrorStatus(out response);
        }

        /* SENS2:SWE:TYPE? */
        public int QuerySweepTypeForChannel(int channelNum, out string sweepType)
        {
            int errorno, count;
            string command = ":SENSe" + channelNum + ":SWEep:TYPE?\n";
            byte[] response = new byte[256];
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            errorno = visa32.viRead(analyzerSession, response, 256, out count);
            sweepType = Encoding.ASCII.GetString(response, 0, count);
            return errorno;
        }

        /* :SOUR1:POW -12.5 */
        public int SetPowerLevelForChannel(int channelNum = 1, double powerLevel = 0 /* unit : dBm */)
        {
            int errorno, count;
            string command = ":SOURce" + channelNum + ":POWer:LEVel " + powerLevel + "\n";
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            string response;
            return QueryErrorStatus(out response);
        }

        /* :SOUR1:POW:LEV? */
        public int QueryPowerLevelForChannel(int channelNum, out double powerLevel)
        {
            int errorno, count;
            string command = ":SOURce" + channelNum + ":POWer:LEVel?\n";
            byte[] response = new byte[256];
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            errorno = visa32.viRead(analyzerSession, response, 256, out count);
            powerLevel = Convert.ToDouble(Encoding.ASCII.GetString(response, 0, count));
            return errorno;
        }

        /* :SOUR1:POW:ATT 15 */
        public int SetPowerRangeForChannel(int channelNum = 1, int attenuatorValue = 0 /* unit : dB */)
        {
            int errorno, count;
            string command = ":SOURce" + channelNum + ":POWer:ATTenuation " + attenuatorValue + "\n";
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            string response;
            return QueryErrorStatus(out response);
        }

        /* :SENS1:SWE:TIME 1.5 */
        public int SetSweepTimeForChannel(int channelNum, float time /* unit : second */)
        {
            int errorno, count;
            string command = ":SENSe" + channelNum + ":SWEep:TIME " + time + "\n";
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            string response;
            return QueryErrorStatus(out response);
        }

        /* :SENS1:SWE:TIME:AUTO ON */
        public int AutoSetSweepTimeForChannel(int channelNum = 1, string autoOnOff = "ON")
        {
            int errorno, count;
            string command = ":SENSe" + channelNum + ":SWEep:TIME:AUTO " + autoOnOff.ToUpper() + "\n";
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            string response;
            return QueryErrorStatus(out response);
        }

        /* :SENS1:SWE:DEL 0.05 */
        public int SetSweepDelayTimeForChannel(int channelNum = 1, float delayTime = 0 /* unit : second */)
        {
            int errorno, count;
            string command = ":SENSe" + channelNum + ":SWEep:DELay " + delayTime + "\n";
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            string response;
            return QueryErrorStatus(out response);
        }

        /* :SENS1:BAND 1.5E3 */
        public int SetIFBandwidthForChannel(int channelNum = 1, string bandwidth = "1.0E5" /* unit : Hz */)
        {
            int errorno, count;
            string command = ":SENSe" + channelNum + ":BANDwidth " + bandwidth + "\n";
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            string response;
            return QueryErrorStatus(out response);
        }

        /* :SENS1:FREQ:START 50E6 */
        public int SetSweepStartFreqValueForChannel(int channelNum = 1, string startFreqValue = "3E5" /* Support formats : 345356.05 or 356E3,  unit : Hz */)
        {
            int errorno, count;
            string command = ":SENSe" + channelNum + ":FREQ:STARt " + startFreqValue + "\n";
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            string response;
            return QueryErrorStatus(out response);
        }

        /* :SENS1:FREQ:STOP 8.5E9 */
        public int SetSweepStopFreqValueForChannel(int channelNum = 1, string stopFreqValue = "8.5E9")
        {
            int errorno, count;
            string command = ":SENSe" + channelNum + ":FREQ:STOP " + stopFreqValue + "\n";
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            string response;
            return QueryErrorStatus(out response);
        }

        /* :SENS1:FREQ:CENT 4.25E9 */
        public int SetSweepCenterFreqValueForChannel(int channelNum = 1, string centerFreqValue = "4.25015E9")
        {
            int errorno, count;
            string command = ":SENSe" + channelNum + ":FREQ:CENTer " + centerFreqValue + "\n";
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            string response;
            return QueryErrorStatus(out response);
        }

        /* :SENS1:FREQ:SPAN 8.499E9 */
        public int SetSweepSpanFreqValueForChannel(int channelNum = 1, string spanFreqValue = "8.499E9")
        {
            int errorno, count;
            string command = ":SENSe" + channelNum + ":FREQ:SPAN " + spanFreqValue + "\n";
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            string response;
            return QueryErrorStatus(out response);
        }

        /* :SOUR1:POW:STAR -10 */
        public int SetPowerSweepRangeStartValueForChannel(int channelNum = 1, double startPowerValue = -15.00 /* unit : dBm */)
        {
            int errorno, count;
            string command = ":SOURce" + channelNum + ":POWer:STARt " + startPowerValue + "\n";
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            string response;
            return QueryErrorStatus(out response);
        }

        /* :SOUR1:POW:STOP 10 */
        public int SetPowerSweepRangeStopValueForChannel(int channelNum = 1, double stopPowerValue = 0 /* unit : dBm */)
        {
            int errorno, count;
            string command = ":SOURce" + channelNum + ":POWer:STOP " + stopPowerValue + "\n";
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            string response;
            return QueryErrorStatus(out response);
        }

        /* SOUR1:POW:CENT 0 */
        public int SetPowerSweepCenterValueForChannel(int channelNum, double centerPowerValue = -7.5)
        {
            int errorno, count;
            string command = ":SOURce" + channelNum + ":POWer:CENTer " + centerPowerValue + "\n", response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :SOUR1:POW:SPAN 10 */
        public int SetPowerSweepSpanValueForChannel(int channelNum = 1, double spanPowerValue = 15.00)
        {
            int errorno, count;
            string command = ":SOURce" + channelNum + ":POWer:SPAN " + spanPowerValue + "\n", response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :SENS1:FREQ 1E9 */
        public int SetPowerSweepFixedFrequenceForChannel(int channelNum = 1, string CWFrequency = "3E5" /* unit : Hz */)
        {
            int errorno, count;
            string command = ":SENSe" + channelNum + ":FREQuency:CW " + CWFrequency + "\n", response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* SENS1:AVER:STAT ON */
        public int TurnOnOffAveragingFunctionForChannel(int channelNum = 1, string on_off = "OFF")
        {
            int errorno, count;
            string command = ":SENSe" + channelNum + ":AVERage:STATe " + on_off + "\n", response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* SENS1:AVER:COUN 4 */
        public int SetAveragingFactorForChannel(int channelNum = 1, int factorValue = 16)
        {
            int errorno, count;
            string command = ":SENSe" + channelNum + ":AVERage:COUNt " + factorValue + "\n", response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :SENS1:AVER:CLE */
        public int ClearAveragingMeasurementDataForChannel(int channelNum = 1)
        {
            int errorno, count;
            string command = ":SENSe" + channelNum + ":AVERage:CLEar\n", response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }
        #endregion
    }
}