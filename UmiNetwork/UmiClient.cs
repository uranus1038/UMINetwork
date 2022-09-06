using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System;
namespace Umi.Networking
{
    public class UmiClient : MonoBehaviour
    {
        public static UmiClient instance;
        public static int dataBufferSize = 4096;
        public string ip = "127.0.0.1";
        public int port = 808;
        public int myId = 0;
        public UmiTcp tcp;
        public UmiUdp udp;
        private bool isConnected = false;
        private delegate void packetHandler(UmiPacket _packet);
        private static Dictionary<int, packetHandler> packetHandlers;
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Debug.Log($"Destroy");
                Destroy(this);
            }
            
            
        }
        private void Start()
        {
            tcp = new UmiTcp();
            udp = new UmiUdp();
            
         
        }
        public void OnApplicationQuit()
        {
            UmiClientSend.disconnectSend(myId);
            Disconnect();
        }
        public void connectServer()
        {

            InitializeClientData();
            isConnected = true;
            tcp.Connect();
            
        }
        public class UmiTcp
        {
            public UmiTcp instancex ;
            public TcpClient socket;
            private UmiPacket receiveData;
            private NetworkStream stream;
            private byte[] receiveBuffer;
            private float float_1; 
      
          
         
          
            public void Connect()
            {
                instancex = this;
                socket = new TcpClient { ReceiveBufferSize = dataBufferSize, SendBufferSize = dataBufferSize };

                receiveBuffer = new byte[dataBufferSize];
                socket.BeginConnect(instance.ip, instance.port, umiConnectCallback, socket);

            }
            private void umiConnectCallback(IAsyncResult _Result)
            {
                if (!socket.Connected)
                {
                    
                    Debug.Log("Not server down");
                    return;
                }

                
                stream = socket.GetStream();
                receiveData = new UmiPacket();
                stream.BeginRead(receiveBuffer, 0, dataBufferSize, umiReceiveCallback, null);
            }

            public void umiSendData(UmiPacket _packet)
            {
                try
                {
                    if (socket != null)
                    {
                        stream.BeginWrite(_packet.ToArray(), 0, _packet.Length(), null, null);
                    }
                }
                catch (Exception _ex)
                {
                    Console.WriteLine($"Error sendig :{_ex}");
                }
            }
            private void umiReceiveCallback(IAsyncResult _result)
            {
                try
                {
                    int _byteLength = stream.EndRead(_result);
                    if (_byteLength <= 0)
                    {

                        instance.Disconnect();
                        UmiClientSend.disconnectSend(UmiClient.instance.myId);
                        return;
                    }
                    byte[] _data = new byte[_byteLength];
                    Array.Copy(receiveBuffer, _data, _byteLength);

                    receiveData.Reset(umiHandleData(_data));
                    stream.BeginRead(receiveBuffer, 0, dataBufferSize, umiReceiveCallback, null);
                }
                catch
                {
                    UmiClientSend.disconnectSend(UmiClient.instance.myId);
                    Disconnect();
                }
            }

            private bool umiHandleData(byte[] _data)
            {
                int _packetLenght = 0;

                receiveData.SetBytes(_data);
                if (receiveData.UnreadLength() >= 4)
                {
                    _packetLenght = receiveData.ReadInt();
                    if (_packetLenght <= 0)
                    {
                        return true;
                    }
                }
                while (_packetLenght > 0 && _packetLenght <= receiveData.UnreadLength())
                {
                    byte[] _packetByte = receiveData.ReadBytes(_packetLenght);
                    UmiThreadManager.umiExecuteOnMainThread(() =>
                    {
                        using (UmiPacket _packet = new UmiPacket(_packetByte))
                        {
                            int _packetId = _packet.ReadInt();
                            packetHandlers[_packetId](_packet);
                        }

                    });
                    _packetLenght = 0;
                    if (receiveData.UnreadLength() >= 4)
                    {
                        _packetLenght = receiveData.ReadInt();
                        if (_packetLenght <= 0)
                        {
                            return true;
                        }
                    }
                }
                if (_packetLenght <= 1)
                {
                    return true;
                }
                return false;
            }

            private void Disconnect()
            {
                instance.Disconnect();
                stream = null;
                receiveData = null;
                receiveBuffer = null;
                socket = null;
            }

        }

        public class UmiUdp
        {
            public UdpClient socket;
            public IPEndPoint endPoint;
            public UmiUdp()
            {
                endPoint = new IPEndPoint(IPAddress.Parse(instance.ip), instance.port);
            }
            public void Connect(int local_Port)
            {
                socket = new UdpClient(local_Port);
                socket.Connect(endPoint);
                socket.BeginReceive(umiReceiveCallback, null);

                using (UmiPacket _packet = new UmiPacket())
                {
                    umiSendData(_packet);
                }

            }
            public void umiSendData(UmiPacket _packet)
            {
                try
                {
                    _packet.InsertInt(instance.myId);
                    if (socket != null)
                    {
                        socket.BeginSend(_packet.ToArray(), _packet.Length(), null, null);
                    }
                }
                catch (Exception _ex)
                {
                    Debug.Log($"Erorr Sending to data {_ex}");
                }
            }
            private void umiReceiveCallback(IAsyncResult _result)
            {
                try
                {
                    byte[] _data = socket.EndReceive(_result, ref endPoint);
                    socket.BeginReceive(umiReceiveCallback, null);
                    if (_data.Length < 4)
                    {
                        UmiClientSend.disconnectSend(UmiClient.instance.myId);
                        instance.Disconnect();
                        return;
                    }
                    umiHandleData(_data);
                }
                catch
                {
                    UmiClientSend.disconnectSend(UmiClient.instance.myId);
                    Disconnect();
                }
            }
            private void umiHandleData(byte[] _data)
            {
                using (UmiPacket _packet = new UmiPacket(_data))
                {
                    int _packetLength = _packet.ReadInt();
                    _data = _packet.ReadBytes(_packetLength);
                }

                UmiThreadManager.umiExecuteOnMainThread(() =>
                {
                    using (UmiPacket _packet = new UmiPacket(_data))
                    {
                        int _packetId = _packet.ReadInt();
                        packetHandlers[_packetId](_packet);
                    }
                });
            }



            private void Disconnect()
            {
                instance.Disconnect();
                endPoint = null;
                socket = null;
            }

        }
        private void Disconnect()
        {
            if (isConnected)
            {

                isConnected = false;
                tcp.socket.Close();
                //udp.Socket.Close();
                Debug.Log("Disconnect from Server");
            }
        }
        private void InitializeClientData()
        {
            packetHandlers = new Dictionary<int, packetHandler>()
        {
           { (int)ServerPackets.welcome ,UmiClientHandle.Welcom},
           { (int)ServerPackets.spawnPlayer ,UmiClientHandle.spawnPlayer},
           { (int)ServerPackets.playerPosition ,UmiClientHandle.playerPosition},
           { (int)ServerPackets.disConnectSv ,UmiClientHandle.disconnectReceive}

        };

        }

    }
}