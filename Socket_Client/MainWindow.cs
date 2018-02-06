using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.Net;

namespace Socket_Client
{
    delegate void SetTextCallback(string strValue);
    delegate void ReceiveMesgCallback(string strMesg);

    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /*========================================================================================*/
        private SetTextCallback setCallback;
        private ReceiveMesgCallback receiveCallback;

        private Socket sendSocket;
        private Thread receiveThread;

        /*========================================================================================*/

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                sendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress ip = IPAddress.Parse(textBoxIPAddress.Text.Trim());
                sendSocket.Connect(ip, Convert.ToInt32(textBoxPort.Text.Trim()));

                /* Instantiate the callbacks */
                setCallback = new SetTextCallback(SetValue);
                receiveCallback = new ReceiveMesgCallback(SetValue);

                textBoxLog.Invoke(setCallback, "Connection succeeds.");

                /* Create a background thread to received the message from server end. */
                receiveThread = new Thread(new ThreadStart(Receive));
                receiveThread.IsBackground = true;
                receiveThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurs while connecting to server : " + ex.Message);
            }
        }

        private void btnSendMesg_Click(object sender, EventArgs e)
        {
            try
            {
                string strMesg = textBoxMesg.Text.Trim();
                byte[] buffer = new byte[2048];
                buffer = Encoding.Default.GetBytes(strMesg);
                int len = sendSocket.Send(buffer);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurs while sending message : " + ex.Message);
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            sendSocket.Close();
            receiveThread.Abort();
        }
    }
}
