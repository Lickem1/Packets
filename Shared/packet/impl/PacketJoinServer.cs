
namespace Shared.packet.impl;
public class PacketJoinServer(string ip, string username) : Packet((int)PacketJoinServerEnumerated.Id, ip)
{
    public string UserName { get; init; } = username;
}

public enum PacketJoinServerEnumerated
{
    Id = 10

}