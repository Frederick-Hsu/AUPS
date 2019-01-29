using System;

using Amphenol.Instruments.Keysight;

namespace Libraries_Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This console project was just used to test and verify user-defined libraries.");

            NetworkAnalyzer_E5071C analyzer = new NetworkAnalyzer_E5071C();
            int error = analyzer.Open("TCPIP0::192.168.30.66::inst0::INSTR");

            double[] real, imag;
            error = analyzer.ReadOutCorrectedDataArray(1, 1, out real, out imag);
            error = analyzer.Close();
        }
    }
}
