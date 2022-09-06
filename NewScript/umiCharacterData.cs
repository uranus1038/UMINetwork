using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Umi.JSON;
using Umi.NetworkRequast;

public class umiCharacterData : MonoBehaviour
{
    public static umiCharacterData instance;
    public static umiCharacterData cDat;
    public int UID;
    public string Name;
    public string Type;
    public string[] nName;
    public string[] nType;
    public string[] nSlot;
    public string[] Data;
    public int lv;
    public int exp;
    public int nexp;
    public int mp;
    public int sp;
    public int ko;
    public int atk;
    public int def;
    public int agi;
    public int vit;
    public int magic;
    public int cha;
    public int tal;
    public int lck;
    public float weight;
    public float runspeed;

    public umiCharacterData()
    {
        
    }
    
    public void CharacterDataUID(string JSONArrayX)
    {
        JSONObject UMI_JSONArray = (JSONObject)JSON.Parse(JSONArrayX);
        for (int i = 0; i < UMI_JSONArray.Count; i++)
        {
            if(this.Data[i] == null)
            {
                this.Data[i] = UMI_JSONArray[i];
                Debug.Log(Data[i]);
            }
        }
        this.getSlot();
    }
    public void CharacterData(string JSONArrayX)
    {
        JSONObject UMI_JSONArray = (JSONObject)JSON.Parse(JSONArrayX);
     
        for (int i = 0; i < UMI_JSONArray.Count; i++)
        {

            if (this.Data[i] == null)
            {
                this.Data[i] = UMI_JSONArray[i];
                
            }else
            {
                this.Data[i+1] = UMI_JSONArray[i];
            }
        }

        this.getDataCharacter();
    }
    
    private void getSlot()
    {
        Debug.Log("success");
        this.StartCoroutine(UmiWebRequast.instance.umiGetSlot(this.Data[0])); 

    }

    private void getDataCharacter()
    {
        this.UID = int.Parse(Data[0]);
        this.nName[0] = this.Data[1];
        this.nName[1] = this.Data[2];
        this.nName[2] = this.Data[3];
        this.nSlot[0] = this.Data[4];
        this.nSlot[1] = this.Data[5];
        this.nSlot[2] = this.Data[6];
      //  this.Name = LoginGui.hashtable[1].ToString();
    }
    
    private void Awake()
    {
        
        this.Data = new string[180];
        this.nType = new string[11];
        this.nSlot = new string[10];
        this.nName = new string[10];
        instance = this;
        cDat = this ;
    }


}
