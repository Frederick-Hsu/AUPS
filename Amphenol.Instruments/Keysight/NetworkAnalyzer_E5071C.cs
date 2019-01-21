using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Amphenol.Instruments.Keysight
{
    public partial class NetworkAnalyzer_E5071C
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
            viError = visa32.viSetAttribute(analyzerSession, visa32.VI_ATTR_TERMCHAR, 0x0A);
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

        #region IEEE488.2 Standard Common Commands
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

            command = "*CLS\n";
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

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

        /* *CLS */
        public int ClearAllErrorQueue()
        {
            int error = 0, count = 0;
            string command = "*CLS\n", response;
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
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
        #endregion

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
    }
}
                                    