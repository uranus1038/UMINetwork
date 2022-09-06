using UnityEngine;
using System.Net;

namespace Umi.Networking { 
public class UmiClientHandle : MonoBehaviour
{
    public static void Welcom(UmiPacket _packet)
    {
        string _msg = _packet.ReadString();
        int _myId = _packet.ReadInt();
        Debug.Log($"Message from server : {_msg}");
        UmiClient.instance.myId = _myId;
        UmiClientSend.welcomReceive();

        UmiClient.instance.udp.Connect(((IPEndPoint)UmiClient.instance.tcp.socket.Client.LocalEndPoint).Port);
    }
        public static void spawnPlayer(UmiPacket _packet)
        {
            int _id = _packet.ReadInt();
            string _username = _packet.ReadString();
            Vector3 _position = _packet.ReadVector3();
            Quaternion _rotation = _packet.ReadQuaternion();
            UmiGameManager.instance.SpawnPlayer(_id, _username, _position, _rotation);
        }
        public static void playerPosition(UmiPacket _packet)
    {
        int _id = _packet.ReadInt();
        Vector3 _position = _packet.ReadVector3();
        // Quaternion _rotation = _Packet.ReadQuaternion();
        UmiGameManager.players[_id].transform.position = _position;
        //   GameManager.players[_id].transform.rotation = _rotation;

    }

    public static void disconnectReceive(UmiPacket _packet)
    {
        int _id = _packet.ReadInt();
        Destroy(UmiGameManager.players[_id].gameObject);
        UmiGameManager.players.Remove(_id);
        Debug.Log(_id);

    }
}
}