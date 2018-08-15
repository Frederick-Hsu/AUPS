using System;
using System.Windows.Forms;
using Amphenol.Instruments.Keysight;
using Amphenol.Instruments.RohdeSchwarz;

using Utilities;

namespace AUPS.Tools
{
    public struct WLAN_Channel_Freq
    {
        public int channelNo;
        public int centerFreq;      /* unit : MHz */
        public int bandwidth;       /* unit : MHz */
    }

    partial class GMVehicleAntennaTesting
    {
#if false
        #region Antenna application layer test items
        private void IperfMeasureTCPUplinkPerformance(out string throughput)
        {
            /* Instantiate the iperf object */
            NetworkTool_iPerf iperf = new NetworkTool_iPerf(textBoxIperf3Path.Text);
            iperf.StartIperf();

            string options = "--client " + textBoxServerIP.Text + " --verbose --bandwidth 1G";
            string result;
            /* Carry out the testing */
            iperf.ExecuteIperf(options, out result);
            iperf.StopIperf();

            string[] array = result.Split(new char[] { '\n', '\r' });
            for (int index = 0; index < array.Length; index++)
            {
                textBoxIperfTestLog.AppendText(array[index] + System.Environment.NewLine);     /* Show the test log */
            }
            textBoxIperfTestLog.AppendText("============================================================================" + System.Environment.NewLine);

            ParseOutIperfTCPLog(result, out throughput);
        }

        private void IperfMeasureTCPDownlinkPerformance(out string throughput)
        {
            NetworkTool_iPerf iperf = new NetworkTool_iPerf(textBoxIperf3Path.Text);
            iperf.StartIperf();

            string options = "--client " + textBoxServerIP.Text + " --verbose --bandwidth 1G --reverse";
            string result;
            iperf.ExecuteIperf(options, out result);
            string[] array = result.Split(new char[] { '\n', '\r' });
            for (int index = 0; index < array.Length; index++)
            {
                textBoxIperfTestLog.AppendText(array[index] + System.Environment.NewLine);
            }
            textBoxIperfTestLog.AppendText("============================================================================" + System.Environment.NewLine);

            ParseOutIperfTCPLog(result, out throughput);
        }

        private void IperfMeasureUDPUplinkPerformance(out string throughput, out string latency, out string packetLoss)
        {
            NetworkTool_iPerf iperf = new NetworkTool_iPerf(textBoxIperf3Path.Text);
            iperf.StartIperf();

            string options = "--client " + textBoxServerIP.Text + " --verbose --bandwidth 1G --udp";
            string result;
            iperf.ExecuteIperf(options, out result);

            string[] array = result.Split(new char[] { '\n', '\r' });
            for (int index = 0; index < array.Length; index++)
            {
                textBoxIperfTestLog.AppendText(array[index] + System.Environment.NewLine);
            }
            textBoxIperfTestLog.AppendText("============================================================================" + System.Environment.NewLine);

            ParseOutIperfUdpLog(result, out throughput, out latency, out packetLoss);
        }

        private void IperfMeasureUDPDownlinkPerformance(out string throughput, out string latency, out string packetLoss)
        {
            NetworkTool_iPerf iperf = new NetworkTool_iPerf(textBoxIperf3Path.Text);
            iperf.StartIperf();

            string options = "--client " + textBoxServerIP.Text + " --verbose --bandwidth 1G --udp --reverse";
            string result;
            iperf.ExecuteIperf(options, out result);

            string[] array = result.Split(new char[] { '\n', '\r' });
            for (int index = 0; index < array.Length; index++)
            {
                textBoxIperfTestLog.AppendText(array[index] + Environment.NewLine);
            }
            textBoxIperfTestLog.AppendText("============================================================================" + System.Environment.NewLine);

            ParseOutIperfUdpLog(result, out throughput, out latency, out packetLoss);
        }
        #endregion
#endif

