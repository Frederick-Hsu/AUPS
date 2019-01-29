using System;
using System.Text;

namespace Amphenol.Instruments.Keysight
{
    partial class NetworkAnalyzer_E5071C
    {
        #region Chapter 7 : Reading / Writing Measurement Data
        /* :FORMat:DATA ASCii */
        public int SpecifyDataTransferFormat(string format = "ASCii" /* 3 options available {ASCii|REAL|REAL32} */)
        {
            int error = 0, count = 0;
            string command = ":FORMat:DATA " + format + "\n", response;
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QueryErrorStatus(out response);
        }

        /* :FORMat:DATA? */
        public int QueryDataTransferFormat(out string format)
        {
            int error = 0, count = 0;
            string command = ":FORMat:DATA?\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            byte[] response = new byte[128];
            error = visa32.viRead(analyzerSession, response, 128, out count);
            format = Encoding.ASCII.GetString(response, 0, count - 1);
            return error;
        }

        /* :CALCulate1:SELected:DATA:SDATa? */
        public int ReadOutCorrectedDataArray(uint activeChannelNumber, 
                                             uint selectedTraceNumber, 
                                             out double[] correctedDataArrayReal,
                                             out double[] correctedDataArrayImag)
        {
            int error = 0, count = 0;
            string command = ":CALC" + activeChannelNumber + ":PAR" + selectedTraceNumber + ":SEL\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":FORMat:DATA ASCii\n";       /* Specify to use the ASCII data format */
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALCulate" + activeChannelNumber + ":SELected:DATA:SDATa?\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            string response;
            error = visa32.viRead(analyzerSession, out response, 1024 * 1024);
            string[] array = response.Split(new char[] { ',', '\n', ' ' });
            int length = array.Length;

            correctedDataArrayReal = new double[length / 2];
            correctedDataArrayImag = new double[length / 2];
            int n = 0;
            for (int index = 0; index < length-1; index = index+2)
            {
                correctedDataArrayReal[n] = Convert.ToDouble(array[index]);
                correctedDataArrayImag[n] = Convert.ToDouble(array[index + 1]);
                ++n;
            }
            return error;
        }
        #endregion
    }
}