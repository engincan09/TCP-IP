using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TcpIp.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] data = new byte[32];
            IPHostEntry iphostInfo = Dns.GetHostEntry(Dns.GetHostName());
            //IPAddress ipAdress  = IPAddress.Parse("ipadress");
            IPAddress ipAddress = iphostInfo.AddressList[0];
            IPEndPoint localEndpoint = new IPEndPoint(ipAddress, 32000);

            Socket client = new Socket(localEndpoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                client.Connect(localEndpoint);

                Console.WriteLine("Bağlantı oluşturuldu! {0}", client.RemoteEndPoint.ToString());

                byte[] sendmsg = Encoding.ASCII.GetBytes("This is from Client\n");

                //int n = client.Send(sendmsg);

                int m = client.Receive(data);

                var a = Encoding.ASCII.GetString(data);
                Console.WriteLine("" + Encoding.ASCII.GetString(data));
                client.Shutdown(SocketShutdown.Both);
                client.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("İşlem tamamlandı");
            Console.ReadKey();

        }
    }
}