        /******************************************************************************************/
        #region WiFi Channel List, Center Frequency and Bandwidth : Table
                                                    /* 2.4GHz channel list, including 802.11b (DSSS), 802.11g/n (OFDM) */
        private WLAN_Channel_Freq[] channelList = { new WLAN_Channel_Freq { channelNo =   1, centerFreq = 2412, bandwidth = 20 },
                                                    new WLAN_Channel_Freq { channelNo =   2, centerFreq = 2417, bandwidth = 20 },
                                                    new WLAN_Channel_Freq { channelNo =   3, centerFreq = 2422, bandwidth = 40 },
                                                    new WLAN_Channel_Freq { channelNo =   4, centerFreq = 2427, bandwidth = 20 },
                                                    new WLAN_Channel_Freq { channelNo =   5, centerFreq = 2432, bandwidth = 20 },
                                                    new WLAN_Channel_Freq { channelNo =   6, centerFreq = 2437, bandwidth = 20 },
                                                    new WLAN_Channel_Freq { channelNo =   7, centerFreq = 2442, bandwidth = 20 },
                                                    new WLAN_Channel_Freq { channelNo =   8, centerFreq = 2447, bandwidth = 20 },
                                                    new WLAN_Channel_Freq { channelNo =   9, centerFreq = 2452, bandwidth = 20 },
                                                    new WLAN_Channel_Freq { channelNo =  10, centerFreq = 2457, bandwidth = 20 },
                                                    new WLAN_Channel_Freq { channelNo =  11, centerFreq = 2462, bandwidth = 20 },
                                                    new WLAN_Channel_Freq { channelNo =  12, centerFreq = 2467, bandwidth = 20 },
                                                    new WLAN_Channel_Freq { channelNo =  13, centerFreq = 2472, bandwidth = 20 },
                                                    new WLAN_Channel_Freq { channelNo =  14, centerFreq = 2484, bandwidth = 22 },
                                                    /* 5.0GHz channel list, including 802.11a/ac */
                                                    new WLAN_Channel_Freq { channelNo =  16, centerFreq = 5080, bandwidth = 20 },
                                                    new WLAN_Channel_Freq { channelNo =  36, centerFreq = 5180, bandwidth = 20 },
                                                    new WLAN_Channel_Freq { channelNo =  38, centerFreq = 5190, bandwidth = 40 },
                                                    new WLAN_Channel_Freq { channelNo =  40, centerFreq = 5200, bandwidth = 20 },
                                                    new WLAN_Channel_Freq { channelNo =  42, centerFreq = 5210, bandwidth = 80 },
                                                    new WLAN_Channel_Freq { channelNo =  44, centerFreq = 5220, bandwidth = 20 },
                                                    new WLAN_Channel_Freq { channelNo =  46, centerFreq = 5230, bandwidth = 40 },
                                                    new WLAN_Channel_Freq { channelNo =  48, centerFreq = 5240, bandwidth = 20 },
                                                    new WLAN_Channel_Freq { channelNo =  50, centerFreq = 5250, bandwidth = 160},
                                                    new WLAN_Channel_Freq { channelNo =  52, centerFreq = 5260, bandwidth = 20 },
                                                    new WLAN_Channel_Freq { channelNo =  54, centerFreq = 5270, bandwidth = 40 },
                                                    new WLAN_Channel_Freq { channelNo =  56, centerFreq = 5280, bandwidth = 20 },
                                                    new WLAN_Channel_Freq { channelNo =  58, centerFreq = 5290, bandwidth = 80 },
                                                    new WLAN_Channel_Freq { channelNo =  60, centerFreq = 5300, bandwidth = 20 },
                                                    new WLAN_Channel_Freq { channelNo =  62, centerFreq = 5310, bandwidth = 40 },
                                                    new WLAN_Channel_Freq { channelNo =  64, centerFreq = 5320, bandwidth = 20 },
                                                    new WLAN_Channel_Freq { channelNo = 100, centerFreq = 5500, bandwidth = 20 },
                                                    new WLAN_Channel_Freq { channelNo = 102, centerFreq = 5510, bandwidth = 40 },
                                                    new WLAN_Channel_Freq { channelNo = 104, centerFreq = 5520, bandwidth = 20 },
                                                    new WLAN_Channel_Freq { channelNo = 106, centerFreq = 5530, bandwidth = 80 },
                                                    new WLAN_Channel_Freq { channelNo = 108, centerFreq = 5540, bandwidth = 20 },
                                                    new WLAN_Channel_Freq { channelNo = 110, centerFreq = 5550, bandwidth = 40 },
                                                    new WLAN_Channel_Freq { channelNo = 112, centerFreq = 5560, bandwidth = 20 },
                                                    new WLAN_Channel_Freq { channelNo = 114, centerFreq = 5570, bandwidth = 160},
                                                    new WLAN_Channel_Freq { channelNo = 116, centerFreq = 5580, bandwidth = 20 },
                                                    new WLAN_Channel_Freq { channelNo = 118, centerFreq = 5590, bandwidth = 40 },
                                                    new WLAN_Channel_Freq { channelNo = 120, centerFreq = 5600, bandwidth = 20 },
                                                    new WLAN_Channel_Freq { channelNo = 122, centerFreq = 5610, bandwidth = 80 },
                                                    new WLAN_Channel_Freq { channelNo = 124, centerFreq = 5620, bandwidth = 20 },
                                                    new WLAN_Channel_Freq { channelNo = 126, centerFreq = 5630, bandwidth = 40 },
                                                    new WLAN_Channel_Freq { channelNo = 128, centerFreq = 5640, bandwidth = 20 },
                                                    new WLAN_Channel_Freq { channelNo = 132, centerFreq = 5660, bandwidth = 20 },
                                                    new WLAN_Channel_Freq { channelNo = 134, centerFreq = 5670, bandwidth = 40 },
                                                    new WLAN_Channel_Freq { channelNo = 136, centerFreq = 5680, bandwidth = 20 },
                                                    new WLAN_Channel_Freq { channelNo = 138, centerFreq = 5690, bandwidth = 80 },
                                                    new WLAN_Channel_Freq { channelNo = 140, centerFreq = 5700, bandwidth = 20 },
                                                    new WLAN_Channel_Freq { channelNo = 142, centerFreq = 5710, bandwidth = 40 },
                                                    new WLAN_Channel_Freq { channelNo = 144, centerFreq = 5720, bandwidth = 20 },
                                                    new WLAN_Channel_Freq { channelNo = 149, centerFreq = 5745, bandwidth = 20 },
                                                    new WLAN_Channel_Freq { channelNo = 151, centerFreq = 5755, bandwidth = 40 },
                                                    new WLAN_Channel_Freq { channelNo = 153, centerFreq = 5765, bandwidth = 20 },
                                                    new WLAN_Channel_Freq { channelNo = 155, centerFreq = 5775, bandwidth = 80 },
                                                    new WLAN_Channel_Freq { channelNo = 157, centerFreq = 5785, bandwidth = 20 },
                                                    new WLAN_Channel_Freq { channelNo = 159, centerFreq = 5795, bandwidth = 40 },
                                                    new WLAN_Channel_Freq { channelNo = 161, centerFreq = 5805, bandwidth = 20 },
                                                    new WLAN_Channel_Freq { channelNo = 165, centerFreq = 5825, bandwidth = 20 },
                                                    new WLAN_Channel_Freq { channelNo = 169, centerFreq = 5845, bandwidth = 20 },
                                                    new WLAN_Channel_Freq { channelNo = 173, centerFreq = 5865, bandwidth = 20 },
                                                    new WLAN_Channel_Freq { channelNo = 183, centerFreq = 4915, bandwidth = 10 },
                                                    new WLAN_Channel_Freq { channelNo = 184, centerFreq = 4920, bandwidth = 20 },
                                                    new WLAN_Channel_Freq { channelNo = 185, centerFreq = 4925, bandwidth = 10 },
                                                    new WLAN_Channel_Freq { channelNo = 187, centerFreq = 4935, bandwidth = 10 },
                                                    new WLAN_Channel_Freq { channelNo = 188, centerFreq = 4940, bandwidth = 20 },
                                                    new WLAN_Channel_Freq { channelNo = 189, centerFreq = 4945, bandwidth = 10 },
                                                    new WLAN_Channel_Freq { channelNo = 192, centerFreq = 4960, bandwidth = 20 },
                                                    new WLAN_Channel_Freq { channelNo = 196, centerFreq = 4980, bandwidth = 20 } };
        #endregion

