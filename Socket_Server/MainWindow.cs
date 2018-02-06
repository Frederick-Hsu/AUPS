using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace Socket_Server
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /*========================================================================================*/

        /* Call-back prototype : to solve the problem of trans-thread aceessing */
        private delegate void SetTextValueCallback(string strValue);

        /* Call-back prototype : to receive the message from client */
        private delegate void ReceiveMesgCallback(string strReceive);

        private SetTextValueCallback setCallback;
        private ReceiveMesgCallback  receiveCallback;

        /* Call-back prototype : Add elements for ComboBox control */
        private delegate void SetCmdCallback(string strItem);

        private SetCmdCallback setComboBox;

        private delegate void SendFileCallback(byte[] buffer);
        private SendFileCallback sendCallback;

        Socket socketSend;       /* socket for communicate */
        Socket socketWatch;      /* socket for watch */

        Dictionary<string, Socket> dicSocket = new Dictionary<string, Socket>();

        Thread acceptSocketThread;
        Thread receiveSocketThread;

        /*========================================================================================*/

        private void btnStartWatch_Click(object sender, EventArgs e)
        {
            socketWatch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ip = IPAddress.Parse(textBoxIPAddress.Text.Trim());
            IPEndPoint ip_port = new IPEndPoint(ip, Convert.ToInt32(textBoxPort.Text.Trim()));

            socketWatch.Bind(ip_port);
            textBoxLog.AppendText("Watching succeeds.\r\n");

            socketWatch.Listen(10);     /* Allow max. 10 simulataneous connections request */

            /* Instantiate these callbacks */
            setCallback = new SetTextValueCallback(SetTextValue);
            receiveCallback = new ReceiveMesgCallback(ReceiveMesg);
            setComboBox = new SetCmdCallback(AddComboBoxItem);
            sendCallback = new SendFileCallback(SendFile);

            /* Create thread */
            acceptSocketThread = new Thread(new ParameterizedThreadStart(StartListen));
            acceptSocketThread.IsBackground = true;
            acceptSocketThread.Start(socketWatch);
        }

        private void btnSendMesg_Click(object sender, EventArgs e)
        {
            try
            {
                string strMesg = textBoxMesg.Text.Trim();
                byte[] buffer = Encoding.Default.GetBytes(strMesg);
                List<byte> list = new List<byte>();
                list.Add(0);
                list.AddRange(buffer);

                byte[] newBuffer = list.ToArray();
                string ip = comboBoxSocket.SelectedItem.ToString();
                dicSocket[ip].Send(newBuffer);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurs when sending message to client : " + ex.Message);
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = @"";
            dlg.Title = "Please select file to send";
            dlg.Filter = "All files | *.*";
            dlg.ShowDialog();

            textBoxFilePath.Text = dlg.FileName;
        }

        private void btnSendFile_Click(object sender, EventArgs e)
        {
            List<byte> list = new List<byte>();
            string path = textBoxFilePath.Text.Trim();

            using (FileStream sw = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                byte[] buffer = new byte[1024];
                int len = sw.Read(buffer, 0, buffer.Length);
                list.Add(1);
                list.AddRange(buffer);

                byte[] newBuff = list.ToArray();
                btnSendFile.Invoke(sendCallback, newBuff);
            }
        }

        private void btnStopWatch_Click(object sender, EventArgs e)
        {
            /* Close the sockets */
            socketWatch.Close();
            socketSend.Close();
            /* Terminate the threads */
            acceptSocketThread.Abort();
            receiveSocketThread.Abort();
        }
    }
}
