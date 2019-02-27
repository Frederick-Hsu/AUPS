using System;

namespace Utilities
{
    public class Conversion
    {
        public static double ToDouble(byte[] values, int bytesCount = 8)
        {
            if (bytesCount != 8)
            {
                return 0;
            }
            if (values.Length != 8)
            {
                return 0;
            }
            double ret = 0.00;

            Int64[] Values64 = new Int64[8];
            for (int index = 0; index < 8; ++index)
            {
                Values64[index] = values[index];
            }

            Int64 signbit = (Values64[0] & 0x80) >> 7;
            Int64 exponent = (((Values64[0] & 0x7F) << 8) + (Values64[1] & 0xF0)) >> 4;
            Values64[0] = 0x01;
            Int64 fraction =  ( Values64[0]         << 52) +
                              ((Values64[1] & 0x0F) << 48) +
                              ((Values64[2] & 0xFF) << 40) +
                              ((Values64[3] & 0xFF) << 32) +
                              ((Values64[4] & 0xFF) << 24) +
                              ((Values64[5] & 0xFF) << 16) +
                              ((Values64[6] & 0xFF) <<  8) +
                              ((Values64[7] & 0xFF)      );

            Int64 sign = (signbit == 0) ? 1 : (-1);
            ret = sign * Math.Pow(2, (exponent - 1023)) * fraction * Math.Pow(2, -52);
            return ret;
        }

        public static float ToSingleFloat(byte[] values, int bytesCount = 4)
        {
            if ((bytesCount != 4) || (values.Length != 4))
            {
                return 0;
            }

            float ret = 0.00f;
            Int32[] Values32 = new Int32[4];
            for (int index = 0; index < 4; ++index)
            {
                Values32[index] = values[index];
            }

            Int32 signbit = (Values32[0] & 0x80) >> 7;
            Int32 exponent = ((Values32[0] & 0x7F) << 1) + ((Values32[1] & 0x80) >> 7);
            Values32[0] = 0x01;
            Int32 fraction = ( Values32[0]         << 23) +
                             ((Values32[1] & 0x7F) << 16) + 
                             ((Values32[2] & 0xFF) <<  8) + 
                             ((Values32[3] & 0xFF)      );
            Int32 sign = (signbit == 0) ? 1 : (-1);
            ret = (float)(sign * Math.Pow(2, (exponent - 127)) * fraction * Math.Pow(2, -23));
            return ret;
        }
    }
}