        private void GMVehicleAntennaTesting_Load(object sender, EventArgs e)
        {
            for (int index = 0; index < channelList.Length; index++)
            {
                comboBoxChannel.Items.Add(channelList[index].channelNo);
            }
        }

        private void comboBoxChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = 0;
            for (index = 0; index < channelList.Length; index++)
            {
                if (Convert.ToInt32(comboBoxChannel.Text) == channelList[index].channelNo)
                {
                    break;
                }
            }
            string freq = Convert.ToString(channelList[index].centerFreq);
            string bandwidth = Convert.ToString(channelList[index].bandwidth);
            textBoxFreqBand.Text = freq;
            comboBoxBandWidth.Text = bandwidth;
        }

        /******************************************************************************************/

        #region Antenna application layer test items
        private System.Diagnostics.Process iPerfCmdProc;
        private string iPerfCmd;
        private string serverIP;

        private void InitializeIperfProcess()
        {
            iPerfCmd = textBoxIperf3Path.Text.Trim();   /* retrieve the iperf3.exe path */
            serverIP = textBoxServerIP.Text.Trim();     /* retrieve the server IP address */

            // iPerfCmdProc.OutputDataReceived -= new System.Diagnostics.DataReceivedEventHandler(IPerfCmdProc_OutputDataReceived);
            iPerfCmdProc = new System.Diagnostics.Process();
            iPerfCmdProc.StartInfo.FileName = "cmd.exe";

            iPerfCmdProc.StartInfo.CreateNoWindow = true;
            iPerfCmdProc.StartInfo.UseShellExecute = false;
            iPerfCmdProc.StartInfo.RedirectStandardInput = true;
            iPerfCmdProc.StartInfo.RedirectStandardOutput = true;
            iPerfCmdProc.StartInfo.RedirectStandardError = true;

            iPerfCmdProc.Start();
            // iPerfCmdProc.BeginOutputReadLine();
            // iPerfCmdProc.OutputDataReceived += new System.Diagnostics.DataReceivedEventHandler(IPerfCmdProc_OutputDataReceived);
        }

