using System;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Socket_Client
{
    partial class MainWindow
    {
        private void SetValue(string strValue)
        {
            textBoxLog.AppendText(strValue + "\r\n");
        }

        /* Receive the message from server end. */
        private void Receive()
        {
            try
            {
                while (true)
                {
                    byte[] buffer = new byte[2048];
                    int len = sendSocket.Receive(buffer);
                    if (len == 0)
                    {
                        break;
                    }
                    else
                    {
                        if (buffer[0] == 0)     /* presents that character string were received. */
                        {
                            string str = Encoding.Default.GetString(buffer, 1, len - 1);
                            textBoxLog.Invoke(receiveCallback, "Receive remote server : " + sendSocket.RemoteEndPoint + "Message : " + str);
                        }
                        if (buffer[0] == 1)     /* presents that a file was received. */
                        {
                            SaveFileDialog dlg = new SaveFileDialog();
                            dlg.InitialDirectory = @"";
                            dlg.Title = "Please select the file name you want to save";
                            dlg.Filter = "All files | *.*";
                            dlg.ShowDialog(this);

                            string path = dlg.FileName;
                            using (FileStream fsWrite = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
                            {
                                fsWrite.Write(buffer, 1, len - 1);
                            }
                            MessageBox.Show("Saving file succeeds.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurs while receiving the message from server : " + ex.Message);
            }
        }
    }
}