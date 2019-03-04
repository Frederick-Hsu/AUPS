using System;
using System.Collections.Generic;
using System.Text;

namespace Amphenol.Instruments.Keysight
{
    partial class NetworkAnalyzer_E5071C
    {
        #region Performing a Limit Test
        /* :CALCulate1:SELected:LIMit:DISPlay:STATe ON */
        public int TurnOnOffLimitLineDisplay(uint channelNum, string onOff = "OFF")
        {
            int error = 0, count = 0;
            string command = ":CALCulate" + channelNum + ":SELected:LIMit:DISPlay:STATe " + onOff + "\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            string response;
            return QueryErrorStatus(out response);
        }

        /* :CALCulate1:SELected:LIMit:STATe ON */
        public int TurnOnOffLimitTestFunction(uint channelNum, string onOff = "OFF")
        {
            int error = 0, count = 0;
            string command = ":CALCulate" + channelNum + ":SELected:LIMit:STATe " + onOff + "\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            string response;
            return QueryErrorStatus(out response);
        }

        /* :CALCulate1:SELected:LIMit:DATA 2, 1, 1E9, 3E9, 0, 0, 2, 1E9, 3E9, -3, -3 */
        public struct LimitLineSegment
        {
            public uint type;      /* the type of the n-th line. 0 : Off, 1 : Upper limit line, 2 : Lower limit line */
            public string startPointHAxisValue;    /* MUST use scientific notation, e.g. 1.5e9 */
            public string endPointHAxisValue;      /* MUST use scientific notation */
            public string startPointVAxisValue;    /* MUST be numeric format */
            public string endPointVAxisValue;      /* MUST be numeric format */
        }
        public int SetLimitTable(uint channelNum, uint numberOfLineSegments, List<LimitLineSegment> segments)
        {
            int error = 0, count = 0;
            string command = ":CALCulate" + channelNum + ":SELected:LIMit:DATA " + numberOfLineSegments + ", ";
            if ((segments.Count != numberOfLineSegments) || (numberOfLineSegments == 0))
            {
                return (-1);        /* Check the limit line segments number */
            }
            for (int n = 0; n < segments.Count; ++n)
            {
                command += (segments[n].type + ", " + 
                            segments[n].startPointHAxisValue + ", " + 
                            segments[n].endPointHAxisValue + ", " + 
                            segments[n].startPointVAxisValue + ", " + 
                            segments[n].endPointVAxisValue);
                if (n == (segments.Count-1))
                {
                    command += "\n";
                }
                else
                {
                    command += ", ";
                }
            }
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            string response;
            return QueryErrorStatus(out response);
        }

        /* :CALCulate1:SELected:LIMit:DATA 0 */
        public int ClearLimitTable(uint channelNum)
        {
            int error = 0, count = 0;
            string command = ":CALCulate" + channelNum + ":SELected:LIMit:DATA 0\n", response;
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :MMEMory:LOAD:LIMit "D:\Test\Limit_Table.csv" */
        public int ConfigureLimitLineSegmentsCsvFile(string segmentsCsvFilePath /* must contain the .csv extension */)
        {
            /* [NOTICE] the segments .csv file was stored in the hard disk of network analyzer computer,
             *          not stored in the test host computer.
             */
            int error = 0, count = 0;
            string command = ":MMEMory:LOAD:LIMit \"" + segmentsCsvFilePath + "\"\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            string response;
            return QueryErrorStatus(out response);
        }

        /* :MMEMory:STORe:LIMit "D:\Test\Limit_Table.csv" */
        public int StoreLimitLineSegmentsIntoCsvFile(string limitTableCsvFile /* MUST contain the .csv extension */)
        {
            /* [NOTICE] the segments .csv file was stored in the hard disk of network analyzer computer,
             *          not stored in the test host computer.
             */
            int error = 0, count = 0;
            string command = ":MMEMory:STORe:LIMit \"" + limitTableCsvFile + "\"\n", response;
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :DISPlay:FSIGn ON */
        public int TurnOnOffFailIndicatorOnScreen(string onOff = "ON")
        {
            int error = 0, count = 0;
            string command = ":DISPlay:FSIGn " + onOff + "\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return error;
        }
        #endregion
    }
}