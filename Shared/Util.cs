using System.Net;
using System.Net.Sockets;
using Newtonsoft.Json;

namespace Shared;

public class Util
{
    public static string GetLocalIpAddress()
    {
        var host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (var ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                return ip.ToString();
            }
        }

        throw new Exception("No network adapters with an IPv4 address in the system!");
    }

    public static void SendJsonData(NetworkStream stream, object clazz)
    {
        using var writer = new StreamWriter(stream);
        using var jsonTextWriter = new JsonTextWriter(writer);
        var ser = new JsonSerializer();
        
        ser.Serialize(jsonTextWriter, clazz);
        jsonTextWriter.Flush();
    }

    public static T? DeserializeJsonData<T>(Stream s)
    {
        using var reader = new StreamReader(s);
        using var jsonReader = new JsonTextReader(reader);
        var ser = new JsonSerializer();
        return ser.Deserialize<T>(jsonReader);
    }
}