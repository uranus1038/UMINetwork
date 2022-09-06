
using UnityEngine;

namespace Umi.Networking
{
    public class UmiClientSend : MonoBehaviour
    {
        private static void umiSendTcpData(UmiPacket _packet)
        {
            _packet.WriteLength();
            UmiClient.instance.tcp.umiSendData(_packet);
        }
        private static void umiSendUdpData(UmiPacket _packet)
        {
            _packet.WriteLength();
            UmiClient.instance.udp.umiSendData(_packet);
        }

        public static void welcomReceive()
        {
            using (UmiPacket _packet = new UmiPacket((int)ClientPackets.welcomeReceived))
            {
                _packet.Write(UmiClient.instance.myId);
                _packet.Write(LoginGui.instance.string_0);
                umiSendTcpData(_packet);
            }
        }

        public static void playerMoveMent(Vector3 _position)
        {
            using (UmiPacket _packet = new UmiPacket((int)ClientPackets.playerMovement))
            {

                _packet.Write(_position);
                // _Packet.Write(GameManager.players[Client.instance.my_Id].transform.rotation);
                umiSendUdpData(_packet);
            }
        }

        public static void disconnectSend(int _id)
        {
            using (UmiPacket _packet = new UmiPacket((int)ClientPackets.disConnectClient))
            {

                _packet.Write(_id);
                // _Packet.Write(GameManager.players[Client.instance.my_Id].transform.rotation);
                umiSendTcpData(_packet);
            }
        }




    }
}