using System;
using Amphenol.SequenceLib;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;

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
#if false
            /* Launch a thread to record the testing time specifically  */
            Thread timerThread = new Thread(TraceTestingTime);
            timerThread.IsBackground = true;    /* And this thread must run in background */
            timerThread.Start(int.Parse(testSeq.TotalStepNum().ToString()));
#endif
            timer = DateTime.Now;       /* Start to record the testing time */
            TraceAndShowTestingTime();
            finishedStepNum = 0;        /* Reset this finishedStepNum when each test cycle starts */
            int totalStepNum = testSeq.TotalStepNum();
            progressBarTestProgress.Maximum = totalStepNum;
            progressBarTestProgress.Minimum = 0;

            /* Indicating the "Testing..." status */
            labelIndicator.Text = "Testing......";
            labelIndicator.ForeColor = System.Drawing.Color.Black;

            listViewTestItems.Items.Clear();        /* Clean up all old test steps */
            string serialnumber = textBoxSerialNum.Text;        /* Get the serial number for current DUT */
            if (serialnumber == "")
                return;

            testSeq.Refresh();
            Font font = new Font("Microsoft Sans Serif", (float)11, System.Drawing.FontStyle.Regular);
            PointF pt = new PointF(progressBarTestProgress.Width / 2 - 10, progressBarTestProgress.Height / 2 - 10);
            foreach (TestBlock block in testSeq.TestBlockList)
            {
                foreach (TestStep step in block.TestStepList)
                {
                    flag = step.PerformTestStep(serialnumber, testSeq.SeqXmlDoc);      /* Perform current test step */
                    finishedStepNum++;
                    progressBarTestProgress.CreateGraphics().DrawString((finishedStepNum + " / " + totalStepNum), font, Brushes.Black, pt);
                    progressBarTestProgress.Value = finishedStepNum;

                    string[] stepSubItems = new string[4];
                    stepSubItems[0] = step.StepNum;
                    stepSubItems[1] = step.StepName;
                    stepSubItems[2] = step.StepConclusion.Status;
                    // stepSubItems[3] = step.StepSpec.Result;
                    ListViewItem lvi = new ListViewItem(stepSubItems);
                    listViewTestItems.Items.Add(lvi);   /* Display current step in the ListView box */

                    int index = listViewTestItems.Items.Count;
                    listViewTestItems.Items[index - 1].EnsureVisible();   /* Ensure the selected row is visible */

                    /* Judge current step is "Pass" or "Fail", and indicate it in color mark. */
                    if (flag == false)
                    {
                        labelIndicator.Text = "FAIL";
                        labelIndicator.ForeColor = System.Drawing.Color.Red;   
                        listViewTestItems.Items[index - 1].ForeColor = System.Drawing.Color.Red;

                        SaveTestRecord("FAIL");
                        exitFlag = true;

                        textBoxSerialNum.SelectAll();
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
            SaveTestRecord("PASS");
            exitFlag = true;

            textBoxSerialNum.SelectAll();
            return;
        }

        private void SaveTestRecord(string finalConclusion)
        {
            string timestamp = System.DateTime.Now.ToString("yyyyMMddHHmmss");
            string sn = textBoxSerialNum.Text;

            string currDir = System.IO.Directory.GetCurrentDirectory();
            string recordFileName = currDir + "\\" + sn + "_" + timestamp + ".xml";

            testSeq.SaveAsTestRecord(recordFileName);
            testSeq.StoreTestResultsIntoPostgresqlDatabase(sn, finalConclusion);
            testSeq.StoreTestXmlLogIntoPostgresqlDatabase(sn, finalConclusion);
        }

#if false
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
                // progressBarTestProgress.Maximum = (int)number;
                while (exitFlag == false)
                {
                    // progressBarTestProgress.Value = finishedStepNum;
                    toolStripStatusLabelElapsedTime.Text = "Elapsed time : " + DateTime.Now.Subtract(timer).ToString();

                    Application.DoEvents();     /* Allow other task to win enough CPU time slices to run. */
                }
                toolStripStatusLabelElapsedTime.Text = "Elapsed time : " + DateTime.Now.Subtract(timer).ToString();
            }
        }
#endif
        private void TraceAndShowTestingTime()
        {
            Thread traceTimeThread = new Thread(new ThreadStart(()=>
            {
                while (exitFlag == false)
                {
                    labelElapsedTime.BeginInvoke(new MethodInvoker(()=>labelElapsedTime.Text = "Elapsed time : " + DateTime.Now.Subtract(timer).ToString()));
                    Application.DoEvents();
                    // Thread.Sleep(100);
                }
            }));
            traceTimeThread.IsBackground = true;
            traceTimeThread.Start();
        }
    }
}