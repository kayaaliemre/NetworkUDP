using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetworkUDP
{
    public partial class Form1 : Form
    {
        public string SendingFilePath = string.Empty;
        private const int BufferSize = 1000;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(EventArgs e)
        {
            byte[] data = new byte[1024];
            string input, stringData;
            IPEndPoint ip = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);

            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            string welcome = "Hello";
            data = Encoding.ASCII.GetBytes(welcome);
            server.SendTo(data, data.Length, SocketFlags.None, ip);

            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
            EndPoint Remote = (EndPoint)sender;

            data = new byte[1024];
            int receivedDataLength = server.ReceiveFrom(data, ref Remote);

            Console.WriteLine("Message received from {0}:", Remote.ToString());
            Console.WriteLine(Encoding.ASCII.GetString(data, 0, receivedDataLength));

            server.Close();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            byte[] data = new byte[1024];
            string input, stringData;
            IPEndPoint ip = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);

            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            string welcome = "Hello";
            data = Encoding.ASCII.GetBytes(welcome);
            server.SendTo(data, data.Length, SocketFlags.None, ip);

            sender = new IPEndPoint(IPAddress.Any, 0);
            EndPoint Remote = (EndPoint)sender;

            data = new byte[1024];
            int receivedDataLength = server.ReceiveFrom(data, ref Remote);

            Console.WriteLine("Message received from {0}:", Remote.ToString());
            Console.WriteLine(Encoding.ASCII.GetString(data, 0, receivedDataLength));

            server.Close();
        }
    }
}