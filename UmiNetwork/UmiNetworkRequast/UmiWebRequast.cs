using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Umi.JSON;

namespace Umi.NetworkRequast
{
    
    public class UmiWebRequast : MonoBehaviour
    {

        public static UmiWebRequast instance;
      //  private string umiWebRequast = "http://localhost:8000/loginServer";
        private  string umiWebLogin = "http://localhost:8000/loginServer";
        private  string umiWebUserId= "http://localhost:8000/userId";
        private  string umiWebUserSlot = "http://localhost:8000/userSlot";
        public string stringReq;
       
        public UmiWebRequast()
        {
            
        }

        void Start()
        {
            instance = this;
            
        }
        // # req POST
      public  IEnumerator umiLogin( string userName ,string passWord)
      {
            WWWForm umiReq = new WWWForm();
            umiReq.AddField("userName", userName);
            umiReq.AddField("userPass", passWord);

            using (UnityWebRequest www = UnityWebRequest.Post(this.umiWebLogin, umiReq))
            {
                yield return www.SendWebRequest();

                if (www.result != UnityWebRequest.Result.Success)
                {
                    Debug.Log(www.error);
                }
                else
                {
                    Debug.Log(www.downloadHandler.text);
                    StartCoroutine(this.umiGetUID(userName));
                    this.stringReq = www.downloadHandler.text; 
                }
                
            }

      }
        public IEnumerator umiGetUID(string userNameX)
        {
            WWWForm umiReq = new WWWForm();
            umiReq.AddField("userName", userNameX);
            using (UnityWebRequest www = UnityWebRequest.Post(this.umiWebUserId, umiReq))
            {
                yield return www.SendWebRequest();

                if (www.result != UnityWebRequest.Result.Success)
                {
                    Debug.Log(www.error);
                }
                else
                {
                    Debug.Log(www.downloadHandler.text);
                    string UMI_JSON = www.downloadHandler.text;
                    umiCharacterData.instance.CharacterDataUID(UMI_JSON);
                    

                }
            }
        }
        public IEnumerator umiGetSlot(string UID)
        {
            WWWForm umiReq = new WWWForm();
            umiReq.AddField("UID", UID);
            using (UnityWebRequest www = UnityWebRequest.Post(this.umiWebUserSlot, umiReq))
            {
                yield return www.SendWebRequest();

                if (www.result != UnityWebRequest.Result.Success)
                {
                    Debug.Log(www.error);
                }
                else
                {
                    Debug.Log(www.downloadHandler.text);
                    string UMI_JSON = www.downloadHandler.text;
                    umiCharacterData.instance.CharacterData(UMI_JSON);
                  
                }
            }
        }













        // # req GET
        //IEnumerator umiLogin(string name, string pass)
        //{
        //    WWWForm form = new WWWForm();
        //    //form.AddField("userName", name);
        //    //form.AddField("userPass", pass);

        //    using (UnityWebRequest www = UnityWebRequest.Get($"{umiWebLogin}?userName={name}&userPass={pass}"))
        //    {
        //        yield return www.SendWebRequest();

        //        if (www.result != UnityWebRequest.Result.Success)
        //        {
        //            Debug.Log(www.error);
        //        }
        //        else
        //        {
        //            Debug.Log(www.downloadHandler.text);
        //        }
        //    }

        // #getLogin
        //IEnumerator umiGetText()
        //{
        //    using (UnityWebRequest webRequest = UnityWebRequest.Get(umiWebRequast))
        //    {
        //        // Request and wait for the desired page.
        //        yield return webRequest.SendWebRequest();

        //        string[] pages = umiWebRequast.Split('/');
        //        int page = pages.Length - 1;

        //        switch (webRequest.result)
        //        {
        //            case UnityWebRequest.Result.ConnectionError:
        //            case UnityWebRequest.Result.DataProcessingError:

        //                Debug.LogError(pages[page] + ": Error: " + webRequest.error);
        //                break;
        //            case UnityWebRequest.Result.ProtocolError:
        //                Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
        //                break;
        //            case UnityWebRequest.Result.Success:
        //                Debug.Log(pages[page] + "\nReceived: " + webRequest.downloadHandler.text);
        //                break;
        //        }
        //    }
        //}

    }
}
