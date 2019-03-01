using System;
using System.Collections;
using System.Collections.Generic;
using Amphenol.Instruments.Keysight;
using Utilities;

namespace Libraries_Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            TestCases.TestCases_MarkerSearch();

            TestCases.TestCases_RetrieveFormattedFullTraceData();
        }
    }
}
