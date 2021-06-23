using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            string address = Convert.ToString(Dns.GetHostAddresses(Dns.GetHostName())[0]);
            int port = 8000;
            TcpClient socket = new TcpClient(address, port);

            BinaryReader reader = new BinaryReader(new BufferedStream(socket.GetStream()));

            while (true)
            {
                string serverText = reader.ReadString();
                Console.WriteLine(serverText);
            }
        }
    }
}
