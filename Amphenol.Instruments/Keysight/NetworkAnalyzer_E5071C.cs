using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Amphenol.Instruments.Keysight
{
    public class NetworkAnalyzer_E5071C
    {
        private int resourceMgr;
        private int analyzerSession;

        public NetworkAnalyzer_E5071C()
        {
            resourceMgr = 0;
            analyzerSession = 0;
        }

        public int Open(string visaAddress)
        {
            int viError;

            viError = visa32.viOpenDefaultRM(out resourceMgr);
            if (viError != visa32.VI_SUCCESS)
            {
                return viError;
            }
            viError = visa32.viOpen(resourceMgr, visaAddress, visa32.VI_NO_LOCK, visa32.VI_TMO_IMMEDIATE, out analyzerSession);
            if (viError != visa32.VI_SUCCESS)
            {
                return viError;
            }
            StringBuilder attr = new StringBuilder();
            viError = visa32.viGetAttribute(analyzerSession, visa32.VI_ATTR_RSRC_CLASS, attr);
            viError = visa32.viSetAttribute(analyzerSession, visa32.VI_ATTR_TERMCHAR_EN, visa32.VI_TRUE);
            viError = visa32.viSetAttribute(analyzerSession, visa32.VI_ATTR_TMO_VALUE, 20000);
            return viError;
        }

        public int Close()
        {
            int viError = visa32.viClose(analyzerSession);
            analyzerSession = 0;

            viError = visa32.viClose(resourceMgr);
            resourceMgr = 0;
            return viError;
        }

        /* *IDN? */
        public int GetInstrumentIdentifier(out string idn)
        {
            int viError;
            int count = 0;
            string command = "*IDN?\n";
            byte[] response = new byte[256];

            viError = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            if (viError != visa32.VI_SUCCESS)
            {
                idn = string.Empty;
                return viError;
            }
            viError = visa32.viRead(analyzerSession, response, 256, out count);
            if (viError != visa32.VI_SUCCESS)
            {
                idn = string.Empty;
                return viError;
            }

            idn = Encoding.ASCII.GetString(response, 0, count);
            return viError;
        }

        /* :SYST:PRES */
        public int Preset()
        {
            int errorno;
            string command = ":SYSTem:PRESet\n";
            byte[] response = new byte[128];
            int count = 0;

            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            if (errorno != visa32.VI_SUCCESS)
            {
                return errorno;
            }

            command = "SYSTem:ERRor?\n";
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            errorno = visa32.viRead(analyzerSession, response, 128, out count);
            if (errorno != visa32.VI_SUCCESS)
            {
                return errorno;
            }

            string[] array = new string[2];
            array = Encoding.ASCII.GetString(response, 0, count).Split(',');
            errorno = Convert.ToInt32(array[0]);
            return errorno;
        }

        /* :DISP:SPL D1 */
        public int SelectChannelDisplayMode(string windowLayout = "D1")
        {
            int errorno;
            int count = 0;
            string command = ":DISPlay:SPLit " + windowLayout + "\n";

            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            if (errorno != visa32.VI_SUCCESS)
            {
                return errorno;
            }

            command = "SYSTem:ERRor?\n";
            byte[] response = new byte[128];
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            errorno = visa32.viRead(analyzerSession, response, 128, out count);
            if (errorno != visa32.VI_SUCCESS)
            {
                return errorno;
            }

            string[] array = new string[2];
            array = Encoding.ASCII.GetString(response, 0, count).Split(',');
            errorno = Convert.ToInt32(array[0]);
            return errorno;
        }

        /* :DISP:WIND1:SPL D12 */
        public int SelectTraceDisplayMode(int windowNum = 1, string graphLayout = "D1")
        {
            int errorno, count;
            string command = ":DISPlay:WINDow" + windowNum + ":SPLit " + graphLayout + "\n";

            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            if (errorno != visa32.VI_SUCCESS)
            {
                return errorno;
            }

            string response;
            errorno = QueryErrorStatus(out response);
            return errorno;
        }

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

        /* SYST:ERR? */
        public int QueryErrorStatus(out string errorMesg)
        {
            int errorno, count;
            string command = "SYSTem:ERRor?\n";
            byte[] response = new byte[256];

            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            errorno = visa32.viRead(analyzerSession, response, 256, out count);
            if (errorno != visa32.VI_SUCCESS)
            {
                errorMesg = "VISA library error : " + errorno;
                return errorno;
            }

            string[] messages = new string[2];
            messages = Encoding.ASCII.GetString(response, 0, count).Split(',');
            errorno = Convert.ToInt32(messages[0]);
            errorMesg = messages[1];
            return errorno;
        }

        /* :DISP:WIND2:ACT */
        public int ActivateChannelAt(int channelNum)
        {
            int errorno, count;
            string command = ":DISPlay:WINDow" + channelNum + ":ACTivate\n";

            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            if (errorno != visa32.VI_SUCCESS)
            {
                return errorno;
            }
            string response;
            return QueryErrorStatus(out response);
        }

        /* :DISP:MAX ON */
        public int MaximizeOnOffActiveChannel(string on_off)
        {
            int errorno, count;
            string command;
            if (on_off.ToUpper() == "ON")
            {
                command = ":DISPlay:MAXimize ON\n";
            }
            else if (on_off.ToUpper() == "OFF")
            {
                command = ":DISPlay::MAXimize OFF\n";
            }
            else
            {
                return (-1);    /* command error */
            }
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            if (errorno != visa32.VI_SUCCESS)
            {
                return errorno;
            }
            string response;
            return QueryErrorStatus(out response);
        }

        /* :DISP:WIND1:MAX ON */
        public int MaximizeOnOffActiveTraceForChannel(int channelNum, string on_off)
        {
            int errorno, count;
            string command = ":DISPlay:WINDow" + channelNum + ":MAXimize " + on_off.ToUpper() + "\n";
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            if (errorno != visa32.VI_SUCCESS)
            {
                return errorno;
            }
            string response;
            return QueryErrorStatus(out response);
        }

        /* :DISPlay:TABLe ON */
        public int ShowHideEditTableWindow(string on_off)
        {
            int error = 0, count = 0;
            string command = ":DISPlay:TABLe " + on_off.ToUpper() + "\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            if (error != visa32.VI_SUCCESS)
                return error;
            string response;
            return QueryErrorStatus(out response);
        }

        /* :DISP:TABL:TYPE MARKer */
        public int SelectTableType(string type = "MARKer")
        {
            /* For the table type, you can select from : MARKer     - marker table winddow
             *                                           LIMit      - limit test table window
             *                                           SEGMent    - segment table window
             *                                           ECHO       - echo window
             *                                           PLOSs      - loss compensation table window
             *                                           SCFactor   - power sensor's calibration factor table window
             *                                           RLIMit     - ripple test table window
             */
            int error = 0, count = 0;
            string command = ":DISPlay:TABLe:TYPE " + type.ToUpper() + "\n", response;
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :DISP:TABL:TYPE? */
        public int QueryTableType(out string type)
        {
            int error = 0, count = 0;
            string command = ":DISPlay:TABLe:TYPE?\n";
            byte[] response = new byte[256];
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(analyzerSession, response, 256, out count);
            type = Encoding.ASCII.GetString(response, 0, count);
            return error;
        }

        /* :DISP:SKEY ON */
        public int ShowHideSoftkeyLabels(string on_off)
        {
            int error = 0, count = 0;
            string command = ":DISPlay:SKEY:STATe " + on_off.ToUpper() + "\n", response;
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :CALC1:PAR3:SEL */
        public int ActivateTraceAt(int channelNum, int traceNum)
        {
            int errorno, count;
            string command = ":CALCulate" + channelNum + ":PARameter" + traceNum + ":SELect\n";

            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            if (errorno != visa32.VI_SUCCESS)
            {
                return errorno;
            }
            string response;
            return QueryErrorStatus(out response);
        }

        /* :CALC2:PAR3:DEF S12 */
        public int SelectMeasurementParameterFor(int channelNum, int traceNum, string measurementParameter = "S11")
        {
            int errorno, count;
            string command = ":CALCulate" + channelNum + ":PARameter" + traceNum + ":DEFine " + measurementParameter + "\n";

            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            if (errorno != visa32.VI_SUCCESS)
            {
                return errorno;
            }
            string response;
            return QueryErrorStatus(out response);
        }

        /* :CAL2:PAR3:DEF? */
        public int QueryMeasurementParameterFor(int channelNum, int traceNum, out string measurementParameter)
        {
            int errorno, count;
            string command = ":CALCulate" + channelNum + ":PARameter" + traceNum + ":DEFine?\n";
            byte[] response = new byte[256];

            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            errorno = visa32.viRead(analyzerSession, response, 256, out count);
            measurementParameter = Encoding.ASCII.GetString(response, 0 , count);
            return errorno;
        }

        /* :CALC1:FORM SLOG */
        public int SelectDataFormatForActiveTraceOfChannel(int channelNum, int traceNum, string dataFormat)
        {
            int errorno, count;
            string command = ":DISP:WIND" + channelNum + ":ACT\n";
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALC" + channelNum + ":PAR" + traceNum + ":SEL\n";
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALCulate" + channelNum + ":FORMat " + dataFormat + "\n";
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            string response;
            return QueryErrorStatus(out response);
        }

        /* :CAL1:FORM? */
        public int QueryDataFormatForActiveTraceOfChannel(int channelNum, int traceNum, out string dataFormat)
        {
            int errorno, count;
            string command = ":DISP:WIND" + channelNum + ":ACT\n";
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALC" + channelNum + ":PAR" + traceNum + ":SEL\n";
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALCulate" + channelNum + ":FORMat?\n";
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            byte[] response = new byte[256];
            errorno = visa32.viRead(analyzerSession, response, 256, out count);
            dataFormat = Encoding.ASCII.GetString(response, 0, count);
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

        /* OUTP:STAT ON */
        public int TurnOnOffStimulusSignalOutput(int status /* 1: ON,  0: OFF*/)
        {
            int errorno, count;
            string command;
            if (status == 1)
            {
                command = ":OUTPut:STATe ON\n";
            }
            else if (status == 0)
            {
                command = ":OUTPut:STATe OFF\n";
            }
            else
            {
                command = "";
            }

            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            if (errorno != visa32.VI_SUCCESS)
            {
                return errorno;
            }
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

        /* :SENS1:SWE:POIN 201 */
        public int SetSweepMeasurementPoints(int channelNum = 1, int pointNum = 201)
        {
            int errorno, count;
            string command = ":SENSe" + channelNum + ":SWEep:POINts " + pointNum + "\n";
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            string response;
            return QueryErrorStatus(out response);
        }

        /* :SENS1:SWE:POIN? */
        public int QueryNumberOfMeasurementPointsForChannel(int channelNum, out int pointNum)
        {
            int error, count;
            string command = ":SENSe" + channelNum + ":SWEep:POINts?\n";
            byte[] response = new byte[256];
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(analyzerSession, response, 256, out count);
            pointNum = Convert.ToInt32(Encoding.ASCII.GetString(response, 0, count));
            return error;
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

        public int ExecuteCommand(string command)
        {
            int errorno, count;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command + "\n"), command.Length, out count);
            string response;
            return QueryErrorStatus(out response);
        }

        public int QueryCommand(string command, out string response)
        {
            int errorno, count;
            byte[] result = new byte[256];
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command + "\n"), command.Length, out count);
            errorno = visa32.viRead(analyzerSession, result, 256, out count);
            response = Encoding.ASCII.GetString(result, 0, count);
            return errorno;
        }

        /* :MMEM:LOAD:SEGM "Segm01.csv" */
        public int ConfigureSegmentSweepSettings(string segmentSweepTableCsvFile)
        {
            int errorno, count;
            string command = "MMEMory:LOAD:SEGMent \"" + segmentSweepTableCsvFile + "\"\n", response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :DISP:WIND1:Y:DIV 12 */
        public int SetTraceDivisionNumberForChannel(int channelNum = 1, int divisionNumber = 10)
        {
            int errorno, count;
            string command = ":DISPlay:WINDow" + channelNum + ":Y:SCALe:DIV " + divisionNumber + "\n", response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :DISP:WIND1:TRAC1:Y:PDIV 2.5 */
        public int SetScalePerDivisionForChannelTrace(int channelNum = 1, int traceNum = 1, string scaleValue = "0.2")
        {
            int errorno, count;
            string command = ":DISPlay:WINDow" + channelNum + ":TRACe" + traceNum + ":Y:SCALe:PDIVision " + scaleValue + "\n", response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }        

        /* :DISP:WIND1:TRAC1:Y:RPOS 6 */
        public int SetReferenceGraticuleLineNumber(int channelNum = 1, int traceNum = 1, int gradticuleLineNumber = 5)
        {
            int errorno, count;
            string command = ":DISPlay:WINDow" + channelNum + ":TRACe" + traceNum + ":Y:SCALe:RPOSition " + gradticuleLineNumber + "\n", response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :DISP:WIND1:TRAC1:Y:RLEV 1E2 */
        public int SetReferenceGraticuleLineLevel(int channelNum = 1, int traceNum = 1, string referenceGraticuleLineValue = "1E2")
        {
            int errorno, count;
            string command = ":DISPlay:WINDow" + channelNum + ":TRACe" + traceNum + ":Y:SCALe:RLEVel " + referenceGraticuleLineValue + "\n", response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :DISP:WIND1:TRAC1:Y:AUTO */
        public int AutoScaleTraceDisplay(int channelNum = 1, int traceNum = 1)
        {
            int errorno, count;
            string command = ":DISPlay:WINDow" + channelNum + ":TRACe" + traceNum + ":Y:SCALe:AUTO\n", response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :MMEM:STOR "state01.sta" */
        public int SaveInstrumentStateIntoFile(string instrumentStateFileName = "State01.sta")
        {
            int errorno, count;
            string command = ":MMEMory:STORe:STATe \"" + instrumentStateFileName + "\"\n", response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :MMEM:LOAD "State01.sta" */
        public int RecallSpecifiedInstrumentStateFile(string instrumentStateFileName)
        {
            int errorno, count;
            string command = ":MMEMory:LOAD \"" + instrumentStateFileName + "\"\n", response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :TRIG:SOUR BUS */
        public int SelectTriggerSource(string triggerSource /* 4 types : INTernal, EXTernal, MANual, BUS */ )
        {
            int errorno, count;
            string command = ":TRIGger:SOURce " + triggerSource + "\n", response;
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
            string command = ":INITiate" + channelNum + ":CONTinuous " + on_off  + "\n", response;
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

        /* *CLS */
        public int ClearInstrument()
        {
            int errorno, count;
            string command = "*CLS\n",     /* Clean up all of the instrument, including the entire error queue */
                   response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);      /* Make sure all errors had been cleaned up. */
        }

        /* *OPC? */
        public int QueryEventsCompletionStatus(out int status)
        {
            int errorno, count;
            string command = "*OPC?\n";
            byte[] response = new byte[256];
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            errorno = visa32.viRead(analyzerSession, response, 256, out count);
            status = Convert.ToInt32(Encoding.ASCII.GetString(response, 0, count));
            return errorno;
        }

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

        /* :CALC1:MARK2 ON */
        public int ShowHideGeneralMarkerForActiveTrace(int channelNum, int traceNum, int markerNo, string on_off = "OFF")
        {
            int errorno, count;
            string command = ":CALC" + channelNum + ":PAR" + traceNum + ":SEL\n", response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALCulate" + channelNum + ":SELected:MARKer" + markerNo + ":STATe " + on_off.ToUpper() + "\n";
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :CALC1:MARK2? */
        public int QueryGeneralMarkerDisplayStateForActiveTrace(int channelNum, int traceNum, int markerNo, out string on_off)
        {
            int errorno, count;
            string command = ":CALC" + channelNum + ":PAR" + traceNum + ":SEL\n";
            byte[] response = new byte[256];
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALCulate" + channelNum + ":SELected:MARKer" + markerNo + ":STATe?\n";
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            errorno = visa32.viRead(analyzerSession, response, 256, out count);
            if (1 == Convert.ToInt32(Encoding.ASCII.GetString(response, 0, count)))
            {
                on_off = "ON";
            }
            else if (0 == Convert.ToInt32(Encoding.ASCII.GetString(response, 0, count)))
            {
                on_off = "OFF";
            }
            else
            {
                on_off = "";
            }
            return errorno;
        }

        /* :CALC1:MARK:REF ON */
        public int ShowHideReferenceMarkerForActiveTrace(int channelNum, int traceNum, string on_off = "OFF")
        {
            int errorno, count;
            string command = ":CALC" + channelNum + ":PAR" + traceNum + ":SEL\n", response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALCulate" + channelNum + ":SELected:MARKer:REFerence:STATe " + on_off.ToUpper() + "\n";
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :CALC1:MARK:REF? */
        public int QueryReferenceMarkerDisplayStateForActiveTrace(int channelNum, int traceNum, out string on_off)
        {
            int errorno, count;
            string command = ":CALC" + channelNum + ":PAR" + traceNum + ":SEL\n";
            byte[] response = new byte[256];
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALCulate" + channelNum + ":SELected:MARKer:REFerence:STATe?\n";
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            errorno = visa32.viRead(analyzerSession, response, 256, out count);
            if (1 == Convert.ToInt32(Encoding.ASCII.GetString(response, 0, count)))
            {
                on_off = "ON";
            }
            else if (0 == Convert.ToInt32(Encoding.ASCII.GetString(response, 0, count)))
            {
                on_off = "OFF";
            }
            else
            {
                on_off = "";
            }
            return errorno;
        }

        /* :CALC1:MARK1:X 1E9 */
        public int SetStimulusFrequencyValueAtMarker(int channelNum, int traceNum, int markerNo, string frequencyValue = "1E9" /* Freq. unit : Hz */)
        {
            int errorno, count;
            string command = ":CALC" + channelNum + ":PAR" + traceNum + ":SEL\n", response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALCulate" + channelNum + ":SELected:MARKer" + markerNo + ":X " + frequencyValue + "\n";
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :CALC1:MARK1:X? */
        public int RetrieveFrequencyValueAtGeneralMarker(int channelNum, int traceNum, int markerNo, out double frequencyValue /* unit : Hz */)
        {
            int errorno, count;
            string command = ":CALC" + channelNum + ":PAR" + traceNum + ":SEL\n";
            byte[] response = new byte[256];
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALCulate" + channelNum + ":SELected:MARKer" + markerNo + ":X?\n";
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            errorno = visa32.viRead(analyzerSession, response, 256, out count);
            frequencyValue = Convert.ToDouble(Encoding.ASCII.GetString(response, 0, count));
            return errorno;
        }

        /* CALC1:MARK2:Y? */
        public int RetrieveMeasurementResultAtGeneralMarker(int channelNum, int traceNum, int markerNo, out double attenuationAmplitude /* unit : dB */)
        {
            int errorno, count;
            string command = ":CALC" + channelNum + ":PAR" + traceNum + ":SEL\n";
            byte[] response = new byte[256];
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALCulate" + channelNum + ":SELected:MARKer" + markerNo + ":Y?\n";
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            errorno = visa32.viRead(analyzerSession, response, 256, out count);

            string[] resultArray = new string[2];
            resultArray = Encoding.ASCII.GetString(response, 0, count).Split(',');
            attenuationAmplitude = Convert.ToDouble(resultArray[0]);
            return errorno;
        }

        /* CALC1:MARK:FUNC:DOM ON */
        public int SetMarkerSearchArbitraryRange(int channelNum, string on_off = "OFF")
        {
            int errorno, count;
            string command = ":CALCulate" + channelNum + ":SELected:MARKer:FUNCtion:DOMain:STATe " + on_off + "\n", response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :CALC1:MARK:FUNC:DOM:STAR 1.7E9
         * :CALC1:MARK:FUNC:DOM:STOP 1.8E9 
         */
        public int SetMarkerSearchRangeStartStopValues(int channelNum, string startValue = "1.0E6", string stopValue = "3.0E9" /* unit : Hz, dBm or second */)
        {
            int errorno, count;
            string command = ":CALCulate" + channelNum + ":SELected:MARKer:FUNCtion:DOMain:STARt " + startValue + "\n", response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALCulate" + channelNum + ":SELected:MARKer:FUNCtion:DOMain:STOP " + stopValue + "\n";
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :CALC1:MARK:FUNC:DOM:COUP ON */
        public int SpecifyMarkerSearchRangeWithTraceCoupling(int channelNum, string traceCouplingOnOff = "ON")
        {
            int errorno, count;
            string command = ":CALCulate" + channelNum + ":SELected:MARKer:FUNCtion:DOMain:COUPle " + traceCouplingOnOff.ToUpper() + "\n", response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :CALC1:MARK1:FUNC:TYPE PEAK */
        public int SelectMarkerSearchType(int channelNum, 
                                          int traceNum, 
                                          int markerNo, 
                                          string searchType = "MAXimum" 
                                          /* 8 types : MAXimum, MINimum, PEAK, LPEak, RPEak, TARGet, LTARget, RTARget */)
        {
            int errorno, count;
            string command = ":CALC" + channelNum + ":PAR" + traceNum + ":SEL\n", response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALCulate" + channelNum + ":SELected:MARKer" + markerNo + ":FUNCtion:TYPE " + searchType.ToUpper() + "\n";
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :CALC1:MARK1:FUNC:PEXC 0.2 */
        public int SetLowerLimitForPeakExcursionSearchAtMarker(int channelNum, int traceNum, int markerNo, string peakExcursionValue = "3.0")
        {
            int errorno, count;
            string command = ":CALC" + channelNum + ":PAR" + traceNum + ":SEL\n", response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALCulate" + channelNum + ":SELected:MARKer" + markerNo + ":FUNCtion:PEXCursion " + peakExcursionValue + "\n";
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :CALC1:MARK1:FUNC:PPOL NEG */
        public int SetPeakSearchPolarityAtMarker(int channelNum, int traceNum, int markerNo, string polarity = "POSitive")
        {
            int errorno, count;
            string command = ":DISP:WIND" + channelNum + ":ACT\n", response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALC" + channelNum + ":PAR" + traceNum + ":SEL\n";
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALCulate" + channelNum + ":SELected:MARKer" + markerNo + ":FUNCtion:PPOLarity " + polarity + "\n";
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :CALC1:MARK1:FUNC:TARG -12.5
         * :CALC1:MARK1:FUNC:TTR  NEG
         */
        public int SetMarkerTargetSearch(int channelNum, int traceNum, int markerNo, string targetValue, string transitionalDirection)
        {
            int errorno, count;
            string command = ":CALC" + channelNum + ":PAR" + traceNum + ":SEL\n", response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALCulate" + channelNum + ":SELected:MARKer" + markerNo + ":FUNCtion:TARGet " + targetValue + "\n";
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALCulate" + channelNum + ":SELected:MARKer" + markerNo + ":FUNCtion:TTRansition " + transitionalDirection + "\n";
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :CALC1:FUNC:EXEC */
        public int PerformMarkerSearch(int channelNum = 1)
        {
            int errorno, count;
            string command = ":CALCulate" + channelNum + ":SELected:FUNCtion:EXECute\n", response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :CALC1:FUNC:DATA? 
         * :CALC1:FUNC:POIN?
         */
        public int RetrieveSearchResults(int channelNum, out int pointNum, out double[] results)
        {
            int errorno, count;
            string command = ":CALCulate" + channelNum + ":FUNCtion:POINts?\n";
            byte[] response = new byte[256];
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            errorno = visa32.viRead(analyzerSession, response, 256, out count);
            pointNum = Convert.ToInt32(Encoding.ASCII.GetString(response, 0, count));

            command = ":CALCulate" + channelNum + ":FUNCtion:DATA?\n";
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            errorno = visa32.viRead(analyzerSession, response, 256, out count);

            results = new double[pointNum + 1];
            string[] array = new string[pointNum + 1];
            array = Encoding.ASCII.GetString(response, 0, count).Split(',');

            for (int index = 0; index < (pointNum+1); index++)
            {
                results[index] = Convert.ToDouble(array[index]);
            }
            return errorno;
        }
    }
}
                                    