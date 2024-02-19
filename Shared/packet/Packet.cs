
namespace Shared.packet;

public class Packet
{
    public int PacketId { get; init; }
    public string Ip { get; init; }
    public Packet(int id, string ip)
    {
        PacketId = id;
        Ip = ip;
    }
    
    [System.Text.Json.Serialization.JsonConstructor]
    public Packet() { }
    
}