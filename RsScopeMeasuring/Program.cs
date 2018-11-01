using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Amphenol.Instruments.RohdeSchwarz;
using Amphenol.Instruments.Keysight;

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
            /*
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

            long freq, offset;
            error = sg.SetRFOutputSignalFrequency("2.45GHz");
            error = sg.RetrieveRFOutputSignalFrequency(out freq);
            error = sg.SetFrequencyOffsetForDownstreamInstrument("520KHz");
            error = sg.RetrieveFrequencyOffset(out offset);

            error = sg.SetFrequencyVariationModeAndStepWidth(SignalGenerator_SMB100A.Freq_Step_Mode.USER, "25KHz");
            SignalGenerator_SMB100A.Freq_Step_Mode mode;
            long stepWidth;
            error = sg.QueryFrequencyVariationModeAndStepWidth(out mode, out stepWidth);
            error = sg.SetPhaseVariationRelativeToCurrentPhase(-120.00);
            error = sg.ResetDeltaPhaseDisplay();

            double level = -12.45;
            error = sg.SetRFLevelAppliedOntoDUT(level);
            error = sg.RetrieveRFLevelAppliedOntoDUT(out level);

            double levelOffset;
            error = sg.SpecifyLevelOffsetForDownstreamAttenuatorAmplifier(-12.50);
            error = sg.QueryLevelOffsetForDownstreamAttenuatorAmplifier(out levelOffset);
            error = sg.Close();
            */

            SignalGenerator_SMB100A sg = new SignalGenerator_SMB100A();
            int error = sg.Open("TCPIP0::192.168.1.158::inst0::INSTR");
            string sgIDN;
            error = sg.GetInstrumentIdentifier(out sgIDN);

            SignalAnalyzer_N9020A sa = new SignalAnalyzer_N9020A();
            error = sa.Open("TCPIP0::192.168.1.142::inst0::INSTR");
            string saIDN;
            error = sa.GetInstrumentIdentifier(out saIDN);

            /* Setup signal generator */
            error = sg.CleanAllErrorQueue();
            error = sg.PresetInstrument();
            error = sg.SetRFOutputSignalFrequency("2.4GHz");
            error = sg.SetRFLevelAppliedOntoDUT(-5.00);
            error = sg.RFSignalOutputOnOff(SignalGenerator_SMB100A.State.ON);

            /* Setip signal analyzer */
            error = sa.ClearStatusAndErrorQueue();
            error = sa.RestoreAllModesGlobalSettingsToDefault();
            error = sa.SelectMeasurementMode("SA");
            error = sa.SelectMeasurementItemInSignalAnalyzerMode("SANalyzer");
            error = sa.SetRFCenterFrequency("2.4GHz");
            error = sa.SetStartStopFrequency(Convert.ToString(2.4 * Math.Pow(10, 9) - 250 * Math.Pow(10, 6)),
                                             Convert.ToString(2.4 * Math.Pow(10, 9) + 250 * Math.Pow(10, 6)));
            error = sa.SetMarkerControlMode(SignalAnalyzer_N9020A.MarkerNo.Marker1, "POSition");
            error = sa.SetMarkerXAxisFrequencyValue(SignalAnalyzer_N9020A.MarkerNo.Marker1, "2.4GHz");
            error = sa.TurnOnOffCrossLinesAtMarker(SignalAnalyzer_N9020A.MarkerNo.Marker1, SignalAnalyzer_N9020A.State.ON);

            double peakFreq = 0.00, peakAmpl = 0.00;
            error = sa.SearchMaxPeakPoint(SignalAnalyzer_N9020A.MarkerNo.Marker1, out peakFreq, out peakAmpl);

            error = sa.Close();
            error = sa.Close();
#endif
        }
    }
}
