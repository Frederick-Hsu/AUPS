using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Utilities;

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

        /* :CALCulate1:SELected:DATA:FDATa? */
        public int ReadOutFormattedDataArray(uint activeChannelNumber,
                                             uint selectedTraceNumber,
                                             out List<double> primaryDataList,
                                             out List<double> secondaryDataList)
        {
            int error = 0, count = 0;
            string command = ":CALC" + activeChannelNumber + ":PAR" + selectedTraceNumber + ":SEL\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":FORMat:DATA ASCii\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CALCulate" + activeChannelNumber + ":SELected:DATA:FDATa?\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            string response;
            error = visa32.viRead(analyzerSession, out response, 1024 * 1024);

            string[] dataArray = response.Split(new char[] { ',', '\n', ' ' });
            int length = dataArray.Length;
            primaryDataList = new List<double>();
            secondaryDataList = new List<double>();
            for (int index = 0; index < length-1; index = index + 2)
            {
                primaryDataList.Add(Convert.ToDouble(dataArray[index]));
                secondaryDataList.Add(Convert.ToDouble(dataArray[index+1]));
            }
            return error;
        }

        public enum DataTransferFormat
        {
            ASCII = 0,
            REAL = 1,
            REAL32 = 2
        }

        public int ReadOutFormattedDataArray(uint activeChannelNumber,
                                             uint selectedTraceNumber,
                                             DataTransferFormat format,
                                             out List<double> primaryDataList,
                                             out List<double> secondaryDataList)
        {
            int error = 0, count = 0;
            string command = ":CALC" + activeChannelNumber + ":PAR" + selectedTraceNumber + ":SEL\n";
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            switch (format)
            {
                case DataTransferFormat.REAL:
                    command = ":FORMat:DATA REAL\n";
                    break;
                case DataTransferFormat.REAL32:
                    command = ":FORMat:DATA REAL32\n";
                    break;
                case DataTransferFormat.ASCII:
                default:
                    command = ":FORMat:DATA ASCii\n";
                    break;
            }
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

            primaryDataList = new List<double>();
            secondaryDataList = new List<double>();
            switch (format)
            {
                case DataTransferFormat.REAL:
                    error = visa32.viSetAttribute(analyzerSession, visa32.VI_ATTR_TERMCHAR_EN, visa32.VI_FALSE);    /* Disable the terminator char */
                    command = ":CALCulate" + activeChannelNumber + ":SELected:DATA:FDATa?\n";
                    error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

                    byte[] responseBytes = new byte[1024 * 1024];
                    error = visa32.viRead(analyzerSession, responseBytes, 1024 * 1024, out count);
                    int numberOfBytesTransferred = Convert.ToInt32(Encoding.ASCII.GetString(responseBytes, 2, 6));
                    if (numberOfBytesTransferred % 8 != 0) { return error; }

                    byte[] data64Bit = new byte[numberOfBytesTransferred];
                    for (int index = 0; index < numberOfBytesTransferred; ++index)
                    {
                        data64Bit[index] = responseBytes[8 + index];
                    }
                    byte[] primaryValues64Bit = new byte[8];
                    byte[] secondaryValues64Bit = new byte[8];

                    for (int i = 0; i < numberOfBytesTransferred; i = i + 16)
                    {
                        for (int n = 0; n < 8; ++n)
                        {
                            primaryValues64Bit[n] = data64Bit[i + n];
                        }
                        primaryDataList.Add(Conversion.ToDouble(primaryValues64Bit));
                        for (int n = 0; n < 8; ++n)
                        {
                            secondaryValues64Bit[n] = data64Bit[i + 8 + n];
                        }
                        secondaryDataList.Add(Conversion.ToDouble(secondaryValues64Bit));
                    }

                    error = visa32.viSetAttribute(analyzerSession, visa32.VI_ATTR_TERMCHAR_EN, visa32.VI_TRUE);     /* DO NOT forget to enable terminator char */
                    /* And you must restore the data format to ASCII, otherwise it will influence other commands */
                    command = ":FORMat:DATA ASCii\n";
                    error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
                    break;
                case DataTransferFormat.REAL32:
                    error = visa32.viSetAttribute(analyzerSession, visa32.VI_ATTR_TERMCHAR_EN, visa32.VI_FALSE);
                    command = ":CALCulate" + activeChannelNumber + ":SELected:DATA:FDATa?\n";
                    error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

                    byte[] respBytes = new byte[1024 * 1024];
                    error = visa32.viRead(analyzerSession, respBytes, 1024 * 1024, out count);
                    int bytesNum = Convert.ToInt32(Encoding.ASCII.GetString(respBytes, 2, 6));
                    if (bytesNum % 8 != 0) { return error; }

                    byte[] data32Bit = new byte[bytesNum];
                    for (int index = 0; index < bytesNum; ++index)
                    {
                        data32Bit[index] = respBytes[8 + index];
                    }
                    byte[] primaryValues32Bit = new byte[4];
                    byte[] secondaryValues32Bit = new byte[4];

                    for (int i = 0; i < bytesNum; i = i + 8)
                    {
                        for (int n = 0; n < 4; ++n)
                        {
                            primaryValues32Bit[n] = data32Bit[i + n];
                        }
                        primaryDataList.Add(Conversion.ToSingleFloat(primaryValues32Bit));
                        for (int n = 0; n < 4; ++n)
                        {
                            secondaryValues32Bit[n] = data32Bit[i + 4 + n];
                        }
                        secondaryDataList.Add(Conversion.ToSingleFloat(secondaryValues32Bit));
                    }

                    error = visa32.viSetAttribute(analyzerSession, visa32.VI_ATTR_TERMCHAR_EN, visa32.VI_TRUE);
                    command = ":FORMat:DATA ASCii\n";
                    error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
                    break;
                case DataTransferFormat.ASCII:
                default:
                    command = ":CALCulate" + activeChannelNumber + ":SELected:DATA:FDATa?\n";
                    error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);

                    string responseStr;
                    error = visa32.viRead(analyzerSession, out responseStr, 1024 * 1024 * 1024);
                    string[] dataArray = responseStr.Split(new char[] { ',', '\n', ' ' });
                    int length = dataArray.Length;
                    for (int index = 0; index < length-1; index = index + 2)
                    {
                        primaryDataList.Add(Convert.ToDouble(dataArray[index]));
                        secondaryDataList.Add(Convert.ToDouble(dataArray[index + 1]));
                    }
                    break;
            }
            string errormesg;
            return QueryErrorStatus(out errormesg);
        }

        /* :SENSe1:FREQuency:DATA? */
        public int ReadOutFrequenciesOfAllMeasurementPoints(uint activeChannelNumber, out List<double> frequencies)
        {
            int error = 0, count = 0;
            string command = ":SENSe" + activeChannelNumber + ":FREQuency:DATA?\n", response;
            error = visa32.viWrite(analyzerSession, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(analyzerSession, out response, 1024 * 1024);

            string[] array = response.Split(new char[] { ',', ' ', '\n' });
            frequencies = new List<double>();
            int length = array.Length;
            for (int index = 0; index < length-1; ++index)
            {
                frequencies.Add(Convert.ToDouble(array[index]));
            }
            return error;
        }
        #endregion
    }
}