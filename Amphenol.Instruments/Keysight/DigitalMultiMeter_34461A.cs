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
        private IPAddress ip;
        private IPEndPoint iep;

        public DigitalMultiMeter_34461A()
        {
            string localHostName = Dns.GetHostName();
            IPHostEntry container = Dns.GetHostEntry(localHostName);
            IPAddress[] ipList = container.AddressList;
            IPAddress loopbackIP = IPAddress.Loopback;

            NetworkInterface[] nic = NetworkInterface.GetAllNetworkInterfaces();
            int nicNum = nic.Length;
            IPInterfaceProperties property = nic[nicNum - 1].GetIPProperties();
            IPAddressCollection dns = property.DnsAddresses;

            IPGlobalProperties netProperties = IPGlobalProperties.GetIPGlobalProperties();
            IPGlobalStatistics ipStats = netProperties.GetIPv4GlobalStatistics();
        }

        public DigitalMultiMeter_34461A(string ipAddr, int portNum)
        {
            ip = IPAddress.Parse(ipAddr);
            iep = new IPEndPoint(ip, portNum);
        }

        public bool PingDMM()
        {
            bool result = false;

            Ping pingSender = new Ping();
            PingOptions options = new PingOptions();
            options.DontFragment = true;

            byte[] buffer = Encoding.ASCII.GetBytes("Hi, Keysight Digital Multimeter.");
            int timeout = 128;      /* TTL : 128ms */

            PingReply reply = pingSender.Send(ip, timeout, buffer, options);
            IPStatus status = reply.Status;
            if (status == IPStatus.Success)
            {
                result = true;
            }
            return result;
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
