using System;
using System.Text;

namespace Amphenol.Instruments.Keysight
{
    partial class SignalAnalyzer_N9020A
    {
        #region Swept SA Measurement, Marker
        public enum MarkerNo
        {
            Marker1 = 1,
            Marker2 = 2,
            Marker3 = 3,
            Marker4 = 4,
            Marker5 = 5,
            Marker6 = 6,
            Marker7 = 7,
            Marker8 = 9,
            Marker9 = 9,
            Marker10 = 10,
            Marker11 = 11,
            Marker12 = 12
        }
        /* :CALC:MARK1:X 2.4GHZ */
        public int SetMarkerXAxisFrequencyValue(MarkerNo markerNo, string frequency /* you can write the freq. like this "2.4GHZ" */)
        {
            int error = 0, count = 0;
            string command = ":CALCulate:" + markerNo + ":X " + frequency.ToUpper() + "\n", response;
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* :CALC:MARK1:X? */
        public int QuerySpecificMarkerXAxisFrequency(MarkerNo markerNo, out double frequency)
        {
            int error = 0, count = 0;
            string command = ":CALCulate:" + markerNo + ":X?\n";
            byte[] response = new byte[64];
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, response, 64, out count);
            frequency = Convert.ToDouble(Encoding.ASCII.GetString(response, 0, count - 1));
            return error;
        }

        /* :CALC:MARK1:Y? */
        public int QueryMarkerYAxisValue(MarkerNo markerNo, out double powerValue)
        {
            int error = 0, count = 0;
            string command = ":CALCulate:" + markerNo + ":Y?\n";
            byte[] response = new byte[64];
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, response, 64, out count);
            powerValue = Convert.ToDouble(Encoding.ASCII.GetString(response, 0, count - 1));
            return error;
        }

        static public string[] MarkerControlMode = { "POSition", "DELTa", "FIXed", "OFF" };
        public int SetMarkerControlMode(MarkerNo markerNo, string controlMode)
        {
            int error = 0, count = 0;
            string command = ":CALCulate:" + markerNo + ":MODE " + controlMode + "\n", response;
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* :CALC:MARK1:LIN:STAT ON */
        public int TurnOnOffCrossLinesAtMarker(MarkerNo markerNo, State on_ff)
        {
            int error = 0, count = 0;
            string command = ":CALCulate:" + markerNo + ":LINes:STATe " + on_ff + "\n", response;
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* :CALC:MARK:TABL:STAT ON */
        public int DisplayOnOffMarkerTable(State on_off)
        {
            int error = 0, cnt = 0;
            string command = ":CALCulate:MARKer:TABLe:STATe " + on_off + "\n", response;
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out cnt);
            return QuerySystemError(out response);
        }

        /* :CALC:MARK:COUP:STAT ON */
        public int TurnOnOffCoupleMarkers(State on_off)
        {
            int error = 0, cnt = 0;
            string command = ":CALCulate:MARKer:COUPle:STATe " + on_off + "\n", response;
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out cnt);
            return QuerySystemError(out response);
        }

        /* :CALC:MARK:AOFF */
        public int TurnOffAllMarkers()
        {
            int error = 0, cnt = 0;
            string command = ":CALCulate:MARKer:AOFF\n", response;
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out cnt);
            return QuerySystemError(out response);
        }
        #endregion Swept SA Measurement Marker

        /*******************************************************************************************/

        #region Swept SA Measurement, Peak Search
        /* :CALC:MARK1:MAX 
         * :CALC:MARK1:Y?
         * :CALC:MARK1:X?
         * SYST:ERR?
         */
        public int SearchMaxPeakPoint(MarkerNo markerNo, out double peakFrequency /* unit : Hz */, out double peakAmplitude /* unit : dBm */)
        {
            int error = 0, cnt = 0;
            string command = ":CALCulate:" + markerNo + ":MAXimum\n";
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out cnt);

            command = ":CALCulate:" + markerNo + ":X?\n";
            byte[] response = new byte[256];
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out cnt);
            error = visa32.viRead(session, response, 256, out cnt);
            peakFrequency = Convert.ToDouble(Encoding.ASCII.GetString(response, 0, cnt - 1));

            command = ":CALCulate:" + markerNo + ":Y?\n";
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out cnt);
            error = visa32.viRead(session, response, 256, out cnt);
            peakAmplitude = Convert.ToDouble(Encoding.ASCII.GetString(response, 0, cnt - 1));

            string errstr;
            return QuerySystemError(out errstr);
        }
        #endregion
    }
}