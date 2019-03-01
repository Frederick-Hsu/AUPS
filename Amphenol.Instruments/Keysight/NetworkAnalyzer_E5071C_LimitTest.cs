using System;
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
        #endregion
    }
}