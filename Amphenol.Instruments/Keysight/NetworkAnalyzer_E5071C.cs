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
    }
}
