using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Umi.JSON;
namespace Umi.Networking
{
    public class UmiGameManager : MonoBehaviour
    {
        public static UmiGameManager instance;

        public static Dictionary<int, UmiPlayerManager> players = new Dictionary<int, UmiPlayerManager>();

        public GameObject localPlayerPrefab;
        public GameObject playerPrefab;
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
        public void SpawnPlayer(int _id, string _username, Vector3 _position, Quaternion _rotation)
        {
            GameObject _player;
            if (_id == UmiClient.instance.myId)
            {
                _player = Instantiate(localPlayerPrefab, _position, _rotation);

            }
            else
            {
                _player = Instantiate(playerPrefab, _position, _rotation);

            }


            _player.GetComponent<UmiPlayerManager>().id = _id;
            _player.GetComponent<UmiPlayerManager>().username = _username;
            players.Add(_id, _player.GetComponent<UmiPlayerManager>());





        }

    }
}