        private void IPerfCmdProc_OutputDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e)
        {
            if (textBoxIperfTestLog.InvokeRequired)
            {
                textBoxIperfTestLog.Invoke(new Action(()=>
                {
                    textBoxIperfTestLog.AppendText(e.Data + Environment.NewLine);
                }));
            }
            else
            {
                textBoxIperfTestLog.AppendText(e.Data + Environment.NewLine);
            }
        }

        private void CloseIperfProcess()
        {
            iPerfCmdProc.Close();
            iPerfCmdProc = null;
        }

        private void MeasureUdpUplinkPerformance(out string throughput, out string latency, out string packetLoss)
        {
            string commandStr = iPerfCmd + " --client " + serverIP + " --verbose --udp --bandwidth 1G\r";

            iPerfCmdProc.StandardInput.WriteLine(commandStr + "&exit");
            iPerfCmdProc.StandardInput.AutoFlush = true;
            
            while (iPerfCmdProc.HasExited == false)
            {
                Application.DoEvents();
            }
            string executionResult = iPerfCmdProc.StandardOutput.ReadToEnd();
            DisplayIperfTestLog(executionResult);
            ParseOutIperfUdpLog(executionResult, out throughput, out latency, out packetLoss);
        }

        private void MeasureUdpDownlinkPerformance(out string throughput, out string latency, out string packetLoass)
        {
            string commandStr = iPerfCmd + " --client " + serverIP + " --verbose --udp --bandwidth 1G --reverse\r";

            iPerfCmdProc.StandardInput.WriteLine(commandStr + "&exit");
            iPerfCmdProc.StandardInput.AutoFlush = true;
            
            while (iPerfCmdProc.HasExited == false)
            {
                Application.DoEvents();
            }
            string executionResult = iPerfCmdProc.StandardOutput.ReadToEnd();
            DisplayIperfTestLog(executionResult);
            ParseOutIperfUdpLog(executionResult, out throughput, out latency, out packetLoass);
        }

        private void MeasureTcpUplinkPerformance(out string throughput)
        {
            string commandStr = iPerfCmd + " --client " + serverIP + " --verbose --bandwidth 1G\r";

            iPerfCmdProc.StandardInput.WriteLine(commandStr + "&exit");
            iPerfCmdProc.StandardInput.AutoFlush = true;

            while (iPerfCmdProc.HasExited == false)
            {
                Application.DoEvents();
            }
            string executionResult = iPerfCmdProc.StandardOutput.ReadToEnd();
            DisplayIperfTestLog(executionResult);
            ParseOutIperfTCPLog(executionResult, out throughput);
        }

        private void MeasureTcpDownlinkPerformance(out string throughput)
        {
            string commandStr = iPerfCmd + " --client " + serverIP + " --verbose --bandwidth 1G --reverse\r";

            iPerfCmdProc.StandardInput.WriteLine(commandStr + "&exit");
            iPerfCmdProc.StandardInput.AutoFlush = true;

            while (iPerfCmdProc.HasExited == false)
            {
                Application.DoEvents();
            }
            string executionResult = iPerfCmdProc.StandardOutput.ReadToEnd();
            DisplayIperfTestLog(executionResult);
            ParseOutIperfTCPLog(executionResult, out throughput);
        }

        private void DisplayIperfTestLog(string testLog)
        {
            string[] array = testLog.Split(new char[] { '\n' });
            for (int index = 0; index < array.Length; index++)
            {
                textBoxIperfTestLog.AppendText(array[index] + Environment.NewLine);
            }
            textBoxIperfTestLog.AppendText("============================================================================" + System.Environment.NewLine);
        }

        private void ParseOutIperfTCPLog(string iperfLog, out string bandWidth)
        {
            if (iperfLog.Contains("iperf Done.") != true)
            {
                MessageBox.Show("Failed to connect with server.\nCheck your network connectivity, and try again.", "Error");
                bandWidth = string.Empty;
                return;
            }

            string summaryResults = iperfLog.Substring(iperfLog.IndexOf("Test Complete."));
            string[] lines = summaryResults.Split(new char[] { '\n' });
            /* lines[2] stores the measurement values */
            string[] measurements = lines[2].Split(new char[] { ' ' });

            bandWidth = string.Empty;
            for (int index = 0; index < measurements.Length; index++)
            {
                if (measurements[index].Contains("bits/sec") == true)
                {
                    bandWidth = measurements[index - 1] + measurements[index];
                    break;
                }
            }
        }

        private void ParseOutIperfUdpLog(string iperfLog, out string throughput, out string latency, out string packetLoss)
        {
            if (iperfLog.Contains("iperf Done.") != true)
            {
                MessageBox.Show("Failed to connect with server.\nCheck your network connectivity, and try again.", "Error");
                throughput = string.Empty;
                latency = string.Empty;
                packetLoss = string.Empty;
                return;
            }

            string summaryResults = iperfLog.Substring(iperfLog.IndexOf("Test Complete."));
            string[] lines = summaryResults.Split(new char[] { '\n' });
            string[] measurements = lines[2].Split(new char[] { ' ' });

            throughput = string.Empty;
            latency = string.Empty;
            packetLoss = string.Empty;

            for (int index = 0; index < measurements.Length; index++)
            {
                if (measurements[index].Contains("bits/sec") == true)
                {
                    throughput = measurements[index - 1] + measurements[index];
                    continue;
                }
                if (measurements[index].Contains("ms") == true)
                {
                    latency = measurements[index - 1] + measurements[index];
                    continue;
                }
                if (measurements[index].Contains("%)") == true)
                {
                    packetLoss = measurements[index - 1] + measurements[index];
                    continue;
                }
            }
        }
        #endregion

        #region Antenna physical layer test items
