using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ChatClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //client requires to establish endpoint(ip address, port number) to connect with the socket 
            IPHostEntry hostInfo = Dns.Resolve(Dns.GetHostName());
            IPAddress ip = hostInfo.AddressList[0];
            IPEndPoint remoteEndpoint = new IPEndPoint(ip, 1000);

            //intialize a socket
            Socket sender = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);
            //connect the socket with the remote end point

            try
            {
                sender.Connect(remoteEndpoint);

                Console.WriteLine("Connected", sender.RemoteEndPoint.ToString());

                //pass the data to check the connection with the socket

                byte[] array = Encoding.ASCII.GetBytes("Running my first test");
                int numOfBytes = sender.Send(array);

                //get the response from the remote endpoint

            }


        }
    }
}
