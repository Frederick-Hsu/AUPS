using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilities
{
    public class NetworkTool_iPerf
    {
        private string iPerfCmd;
        private System.Diagnostics.Process iPerfCmdProc;

        public NetworkTool_iPerf(string iPerfExeFilePath)
        {
            iPerfCmd = iPerfExeFilePath;
        }

#if true
        public void StartIperf(bool createNoWindow = false,         /* Option : whether not to create DOS window */
                               bool useShellExecute = false,        /* Option : whether to start the Shell process */
                               bool redirectStandardInput = true,   /* Option : whether to redirect the input stream */
                               bool redirectStandardOutput = true,  /* Option : whether to redirect the output stream */
                               bool redirectStandardError = true)   /* Option : whether to redirect the error stream */
        {
            iPerfCmdProc = new System.Diagnostics.Process();
            iPerfCmdProc.StartInfo.FileName = "cmd.exe";

            iPerfCmdProc.StartInfo.CreateNoWindow = createNoWindow;
            iPerfCmdProc.StartInfo.UseShellExecute = useShellExecute;
            iPerfCmdProc.StartInfo.RedirectStandardInput = redirectStandardInput;
            iPerfCmdProc.StartInfo.RedirectStandardOutput = redirectStandardOutput;
            iPerfCmdProc.StartInfo.RedirectStandardError = redirectStandardError;

            iPerfCmdProc.Start();
        }

        public void StopIperf()
        {
            iPerfCmdProc.Close();
            iPerfCmdProc = null;
        }

        public void ExecuteIperf(string iPerfOptions, out string executionReturnedResult)
        {
            string commandStr = iPerfCmd + " " + iPerfOptions + "\r";

            iPerfCmdProc.StandardInput.WriteLine(commandStr + "&exit");
            iPerfCmdProc.StandardInput.AutoFlush = true;
            executionReturnedResult = iPerfCmdProc.StandardOutput.ReadToEnd();
            iPerfCmdProc.WaitForExit();
        }
#else
        System.Diagnostics.ProcessStartInfo procInfo;
        public void StartIperf(bool createNoWindow = false,
                               bool useShellExecute = false,
                               bool redirectStandardInput = true,
                               bool redirectStandardOutput = true,
                               bool redirectStandardError = true)
        {
            procInfo = new System.Diagnostics.ProcessStartInfo("cmd.exe");
            procInfo.CreateNoWindow = createNoWindow;
            procInfo.UseShellExecute = useShellExecute;
            procInfo.RedirectStandardInput = redirectStandardInput;
            procInfo.RedirectStandardOutput = redirectStandardOutput;
            procInfo.RedirectStandardError = redirectStandardError;

            iPerfCmdProc = System.Diagnostics.Process.Start(procInfo);
            iPerfCmdProc.OutputDataReceived += IPerfCmdProc_OutputDataReceived;
            iPerfCmdProc.ErrorDataReceived += IPerfCmdProc_ErrorDataReceived;
        }

        private void IPerfCmdProc_ErrorDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void IPerfCmdProc_OutputDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ExecuteIperf(string iPerfOptions, out string executionReturnedResult)
        {
            string commandStr = iPerfCmd + " " + iPerfOptions + "\r";
            iPerfCmdProc.StandardInput.WriteLine(commandStr + "&exit");
            iPerfCmdProc.StandardInput.AutoFlush = true;

            iPerfCmdProc.BeginOutputReadLine();
            iPerfCmdProc.BeginErrorReadLine();

            iPerfCmdProc.Exited += IPerfCmdProc_Exited;
        }

        private void IPerfCmdProc_Exited(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
#endif
    }
}
