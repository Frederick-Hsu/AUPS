using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Amphenol.Instruments.Keysight
{
    partial class NetworkAnalyzer_E5071C
    {
        #region Marker search
        /* :CALCulate1:SELected:MARKer2:STATe ON */
        public int MarkerSearchShowHideRegularMarkerForActiveTrace(int channelNo, int traceNo, int markerNo, string on_off = "OFF")
        {
            int error = 0, count = 0;
            string command = ":CALC" + channelNo + ":PAR" + traceNo + ":SEL\n", response;
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALCulate" + channelNo + ":SELected:MARKer" + markerNo + ":STATe " + on_off + "\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :CALCulate1:SELected:MARKer3:ACTivate */
        public int MarkerSearchActivateRegularMarkerNo(int channelNo, int traceNo, int markerNo)
        {
            int error = 0, count = 0;
            string command = ":CALC" + channelNo + ":PAR" + traceNo + ":SEL\n", response;
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALCulate" + channelNo + ":SELected:MARKer" + markerNo + ":ACTivate\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :CALCulate1:SELected:MARKer3:STATe? */
        public int MarkerSearchQueryMarkerDisplayState(int channelNo, int traceNo, int markerNo, out string onOffState)
        {
            int error = 0, count = 0;
            string command = ":CALC" + channelNo + ":PAR" + traceNo + ":SEL\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALCulate" + channelNo + ":SELected:MARKer" + markerNo + ":STATe?\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            byte[] response = new byte[256];
            error = visa32.viRead(analyzerSession, response, 256, out count);
            int state = Convert.ToInt32(Encoding.ASCII.GetString(response, 0, count));
            if (1 == state)
            {
                onOffState = "ON";
            }
            else
            {
                onOffState = "OFF";
            }
            return error;
        }

        /* :CALCulate1:SELected:MARKer:REFerence:STATe ON */
        public int MarkerSearchShowOnOffReferenceMarkerMode(int channelNo, int traceNo, string onOffState = "OFF")
        {
            int error = 0, count = 0;
            string command = ":CALC" + channelNo + ":PAR" + traceNo + ":SEL\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALCulate" + channelNo + ":SELected:MARKer:REFerence:STATe " + onOffState + "\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            string response;
            return QueryErrorStatus(out response);
        }

        /* :CALCulate3:SELected:MARKer:REFerence:STATe? */
        public int MarkerSearchQueryReferenceMarkerDisplayState(int channelNo, int traceNo, out string onOffState)
        {
            int error = 0, count = 0;
            string command = ":CALC" + channelNo + ":PAR" + traceNo + ":SEL\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALCulate" + channelNo + ":SELected:MARKer:REFerence:STATe?\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            byte[] response = new byte[256];
            error = visa32.viRead(analyzerSession, response, 256, out count);
            int state = Convert.ToInt32(Encoding.ASCII.GetString(response, 0, count));
            if (state == 1)
            {
                onOffState = "ON";
            }
            else
            {
                onOffState = "OFF";
            }
            return error;
        }

        /* :CALCulate3:SELected:MARKer:FUNCtion:DOMain:STATe ON */
        public int MarkerSearchSetSearchRange(int channelNo, string onOffState = "OFF")
        {
            int error = 0, count = 0;
            string command = ":CALCulate" + channelNo + ":SELected:MARKer:FUNCtion:DOMain:STATe " + onOffState + "\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            string response;
            return QueryErrorStatus(out response);
        }

        /* :CALCulate3:SELected:MARKer:FUNCtion:DOMain:STARt 1.7E9
         * :CALCulate3:SELected:MARKer:FUNCtion:DOMain:STOP  1.9E9
         */
        public int MarkerSearchSetSearchRangeStartStopValues(int channelNo, string startValue, string stopValue /* unit : Hz, dBm or second */)
        {
            int error = 0, count = 0;
            string command = ":CALCulate" + channelNo + ":SELected:MARKer:FUNCtion:DOMain:STARt " + startValue + "\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALCulate" + channelNo + ":SELected:MARKer:FUNCtion:DOMain:STOP " + stopValue + "\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            string response;
            return QueryErrorStatus(out response);
        }

        /* :CALCulate3:SELected:MARKer:FUNCtion:DOMain:STARt?
         * :CALCulate3:SELected:MARKer:FUNCtion:DOMain:STOP?
         */
        public int MarkerSearchQuerySearchRangeStartStopValues(int channelNo, out double startValue, out double stopValue)
        {
            int error = 0, count = 0;
            string command = ":CALCulate" + channelNo + ":SELected:MARKer:FUNCtion:DOMain:STARt?\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            byte[] response = new byte[256];
            error = visa32.viRead(analyzerSession, response, 256, out count);
            startValue = Convert.ToDouble(Encoding.ASCII.GetString(response, 0, count));

            command = ":CALCulate" + channelNo + ":SELected:MARKer:FUNCtion:DOMain:STOP?\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(analyzerSession, response, 256, out count);
            stopValue = Convert.ToDouble(Encoding.ASCII.GetString(response, 0, count));
            return error;
        }

        /* :CALCulate3:SELected:MARKer:FUNCtion:DOMain:COUPle ON */
        public int MarkerSearchSpecifySearchRangeTraceCoupling(int channelNo, string couplingOnOff = "ON")
        {
            int error = 0, count = 0;
            string command = ":CALCulate" + channelNo + ":SELected:MARKer:FUNCtion:DOMain:COUPle " + couplingOnOff + "\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            string response;
            return QueryErrorStatus(out response);
        }

        /* :CALCulate3:SELected:MARKer:FUNCtion:DOMain:COUPle? */
        public int MarkerSearchQuerySearchRangeTraceCouplingState(int channelNo, out string couplingOnOff)
        {
            int error = 0, count = 0;
            string command = ":CALCulate" + channelNo + ":SELected:MARKer:FUNCtion:DOMain:COUPle?\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            byte[] response = new byte[256];
            error = visa32.viRead(analyzerSession, response, 256, out count);
            int state = Convert.ToInt32(Encoding.ASCII.GetString(response, 0, count));
            if (state == 1)
            {
                couplingOnOff = "ON";
            }
            else
            {
                couplingOnOff = "OFF";
            }
            return error;
        }

        /* :CALC1:MARK1:FUNC:TYPE PEAK */
        public int MarkerSearchSelectSearchType(int channelNo,
                                                int traceNo,
                                                int markerNo,
                                                string searchType = "MAXimum"
                                                /* 8 types : MAXimum, MINimum, PEAK, LPEak, RPEak, TARGet, LTARget, RTARget */)
        {
            int errorno, count;
            string command = ":CALC" + channelNo + ":PAR" + traceNo + ":SEL\n", response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALCulate" + channelNo + ":SELected:MARKer" + markerNo + ":FUNCtion:TYPE " + searchType.ToUpper() + "\n";
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :CALCulate5:SELected:MARKer2:FUNCtion:PEXCursion 0.2 
         * :CALCulate5:SELected:MARKer2:FUNCtion:PPOLarity BOTH
         */
        public int MarkerSearchDefinePeak(int channelNo, int traceNo, int markerNo, 
                                          string peakExcursionValue,  /* range : 0 to 5E8, you can use both decimal or scientific notation */
                                          string peakPolarity /* range : POSitive, NEGative, BOTH */)
        {
            int error = 0, count = 0;
            string command = ":CALC" + channelNo + ":PAR" + traceNo + ":SEL\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALCulate" + channelNo + ":SELected:MARKer" + markerNo + ":FUNCtion:PEXCursion " + peakExcursionValue + "\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALCulate" + channelNo + ":SELected:MARKer" + markerNo + ":FUNCtion:PPOLarity " + peakPolarity + "\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            string response;
            return QueryErrorStatus(out response);
        }

        /* :CALCulate1:SELected:MARKer3:FUNCtion:TARGet -12.5
         * :CALCulate1:SELected:MARKer3:FUNCtion:TTRansition POSitive
         */
        public int MarkerSearchDefineTarget(int channelNo, int traceNo, int markerNo, 
                                            string targetValue,     /* range : -5E8 to 5E8, use decimal or scientific notation */
                                            string transitionType   /* range : POSitive, NEGative, BOTH */)
        {
            int error = 0, count = 0;
            string command = ":CALC" + channelNo + ":PAR" + traceNo + ":SEL\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALCulate" + channelNo + ":SELected:MARKer" + markerNo + ":FUNCtion:TARGet " + targetValue + "\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALCulate" + channelNo + ":SELected:MARKer" + markerNo + ":FUNCtion:TTRansition " + transitionType + "\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            string response;
            return QueryErrorStatus(out response);
        }

        /* :CALCulate3:SELected:MARKer5:FUNCtion:EXECute */
        public int MarkerSearchPerformSearchWithMarker(int channelNo, int traceNo, int markerNo)
        {
            int error = 0, count = 0;
            string command = ":CALC" + channelNo + ":PAR" + traceNo + ":SEL\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALCulate" + channelNo + ":SELected:MARKer" + markerNo + ":FUNCtion:EXECute\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            string response;
            return QueryErrorStatus(out response);
        }

        /* :CALCulate3:SELected:MARKer5:FUNCtion:TRACking ON */
        public int MarkerSearchTurnOnOffSearchTrackingFeature(int channelNo, int traceNo, int markerNo, string onOffState = "OFF")
        {
            int error = 0, count = 0;
            string command = ":CALC" + channelNo + ":PAR" + traceNo + ":SEL\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALCulate" + channelNo + ":SELected:MARKer" + markerNo + ":FUNCtion:TRACking " + onOffState + "\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            string response;
            return QueryErrorStatus(out response);
        }

        /* :CALCulate3:SELected:MARKer5:X 1.2E9 */
        public int MarkerSearchSetStimulusValueAtMarkerPosition(int channelNo, int traceNo, int markerNo, 
                                                                string stimulusValue 
                                                                /* unit : Hz, dBm or second, can use decimal or scientific notation */)
        {
            int error = 0, count = 0;
            string command = ":CALC" + channelNo + ":PAR" + traceNo + ":SEL\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALCulate" + channelNo + ":SELected:MARKer" + markerNo + ":X " + stimulusValue + "\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            string response;
            return QueryErrorStatus(out response);
        }

        /* :CALCulate3:SELected:MARKer5:X? */
        public int MarkerSearchRetrieveStimulusValueAtMarkerPosition(int channelNo, int traceNo, int markerNo, out double stimulusValue)
        {
            int error = 0, count = 0;
            string command = ":CALC" + channelNo + ":PAR" + traceNo + ":SEL\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALCulate" + channelNo + ":SELected:MARKer" + markerNo + ":X?\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            byte[] response = new byte[256];
            error = visa32.viRead(analyzerSession, response, 256, out count);
            stimulusValue = Convert.ToDouble(Encoding.ASCII.GetString(response, 0, count));
            return error;
        }

        /* :CALCulate3:SELected:MARKer5:Y? */
        public int MarkerSearchRetrieveResponseValueAtMarkerPosition(int channelNo, int traceNo, int markerNo, out List<double> responseValues)
        {
            int error = 0, count = 0;
            string command = ":CALC" + channelNo + ":PAR" + traceNo + ":SEL\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALCulate" + channelNo + ":SELected:MARKer" + markerNo + ":Y?\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            byte[] result = new byte[256];
            error = visa32.viRead(analyzerSession, result, 256, out count);

            string[] resultArray = Encoding.ASCII.GetString(result, 0, count).Split(new char[] { ',', ' ', '\n' });
            responseValues = new List<double>();
            foreach (string res in resultArray)
            {
                responseValues.Add(Convert.ToDouble(res));
            }
            return error;
        }
        #endregion

        #region Using analysis commands to perform search and analysis
        /* :CALCulate3:SELected:FUNCtion:DOMain:STATe ON */
        public int AnalysisSearchTurnOnOffRangeState(int channelNo, string onOffState = "OFF")
        {
            int error = 0, count = 0;
            string command = ":CALCulate" + channelNo + ":SELected:FUNCtion:DOMain:STATe " + onOffState + "\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            string response;
            return QueryErrorStatus(out response);
        }

        /* :CALCulate3:SELected:FUNCtion:DOMain:STATe? */
        public int AnalysisSearchQueryRangeState(int channelNo, out string onOffState)
        {
            int error = 0, count = 0;
            string command = ":CALCulate" + channelNo + ":SELected:FUNCtion:DOMain:STATe?\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            byte[] response = new byte[256];
            error = visa32.viRead(analyzerSession, response, 256, out count);
            int state = Convert.ToInt32(Encoding.ASCII.GetString(response, 0, count));
            if (state == 1)
            {
                onOffState = "ON";
            }
            else
            {
                onOffState = "OFF";
            }
            return error;
        }

        /* :CALCulate3:SELected:FUNCtion:DOMain:STARt 1.7E9
         * :CALCulate3:SELected:FUNCtion:DOMain:STOP  1.8E9
         */
        public int AnalysisSearchSetRangeStartStopValues(int channelNo, string startValue, string stopValue)
        {
            int error = 0, count = 0;
            string command = ":CALCulate" + channelNo + ":SELected:FUNCtion:DOMain:STARt " + startValue + "\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALCulate" + channelNo + ":SELected:FUNCtion:DOMain:STOP " + stopValue + "\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            string response;
            return QueryErrorStatus(out response);
        }

        /* :CALCulate3:SELected:FUNCtion:DOMain:STARt?
         * :CALCulate3:SELected:FUNCtion:DOMain:STOP?
         */
        public int AnalysisSearchQueryRangeStartStopValues(int channelNo, out double startValue, out double stopValue)
        {
            int error = 0, count = 0;
            string command = ":CALCulate" + channelNo + ":SELected:FUNCtion:DOMain:STARt?\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            byte[] result = new byte[256];
            error = visa32.viRead(analyzerSession, result, 256, out count);
            startValue = Convert.ToDouble(Encoding.ASCII.GetString(result, 0, count));

            command = ":CALCulate" + channelNo + ":SELected:FUNCtion:DOMain:STOP?\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(analyzerSession, result, 256, out count);
            stopValue = Convert.ToDouble(Encoding.ASCII.GetString(result, 0, count));
            return error;
        }

        /* :CALCulate3:SELected:FUNCtion:DOMain:COUPle ON */
        public int AnalysisSearchSpecifySearchRangeTraceCoupling(int channelNo, string couplingOnOff = "ON")
        {
            int error = 0, count = 0;
            string command = ":CALCulate" + channelNo + ":SELected:FUNCtion:DOMain:COUPle " + couplingOnOff + "\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            string response;
            return QueryErrorStatus(out response);
        }

        /* :CALCulate4:SELected:FUNCtion:DOMain:COUPle? */
        public int AnalysisSearchQuerySearchRangeTraceCouplingState(int channelNo, out string couplingStateOnOff)
        {
            int error = 0, count = 0;
            string command = ":CALCulate" + channelNo + ":SELected:FUNCtion:DOMain:COUPle?\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            byte[] response = new byte[256];
            error = visa32.viRead(analyzerSession, response, 256, out count);
            int state = Convert.ToInt32(Encoding.ASCII.GetString(response, 0, count));
            if (state == 1)
            {
                couplingStateOnOff = "ON";
            }
            else
            {
                couplingStateOnOff = "OFF";
            }
            return error;
        }

        /* :CALCulate3:SELected:FUNCtion:TYPE PEAK */
        public int AnalysisSearchSelectSearchType(int channelNo, int traceNo, string searchType = "PTPeak")
        {
            int error = 0, count = 0;
            string command = ":CALC" + channelNo + ":PAR" + traceNo + ":SEL\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALCulate" + channelNo + ":SELected:FUNCtion:TYPE " + searchType.ToUpper() + "\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            string response;
            return QueryErrorStatus(out response);
        }

        /* :CALCulate3:SELected:FUNCtion:TYPE? */
        public int AnalysisSearchQuerySearchType(int channelNo, int traceNo, out string searchType)
        {
            int error = 0, count = 0;
            string command = ":CALC" + channelNo + ":PAR" + traceNo + ":SEL\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALCulate" + channelNo + ":SELected:FUNCtion:TYPE?\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            byte[] response = new byte[256];
            error = visa32.viRead(analyzerSession, response, 256, out count);
            searchType = Encoding.ASCII.GetString(response, 0, count);
            return error;
        }

        /* :CALCulate3:SELected:FUNCtion:PEXCursion 0.2
         * :CALCulate3:SELected:FUNCtion:PPOLarity BOTH
         */
        public int AnalysisSearchDefinePeak(int channelNo, int traceNo,
                                            string peakExcursionValue,  /* range : 0 to 5e8, use double or scientific notation */
                                            string peakPolarity)        /* selected from 3 values : POSitive, NEGative, BOTH */
        {
            int error = 0, count = 0;
            string command = ":CALC" + channelNo + ":PAR" + traceNo + ":SEL\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALCulate" + channelNo + ":SELected:FUNCtion:PEXCursion " + peakExcursionValue + "\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALCulate" + channelNo + ":SELected:FUNCtion:PPOLarity " + peakPolarity.ToUpper() + "\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            string response;
            return QueryErrorStatus(out response);
        }

        /* :CALCulate3:SELected:FUNCtion:TARGet -12.5
         * :CALCulate3:SELected:FUNCtion:TTRansition BOTH
         */
        public int AnalysisSearchDefineTarget(int channelNo, int traceNo, string targetValue, string transitionType)
        {
            int error = 0, count = 0;
            string command = ":CALC" + channelNo + ":PAR" + traceNo + ":SEL\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALCulate" + channelNo + ":SELected:FUNCtion:TARGet " + targetValue + "\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALCulate" + channelNo + ":SELected:FUNCtion:TTRansition " + transitionType.ToUpper() + "\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            string response;
            return QueryErrorStatus(out response);
        }

        /* :CALCulate3:SELected:FUNCtion:EXECute */
        public int AnalysisSearchPerformSearch(int channelNo, int traceNo)
        {
            int error = 0, count = 0;
            string command = ":CALC" + channelNo + ":PAR" + traceNo + ":SEL\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALCulate" + channelNo + ":SELected:FUNCtion:EXECute\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            string response;
            return QueryErrorStatus(out response);
        }

        public struct AnalysisSearch_MeasuredResults
        {
            double response_value;
            double stimulus_value;
            public AnalysisSearch_MeasuredResults(double response, double stimulus)
            {
                response_value = response;
                stimulus_value = stimulus;
            }
            public double Response_Value
            {
                get { return response_value; }
                set { response_value = value; }
            }
            public double Stimulus_Value
            {
                get { return stimulus_value; }
                set { stimulus_value = value; }
            }
        }
        /* :CALCulate3:SELected:FUNCtion:DATA? 
         * :CALCulate3:SELected:FUNCtion:POINts?
         */
        public int AnalysisSearchRetrieveSearchResults(int channelNo, int traceNo, 
                                                       out List<AnalysisSearch_MeasuredResults> results, 
                                                       out int measuredPointsAmount)
        {
            int error = 0, count = 0;
            string command = ":CALC" + channelNo + ":PAR" + traceNo + ":SEL\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALCulate" + channelNo + ":SELected:FUNCtion:POINts?\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            byte[] points = new byte[256];
            error = visa32.viRead(analyzerSession, points, 256, out count);
            measuredPointsAmount = Convert.ToInt32(Encoding.ASCII.GetString(points, 0, count));

            command = ":CALCulate" + channelNo + ":SELected:FUNCtion:DATA?\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            byte[] data = new byte[100 * 0x0400];       // 100KByte
            error = visa32.viRead(analyzerSession, data, 100 * 0x0400, out count);
            string[] array = Encoding.ASCII.GetString(data, 0, count).Split(new char[] { ',', ' ', '\n' });

            results = new List<AnalysisSearch_MeasuredResults>();
            for (int index = 0; index < (array.Length - 1); index = index + 2)
            {
                double response = Convert.ToDouble(array[index]);
                double stimulus = Convert.ToDouble(array[index + 1]);
                results.Add(new AnalysisSearch_MeasuredResults(response, stimulus));
            }
            return ((results.Count == measuredPointsAmount) ? 0 : (-1));
        }
        #endregion

        #region Multiple search ranges and markers
        /* :CALCulate1:SELected:MARKer1:FUNCtion:DOMain:MULTiple:STATe ON */
        public int SetMultipleSearchRangeState(uint channelNum, uint markerNum, string on_off = "ON")
        {
            int error = 0, count = 0;
            string command = ":CALCulate" + channelNum + ":SELected:MARKer" + markerNum + ":FUNCtion:DOMain:MULTiple:STATe " + on_off + "\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return error;
        }

        /* :CALCulate1:SELected:MARKer1:FUNCtion:DOMain:MULTiple:RANGe 3
         * :CALCulate1:SELected:MARKer1:FUNCtion:DOMain:MULTiple:STARt 3, 1.5e9
         * :CALCulate1:SELected:MARKer1:FUNCtion:DOMain:MULTiple:STOP  3, 1.8E9
         */
        public int SetMultipleSearchTargetRange(uint channleNum, uint markerNum, uint rangeNum, string rangeStartFreq, string rangeStopFreq)
        {
            int error = 0, count = 0;
            string command = ":CALCulate" + channleNum + ":SELected:MARKer" + markerNum + ":FUNCtion:DOMain:MULTiple:RANGe " + rangeNum + "\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALCulate" + channleNum + ":SELected:MARKer" + markerNum + ":FUNCtion:DOMain:MULTiple:STARt " + rangeNum + ", " + rangeStartFreq + "\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALCulate" + channleNum + ":SELected:MARKer" + markerNum + ":FUNCtion:DOMain:MULTiple:STARt " + rangeNum + ", " + rangeStopFreq + "\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return error;
        }

        /* :CALC1:SEL:MARK1:STATE 1
         * :CALC1:SEL:MARK1:ACTIVATE
         * :CALC1:SEL:MARK1:FUNC:DOM:STATE ON
         * :CALC1:SEL:MARK1:FUNC:DOM:MULT:STATE 1
         * :CALC1:SEL:MARK1:FUNC:DOM:MULT:RANG 1
         * :CALC1:SEL:MARK1:FUNC:DOM:MULT:START 1, 1.5e9
         * :CALC1:SEL:MARK1:FUNC:DOM:MULT:STOP 1, 1.8e9
         * :CALC1:TRACE1:MARK1:FUNC:TRACKING 1
         * :CALC1:TRACE1:MARK1:FUNC:TYPE MINIMUM
         * :CALC1:TRACE1:MARK1:FUNC:EXECUTE
         * :CALC1:TRACE1:MARK1:X?
         * :CALC1:TACE1:MARK1:Y?
         */
        public int SegmentedMarkerSearch(uint channelNum, 
                                         uint traceNum,
                                         uint markerNum,
                                         uint rangeNum,
                                         string rangeStartFreq,     /* Please use scientific notation, such as : 1.5e9 */
                                         string rangeStopFreq,      /* Scientific notation, e.g. 1.8e9 */
                                         string searchType,
                                         out double markerPointFreq,
                                         out List<double> markerPointResponses)
        {
            int error = 0, count = 0;
            string command = ":CALC" + channelNum + ":PAR" + traceNum + ":SEL\n";   /* Select and activate the channel/trace on user-demod. */
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALCulate" + channelNum + ":SELected:FORMat MLOGarithmic\n";    /* Select the format : Log Mag */
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":DISPlay:WINDow" + channelNum + ":TRACe" + traceNum + ":Y:SCALe:AUTO\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALCulate" + channelNum + ":SELected:MARKer" + markerNum + ":STATe ON\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALCulate" + channelNum + ":TRACe" + traceNum + ":MARKer" + markerNum + ":ACTivate\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALCulate" + channelNum + ":SELected:MARKer" + markerNum + ":FUNCtion:DOMain:STATe ON\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALCulate" + channelNum + ":SELected:MARKer" + markerNum + ":FUNCtion:DOMain:MULTiple:STATe ON\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALCulate" + channelNum + ":SELected:MARKer" + markerNum + ":FUNCtion:DOMain:MULTiple:RANGe " + rangeNum + "\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALCulate" + channelNum + ":SELected:MARKer" + markerNum + ":FUNCtion:DOMain:MULTiple:STARt " + rangeNum + ", " + rangeStartFreq + "\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALCulate" + channelNum + ":SELected:MARKer" + markerNum + ":FUNCtion:DOMain:MULTiple:STOP " + rangeNum + ", " + rangeStopFreq + "\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALCulate" + channelNum + ":TRACe" + traceNum + ":MARKer" + markerNum + ":FUNCtion:TRACking ON\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALCulate" + channelNum + ":TRACe" + traceNum + ":MARKer" + markerNum + ":FUNCtion:TYPE " + searchType + "\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALCulate" + channelNum + ":TRACe" + traceNum + ":MARKer" + markerNum + ":FUNCtion:EXEcute\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALCulate" + channelNum + ":TRACe" + traceNum + ":MARKer" + markerNum + ":X?\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            byte[] response = new byte[256];
            error = visa32.viRead(analyzerSession, response, 256, out count);
            markerPointFreq = Convert.ToDouble(Encoding.ASCII.GetString(response, 0, count - 1));

            command = ":CALCulate" + channelNum + ":TRACe" + traceNum + ":MARKer" + markerNum + ":Y?\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(analyzerSession, response, 256, out count);
            markerPointResponses = new List<double>();
            string[] array = Encoding.ASCII.GetString(response, 0, count - 1).Split(new char[] { ',', ' ', '\n' });
            for (int index = 0; index < array.Length - 1; ++index)
            {
                markerPointResponses.Add(Convert.ToDouble(array[index]));
            }
            return error;
        }
        #endregion

        #region Statistical Analysis
        /* :CALCULATE1:SELected:MSTatistics:DATA? */
        public int RetrieveTraceStatisticsAnalysisValues(uint channelNum, int traceNum, out double meanValue, out double standardDeviation, out double peak2PeakValue)
        {
            int error = 0, count = 0;
            string command = ":CALC" + channelNum + ":PAR" + traceNum + ":SEL\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALCulate" + channelNum + ":SELected:MSTatistics:DATA?\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            byte[] response = new byte[256];
            error = visa32.viRead(analyzerSession, response, 256, out count);

            string[] values = Encoding.ASCII.GetString(response, 0, count - 1).Split(new char[] { ',', '\n', ' ', '\r' });
            meanValue = Convert.ToDouble(values[0]);
            standardDeviation = Convert.ToDouble(values[1]);
            peak2PeakValue = Convert.ToDouble(values[2]);
            return error;
        }

        /* :CALCulate1:SELected:MSTatistics:STATe ON */
        public int TurnOnOffStatisticsValueDisplay(uint channelNum, int traceNum, string on_off = "OFF")
        {
            int error = 0, count = 0;
            string command = ":CALC" + channelNum + ":PAR" + traceNum + ":SEL\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALCulate" + channelNum + ":SELected:MSTatistics:STATe " + on_off + "\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            string response;
            return QueryErrorStatus(out response);
        }
        #endregion

        #region Analysis Using the Fixture Simulator
        #endregion
    }
}