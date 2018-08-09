using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Amphenol.Instruments.RohdeSchwarz;

using Ivi.Driver;
using Ivi.Scope;
using RohdeSchwarz.RsScope;

namespace RsScopeMeasuring
{
    class Program
    {
        static void Main(string[] args)
        {
#if false
            RSOscilloscope oscilloscope = new RSOscilloscope("TCPIP0::192.168.30.71::inst0::INSTR");

            int status = 0;
            string idn;
            status = oscilloscope.GetInstrumentIdentifier(out idn);
            status = oscilloscope.ConfigureHorizontalScale(100);
            IRsScopeTrigger trigger = oscilloscope.ConfigureTrigger(RohdeSchwarz.RsScope.TriggerModifier.Normal, 
                                                                    13.0, 
                                                                    RohdeSchwarz.RsScope.TriggerSource.Channel1, 
                                                                    RohdeSchwarz.RsScope.TriggerType.Edge, 
                                                                    RohdeSchwarz.RsScope.Slope.Negative, 
                                                                    RSOscilloscope.ChannelIndex.CH1, 
                                                                    0.3);
#else
            DigitalOscilloscope_RTB2004 scope = new DigitalOscilloscope_RTB2004();
            int error = scope.Open("TCPIP0::192.168.30.47::inst0::INSTR");
            string idn;
            error = scope.GetInstrumentIdentifier(out idn);
            error = scope.Close();

            SignalGenerator_SMB100A sg = new SignalGenerator_SMB100A();
            error = sg.Open("TCPIP0::192.168.30.75::inst0::INSTR");
            error = sg.GetInstrumentIdentifier(out idn);

            error = sg.CleanAllErrorQueue();
            error = sg.PresetInstrument();
            string[] assemblies;
            error = sg.QueryInstalledAssemblies(out assemblies);
            string hostname;
            error = sg.QueryHostName(out hostname);
            int impedance = 0;
            error = sg.QueryRFOutputImpedance(out impedance);
            error = sg.RFSignalOutputOnOff(SignalGenerator_SMB100A.State.ON);
            SignalGenerator_SMB100A.State state;
            error = sg.QueryRFSignalOutputState(out state);
            error = sg.Close();
#endif
        }
    }
}
