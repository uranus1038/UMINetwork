using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Umi.Networking;

public class UmiGame : MonoBehaviour
{
    public static void onJoinConnect()
    {
        UmiClient.instance.OnApplicationQuit();
    }
    public static void JoinConnect()
    {
        UmiClient.instance.connectServer();
    }
    public static void loadNextLevel(int _num)
    {
        if (_num == 1)
        {
            Application.LoadLevel("nL11_LobbyPlain");
            return;
        }

    }


}
