using System;
using Amphenol.SequenceLib;
using System.Windows.Forms;
using System.Threading;

namespace Amphenol.AUPS
{
    partial class TestPanel
    {
        private static bool exitFlag = false;
        private static DateTime timer;
        private static int finishedStepNum = 0;

        private void btnStart_Click(object sender, EventArgs e)
        {
            bool flag = false;
            exitFlag = false;

            if (testSeq == null)
                return;

            /* Launch a thread to record the testing time specifically  */
            Thread timerThread = new Thread(TraceTestingTime);
            timerThread.IsBackground = true;    /* And this thread must run in background */
            timerThread.Start(int.Parse(testSeq.TotalStepNum().ToString()));

            timer = DateTime.Now;       /* Start to record the testing time */
            finishedStepNum = 0;        /* Reset this finishedStepNum when each test cycle starts */

            /* Indicating the "Testing..." status */
            labelIndicator.Text = "Testing......";
            labelIndicator.ForeColor = System.Drawing.Color.Black;

            listViewTestItems.Items.Clear();        /* Clean up all old test steps */

            foreach (TestBlock block in testSeq.TestBlockList)
            {
                foreach (TestStep step in block.TestStepList)
                {
                    string serialnumber = textBoxSerialNum.Text;        /* Get the serial number for current DUT */

                    flag = step.PerformTestStep(serialnumber, testSeq.SeqXmlDoc);      /* Perform current test step */
                    finishedStepNum++;

                    string[] stepSubItems = new string[3];
                    stepSubItems[0] = step.StepNum;
                    stepSubItems[1] = step.StepName;
                    stepSubItems[2] = step.StepConclusion.Status;
                    ListViewItem lvi = new ListViewItem(stepSubItems);
                    listViewTestItems.Items.Add(lvi);   /* Display current step in the ListView box */

                    int index = listViewTestItems.Items.Count;
                    /* Judge current step is "Pass" or "Fail", and indicate it in color mark. */
                    if (flag == false)
                    {
                        labelIndicator.Text = "FAIL";
                        labelIndicator.ForeColor = System.Drawing.Color.Red;

                        listViewTestItems.Items[index - 1].ForeColor = System.Drawing.Color.Red;

                        SaveTestRecord();
                        exitFlag = true;
                        return;
                    }
                    else
                    {
                        listViewTestItems.Items[index - 1].ForeColor = System.Drawing.Color.Green;
                    }
                }
            }

            labelIndicator.Text = "PASS";
            labelIndicator.ForeColor = System.Drawing.Color.Green;
            SaveTestRecord();
            exitFlag = true;
            return;
        }

        private void SaveTestRecord()
        {
            string timestamp = System.DateTime.Now.ToString("yyyyMMddHHmmss");
            string sn = textBoxSerialNum.Text;

            string currDir = System.IO.Directory.GetCurrentDirectory();
            string recordFileName = currDir + "\\" + sn + "_" + timestamp + ".xml";

            testSeq.SaveAsTestRecord(recordFileName);
        }

        private delegate void TraceTestingTimeDelegate(object number);

        private void TraceTestingTime(object number)
        {
            if (progressBarTestProgress.InvokeRequired)
            {
                TraceTestingTimeDelegate delg = TraceTestingTime;
                progressBarTestProgress.Invoke(delg, number);
            }
            else
            {
                progressBarTestProgress.Maximum = (int)number;
                while (exitFlag == false)
                {
                    progressBarTestProgress.Value = finishedStepNum;
                    toolStripStatusLabelElapsedTime.Text = "Elapsed time : " + DateTime.Now.Subtract(timer).ToString();

                    Application.DoEvents();     /* Allow other task to win enough CPU time slices to run. */
                }
                toolStripStatusLabelElapsedTime.Text = "Elapsed time : " + DateTime.Now.Subtract(timer).ToString();
            }
        }
    }
}