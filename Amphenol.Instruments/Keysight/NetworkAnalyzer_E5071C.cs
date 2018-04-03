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
            string command = "*IDN?", response;

            viError = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            if (viError != visa32.VI_SUCCESS)
            {
                idn = string.Empty;
                return viError;
            }
            viError = visa32.viRead(analyzerSession, out response, 256);
            if (viError != visa32.VI_SUCCESS)
            {
                idn = string.Empty;
                return viError;
            }

            idn = response;
            return viError;
        }

        /* :SYST:PRES */
        public int Preset()
        {
            int errorno;
            string command = ":SYSTem:PRESet", response;
            int count = 0;

            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            if (errorno != visa32.VI_SUCCESS)
            {
                return errorno;
            }

            command = "SYSTem:ERRor?";
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            errorno = visa32.viRead(analyzerSession, out response, 128);
            if (errorno != visa32.VI_SUCCESS)
            {
                return errorno;
            }

            string[] array = new string[2];
            array = response.Split(',');
            errorno = Convert.ToInt32(array[0]);
            return errorno;
        }

        /* :DISP:SPL D1 */
        public int SelectChannelDisplayMode(string windowLayout = "D1")
        {
            int errorno;
            int count = 0;
            string command = ":DISPlay:SPLit " + windowLayout;

            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            if (errorno != visa32.VI_SUCCESS)
            {
                return errorno;
            }

            command = "SYSTem:ERRor?";
            string response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            errorno = visa32.viRead(analyzerSession, out response, 128);
            if (errorno != visa32.VI_SUCCESS)
            {
                return errorno;
            }

            string[] array = new string[2];
            array = response.Split(',');
            errorno = Convert.ToInt32(array[0]);
            return errorno;
        }

        /* :DISP:WIND1:SPL D12 */
        public int SelectTraceDisplayMode(int windowNum = 1, string graphLayout = "D1")
        {
            int errorno, count;
            string command = ":DISPlay:WINDow" + windowNum + ":SPLit " + graphLayout;

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
            string command = ":CALCulate" + channelNum + ":PARameter:COUNt " + traceNum;

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
            string command = ":CALCulate" + channelNum + ":PARameter:COUNt?", response;

            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            errorno = visa32.viRead(analyzerSession, out response, 256);
            if (errorno != visa32.VI_SUCCESS)
            {
                traceNum = 0;
                return errorno;
            }
            traceNum = Convert.ToUInt32(response);
            return errorno;
        }

        /* SYST:ERR? */
        public int QueryErrorStatus(out string errorMesg)
        {
            int errorno, count;
            string command = "SYSTem:ERRor?", response;

            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            errorno = visa32.viRead(analyzerSession, out response, 256);
            if (errorno != visa32.VI_SUCCESS)
            {
                errorMesg = "VISA library error : " + errorno;
                return errorno;
            }

            string[] messages = new string[2];
            messages = response.Split(',');
            errorno = Convert.ToInt32(messages[0]);
            errorMesg = messages[1];
            return errorno;
        }

        /* :DISP:WIND2:ACT */
        public int ActivateChannelAt(int channelNum)
        {
            int errorno, count;
            string command = ":DISPlay:WINDow" + channelNum + ":ACTivate";

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
                command = ":DISPlay:MAXimize ON";
            }
            else if (on_off.ToUpper() == "OFF")
            {
                command = ":DISPlay::MAXimize OFF";
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
            string command = ":DISPlay:WINDow" + channelNum + ":MAXimize " + on_off.ToUpper();
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            if (errorno != visa32.VI_SUCCESS)
            {
                return errorno;
            }
            string response;
            return QueryErrorStatus(out response);
        }

        /* :CALC1:PAR3:SEL */
        public int ActivateTraceAt(int channelNum, int traceNum)
        {
            int errorno, count;
            string command = ":CALCulate" + channelNum + ":PARameter" + traceNum + ":SELect";

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
            string command = ":CALCulate" + channelNum + ":PARameter" + traceNum + ":DEFine " + measurementParameter;

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
            string command = ":CALCulate" + channelNum + ":PARameter" + traceNum + ":DEFine?";
            string response;

            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            errorno = visa32.viRead(analyzerSession, out response, 256);
            measurementParameter = response;
            return errorno;
        }

        /* :CALC1:FORM SLOG */
        public int SelectDataFormatForActiveTraceOfChannel(int channelNum, int traceNum, string dataFormat)
        {
            int errorno, count;
            string command = ":DISP:WIND" + channelNum + ":ACT";
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALC" + channelNum + ":PAR" + traceNum + ":SEL";
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALCulate" + channelNum + ":FORMat " + dataFormat;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            string response;
            return QueryErrorStatus(out response);
        }

        /* :CAL1:FORM? */
        public int QueryDataFormatForActiveTraceOfChannel(int channelNum, int traceNum, out string dataFormat)
        {
            int errorno, count;
            string command = ":DISP:WIND" + channelNum + ":ACT";
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALC" + channelNum + ":PAR" + traceNum + ":SEL";
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALCulate" + channelNum + ":FORMat?";
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            string response;
            errorno = visa32.viRead(analyzerSession, out response, 256);
            dataFormat = response;
            return errorno;
        }

        /* :SENS1:SWE:TYPE SEGM */
        public int SetSweepTypeForChannel(int channelNum, string sweepType)
        {
            int errorno, count;
            string command = ":SENSe" + channelNum + ":SWEep:TYPE " + sweepType;

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
            string command = ":SENSe" + channelNum + ":SWEep:TYPE?", response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            errorno = visa32.viRead(analyzerSession, out response, 256);
            sweepType = response;
            return errorno;
        }

        /* OUTP:STAT ON */
        public int TurnOnOffStimulusSignalOutput(int status /* 1: ON,  0: OFF*/)
        {
            int errorno, count;
            string command;
            if (status == 1)
            {
                command = ":OUTPut:STATe ON";
            }
            else if (status == 0)
            {
                command = ":OUTPut:STATe OFF";
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
            string command = ":SENSe" + channelNum + ":FREQ:STARt " + startFreqValue;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            string response;
            return QueryErrorStatus(out response);
        }

        /* :SENS1:FREQ:STOP 8.5E9 */
        public int SetSweepStopFreqValueForChannel(int channelNum = 1, string stopFreqValue = "8.5E9")
        {
            int errorno, count;
            string command = ":SENSe" + channelNum + ":FREQ:STOP " + stopFreqValue;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            string response;
            return QueryErrorStatus(out response);
        }

        /* :SENS1:FREQ:CENT 4.25E9 */
        public int SetSweepCenterFreqValueForChannel(int channelNum = 1, string centerFreqValue = "4.25015E9")
        {
            int errorno, count;
            string command = ":SENSe" + channelNum + ":FREQ:CENTer " + centerFreqValue;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            string response;
            return QueryErrorStatus(out response);
        }

        /* :SENS1:FREQ:SPAN 8.499E9 */
        public int SetSweepSpanFreqValueForChannel(int channelNum = 1, string spanFreqValue = "8.499E9")
        {
            int errorno, count;
            string command = ":SENSe" + channelNum + ":FREQ:SPAN " + spanFreqValue;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            string response;
            return QueryErrorStatus(out response);
        }

        /* :SENS1:SWE:POIN 201 */
        public int SetSweepMeasurementPoints(int channelNum = 1, int pointNum = 201)
        {
            int errorno, count;
            string command = ":SENSe" + channelNum + ":SWEep:POINts " + pointNum;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            string response;
            return QueryErrorStatus(out response);
        }

        /* :SENS1:SWE:TIME 1.5 */
        public int SetSweepTimeForChannel(int channelNum, float time /* unit : second */)
        {
            int errorno, count;
            string command = ":SENSe" + channelNum + ":SWEep:TIME " + time;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            string response;
            return QueryErrorStatus(out response);
        }

        /* :SENS1:SWE:TIME:AUTO ON */
        public int AutoSetSweepTimeForChannel(int channelNum = 1, string autoOnOff = "ON")
        {
            int errorno, count;
            string command = ":SENSe" + channelNum + ":SWEep:TIME:AUTO " + autoOnOff.ToUpper();
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            string response;
            return QueryErrorStatus(out response);
        }

        /* :SENS1:SWE:DEL 0.05 */
        public int SetSweepDelayTimeForChannel(int channelNum = 1, float delayTime = 0 /* unit : second */)
        {
            int errorno, count;
            string command = ":SENSe" + channelNum + ":SWEep:DELay " + delayTime;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            string response;
            return QueryErrorStatus(out response);
        }

        /* :SENS1:BAND 1.5E3 */
        public int SetIFBandwidthForChannel(int channelNum = 1, string bandwidth = "1.0E5" /* unit : Hz */)
        {
            int errorno, count;
            string command = ":SENSe" + channelNum + ":BANDwidth " + bandwidth;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            string response;
            return QueryErrorStatus(out response);
        }

        /* :SOUR1:POW -12.5 */
        public int SetPowerLevelForChannel(int channelNum = 1, double powerLevel = 0 /* unit : dBm */)
        {
            int errorno, count;
            string command = ":SOURce" + channelNum + ":POWer:LEVel " + powerLevel;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            string response;
            return QueryErrorStatus(out response);
        }

        /* :SOUR1:POW:LEV? */
        public int QueryPowerLevelForChannel(int channelNum, out double powerLevel)
        {
            int errorno, count;
            string command = ":SOURce" + channelNum + ":POWer:LEVel?", response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            errorno = visa32.viRead(analyzerSession, out response, 256);
            powerLevel = Convert.ToDouble(response);
            return errorno;
        }

        /* :SOUR1:POW:ATT 15 */
        public int SetPowerRangeForChannel(int channelNum = 1, int attenuatorValue = 0 /* unit : dB */)
        {
            int errorno, count;
            string command = ":SOURce" + channelNum + ":POWer:ATTenuation " + attenuatorValue;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            string response;
            return QueryErrorStatus(out response);
        }

        /* :SOUR1:POW:STAR -10 */
        public int SetPowerSweepRangeStartValueForChannel(int channelNum = 1, double startPowerValue = -15.00 /* unit : dBm */)
        {
            int errorno, count;
            string command = ":SOURce" + channelNum + ":POWer:STARt " + startPowerValue;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            string response;
            return QueryErrorStatus(out response);
        }

        /* :SOUR1:POW:STOP 10 */
        public int SetPowerSweepRangeStopValueForChannel(int channelNum = 1, double stopPowerValue = 0 /* unit : dBm */)
        {
            int errorno, count;
            string command = ":SOURce" + channelNum + ":POWer:STOP " + stopPowerValue;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            string response;
            return QueryErrorStatus(out response);
        }

        /* SOUR1:POW:CENT 0 */
        public int SetPowerSweepCenterValueForChannel(int channelNum, double centerPowerValue = -7.5)
        {
            int errorno, count;
            string command = ":SOURce" + channelNum + ":POWer:CENTer " + centerPowerValue, response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :SOUR1:POW:SPAN 10 */
        public int SetPowerSweepSpanValueForChannel(int channelNum = 1, double spanPowerValue = 15.00)
        {
            int errorno, count;
            string command = ":SOURce" + channelNum + ":POWer:SPAN " + spanPowerValue, response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :SENS1:FREQ 1E9 */
        public int SetPowerSweepFixedFrequenceForChannel(int channelNum = 1, string CWFrequency = "3E5" /* unit : Hz */)
        {
            int errorno, count;
            string command = ":SENSe" + channelNum + ":FREQuency:CW " + CWFrequency, response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* SENS1:AVER:STAT ON */
        public int TurnOnOffAveragingFunctionForChannel(int channelNum = 1, string on_off = "OFF")
        {
            int errorno, count;
            string command = ":SENSe" + channelNum + ":AVERage:STATe " + on_off, response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* SENS1:AVER:COUN 4 */
        public int SetAveragingFactorForChannel(int channelNum = 1, int factorValue = 16)
        {
            int errorno, count;
            string command = ":SENSe" + channelNum + ":AVERage:COUNt " + factorValue, response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :SENS1:AVER:CLE */
        public int ClearAveragingMeasurementDataForChannel(int channelNum = 1)
        {
            int errorno, count;
            string command = ":SENSe" + channelNum + ":AVERage:CLEar", response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        public int ExecuteCommand(string command)
        {
            int errorno, count;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            string response;
            return QueryErrorStatus(out response);
        }

        public int QueryCommand(string command, out string response)
        {
            int errorno, count;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            errorno = visa32.viRead(analyzerSession, out response, 256);
            return errorno;
        }

        /* :MMEM:LOAD:SEGM "Segm01.csv" */
        public int ConfigureSegmentSweepSettings(string segmentSweepTableCsvFile)
        {
            int errorno, count;
            string command = "MMEMory:LOAD:SEGMent \"" + segmentSweepTableCsvFile + "\"", response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :DISP:WIND1:Y:DIV 12 */
        public int SetTraceDivisionNumberForChannel(int channelNum = 1, int divisionNumber = 10)
        {
            int errorno, count;
            string command = ":DISPlay:WINDow" + channelNum + ":Y:SCALe:DIV " + divisionNumber, response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :DISP:WIND1:TRAC1:Y:PDIV 2.5 */
        public int SetScalePerDivisionForChannelTrace(int channelNum = 1, int traceNum = 1, string scaleValue = "0.2")
        {
            int errorno, count;
            string command = ":DISPlay:WINDow" + channelNum + ":TRACe" + traceNum + ":Y:SCALe:PDIVision " + scaleValue, response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }        

        /* :DISP:WIND1:TRAC1:Y:RPOS 6 */
        public int SetReferenceGraticuleLineNumber(int channelNum = 1, int traceNum = 1, int gradticuleLineNumber = 5)
        {
            int errorno, count;
            string command = ":DISPlay:WINDow" + channelNum + ":TRACe" + traceNum + ":Y:SCALe:RPOSition " + gradticuleLineNumber, response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :DISP:WIND1:TRAC1:Y:RLEV 1E2 */
        public int SetReferenceGraticuleLineLevel(int channelNum = 1, int traceNum = 1, string referenceGraticuleLineValue = "1E2")
        {
            int errorno, count;
            string command = ":DISPlay:WINDow" + channelNum + ":TRACe" + traceNum + ":Y:SCALe:RLEVel " + referenceGraticuleLineValue, response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :DISP:WIND1:TRAC1:Y:AUTO */
        public int AutoScaleTraceDisplay(int channelNum = 1, int traceNum = 1)
        {
            int errorno, count;
            string command = ":DISPlay:WINDow" + channelNum + ":TRACe" + traceNum + ":Y:SCALe:AUTO", response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :MMEM:STOR "state01.sta" */
        public int SaveInstrumentStateIntoFile(string instrumentStateFileName = "State01.sta")
        {
            int errorno, count;
            string command = ":MMEMory:STORe:STATe \"" + instrumentStateFileName + "\"", response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :MMEM:LOAD "State01.sta" */
        public int RecallSpecifiedInstrumentStateFile(string instrumentStateFileName)
        {
            int errorno, count;
            string command = ":MMEMory:LOAD \"" + instrumentStateFileName + "\"", response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :TRIG:SOUR BUS */
        public int SelectTriggerSource(string triggerSource /* 4 types : INTernal, EXTernal, MANual, BUS */ )
        {
            int errorno, count;
            string command = ":TRIGger:SOURce " + triggerSource, response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* TRIG */
        public int TriggerMeasurement()
        {
            int errorno, count;
            string command = ":TRIGger:IMMediate", response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :TRIG:SING */
        public int SingleTriggerMeasurement()
        {
            int errorno, count;
            string command = ":TRIGger:SINGle", response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :INIT1 */
        public int SwitchToStartupStateForChannel(int channelNum)
        {
            int errorno, count;
            string command = ":INITiate" + channelNum + ":IMMediate", response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :INIT1:CONT OFF */
        public int TurnOnOffContinuousInitiationModeForChannel(int channelNum = 1, string on_off = "ON")
        {
            int errorno, count;
            string command = ":INITiate" + channelNum + ":CONTinuous " + on_off, response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :TRIG:SCOP ACT */
        public int SelectActiveChannelToTrigger(string activeChannel = "ALL" /* only 2 kinds : "ALL" or "ACT" */)
        {
            int errorno, count;
            string command = ":TRIGger:SEQuence:SCOPe " + activeChannel, response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* *SRE 128 */
        public int SetServiceRequestEnableRegister(byte registerValue = 0x80 /* range : [0x00, 0xFF] */)
        {
            int errorno, count;
            string command = "*SRE " + registerValue, response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :STAT:OPER:ENAB 16 */
        public int SetOperationStatusEnableRegister(ushort registerValue = 0x0010 /* range : [0x00, 0xFFFF] */ )
        {
            int errorno, count;
            string command = ":STATus:OPERation:ENABle " + registerValue, response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :STAT:OPE:ENAB? */
        public int QueryOperationRegisterStatus(out ushort registerValue)
        {
            int errorno, count;
            string command = ":STATus:OPERation:ENABle?", response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            errorno = visa32.viRead(analyzerSession, out response, 256);
            registerValue = Convert.ToUInt16(response);
            return errorno;
        }

        /* :STAT:OPER:PTR 16 */
        public int SetPositiveTransitionFilterOfOperationStatusRegister(ushort positiveTransitionFilterValue = 0x4030 /* range : [0, 0xFFFF] */)
        {
            int errorno, count;
            string command = ":STATus:OPERation:PTRansition " + positiveTransitionFilterValue, response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* STAT:OPER:PTR? */
        public int QueryPositiveTransitionFilterOperationStatus(out ushort operationStatusValue)
        {
            int errorno, count;
            string command = ":STATus:OPERation:PTRansition?", response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            errorno = visa32.viRead(analyzerSession, out response, 256);
            operationStatusValue = Convert.ToUInt16(response);
            return errorno;
        }

        /* :STAT:OPER:NTR 16 */
        public int SetNegativeTransitionFilterOfOperationStatusRegister(ushort negativeTransitionFilterValue = 0x0000)
        {
            int errorno, count;
            string command = ":STATus:OPERation:NTRansition " + negativeTransitionFilterValue, response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :STAT:OPER:NTR? */
        public int QueryNegativeTransitionFilterOperationStatus(out ushort operationStatusValue)
        {
            int errorno, count;
            string command = ":STATus:OPERation:NTRansition?", response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            errorno = visa32.viRead(analyzerSession, out response, 256);
            operationStatusValue = Convert.ToUInt16(response);
            return errorno;
        }

        /* *CLS */
        public int ClearInstrument()
        {
            int errorno, count;
            string command = "*CLS",     /* Clean up all of the instrument, including the entire error queue */
                   response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);      /* Make sure all errors had been cleaned up. */
        }

        /* *OPC? */
        public int QueryEventsCompletionStatus(out int status)
        {
            int errorno, count;
            string command = "*OPC?", response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            errorno = visa32.viRead(analyzerSession, out response, 256);
            status = Convert.ToInt32(response);
            return errorno;
        }

        /* :TRIG:POIN ON */
        public int TurnOnOffPointTrigger(string on_off = "OFF" /* Only "ON" and "OFF" can be chosen. */)
        {
            int errorno, count;
            string command = ":TRIGger:SEQuence:POINt " + on_off.ToUpper(), response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :TRIG:EXT:LLAT ON */
        public int ToggleOnOffLowLatencyExternalTrigger(string on_off = "OFF")
        {
            int errorno, count;
            string command = ":TRIGger:SEQuence:EXTernal:LLATency:STATe " + on_off.ToUpper(), response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :TRIG:EXT:DEL 0.05 */
        public int SetExternalTriggerDelayTime(double delayTime = 0.00 /* range : [0, 1]second, unit : second, resolution : 10us */)
        {
            int errorno, count;
            string command = ":TRIGger:SEQuence:EXTernal:DELay " + delayTime, response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :TRIG:AVER ON */
        public int ToggleOnOffAveragingTrigger(string on_off = "OFF")
        {
            int errorno, count;
            string command = ":TRIGger:SEQuence:AVERage " + on_off.ToUpper(), response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }
    }
}
                                    