using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.NetworkInformation;

namespace Amphenol.Instruments.Keysight
{
    public class DigitalMultiMeter_34461A
    {
        private int resourceMgr;
        private int dmmSession;

        public DigitalMultiMeter_34461A()
        {
            resourceMgr = 0;
            dmmSession = 0;
        }

        public int Open(string dmmVisaAddress)
        {
            int viError;

            /* Open the default resource manager */
            viError = visa32.viOpenDefaultRM(out resourceMgr);
            if (viError != visa32.VI_SUCCESS)
                return viError;
            /* Open the seesion for current Keysight 34461A DMM. */
            viError = visa32.viOpen(resourceMgr, dmmVisaAddress, visa32.VI_NO_LOCK, visa32.VI_TMO_IMMEDIATE, out dmmSession);
            if (viError != visa32.VI_SUCCESS)
                return viError;

            return viError;
        }

        public int Close()
        {
            int viError;
            viError = visa32.viClose(dmmSession);
            dmmSession = 0;

            viError = visa32.viClose(resourceMgr);
            resourceMgr = 0;
            return viError;
        }

        public int GetInstrumentIdentifier(out string idn)
        {
            int viError;
            int actualCount;
            string command = "*IDN?";
            string response;

            viError = visa32.viWrite(dmmSession, Encoding.ASCII.GetBytes(command), command.Length, out actualCount);
            if (viError != visa32.VI_SUCCESS)
            {
                idn = "";
                return viError;
            }

            viError = visa32.viRead(dmmSession, out response, 256);
            if (viError != visa32.VI_SUCCESS)
            {
                idn = string.Empty;
                return viError;
            }

            idn = response;
            return viError;
        }

        public int MeasureResistorVia2Wires(out float resistance)
        {
            int viError;
            int actualCount;
            string response;

            string command = "CONFigure:RESistance";
            viError = visa32.viWrite(dmmSession, Encoding.ASCII.GetBytes(command), command.Length, out actualCount);
            if (viError != visa32.VI_SUCCESS)
            {
                resistance = 0.00F;
                return viError;
            }

            command = "READ?";
            viError = visa32.viWrite(dmmSession, Encoding.ASCII.GetBytes(command), command.Length, out actualCount);
            viError = visa32.viRead(dmmSession, out response, 256);
            if (viError != visa32.VI_SUCCESS)
            {
                resistance = 0.00F;
                return viError;
            }

            resistance = Convert.ToSingle(response);
            return viError;
        }

        public int MeasureResistorVia4Wires(out float resistance)
        {
            int viError;
            int actualCount;
            string response;
            string[] valueArray = new string[3];
            float[] resistanceArray = new float[3];

            string command = "CONFigure:FRESistance";
            viError = visa32.viWrite(dmmSession, Encoding.ASCII.GetBytes(command), command.Length, out actualCount);
            if (viError != visa32.VI_SUCCESS)
            {
                resistance = 0.00F;
                return viError;
            }

            command = "SAMP:COUNt 3";
            viError = visa32.viWrite(dmmSession, Encoding.ASCII.GetBytes(command), command.Length, out actualCount);
            command = "READ?";
            viError = visa32.viWrite(dmmSession, Encoding.ASCII.GetBytes(command), command.Length, out actualCount);
            viError = visa32.viRead(dmmSession, out response, 512);
            if (viError != visa32.VI_SUCCESS)
            {
                resistance = 0.00F;
                return viError;
            }

            valueArray = response.Split(',');
            for (int index = 0; index < 3; index++)
            {
                resistanceArray[index] = Convert.ToSingle(valueArray[index]);
            }
            resistance = (resistanceArray[0] + resistanceArray[1] + resistanceArray[2]) / 3;
            return viError;
        }
    }

    public class CharsetEncodingDecoding
    {
        public static void ConvertEncoding()
        {
            string GB18030String = "余学琴， 我爱你！";
            Console.WriteLine("需要转换的字符串：{0}", GB18030String);

            #region 对字符串进行GB18030-2000格式编码
            Encoding gb18030Encoding = Encoding.GetEncoding("GB18030");
            char[] chars = GB18030String.ToCharArray();
            int bufferLength = gb18030Encoding.GetByteCount(chars, 0, chars.Length);
            byte[] gb18030Buffer = new byte[bufferLength];
            gb18030Buffer = gb18030Encoding.GetBytes(chars, 0, chars.Length);
            Console.WriteLine("GB18030编码的字节序列：{0}", BitConverter.ToString(gb18030Buffer));

            byte[] unicodeBuffer = Encoding.Convert(gb18030Encoding, Encoding.UTF8, gb18030Buffer);
            Console.WriteLine("转换成UTF-8编码字节序列：{0}", BitConverter.ToString(unicodeBuffer));
            #endregion

            #region 将GB18030编码转换为UTF-8编码
            Decoder utf8Decoder = Encoding.UTF8.GetDecoder();
            int utfCharsLength = utf8Decoder.GetCharCount(unicodeBuffer, 0, unicodeBuffer.Length, true);
            char[] utfChars = new char[utfCharsLength];
            utf8Decoder.GetChars(unicodeBuffer, 0, unicodeBuffer.Length, utfChars, 0);

            StringBuilder strBuilder = new StringBuilder();
            foreach (char singleChar in utfChars)
            {
                strBuilder.Append(singleChar);
            }
            Console.WriteLine("UTF-8的字符序列解码：{0}", strBuilder.ToString());
            #endregion
        }

        public byte[] GetEncoderBeforeBuffer(string codeType, string strCode)
        {
            Encoder encoder = Encoding.GetEncoding(codeType).GetEncoder();
            char[] chars = strCode.ToCharArray();
            byte[] bytes = new byte[encoder.GetByteCount(chars, 0, chars.Length, true)];
            encoder.GetBytes(chars, 0, chars.Length, bytes, 0, true);
            return bytes;
        }

        public string GetDecoderBeforeText(string codeType, byte[] byteCode)
        {
            Decoder decoder = Encoding.GetEncoding(codeType).GetDecoder();
            char[] chars = new char[decoder.GetCharCount(byteCode, 0, byteCode.Length, true)];
            int charLen = decoder.GetChars(byteCode, 0, byteCode.Length, chars, 0);
            StringBuilder strResult = new StringBuilder();
            foreach (char singleChar in chars)
            {
                strResult = strResult.Append(singleChar.ToString());
            }
            return strResult.ToString();
        }
    }
}
