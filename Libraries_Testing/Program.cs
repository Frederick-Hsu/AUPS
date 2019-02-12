using System;
using System.Collections;
using System.Collections.Generic;
using Amphenol.Instruments.Keysight;
using Utilities;

namespace Libraries_Testing
{
    class Program
    {
#if true
        static void Main(string[] args)
        {
            Console.WriteLine("This console project was just used to test and verify user-defined libraries.");
            Console.WriteLine("The size of double is : " + sizeof(double) + " bytes");
            Console.WriteLine("The size of float is : " + sizeof(float) + " bytes.");
            NetworkAnalyzer_E5071C analyzer = new NetworkAnalyzer_E5071C();
            // int error = analyzer.Open("TCPIP0::192.168.30.66::inst0::INSTR");
            int error = analyzer.Open("USB0::0x0957::0x0D09::MY46108142::0::INSTR");
            string idn;
            error = analyzer.GetInstrumentIdentifier(out idn);
            // error = analyzer.Preset();
            error = analyzer.ClearAllErrorQueue();
            error = analyzer.SetSweepMeasurementPoints(1, 500);
            error = analyzer.SetSweepStartFreqValueForChannel(1, "2E9");
            error = analyzer.SetSweepStopFreqValueForChannel(1, "6.5E9");

            error = analyzer.SelectDataFormatForActiveTraceOfChannel(1, 1, "MLOGarithmic");
            double[] real, imag;
            error = analyzer.ReadOutCorrectedDataArray(1, 1, out real, out imag);

            error = analyzer.SelectDataFormatForActiveTraceOfChannel(1, 1, "SMITh");

            error = analyzer.SelectTriggerSource("BUS");
            error = analyzer.SingleTriggerMeasurement();
            List<double> realData64Bits, imagData64Bits, frequencies;
            // error = analyzer.ReadOutFormattedDataArray(1, 1, out realData, out imagData);
            error = analyzer.ReadOutFormattedDataArray(1, 1, NetworkAnalyzer_E5071C.DataTransferFormat.REAL, out realData64Bits, out imagData64Bits);
            error = analyzer.ReadOutFrequenciesOfAllMeasurementPoints(1, out frequencies);

            List<double> realData32Bits, imageData32Bits;
            error = analyzer.ReadOutFormattedDataArray(1, 1, NetworkAnalyzer_E5071C.DataTransferFormat.REAL32, out realData32Bits, out imageData32Bits);
            error = analyzer.ReadOutFrequenciesOfAllMeasurementPoints(1, out frequencies);

            for (int i = 0; i < realData64Bits.Count; ++i)
            {
                Console.WriteLine(frequencies[i] + ",\t\t" + realData64Bits[i] + ",\t\t" + realData64Bits[i]);
            }
            error = analyzer.Close();
        }
#else
        static void Main(string[] args)
        {
            Console.WriteLine("sizeof(byte) = " + sizeof(byte));
            Console.WriteLine("sizeof(int) = " + sizeof(int));
            Console.WriteLine("sizeof(double) = " + sizeof(double));
            Console.WriteLine("sizeof(float) = " + sizeof(float));
            Console.WriteLine("sizeof(long) = " + sizeof(long));
            byte[] values = new byte[8] { 0x3F, 0xD5, 0x55, 0x55, 0x55, 0x55, 0x55, 0x55 };
            double d = Conversion.ToDouble(values);
            Console.WriteLine("{0:F32}", d);

            values = new byte[8] { 0x40, 0x09, 0x21, 0xFB, 0x54, 0x44, 0x2D, 0x18};
            d = Conversion.ToDouble(values);
            Console.WriteLine("{0:F32}", d);

            byte[] fvalues = new byte[4] { 0x3F, 0x80, 0x00, 0x01 };
            float f = Conversion.ToSingleFloat(fvalues);
            Console.WriteLine("{0:F16}", f);

            fvalues = new byte[4] { 0x40, 0x49, 0x0F, 0xDB };
            f = Conversion.ToSingleFloat(fvalues);
            Console.WriteLine("{0}", f);
        }
#endif
    }
}
