using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace ÖvningsTenta_Uppgift_2
{
    class ShapeRendererTask
    {
        public void Run(ShapeBuffer2 buffer)
        {
            int number;
            Random randomNumber = new Random();

            //FileInfo file = new FileInfo(@".\Shapes.txt");
            //using (file.Create()) { }

            IPAddress address = Dns.GetHostAddresses(Dns.GetHostName())[0];
            int port = 8000;
            TcpListener server = new TcpListener(address, port);
            server.Start();
            TcpClient client = server.AcceptTcpClient();

            while (true)
            {
                string shapeString = buffer.Read().GetString();

                BinaryWriter writer = new BinaryWriter(new BufferedStream(client.GetStream()));
                writer.Write(shapeString);
                writer.Flush();

                //using (StreamWriter writer = file.AppendText())
                //{
                //    writer.WriteLine(shapeString);
                //}

                number = randomNumber.Next(1000, 5000);
                Thread.Sleep(number);
            }
        }
    }
}
