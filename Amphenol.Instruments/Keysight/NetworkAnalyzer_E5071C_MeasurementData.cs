using System;
using System.Text;

namespace Amphenol.Instruments.Keysight
{
    partial class NetworkAnalyzer_E5071C
    {
        #region Analyzing Data
        /* :CALC1:MARK2 ON */
        public int ShowHideRegularMarkerForActiveTrace(int channelNum, int traceNum, int markerNo, string on_off = "OFF")
        {
            int errorno, count;
            string command = ":CALC" + channelNum + ":PAR" + traceNum + ":SEL\n", response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALCulate" + channelNum + ":SELected:MARKer" + markerNo + ":STATe " + on_off.ToUpper() + "\n";
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :CALC1:MARK2? */
        public int QueryRegularMarkerDisplayStateForActiveTrace(int channelNum, int traceNum, int markerNo, out string on_off)
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
        public int RetrieveFrequencyValueAtRegularMarker(int channelNum, int traceNum, int markerNo, out double frequencyValue /* unit : Hz */)
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
        public int RetrieveMeasurementResultAtRegularMarker(int channelNum, int traceNum, int markerNo, out double attenuationAmplitude /* unit : dB */)
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
#if false
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
#endif
        /* :CALC1:FUNC:PEXC 0.2
         * :CALC1:FUNC:PPOL NEG
         */
        public int SetMarkerPeakSearch(int channelNum, 
                                       int traceNum, 
                                       string peakExcursionLowerLimit = "3", 
                                       string polarity = "POSitive" /* 3 polarities can be selected "POSitive", "NEGative", "BOTH". */)
        {
            int error = 0, count = 0;
            string command = ":DISP:WIND" + channelNum + ":ACT\n", response;
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALC" + channelNum + ":PAR" + traceNum + ":SEL\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALCulate" + channelNum + "SELected:FUNCtion:PEXCursion " + peakExcursionLowerLimit + "\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALCulate" + channelNum + ":SELected:FUNCtion:PPOLarity " + polarity + "\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :CALC1:FUNC:PEXC? 
         * :CALC1:FUNC:PPOL?
         */
        public int QueryMarkerPeakSearch(int channelNum,
                                         int traceNum,
                                         out string peakExcursionLowerLimit,
                                         out string polarity)
        {
            int error = 0, count = 0;
            string command = ":DISP:WIND" + channelNum + ":ACT\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALC" + channelNum + ":PAR" + traceNum + ":SEL\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALCulate" + channelNum + ":SELected:FUNCtion:PEXCursion?\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            byte[] response = new byte[64];
            error = visa32.viRead(analyzerSession, response, 64, out count);
            peakExcursionLowerLimit = Encoding.ASCII.GetString(response, 0, count - 1);

            command = ":CALCulate" + channelNum + ":SELected:FUNCtion:PPOLarity?\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(analyzerSession, response, 64, out count);
            polarity = Encoding.ASCII.GetString(response, 0, count - 1);
            return error;
        }
        /* :CALC1:FUNC:TARG -12.5
         * :CALC1:FUNC:TTR  NEG
         */
        public int SetMarkerTargetSearch(int channelNum, int traceNum, string targetValue, string transitionalDirection)
        {
            int errorno, count;
            string command = ":CALC" + channelNum + ":PAR" + traceNum + ":SEL\n", response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALCulate" + channelNum + ":SELected:FUNCtion:TARGet " + targetValue + "\n";
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALCulate" + channelNum + ":SELected:FUNCtion:TTRansition " + transitionalDirection + "\n";
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :CALC1:FUNC:TARG?
         * :CALC1:FUNC:TTR?
         */
        public int QueryMarkerTargetSearch(int channelNum, int traceNum, out string targetValue, out string transitionDirection)
        {
            int error = 0, cout = 0;
            string command = ":CALC" + channelNum + ":PAR" + traceNum + ":SEL\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out cout);

            command = ":CALCulate" + channelNum + ":SELected:FUNCtion:TARGet?\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out cout);
            byte[] response = new byte[64];
            error = visa32.viRead(analyzerSession, response, 64, out cout);
            targetValue = Encoding.ASCII.GetString(response, 0, cout - 1);

            command = ":CALCulate" + channelNum + ":SELected:FUNCtion:TTRansition?\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out cout);
            error = visa32.viRead(analyzerSession, response, 64, out cout);
            transitionDirection = Encoding.ASCII.GetString(response, 0, cout - 1);
            return error;
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
            string command = ":CALCulate" + channelNum + ":SELected:FUNCtion:POINts?\n";
            byte[] response = new byte[256];
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            errorno = visa32.viRead(analyzerSession, response, 256, out count);
            pointNum = Convert.ToInt32(Encoding.ASCII.GetString(response, 0, count-1));

            command = ":CALCulate" + channelNum + ":SELected:FUNCtion:DATA?\n";
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            errorno = visa32.viRead(analyzerSession, response, 256, out count);

            string[] array = Encoding.ASCII.GetString(response, 0, count-1).Split(new char[] { ',', ' ', '\n' });
            int itemNumber = array.Length;
            results = new double[itemNumber];

            for (int index = 0; index < itemNumber; index++)
            {
                results[index] = Convert.ToDouble(array[index]);
            }
            return errorno;
        }
        #endregion
    }
}