using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Ivi.Driver;
using Ivi.Scope;
using RohdeSchwarz.RsScope;

namespace RS_Scope
{
    class Program
    {
        static void Main(string[] args)
        {
            RsScope driver = new RsScope("TCPIP0::192.168.30.71::hislip0::INSTR", true, true, "Simulate=False");
            string ioRsrc = driver.DriverOperation.IOResourceDescriptor;

            bool rangeChecked = driver.DriverOperation.RangeCheck;
        }
    }
}
