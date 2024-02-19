using System.Net;
using System.Net.Sockets;
using Newtonsoft.Json;
using Shared;
using Shared.packet.impl;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace Server;

public class TextServer
{
    private TcpListener _server;

    public static void Main()
    { 
        new TextServer(true);
    }

    private TextServer(bool start)
    {
        if(start) StartServer();
    }

    private void StartServer()
    {
        var port = 13000;
        var ip = IPAddress.Parse("127.0.0.1");
        _server = new TcpListener(ip, port);
        _server.Start();
        
        Console.WriteLine("Started server on " + ip + ":" + port);

        Console.WriteLine("Awaiting connections...");
        
        while (true)
        {
            
            var sender = _server.AcceptTcpClient();
            NetworkStream stream = sender.GetStream();
            
            
            var packet = Util.DeserializeJsonData<PacketJoinServer>(stream);
            if (packet != null)
            {
                Log(packet.UserName + " " + packet.Ip);
            }
            
        }
    }

    public void Log(String s)
    {
        Console.WriteLine(s);
    }
}