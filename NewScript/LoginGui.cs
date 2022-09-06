using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Networking;
using Umi.NetworkRequast;
using Umi.Networking;
[RequireComponent(typeof(AudioSource))]
public class LoginGui : MonoBehaviour
{

    public static LoginGui instance;
    public static Hashtable hashtable = new Hashtable();
    private Texture texture_0;
    private Texture texture_1;
    private Texture texture_2;
    private Texture texture_5;
    private Texture texture_11;
    private Texture texture_22;
    private Texture texture_27;
    private Texture texture_28;
    private Texture texture_29;
    private Texture texture_30;
    private Texture texture_36;
    private Texture texture_37;
    private Texture texture_38;
    private VideoPlayer introMovie;
    private float float_0;
    private float float_1;
    private int int_0;
    public string string_0;
    private string string_1;
    public string string_2;
    private GUIStyle guistyle_0;
    private GUIStyle guistyle_4;
    private GUIStyle guistyle_7;
    private GUIStyle guistyle_8;
    private GUIStyle guistyle_9;
    private GUIStyle guistyle_10;
    private GUIStyle guistyle_11;
    private AudioClip audioClip_0;
    private AudioClip audioClip_1;
    private AudioClip audioClip_2;
    private AudioClip audioClip_3;
    private AudioClip audioClip_4;
    private AudioSource audioSource_0;
    private AudioSource audioSource_1;
    private AudioSource audioSource_2;
    public eLoginState eLoginState_0;


    public LoginGui()
    {
        string_0 = string.Empty;
        string_1 = string.Empty;
    }
    private void Awake()
    {
        string_0 = string.Empty;
        string_1 = string.Empty;

        this.Init();
        instance = this;
        eLoginState_0 = eLoginState.Init;

    }

    private void Start()
    {
        // introMovie = GetComponent<VideoPlayer>();

    }


