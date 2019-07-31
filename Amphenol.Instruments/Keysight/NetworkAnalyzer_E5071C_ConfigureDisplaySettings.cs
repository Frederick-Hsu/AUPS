using System;
using System.Text;

namespace Amphenol.Instruments.Keysight
{
    partial class NetworkAnalyzer_E5071C
    {
        #region Configuring Display Settings
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

        /* :CALC1:FORM? */
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

        /* :DISP:ENAB ON */
        public int TurnOnOffDisplayUpdate(string on_off)
        {
            int error = 0, count = 0;
            string command = ":DISPlay:ENABle " + on_off.ToUpper() + "\n", response;
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :MMEM:LOAD:SEGM "D:\segm.csv" */
        public int LoadSegmentSweepTableFromCsvFile(uint activeChannelNum, string segmentSweepTableCsvFile = "D:\\segm.csv")
        {
            int errorno, count;
            string command = ":DISP:WIND" + activeChannelNum + ":ACT\n", response;
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = "MMEMory:LOAD:SEGMent \"" + segmentSweepTableCsvFile + "\"\n";
            errorno = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :MMEMory:STORe:SEGMent "D:\segm.csv" */
        public int SaveSegmentSweepTableIntoCsvFile(uint activeChannelNum, string segmentSweepTableCsvFile = "D:\\segm.csv")
        {
            int error = 0, count = 0;
            string command = ":DISP:WIND" + activeChannelNum + ":ACT\n", response;
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":MMEMory:STORe:SEGMent \"" + segmentSweepTableCsvFile + "\"\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
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

        /* :MMEMory:STORe:STATe "autorec.sta" */
        public int AutoRecallEntireInstrumentStatusWhenPowerON()
        {
            return SaveInstrumentStateIntoFile("autorec.sta");
        }
        #endregion

        #region Configuring trace display settings
        /* :DISPlay:WINDow1:TRACe2:STATe ON */
        public int DisplayOnOffDataTrace(uint channelNum, uint traceNum, string onOff = "ON")
        {
            int error = 0, count = 0;
            string command = ":DISPlay:WINDow" + channelNum + ":TRACe" + traceNum + ":STATe " + onOff + "\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            string response;
            return QueryErrorStatus(out response);
        }

        /* :DISPlay:WINDow1:TRACe2:MEMory:STATe ON */
        public int DisplayOnOffMemoryTrace(uint channelNum, uint traceNum, string onOff = "OFF")
        {
            int error = 0, count = 0;
            string command = ":DISPlay:WINDow" + channelNum + ":TRACe" + traceNum + ":MEMory:STATe " + onOff + "\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            string response;
            return QueryErrorStatus(out response);
        }

        /* :CALCulate1:SELected:MATH:MEMorize */
        public int CopyMeasurementDateToMemoryTrace(uint channelNum)
        {
            int error = 0, count = 0;
            string command = ":CALCulate" + channelNum + ":SELected:MATH:MEMorize\n", response;
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :CALCulate1:MATH:FUNC NORMal */
        public int PerformMathOperationBetweenDataAndMemoryTraces(uint channelNum, 
                                                                  string mathOperation = "NORMal" /* only 5 options : NORMal, DIVide, MULTiply, SUBTract, ADD */)
        {
            int error = 0, count = 0;
            string command = ":CALCulate" + channelNum + ":SELected:MATH:FUNC " + mathOperation + "\n", response;
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }
        #endregion
    }
}