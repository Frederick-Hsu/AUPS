using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace TCP_Client
{
    class Program
    {
        private static byte[] m_DataBuffer = new byte[1024];

        static void Main(string[] args)
        {
            IPAddress ip = IPAddress.Parse("192.168.30.52");
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                clientSocket.Connect(new IPEndPoint(ip, 8099));
                Console.WriteLine("Connecting to the server Succeeded.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connecting to server Failed. \nPress Enter to exit");
                Console.WriteLine(ex.Message);
                return;
            }

            /* Receive the data over clientSocket */
            int receiveLength = clientSocket.Receive(m_DataBuffer);
            Console.WriteLine("Receive the message from server : {0}", 
                              Encoding.UTF8.GetString(m_DataBuffer, 0, receiveLength));

            for (int n = 0; n < 10; n++)
            {
                try
                {
                    Thread.Sleep(1000);
                    string sendMesg = string.Format("{0} It is now {1}", "Hello, server!", DateTime.Now.ToString());
                    clientSocket.Send(Encoding.UTF8.GetBytes(sendMesg));
                    Console.WriteLine("Send message to server : {0}", sendMesg);
                }
                catch
                {
                    clientSocket.Shutdown(SocketShutdown.Both);
                    clientSocket.Close();
                    break;
                }
            }

            Console.WriteLine("Sending completed. \nPress Enter to exit.");
            Console.ReadKey();
        }
    }
}