    private void Init()
    {

        this.texture_0 = (Texture)Resources.Load("GameGui/LogIn/LogIn_background", typeof(Texture));
        this.texture_1 = (Texture)Resources.Load("GameGui/Common/Black", typeof(Texture));
        this.texture_2 = (Texture)Resources.Load("GameGui/LogIn/LogIn_serverBg2", typeof(Texture));
        this.texture_5 = (Texture)Resources.Load("GameGui/LogIn/LogIn_server2", typeof(Texture));
        this.texture_11 = (Texture)Resources.Load("GameGui/LogIn/LogIn_server2_sm", typeof(Texture));
        this.texture_22 = (Texture)Resources.Load("GameGui/LogIn/LogIn_realmSelect", typeof(Texture));
        this.texture_27 = (Texture)Resources.Load("GameGui/LogIn/server2_active", typeof(Texture));
        this.texture_28 = (Texture)Resources.Load("GameGui/LogIn/server2_busy", typeof(Texture));
        this.texture_29 = (Texture)Resources.Load("GameGui/LogIn/server2_full", typeof(Texture));
        this.texture_30 = (Texture)Resources.Load("GameGui/LogIn/server2_down", typeof(Texture));
        this.texture_36 = (Texture)Resources.Load("GameGui/LogIn/LogIn_box", typeof(Texture));
        this.texture_37 = (Texture)Resources.Load("GameGui/LogIn/LogIn_check", typeof(Texture));
        this.texture_38 = (Texture)Resources.Load("GameGui/Common/noticeBar", typeof(Texture));
        this.guistyle_0 = new GUIStyle();
        this.guistyle_0.normal.background = (Texture2D)((Texture)Resources.Load("GameGui/LogIn/LogIn_selectServer", typeof(Texture)));
        this.guistyle_0.hover.background = (Texture2D)((Texture)Resources.Load("GameGui/LogIn/LogIn_selectServer_h", typeof(Texture)));
        this.guistyle_4 = new GUIStyle();
        this.guistyle_4.normal.background = (Texture2D)((Texture)Resources.Load("GameGui/LogIn/LogIn_connect", typeof(Texture)));
        this.guistyle_4.hover.background = (Texture2D)((Texture)Resources.Load("GameGui/LogIn/LogIn_connect_h", typeof(Texture)));
        this.guistyle_7 = new GUIStyle();
        this.guistyle_7.hover.background = (Texture2D)((Texture)Resources.Load("GameGui/LogIn/LogIn_login", typeof(Texture)));
        this.guistyle_8 = new GUIStyle();
        this.guistyle_8.hover.background = (Texture2D)((Texture)Resources.Load("GameGui/LogIn/LogIn_back", typeof(Texture)));
        this.guistyle_9 = new GUIStyle();
        this.guistyle_9.normal.background = (Texture2D)((Texture)Resources.Load("GameGui/LogIn/LogIn_toggle_h", typeof(Texture)));
        this.guistyle_9.hover.background = (Texture2D)((Texture)Resources.Load("GameGui/LogIn/LogIn_toggle_h", typeof(Texture)));
        this.guistyle_10 = new GUIStyle();
        this.guistyle_10.font = (Font)Resources.Load("Resources/GameGui/Fonts/MsSansSerif18", typeof(Font));
        this.guistyle_10.alignment = TextAnchor.MiddleLeft;
        this.guistyle_10.fontSize = 16;
        this.guistyle_11 = new GUIStyle();
        this.guistyle_11.font = (Font)Resources.Load("Resources/GameGui/Fonts/GMO32", typeof(Font));
        this.guistyle_11.normal.textColor = new Color(0.23f, 0.2f, 0.14f, 1f);
        this.guistyle_11.alignment = TextAnchor.MiddleCenter;
        this.guistyle_11.fontSize = 19;
        this.audioClip_0 = (AudioClip)Resources.Load("Sound/GUI/click", typeof(AudioClip));
        this.audioClip_1 = (AudioClip)Resources.Load("Sound/GUI/beep", typeof(AudioClip));
        this.audioClip_2 = (AudioClip)Resources.Load("Sound/GUI/cancel", typeof(AudioClip));
        this.audioClip_3 = (AudioClip)Resources.Load("Sound/GUI/shuffle", typeof(AudioClip));
        this.audioClip_4 = (AudioClip)Resources.Load("Sound/GUI/tick", typeof(AudioClip));
        this.audioSource_0 = GetComponent<AudioSource>();
        this.audioSource_1 = GetComponent<AudioSource>();
        this.audioSource_2 = GetComponent<AudioSource>();

    }
    public void RenderNoticeMessage(string message)
    {
        GUI.DrawTexture(new Rect(0.5f * this.float_1 - 233f, 740f, 475f, 102f), this.texture_38);
        GUI.Label(new Rect(0.5f * this.float_1 - 200f, 765f, 400f, 50f), message, this.guistyle_11);
    }
   
