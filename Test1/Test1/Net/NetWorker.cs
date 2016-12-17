using System.Net.Sockets;
using System.Net;

namespace Test1.Net
{
    class NetWorker
    {

        private UdpClient _client;
        private IPEndPoint _sender;

        public void Connect()
        {
            //_client = new UdpClient("192.168.0.104", 30322);
            _client = new UdpClient("2.92.94.145", 30322);
            _sender = new IPEndPoint(IPAddress.Any, 0);
        }

        //public void Work()
        //{
        //    var data = new byte[1500];
        //    UdpClient client = new UdpClient("127.0.0.1", 30322);
        //    IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
        //    while (true)
        //    {
        //        var str = "Love you server";
        //        data = Encoding.UTF8.GetBytes(str);
        //        client.Send(data, data.Length);
        //        data = client.Receive(ref sender);
        //        Console.WriteLine(Encoding.UTF8.GetString(data));
        //    }
        //    //client.Send()
        //}

        public void Send(byte[] data)
        {
            _client.Send(data, data.Length);
        }

        public byte[] Receive()
        {
            var data = _client.Receive(ref _sender);
            return data;
        }
    }
}
