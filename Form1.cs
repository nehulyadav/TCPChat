using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace ChatClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //connect
        private void button2_Click(object sender, EventArgs e)
        {
            TcpClient client = new TcpClient();
            IPEndPoint remoteEndpoint = new IPEndPoint(long.Parse(textBox2.Text), int.Parse(textBox3.Text));

            byte[] incoming = new byte[1024];

            //connect the socket with the remote end point

            try
            {
                //intialize a socket
                Socket sender = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.Tcp);
                sender.Connect(remoteEndpoint);

                Console.WriteLine("Connected", sender.RemoteEndPoint.ToString());

                //pass the data to check the connection with the socket

                byte[] array = Encoding.ASCII.GetBytes("Running my first test");
                int numOfBytes = sender.Send(array);

                //get the response from the remote endpoint
                int receivedBytes = sender.Receive(incoming);
                Console.WriteLine("Echoed test = {0}",
                    Encoding.ASCII.GetString(bytes, 0, bytesRec));

                // Release the socket.
                sender.Shutdown(SocketShutdown.Both);
                sender.Close();
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
            }
            catch (SocketException se)
            {
                Console.WriteLine("SocketException : {0}", se.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected exception : {0}", e.ToString());

            }

        }

    }

}
    
