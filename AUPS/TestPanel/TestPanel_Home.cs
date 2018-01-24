using System;
using Amphenol.SequenceLib;
using System.Windows.Forms;

namespace Amphenol.AUPS
{
    partial class TestPanel
    {
        private void btnStart_Click(object sender, EventArgs e)
        {
            bool flag = false;

            if (testSeq == null)
                return;

            /* Indicating the "Testing..." status */
            labelIndicator.Text = "Testing......";
            labelIndicator.ForeColor = System.Drawing.Color.Black;

            listViewTestItems.Items.Clear();        /* Clean up all old test steps */

            foreach (TestBlock block in testSeq.TestBlockList)
            {
                foreach (TestStep step in block.TestStepList)
                {
                    flag = step.PerformTestStep(testSeq.SeqXmlDoc);      /* Perform current test step */

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
        }

        private void SaveTestRecord()
        {
            string timestamp = System.DateTime.Now.ToString("yyyyMMddHHmmss");
            string sn = textBoxSerialNum.Text;

            string currDir = System.IO.Directory.GetCurrentDirectory();
            string recordFileName = currDir + "\\" + sn + "_" + timestamp + ".xml";

            testSeq.SaveAsTestRecord(recordFileName);
        }
    }
}