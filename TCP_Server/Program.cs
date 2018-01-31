using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace TCP_Server
{
    class Program
    {
        private static byte[] m_DataBuffer = new byte[1024];
        private static int m_Port = 8099;
        static Socket serverSocket;

        static void Main(string[] args)
        {
            IPAddress ip = IPAddress.Loopback;

            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(new IPEndPoint(ip, m_Port));
            serverSocket.Listen(15);        /* Listen to the connection request, max queue length : 15 */

            Console.WriteLine("Launch the listening {0} succeed.", serverSocket.LocalEndPoint.ToString());

            /******************************************************************************************************/

            /* When one TCP client connected this server, create a new thread. */
            Thread connectionThread = new Thread(ListenTcpClientConnect);
            connectionThread.Start();
        }

        private static void ListenTcpClientConnect()
        {
            while (true)
            {
                /* Blocked thread */
                Socket clientSocket = serverSocket.Accept();
                clientSocket.Send(Encoding.UTF8.GetBytes("Server said : Hello, client!"));
                Thread receiveThread = new Thread(ReceiveMessage);
                receiveThread.Start(clientSocket);
            }
        }

        private static void ReceiveMessage(Object clientSocket)
        {
            if (clientSocket != null)
            {
                Socket m_ClientSocket = clientSocket as Socket;
                while (true)
                {
                    try
                    {
                        int receiverNumber = m_ClientSocket.Receive(m_DataBuffer);
                        Console.WriteLine("Receiver client : {0}, Message : {1}", 
                                          m_ClientSocket.RemoteEndPoint.ToString(), 
                                          Encoding.UTF8.GetString(m_DataBuffer, 0, receiverNumber));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        m_ClientSocket.Shutdown(SocketShutdown.Both);
                        m_ClientSocket.Close();
                        break;
                    }
                }
            }
        }
    }
}
