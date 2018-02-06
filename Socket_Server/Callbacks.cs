using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading;

namespace Socket_Server
{
    partial class MainWindow
    {
        private void SetTextValue(string strValue)
        {
            textBoxLog.AppendText(strValue + "\r\n");
        }

        private void ReceiveMesg(string strMesg)
        {
            textBoxLog.AppendText(strMesg + "\r\n");
        }

        private void AddComboBoxItem(string strItem)
        {
            comboBoxSocket.Items.Add(strItem);
        }

        private void SendFile(byte[] buffer)
        {
            try
            {
                dicSocket[comboBoxSocket.SelectedItem.ToString()].Send(buffer, SocketFlags.None);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error occurs wehen sending file : " + ex.Message);
            }
        }

        private void StartListen(object obj)
        {
            socketWatch = obj as Socket;
            while (true)
            {
                /* Wait for client's connection, 
                 * and create a new socket for communication after connected.
                 */
                socketSend = socketWatch.Accept();
                /* Acquire the IP and port of remote host */
                string remoteHostIpPort = socketSend.RemoteEndPoint.ToString();
                dicSocket.Add(remoteHostIpPort, socketSend);
                comboBoxSocket.Invoke(setComboBox, remoteHostIpPort);

                string mesg = "Remote host : " + socketSend.RemoteEndPoint + "connection succeeds.";
                textBoxLog.Invoke(setCallback, mesg);

                /* Define the thread to receive the client's message. */
                receiveSocketThread = new Thread(new ParameterizedThreadStart(Receive));
                receiveSocketThread.IsBackground = true;
                receiveSocketThread.Start(socketSend);
            }
        }

        private void Receive(object obj)
        {
            socketSend = obj as Socket;
            while (true)
            {
                byte[] buffer = new byte[2048];
                int count = socketSend.Receive(buffer);
                if (count == 0)
                {
                    break;
                }
                else
                {
                    string str = Encoding.Default.GetString(buffer, 0, count);
                    string strReceivedMesg = "Received : " + socketSend.RemoteEndPoint + "Sent message : " + str;
                    textBoxLog.Invoke(receiveCallback, strReceivedMesg);
                }
            }
        }
    }
}