#if false
        private void MeasureRSSI(string signalAnalyzerVisaAddress)
        {
            int error = 0;
            string identifier = "";
            SignalAnalyzer_N9020A sa = new SignalAnalyzer_N9020A();
            error = sa.Open(signalAnalyzerVisaAddress);
            error = sa.GetInstrumentIdentifier(out identifier);
            error = sa.ClearStatusAndErrorQueue();

            error = sa.SelectMeasurementMode("SA");
            string application;
            error = sa.QueryWhichModeToBeSelected(out application);

            sa.SelectMeasurementItemInSignalAnalyzerMode();

            error = sa.SetWindowTiled();
            error = sa.SelectActiveWindowAt(1);
            error = sa.TurnOnOffFullDisplay(SignalAnalyzer_N9020A.State.OFF);
            int windowNo = 0;
            error = sa.QueryWhichWindowToBeSelected(out windowNo);
            int result;
            error = sa.SelfTestQuery(out result);
            error = sa.SetRFInputImpedanceCorrection(SignalAnalyzer_N9020A.Impedance.IMPEDANCE_50Ohms);
            SignalAnalyzer_N9020A.Impedance imp;
            error = sa.GetRFInputImpedanceCorrection(out imp);
            error = sa.SelectRFInputCoupling(SignalAnalyzer_N9020A.RFCoupling.AC);
            string coupling = "";
            error = sa.QueryRFInputCoupling(out coupling);
            string calibrator;
            error = sa.QueryRFCalibrator(out calibrator);
            error = sa.SetExtPreampGainForSA(-5);
            double gain;
            error = sa.GetExtPreampGainForSA(out gain);
            error = sa.SetAntennaFieldStrengthUnit(SignalAnalyzer_N9020A.PowerFieldStrenghUnit.PTESla);
            string unit;
            error = sa.GetAntennaFieldStrengthUnit(out unit);
            string state;
            error = sa.QueryAmplitudeCorrectionsState(out state);
            error = sa.EraseAllAmplitudeCorrections();
            string model;
            error = sa.QueryCurrentApplicationModelName(out model);
            string revision, options;
            error = sa.QueryCurrentApplicationRevision(out revision);
            error = sa.QueryCurrentApplicationOptions(out options);
            string radioStandard;
            error = sa.SelectRadioStandardInSpectrumAnalyzerMode("NONE");
            error = sa.QueryWhichRadioStandardToBeSelected(out radioStandard);
            string device;
            error = sa.SpecifyRadioStandardDeviceType("BTS");
            error = sa.QueryRadioStandardDeviceType(out device);

            int calibrationDone;
            error = sa.QueryAllCalibrationDone(out calibrationDone);

            // string[] modes;
            // error = sa.QueryInstalledApplicationModeCatalog(out modes);
            double refLevel = 12.25;
            error = sa.SetAmplitudeYScaleReferenceLevel(1, refLevel);
            error = sa.QueryAmplitudeYScaleReferenceLevel(1, out refLevel);
            uint attenuator = 25;
            error = sa.SetAmplitudeYScaleAttenuation(attenuator);
            error = sa.QueryAmplitudeYScaleAttenuation(out attenuator);
            error = sa.EnableAmplitudeYScaleAttenuationAuto(SignalAnalyzer_N9020A.State.ON);

            error = sa.ChooseAmplitudeYScaleType("LOG");
            error = sa.SetAmplitudeYAxisUnit("dBm");
            error = sa.SetAmplitudeYScaleDivision(1);
            error = sa.SetAmplitudeYScaleReferenceLevel(1, 10, "dBm");

            /*
            error = sa.ChooseAmplitudeYScaleType("LIN");
            error = sa.SetAmplitudeYAxisUnit("V");
            error = sa.SetAmplitudeYScaleDivision(10);
            error = sa.SetAmplitudeYScaleReferenceLevel(1, 100, "mV");
             */
            uint resBW = 240000, videoBW = 150000;
            error = sa.SetAutoCoupleFeature("ALL");
            error = sa.ToggleResolutionBandwidthAutoManualMode(SignalAnalyzer_N9020A.State.OFF);
            error = sa.SetResolutionBandwidthValue(resBW);
            error = sa.QueryResolutionBandwidth(out resBW);

            error = sa.ToggleVideoBandwidthAutoManualMode(SignalAnalyzer_N9020A.State.OFF);
            error = sa.SetVideoBandwidthValue(videoBW);
            error = sa.QueryVideoBandwidth(out videoBW);

            error = sa.SetStartStopFrequency((2400000000 - 10000000).ToString(), (2400000000 + 10000000).ToString());
            long centerFreq;
            error = sa.RetrieveRFCenterFrequency(out centerFreq);
            error = sa.SetMarkerControlMode(SignalAnalyzer_N9020A.MarkerNo.Marker1, SignalAnalyzer_N9020A.MarkerControlMode[0]);
            error = sa.SetMarkerXAxisFrequencyValue(SignalAnalyzer_N9020A.MarkerNo.Marker1, "2.4GHz");

            double freq, power;
            error = sa.QuerySpecificMarkerXAxisFrequency(SignalAnalyzer_N9020A.MarkerNo.Marker1, out freq);
            error = sa.QueryMarkerYAxisValue(SignalAnalyzer_N9020A.MarkerNo.Marker1, out power);

            error = sa.SearchMaxPeakPoint(SignalAnalyzer_N9020A.MarkerNo.Marker1, out freq, out power);
            sa.Close();
        }
