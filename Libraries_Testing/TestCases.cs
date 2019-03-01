using System;
using System.Collections.Generic;
using Amphenol.Instruments.Keysight;
using Utilities;

namespace Libraries_Testing
{
    public class TestCases
    {
        public static void TestCase_PerformingLimitTest()
        {

        }

        public static void TestCases_MarkerSearch()
        {
            NetworkAnalyzer_E5071C analyzer = new NetworkAnalyzer_E5071C();
            int error = analyzer.Open("TCPIP0::192.168.30.64::inst0::INSTR");
            string idn;
            error = analyzer.GetInstrumentIdentifier(out idn);
            error = analyzer.ClearAllErrorQueue();
            error = analyzer.Preset();
            string errorMesg;
            error = analyzer.QueryErrorStatus(out errorMesg);
            error = analyzer.SelectChannelDisplayMode();
            error = analyzer.SelectTraceDisplayMode(1, "D1");
            error = analyzer.ConfigTraceNumInChannel(1, 1);
            error = analyzer.ActivateTraceAt(1, 1);
            error = analyzer.SelectMeasurementParameterFor(1, 1, "S11");
            error = analyzer.SelectDataFormatForActiveTraceOfChannel(1, 1, "MLOG");
            error = analyzer.AutoScaleTraceDisplay(1, 1);
            error = analyzer.SetSweepMeasurementPoints(1, 500);
            error = analyzer.SetSweepStartFreqValueForChannel(1, "1.0E9");
            error = analyzer.SetSweepStopFreqValueForChannel(1, "3.5E9");
            error = analyzer.SelectTriggerSource("BUS");
            error = analyzer.SingleTriggerMeasurement();
            double markerPointFreq = 0.00;
            List<double> markerPointResp;
            error = analyzer.SegmentedMarkerSearch(1, 1, 1, 1, "1.5e9", "1.8e9", "MINimum", out markerPointFreq, out markerPointResp);
            Console.WriteLine("Marker 1: ");
            Console.WriteLine("{0}, \t\t {1}", markerPointFreq, markerPointResp[0]);

            error = analyzer.SegmentedMarkerSearch(1, 1, 2, 2, "2.0e9", "2.3e9", "MIN", out markerPointFreq, out markerPointResp);
            Console.WriteLine("Marker 2: ");
            Console.WriteLine("{0}, \t\t {1}", markerPointFreq, markerPointResp[0]);

            error = analyzer.SegmentedMarkerSearch(1, 1, 3, 3, "2.3e9", "2.6e9", "MAX", out markerPointFreq, out markerPointResp);
            Console.WriteLine("Marker 3: ");
            Console.WriteLine("{0}, \t\t {1}", markerPointFreq, markerPointResp[0]);

            error = analyzer.SegmentedMarkerSearch(1, 1, 4, 4, "2.7e9", "3.0e9", "MIN", out markerPointFreq, out markerPointResp);
            Console.WriteLine("Marker 4: ");
            Console.WriteLine("{0}, \t\t {1}", markerPointFreq, markerPointResp[0]);

            error = analyzer.SelectDataFormatForActiveTraceOfChannel(1, 1, "SMITH");
            error = analyzer.AutoScaleTraceDisplay(1, 1);
            List<double> realData, imagData, frequencies;
            error = analyzer.ReadOutFormattedDataArray(1, 1, out realData, out imagData);
            error = analyzer.ReadOutFrequenciesOfAllMeasurementPoints(1, out frequencies);
            Console.WriteLine("Smith R + jX chart: ");
            Console.WriteLine("Real \t\t\t Image \t\t\t\t Freq");
            for (int index = 0; index < realData.Count; ++index)
            {
                Console.WriteLine("{0}, \t\t {1}, \t\t {2}", realData[index], imagData[index], frequencies[index]);
            }

            Console.WriteLine("Marker search in Smith chart");
            Console.WriteLine("Marker 1: ");
            error = analyzer.RetrieveFrequencyValueAtRegularMarker(1, 1, 1, out markerPointFreq);
            error = analyzer.RetrieveMeasurementResultAtRegularMarker(1, 1, 1, out markerPointResp);
            Console.WriteLine("{0}, \t\t {1}, \t\t {2}", markerPointFreq, markerPointResp[0], markerPointResp[1]);

            Console.WriteLine("Marker 2: ");
            error = analyzer.RetrieveFrequencyValueAtRegularMarker(1, 1, 2, out markerPointFreq);
            error = analyzer.RetrieveMeasurementResultAtRegularMarker(1, 1, 2, out markerPointResp);
            Console.WriteLine("{0}, \t\t {1}, \t\t {2}", markerPointFreq, markerPointResp[0], markerPointResp[1]);

            Console.WriteLine("Marker 3: ");
            error = analyzer.RetrieveFrequencyValueAtRegularMarker(1, 1, 3, out markerPointFreq);
            error = analyzer.RetrieveMeasurementResultAtRegularMarker(1, 1, 3, out markerPointResp);
            Console.WriteLine("{0}, \t\t {1}, \t\t {2}", markerPointFreq, markerPointResp[0], markerPointResp[1]);

            Console.WriteLine("Marker 4: ");
            error = analyzer.RetrieveFrequencyValueAtRegularMarker(1, 1, 4, out markerPointFreq);
            error = analyzer.RetrieveMeasurementResultAtRegularMarker(1, 1, 4, out markerPointResp);
            Console.WriteLine("{0}, \t\t {1}, \t\t {2}", markerPointFreq, markerPointResp[0], markerPointResp[1]);

            error = analyzer.TurnOnOffStatisticsValueDisplay(1, "ON");
            double[] statisticsValues = new double[3];
            error = analyzer.RetrieveTraceStatisticsAnalysisValues(1, out statisticsValues[0], out statisticsValues[1], out statisticsValues[2]);
            Console.WriteLine("Trace statistics values : ");
            Console.WriteLine("Mean \t\t Standard deviation \t\t Peak-Peak");
            Console.WriteLine("{0} \t\t {1} \t\t {2}", statisticsValues[0], statisticsValues[1], statisticsValues[2]);
            error = analyzer.Close();
        }

