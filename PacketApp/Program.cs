using System.Net.Sockets;
using System.Text.Json;
using Newtonsoft.Json;
using Shared;
using Shared.packet;
using Shared.packet.impl;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace PacketApp;

public static class Program
{
    public static void Main()
    {
        try
        {
            var ip = Util.GetLocalIpAddress();
            var client = new TcpClient("127.0.0.1", 13000);

            if (!client.Connected) return;

            Console.WriteLine("Connected to server");

            PacketJoinServer join = new PacketJoinServer(ip, "Isaiah");
            Util.SendJsonData(client.GetStream(), join);
            
            
            client.Close();

        }
        catch (Exception e)
        {
            Console.WriteLine(e.StackTrace);
        }
    }
}