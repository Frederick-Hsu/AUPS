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

        public void StartIperf(bool createNoWindow = true,          /* Option : whether not to create DOS window */
                               bool useShellExecute = false,        /* Option : whether to start the Shell process */
                               bool redirectStandardInput = true,   /* Option : whether to redirect the input stream */
                               bool redirectStandardOutput = true,  /* Option : whether to redirect the output stream */
                               bool redirectStandardError = true    /* Option : whether to redirect the error stream */)
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
    }
}
