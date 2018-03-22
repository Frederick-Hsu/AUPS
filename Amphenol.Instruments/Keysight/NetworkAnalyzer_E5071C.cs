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
    }
}
