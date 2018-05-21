using System;
using System.Windows.Forms;

using Utilities;

namespace AUPS.Tools
{
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

        #region Antenna physical layer test items
        #endregion

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
    }
}