        public static void TestCases_ByteArrayConvertToDouble()
        {
            Console.WriteLine("sizeof(byte) = " + sizeof(byte));
            Console.WriteLine("sizeof(int) = " + sizeof(int));
            Console.WriteLine("sizeof(double) = " + sizeof(double));
            Console.WriteLine("sizeof(float) = " + sizeof(float));
            Console.WriteLine("sizeof(long) = " + sizeof(long));
            byte[] values = new byte[8] { 0x3F, 0xD5, 0x55, 0x55, 0x55, 0x55, 0x55, 0x55 };
            double d = Conversion.ToDouble(values);
            Console.WriteLine("{0:F32}", d);

            values = new byte[8] { 0x40, 0x09, 0x21, 0xFB, 0x54, 0x44, 0x2D, 0x18 };
            d = Conversion.ToDouble(values);
            Console.WriteLine("{0:F32}", d);

            byte[] fvalues = new byte[4] { 0x3F, 0x80, 0x00, 0x01 };
            float f = Conversion.ToSingleFloat(fvalues);
            Console.WriteLine("{0:F16}", f);

            fvalues = new byte[4] { 0x40, 0x49, 0x0F, 0xDB };
            f = Conversion.ToSingleFloat(fvalues);
            Console.WriteLine("{0}", f);
        }

        public static void TestCases_RetrieveFormattedFullTraceData()
        {
            Console.WriteLine("This console project was just used to test and verify user-defined libraries.");
            Console.WriteLine("The size of double is : " + sizeof(double) + " bytes");
            Console.WriteLine("The size of float is : " + sizeof(float) + " bytes.");
            NetworkAnalyzer_E5071C analyzer = new NetworkAnalyzer_E5071C();
            // int error = analyzer.Open("TCPIP0::192.168.30.66::inst0::INSTR");
            int error = analyzer.Open("TCPIP0::192.168.30.64::inst0::INSTR");
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
    }
}