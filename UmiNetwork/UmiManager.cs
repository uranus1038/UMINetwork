
using UnityEngine;

namespace Umi.Networking
{
    public class UmiManager : MonoBehaviour
    {
        public static UmiManager instance;
        public GameObject button;
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

        public void Connect()
        {
            button.SetActive(false);
            UmiClient.instance.connectServer();
        }

    }
}