    private void OnGUI()
    {


        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3((float)Screen.height / 1024f, (float)Screen.height / 1024f, 1f));
        GUI.depth = 2;
        this.float_1 = (float)(1024 * Screen.width / Screen.height);
        GUI.DrawTexture(new Rect(0.5f * this.float_1 - 960f, 0f, 1920f, 1024f), this.texture_0);
        if (eLoginState_0 == eLoginState.Init)
        {
            GUI.DrawTexture(new Rect(0.5f * this.float_1 - 960f, 0f, 1920f, 1024f), this.texture_1);
            float_0 = Time.deltaTime;
            eLoginState_0 = eLoginState.Intro;
            return;
        }
        if (eLoginState_0 == eLoginState.Intro)
        {
            eLoginState_0 = eLoginState.fadeIn;
            float_0 = Time.deltaTime;
            return;
        }
        if (eLoginState_0 == eLoginState.fadeIn)
        {
            if (Time.time < this.float_0 + 0.5f)
            {
                float a = 2f * (this.float_0 + 0.5f - Time.time);
                Color color = GUI.color;
                color.a = a;
                GUI.color = color;
                GUI.DrawTexture(new Rect(0.5f * this.float_1 - 960f, 0f, 1920f, 1024f), this.texture_1);
                Color color2 = GUI.color;
                color2.a = 1f;
                GUI.color = color2;
                return;
            }
            this.eLoginState_0 = eLoginState.serverSelect;
            this.float_0 = Time.time;
            return;
        }
        if (eLoginState_0 == eLoginState.serverSelect)
        {
            GUI.DrawTexture(new Rect(0.5f * this.float_1 - 276f, 735f, 620f, 206f), this.texture_2);
            int num = this.int_0;
            if (num == 0)
            {
                GUI.DrawTexture(new Rect(0.5f * this.float_1 - 109f, 724f, 262f, 170f), this.texture_5);
            }
            if (GUI.Button(new Rect(0.5f * this.float_1 - 42f, 875f, 138f, 36f), string.Empty, this.guistyle_4))
            {
                if (this.audioClip_1)
                {
                    audioSource_1.PlayOneShot(this.audioClip_1);

                }
                this.eLoginState_0 = eLoginState.login;
                this.float_0 = Time.time;
                return;
            }


        }
        // # Login Bar
        if (eLoginState_0 == eLoginState.login)
        {
            GUI.DrawTexture(new Rect(0.5f * this.float_1 - 146f, 736f, 435f, 141f), this.texture_36);
            GUI.DrawTexture(new Rect(0.5f * this.float_1 - 268f, 725f, 173f, 153f), this.texture_11);
            //GUI.Label(new Rect(0.5f * this.float_1 - 65f, 791f, 200f, 30f), this.string_1, this.guistyle_10);
            this.string_0 = GUI.TextField(new Rect(0.5f * this.float_1 - 65f, 751f, 200f, 30f), this.string_0, 15, this.guistyle_10);
            this.string_1 = GUI.PasswordField(new Rect(0.5f * this.float_1 - 65f, 785f, 200f, 30f), this.string_1, "*"[0], 15, this.guistyle_10);
            if (GUI.Button(new Rect(0.5f * this.float_1 + 130f, 754f, 24f, 24f), string.Empty, this.guistyle_9))
            {
                GUI.DrawTexture(new Rect(0.5f * this.float_1 + 132f, 756f, 20f, 20f), this.texture_37);
                Debug.Log("Wait fix . .");
            }
            if (this.string_0 != string.Empty && this.string_1 != string.Empty)
            {
                if (GUI.Button(new Rect(0.5f * this.float_1 - 68f, 832f, 136f, 36f), string.Empty, this.guistyle_7))
                {
                    
                    this.eLoginState_0 = eLoginState.loginServer;
                    StartCoroutine(UmiWebRequast.instance.umiLogin(this.string_0, this.string_1));
                    this.float_0 = Time.time;
                    if (this.audioClip_0)
                    {
                        audioSource_2.PlayOneShot(this.audioClip_0);
                    }
                }
            }
            if (GUI.Button(new Rect(0.5f * this.float_1 + 68f, 832f, 51f, 36f), string.Empty, this.guistyle_8))
            {
                this.eLoginState_0 = eLoginState.serverSelect;
                this.float_0 = Time.time;
                if (this.audioClip_2)
                {
                    audioSource_2.PlayOneShot(this.audioClip_2);
                }
            }
        }
        else if (eLoginState_0 == eLoginState.loginServer)
        {
            string_2 = UmiWebRequast.instance.stringReq;
            if (Time.time - this.float_0 < 1.7f)
            {
                this.RenderNoticeMessage("Logging in..");
                return;
            }
            if (this.string_2 == "LoginSuccess")
            {
                this.eLoginState_0 = eLoginState.realmSelect;
                this.float_0 = Time.time;
                return;
            }
            else if (this.string_2 == "LoginFail")
            {

                this.eLoginState_0 = eLoginState.loginFail;
                this.float_0 = Time.time;
                return;

            }
            if (this.string_2 != "LoginFail" || this.string_2 != "LoginSuccess")
            {
                this.eLoginState_0 = eLoginState.serverDown;
                this.float_0 = Time.time;
                return;
            }
            return;
        }
        else
        {
            if (eLoginState_0 == eLoginState.serverDown)
            {
                if (Time.time - this.float_0 < 1.7f)
                {
                    this.RenderNoticeMessage("Server Down");
                    return;
                }
                this.eLoginState_0 = eLoginState.login;
                this.float_0 = Time.time;
                return;

            }
            if (eLoginState_0 == eLoginState.loginFail)
            {
                if (Time.time - this.float_0 < 1.7f)
                {
                    this.RenderNoticeMessage("Login in fail..");
                    return;
                }
                this.eLoginState_0 = eLoginState.login;
                this.float_0 = Time.time;
                return;

            }
            else if (eLoginState_0 == eLoginState.realmSelect)
            {
                GUI.DrawTexture(new Rect(0.5f * this.float_1 - 276f, 735f, 620f, 206f), this.texture_2);
                if (GUI.Button(new Rect(0.5f * this.float_1 - 140f, 748f, 86f, 143f), string.Empty, this.guistyle_0))
                {
                    UmiGame.JoinConnect();
                    this.eLoginState_0 = eLoginState.nProtectUmi;
                    this.float_0 = Time.time;
                    if (this.audioClip_1)
                    {
                        audioSource_1.PlayOneShot(this.audioClip_1);
                        
                    }
                }
                GUI.DrawTexture(new Rect(0.5f * this.float_1 - 151f, 746f, 111f, 160f), this.texture_27);
                GUI.DrawTexture(new Rect(0.5f * this.float_1 - 30f, 746f, 111f, 160f), this.texture_30);
                GUI.DrawTexture(new Rect(0.5f * this.float_1 + 87f, 746f, 111f, 160f), this.texture_30);
                GUI.DrawTexture(new Rect(0.5f * this.float_1 - 152f, 824f, 349f, 67f), this.texture_22);

                return;
            }
            if (eLoginState_0 == eLoginState.nProtectUmi)
            {
                if(!UmiClient.instance.tcp.instancex.socket.Connected)
                {
                    if(Time.time - this.float_0 < 1.7f)
                    {
                        this.RenderNoticeMessage("Connecting..");
                        return;
                    }
                    UmiGame.onJoinConnect();
                    this.eLoginState_0 = eLoginState.realmDown;
                    hashtable.Add(1, this.string_0);
                    this.float_0 = Time.time;



                }
                else
                {
                    this.eLoginState_0 = eLoginState.connecting;
                    this.float_0 = Time.time;
                    return;
                }
            }
            if(eLoginState_0 == eLoginState.realmDown)
            {
                if (Time.time - this.float_0 < 1.7f)
                {
                    this.RenderNoticeMessage("RealmDown");
                    return;
                }
                this.eLoginState_0 = eLoginState.realmSelect;
                this.float_0 = Time.time;
                return;
            }
                if (eLoginState_0 == eLoginState.connecting)
            {
                if (Time.time - this.float_0 < 1.7f)
                {
                    this.RenderNoticeMessage("Connecting..");
                    return;
                }
                this.eLoginState_0 = eLoginState.connected;
                this.float_0 = Time.time;
                return;
            }
            if (eLoginState_0 == eLoginState.connected)
            {
                if (Time.time - this.float_0 < 1.7f)
                {
                    this.RenderNoticeMessage("Retrieving player data..");
                    return;
                }
                
                this.eLoginState_0 = eLoginState.join;
                this.float_0 = Time.time;
                return;
            }
            if (eLoginState_0 == eLoginState.join)
            {
                if (Time.time - this.float_0 < 1.7f)
                {
                    this.RenderNoticeMessage("Entering 12Tails Online...");
                   
                    return;
                }
                //this.eLoginState_0 = eLoginState.join;
                UmiGame.onJoinConnect();
                UmiGame.loadNextLevel(1);
                this.float_0 = Time.time;
                return;
            }
        }
    }

}