#endif
        private int MeasureRSSI(int freq, int bandWidth, double power, out double rssiValue)
        {
            int state = 0;
            /* Initialize signal analyzer : Keysight N9020A */
            SignalAnalyzer_N9020A sa = new SignalAnalyzer_N9020A();
            state = sa.Open(textBoxSaVisaAddress.Text);
            string sa_idn;
            state = sa.GetInstrumentIdentifier(out sa_idn);

            /* Initialize signal generator : Rohde & Schwarz SMB 100A */
            SignalGenerator_SMB100A sg = new SignalGenerator_SMB100A();
            state = sg.Open(textBoxSgVisaAddress.Text);
            string sg_idn;
            state = sg.GetInstrumentIdentifier(out sg_idn);

            /* Setup signal generator */
            state = sg.CleanAllErrorQueue();
            state = sg.PresetInstrument();
            state = sg.SetRFOutputSignalFrequency(freq.ToString() + "MHz");    /* RF center frequency */
            state = sg.SetRFLevelAppliedOntoDUT(power);     /* Tx RF level */
            state = sg.RFSignalOutputOnOff(SignalGenerator_SMB100A.State.ON);       /* RF output ON */

            /* Setup signal analyzer */
            state = sa.ClearStatusAndErrorQueue();
            state = sa.RestoreAllModesGlobalSettingsToDefault();
            state = sa.SelectMeasurementMode("SA");
            state = sa.SelectMeasurementItemInSignalAnalyzerMode("SANalyzer");
            state = sa.SetRFCenterFrequency(freq.ToString() + "MHz");      /* set central frequency */
            state = sa.SetStartStopFrequency(Convert.ToString(freq - bandWidth/2) + "MHz",
                                             Convert.ToString(freq + bandWidth/2) + "MHz");    /* Set frequency span : start freq. and end freq. */
            state = sa.SetMarkerControlMode(SignalAnalyzer_N9020A.MarkerNo.Marker1, "POSition");    /* Trigger on Marker */
            System.Threading.Thread.Sleep(2000);
            state = sa.SetMarkerXAxisFrequencyValue(SignalAnalyzer_N9020A.MarkerNo.Marker1, freq.ToString() + "MHz");
            state = sa.TurnOnOffCrossLinesAtMarker(SignalAnalyzer_N9020A.MarkerNo.Marker1, SignalAnalyzer_N9020A.State.ON);     /* Display the cross lines at marker */
            System.Threading.Thread.Sleep(2000);

            double peakFreq = 0.00, peakAmpl = 0.00;
            /* Peak marker search, output peak freq. and amplitude. */
            state = sa.SearchMaxPeakPoint(SignalAnalyzer_N9020A.MarkerNo.Marker1, out peakFreq, out peakAmpl);

            /* Close SG and SA */
            state = sg.Close();
            state = sa.Close();

            rssiValue = peakAmpl;
            return state;
        }
        #endregion
    }
}