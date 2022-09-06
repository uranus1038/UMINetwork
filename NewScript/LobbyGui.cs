using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LobbyGui : MonoBehaviour
{
    // # -2.764768 -0.8816143 -98.1071 196.269 -70.63202 -95.62399
    // # -2 1.61 1.06 0 90 0
    public RenderTexture createCamTexture;
    public Camera createCam ;
    public GameObject cameraSelecter;
    public GameObject gameObject_0;
    public GameObject gameObject_1;
    public GameObject gameObject_2;
    private GameObject gameObject_3;
    private GameObject gameObject_4;
    private GameObject gameObject_5;
    private GameObject gameObject_6;
    private Vector3 newPosition;
    private Vector3 vector3_0;
    private Vector3[] vector3_1;
    private Texture texture_0;
    private Texture texture_2;
    private Texture texture_6;
    private Texture texture_7;
    private Texture texture_8;
    private Texture texture_9;
    private Texture texture_10;
    private Texture texture_11;
    private Texture texture_12;
    private Texture texture_13;
    private Texture texture_15;
    private Texture texture_17;
    private Texture texture_19;
    private Texture texture_20;
    private Texture texture_21;
    private Texture texture_22;
    private Texture texture_99;
    private Texture[] texture_14;
    private Texture[] texture_16;
    private Texture[] texture_18;
    private string string_0;
    private string string_2;
    private string[] string_1;
    private float smooth_0 = 5f;
    private float float_0 ;
    private float float_1;
    private float float_2; 
    private float float_3;
    private float float_5;
    private float float_7;
    private float float_8;
    private float float_9;
    private float float_10;
    private float float_11;
    private float float_12;
    private GUIStyle guistyle_0;
    private GUIStyle guistyle_2;
    private GUIStyle guistyle_3;
    private GUIStyle guistyle_4;
    private GUIStyle guistyle_5;
    private GUIStyle guistyle_6;
    private GUIStyle guistyle_8;
    private GUIStyle guistyle_9;
    private GUIStyle guistyle_10;
    private GUIStyle guistyle_11;
    private GUIStyle guistyle_14;
    private GUIStyle guistyle_15;
    private GUIStyle guistyle_16;
    private GUIStyle guistyle_17;
    private GUIStyle guistyle_18;
    private GUISkin guiskin_0;
    private Color color_0;
    private int int_2;
    private int int_3;
    private int int_8;
    private int int_9;
    private int[] int_4;
    private int[] int_5;
    private int[] int_6;
    private int[] int_7;
    private int[] int_10;
    private int[] int_11;
    private int[] int_12;
    private int[] int_13;
    private bool bool_0;
    private bool bool_1;
    private bool bool_2;
    eLobbyMenuState eLobbyMenuState_0;
    eLobbyState eLobbyState_0;
    eCreateCharState eCreateCharState_0;
    public LobbyGui()
    {
        this.int_6 = new int[8];
        this.int_7 = new int[8];
        this.string_2 = string.Empty;

        this.string_1 = new string[]
            {
                "none",
                "Wolf",
                "Sheep",
                "Panda",
                "Chameleon",
                "Mole",
                "Whale",
                "Bat",
                "Penguin",
                "Monkey",
                "Rabbit",
                "Cat",
                "Bison"
            };
            this.int_4 = new int[]
            {
                0,
                525,
                948,
                1270,
                1450,
                1820,
                2120,
                2668,
                3040,
                3358,
                3705,
                4046,
                78
            };
            this.int_5 = new int[]
            {
                0,
                0,
                1,
                2,
                0,
                2,
                0,
                1,
                3,
                2,
                2,
                1,
                0
            };
        this.int_11 = new int[]
            {
                0,
                -449,
                -372,
                -372,
                -580,
                -390,
                -578,
                -410,
                -450,
                -500,
                -440,
                -458,
                -505
            };
            this.int_10 = new int[]
            {
                0,
                643,
                427,
                512,
                848,
                503,
                993,
                576,
                523,
                714,
                848,
                576,
                887
            };
    }

    private void Awake()
    {
        eLobbyState_0 = eLobbyState.lobbyMenu;
        this.eLobbyMenuState_0 = eLobbyMenuState.start;
        this.float_0 = Time.time; 
        this.Init();
        this.InitLobbyMenu();
        this.InitCreateCharacter();
        this.InitStatGraph();
    }

    private void Start()
    {
      
        newPosition = this.transform.position;

        if (umiCharacterData.instance.nSlot[0] != "none")
        {
            gameObject_4 = (GameObject)UnityEngine.Object.Instantiate((GameObject)Resources.Load("GameAssets/Characters/Lobby/viewChar/" + umiCharacterData.cDat.nSlot[0], typeof(GameObject))
           ,new Vector3(6.2596f, 50.42865f, 10.13475f), Quaternion.Euler(-90f, 0f, 60f));
        }
        if (umiCharacterData.instance.nSlot[1] != "none")
        {
            gameObject_4 = (GameObject)UnityEngine.Object.Instantiate((GameObject)Resources.Load("GameAssets/Characters/Lobby/viewChar/" + umiCharacterData.cDat.nSlot[1], typeof(GameObject))

           , new Vector3(6.036811f, 50.42865f, 6.642142f), Quaternion.Euler(-92f, 300f, 0f));
        }
        if (umiCharacterData.instance.nSlot[2] != "none")
        {
            gameObject_4 = (GameObject)UnityEngine.Object.Instantiate((GameObject)Resources.Load("GameAssets/Characters/Lobby/viewChar/" + umiCharacterData.cDat.nSlot[2], typeof(GameObject))

           , new Vector3(8.92727f, 50.42865f, 8.377782f), Quaternion.Euler(-90f, 108f, 60f));
        }

    }
    private void Update()
    {
        Vector3 a = new Vector3(3.689414f, 53.07865f, 14.45476f);
        Vector3 b = new Vector3(3.695871f, 53.07865f, 1.973817f);
        Vector3 c = new Vector3(14.36949f, 53.07865f, 9.378675f);
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray , out hit ,100.0f))
            {
                if (hit.transform != null)
                {
                   if(hit.transform.gameObject.name == "selectBox1")
                    {
                        CharacterData.cDat01.CharacterInit(0);
                        this.newPosition = a;       
                        this.eLobbyMenuState_0 = eLobbyMenuState.selectCharacterFirst;
                        this.gameObject_0.SetActive(false);
                        this.gameObject_1.SetActive(true);
                        this.gameObject_2.SetActive(true);
                        this.float_0 = Time.time;
                    }
                    else if (hit.transform.gameObject.name == "selectBox2")
                    {
                        CharacterData.cDat01.CharacterInit(1);
                        this.newPosition = b;
                        this.eLobbyMenuState_0 = eLobbyMenuState.selectCharacterSecond;
                        this.gameObject_0.SetActive(true);
                        this.gameObject_1.SetActive(false);
                        this.gameObject_2.SetActive(true);
                        this.float_0 = Time.time;
                    }
                    else if (hit.transform.gameObject.name == "selectBox3")
                    {
                        CharacterData.cDat01.CharacterInit(2);
                        this.newPosition = c;
                        this.eLobbyMenuState_0 = eLobbyMenuState.selectCharacterThird;
                        this.gameObject_0.SetActive(true);
                        this.gameObject_1.SetActive(true);
                        this.gameObject_2.SetActive(false);
                        this.float_0 = Time.time;
                    }

                }
            }
        }
        this.transform.position = Vector3.Lerp(this.transform.position, this.newPosition, this.smooth_0*Time.deltaTime);
        this.transform.LookAt(this.cameraSelecter.transform.position);
    }

    private void Init()
    {
        this.vector3_0 = gameObject.transform.position;
        this.float_1 = gameObject.transform.rotation.eulerAngles.y - 270f;
    }
    public  void InitStatGraph()
    {
        this.vector3_1 = new Vector3[8];
        this.int_12 = new int[8];
        this.int_13 = new int[8];
        
    }
    public virtual void InitStatBar()
    {
        this.texture_22 = (Texture)Resources.Load("GameGui/Lobby/selectChar/bar_statusWindow", typeof(Texture));
        this.guistyle_15 = new GUIStyle();
        this.guistyle_15.hover.background = (Texture2D)((Texture)Resources.Load("GameGui/Lobby/selectChar/button_arrowLeft", typeof(Texture)));
        this.guistyle_16 = new GUIStyle();
        this.guistyle_16.hover.background = (Texture2D)((Texture)Resources.Load("GameGui/Lobby/selectChar/button_arrowRight", typeof(Texture)));
        this.guistyle_17 = new GUIStyle();
        this.guistyle_17.font = (Font)Resources.Load("Resources/GameGui/Fonts/Berlin28");
        this.guistyle_17.alignment = TextAnchor.MiddleLeft;
        this.guistyle_18 = new GUIStyle();
        this.guistyle_18.font = (Font)Resources.Load("Resources/GameGui/Fonts/Berlin24");
        this.guistyle_18.normal.textColor = new Color(0.15f, 0.1f, 0f, 1f);
        this.guistyle_18.alignment = TextAnchor.MiddleLeft;
    }


    public virtual void RenderStatBar(int offset,int nSlot)
    {
        GUI.BeginGroup(new Rect(0.5f * this.float_2 - 500f, (float)(800 + offset), 1000f, 200f));
        GUI.Label(new Rect(60f, 0f, 885f, 190f), this.texture_22);
      //  this.guistyle_17.normal.textColor = new Color(0.06f, 0.23f, 0.43f, 1f);
        GUI.Label(new Rect(275f, 56f, 150f, 30f), string.Empty + CharacterData.current.Name, this.guistyle_17);
        this.guistyle_17.normal.textColor = new Color(0.6f, 0.15f, 0.15f, 1f);
        GUI.Label(new Rect(430f, 56f, 100f, 30f), "lv." + CharacterData.current.lv, this.guistyle_17);
      //  this.guistyle_17.normal.textColor = new Color(0.06f, 0.43f, 0.11f, 1f);
      //  GUI.Label(new Rect(550f, 56f, 60f, 30f), string.Empty + CharacterData.current.getStat(3) * 10, this.guistyle_17);
     //   GUI.Label(new Rect(660f, 56f, 60f, 30f), string.Empty + CharacterData.current.getStat(4) * 3, this.guistyle_17);

        GUI.EndGroup();
    }

       
     private void InitLobbyMenu()
    {

        this.float_5 = 0f;
        this.texture_0 = (Texture)Resources.Load("GameGui/Title/chapter1", typeof(Texture));
        this.texture_2 = (Texture)Resources.Load("GameGui/Lobby/selectChar/button_createChar", typeof(Texture));
        this.guistyle_0 = new GUIStyle();
        this.guistyle_0.normal.background = (Texture2D)((Texture)Resources.Load("GameGui/Lobby/selectChar/button_createChar", typeof(Texture)));
        this.guistyle_0.hover.background = (Texture2D)((Texture)Resources.Load("GameGui/Lobby/selectChar/button_createChar_h", typeof(Texture)));
        
    }
    private void RenderLobbyMenu()
    {
        
        if (this.eLobbyMenuState_0 == eLobbyMenuState.start) 
        {
            GUI.DrawTexture(new Rect(0f, Mathf.SmoothStep(-300f, 0f, Time.time - this.float_0), 640f, 150f), this.texture_0);
            return;
        }
        if(this.eLobbyMenuState_0 == eLobbyMenuState.selectCharacterFirst)
        {
            GUI.DrawTexture(new Rect(0f, 0f, 640f, 150f), this.texture_0);
            if (Time.time - this.float_0 <1.0f)
            {
                return;
            }
           // GUI.DrawTexture(new Rect(0.5f * this.float_2 - 200f, 700f, 406f, 107f), this.texture_2);
           if(umiCharacterData.instance.nSlot[0] == "none")
            {
                if (GUI.Button(new Rect(0.5f * this.float_2 - 200f, 700f, 406f, 107f), string.Empty, this.guistyle_0))
                {
                    this.eLobbyState_0 = eLobbyState.CreateChar;
                    Debug.Log("Create Heroes +++");
                    return;
                }
            }else
            {
                this.RenderStatBar((int)Mathf.SmoothStep(400f, 0f, Time.time - this.float_5),0);
            }
            
        }
        if (this.eLobbyMenuState_0 == eLobbyMenuState.selectCharacterSecond)
        {
            GUI.DrawTexture(new Rect(0f, 0f, 640f, 150f), this.texture_0);
            if (Time.time - this.float_0 < 1.0f)
            {
                return;
            }
            //GUI.DrawTexture(new Rect(0.5f * this.float_2 - 200f, 700f, 406f, 107f), this.texture_2);
            if (umiCharacterData.instance.nSlot[1] == "none")
            {
                if (GUI.Button(new Rect(0.5f * this.float_2 - 200f, 700f, 406f, 107f), string.Empty, this.guistyle_0))
                {
                    this.eLobbyState_0 = eLobbyState.CreateChar;
                    Debug.Log("Create Heroes +++");
                    return;
                }
            }
            
           
            
        }
        if (this.eLobbyMenuState_0 == eLobbyMenuState.selectCharacterThird)
        {
            GUI.DrawTexture(new Rect(0f, 0f, 640f, 150f), this.texture_0);
            if (Time.time - this.float_0 < 1.0f)
            {
                return;
            }
            // GUI.DrawTexture(new Rect(0.5f * this.float_2 - 200f, 700f, 406f, 107f), this.texture_2);
            if (umiCharacterData.instance.nSlot[2] == "none")
            {
                if (GUI.Button(new Rect(0.5f * this.float_2 - 200f, 700f, 406f, 107f), string.Empty, this.guistyle_0))
                {
                    this.eLobbyState_0 = eLobbyState.CreateChar;
                    Debug.Log("Create Heroes +++");
                    return;
                }
            }
              
           
            
        }

    }
    public void DrawStatGraph(int posx, int posy)
    {
        Matrix4x4 matrix = GUI.matrix;
        for (int i = 0; i < 8; i++)
        {
            GUIUtility.RotateAroundPivot((float)this.int_13[i], new Vector2((0.5f * this.float_2 + (float)posx + this.vector3_1[i].x) * this.float_3, (this.vector3_1[i].z + (float)posy) * this.float_3));
            GUI.DrawTexture(new Rect(0.5f * this.float_2 + (float)posx + this.vector3_1[i].x, this.vector3_1[i].z + (float)posy, (float)(this.int_12[i] + 2), 2f), this.texture_20, ScaleMode.StretchToFill, true, 0f);
            GUI.matrix = matrix;
        }
    }
    public  void ResetStatGraph(int[] nStat, int nScale)
    {
        for (int i = 0; i < 8; i++)
        {
            this.vector3_1[i] = global::UmiMathX.rotateH(new Vector3(0f, 0f, (float)(nScale * nStat[i])), (float)(180 - i * 45));
        }
        for (int i = 0; i < 8; i++)
        {
            this.int_12[i] = (int)Vector3.Distance(this.vector3_1[i], this.vector3_1[(i + 1) % 8]);
            this.int_13[i] = (int)Vector3.Angle(new Vector3(-1f, 0f, 0f), this.vector3_1[i] - this.vector3_1[(i + 1) % 8]);
            if (this.vector3_1[i].z > this.vector3_1[(i + 1) % 8].z)
            {
                this.int_13[i] = this.int_13[i] * -1;
            }
        }
    }
    private void NextCreateChar(bool forward)
    {
        if (forward)
        {
            this.int_3 = this.int_3 % 12 + 1;
        }
        else
        {
            this.int_3 = (this.int_3 + 10) % 12 + 1;
        }
        this.eCreateCharState_0 = eCreateCharState.nextChar;
        this.float_7 = Time.time;
        this.bool_1 = forward;
        this.bool_2 = true;

        if (this.bool_2)
        {
            this.texture_13 = this.texture_14[this.int_3];
            this.int_9 = this.int_10[this.int_3];
        }
        else
        {
            this.int_9 = this.int_10[this.int_3];
            this.texture_15 = this.texture_16[this.int_3];
        }
        this.texture_17 = this.texture_18[this.int_3];

    }
    private void InitCreateCharacter()
    {
        eCreateCharState_0 = eCreateCharState.start;
        this.string_0 = "Character Name";
        this.int_2 = 100;
        this.int_3 = 1;
        this.int_8 = 0;
        this.float_8 = 0f;
        this.float_9 = 0f;
        this.float_10 = 0f;
        this.float_11 = 0f;
        this.float_12 = 0f;
        this.bool_0 = true;
        this.bool_1 = true;
        this.bool_2 = true;
       
        this.float_7 = 0f;
        this.guistyle_2 = new GUIStyle();
        this.guistyle_2.normal.background = (Texture2D)((Texture)Resources.Load("GameGui/Common/button_ok", typeof(Texture)));
        this.guistyle_2.hover.background = (Texture2D)((Texture)Resources.Load("GameGui/Common/button_ok_h", typeof(Texture)));
        this.guistyle_3 = new GUIStyle();
        this.guistyle_3.normal.background = (Texture2D)((Texture)Resources.Load("GameGui/Common/button_cancel", typeof(Texture)));
        this.guistyle_3.hover.background = (Texture2D)((Texture)Resources.Load("GameGui/Common/button_cancel_h", typeof(Texture)));
        this.guistyle_4 = new GUIStyle();
        this.guistyle_4.font = (Font)Resources.Load("Resources/GameGui/Fonts/GMO48", typeof(Font));
        this.guistyle_4.fontSize = 24; 
        this.guistyle_4.wordWrap = true;
        this.guistyle_5 = new GUIStyle();
        this.guistyle_5.normal.background = (Texture2D)((Texture)Resources.Load("GameGui/Lobby/createChar/button_create", typeof(Texture)));
        this.guistyle_5.hover.background = (Texture2D)((Texture)Resources.Load("GameGui/Lobby/createChar/button_create_h", typeof(Texture)));
        this.guistyle_6 = new GUIStyle();
        this.guistyle_6.hover.background = (Texture2D)((Texture)Resources.Load("GameGui/Lobby/createChar/button_close_h", typeof(Texture)));
        this.guistyle_8 = new GUIStyle();
        this.guistyle_8.normal.background = (Texture2D)((Texture)Resources.Load("GameGui/Lobby/createChar/button_random", typeof(Texture)));
        this.guistyle_8.hover.background = (Texture2D)((Texture)Resources.Load("GameGui/Lobby/createChar/button_random_h", typeof(Texture)));
        this.guistyle_9 = new GUIStyle();
        this.guistyle_9.normal.background = (Texture2D)((Texture)Resources.Load("GameGui/Lobby/createChar/button_arrowLeft", typeof(Texture)));
        this.guistyle_9.hover.background = (Texture2D)((Texture)Resources.Load("GameGui/Lobby/createChar/button_arrowLeft_h", typeof(Texture)));
        this.guistyle_10 = new GUIStyle();
        this.guistyle_10.normal.background = (Texture2D)((Texture)Resources.Load("GameGui/Lobby/createChar/button_arrowRight", typeof(Texture)));
        this.guistyle_10.hover.background = (Texture2D)((Texture)Resources.Load("GameGui/Lobby/createChar/button_arrowRight_h", typeof(Texture)));
        this.guistyle_11 = new GUIStyle();
        this.guistyle_11.alignment = TextAnchor.MiddleLeft;
        this.guistyle_11.fontSize = 16;
        this.guiskin_0 = (GUISkin)Resources.Load("GameGui/Skins/commonSkin", typeof(GUISkin));
        this.texture_6 = (Texture)Resources.Load("GameGui/Lobby/createChar/SlidingBar1");
        this.texture_7 = (Texture)Resources.Load("GameGui/Lobby/createChar/SlidingBar2");
        this.texture_8 = (Texture)Resources.Load("GameGui/Lobby/createChar/SlidingBar3");
        this.texture_9 = (Texture)Resources.Load("GameGui/Lobby/createChar/SlidingBar4");
        this.texture_14 = new Texture[13];
        this.texture_16 = new Texture[13];
        this.texture_18 = new Texture[13];

        
        for (int i = 1; i < 13; i++)
        {
            
            if (this.texture_14[i] == null)
            {
                this.texture_14[i] = (Texture)Resources.Load("GameGui/Lobby/createChar/char_" +this.string_1[i] , typeof(Texture));
            }
            if (this.texture_16[i] == null)
            {
                this.texture_16[i] = (Texture)Resources.Load("GameGui/Lobby/createChar/shadow_"+ this.string_1[i] , typeof(Texture));
            }
            if (this.texture_18[i] == null)
            {
                this.texture_18[i] = (Texture)Resources.Load("GameGui/Lobby/createChar/english/info_"+this.string_1[i] ,typeof(Texture));
            }
        }
        this.texture_10 = (Texture)Resources.Load("GameGui/Lobby/createChar/TopBG", typeof(Texture));
        this.texture_11 = (Texture)Resources.Load("GameGui/Lobby/createChar/BottomBG", typeof(Texture));
        this.texture_12 = (Texture)Resources.Load("GameGui/Lobby/createChar/BottomBar", typeof(Texture));
        this.texture_19 = (Texture)Resources.Load("GameGui/Lobby/createChar/statWindow", typeof(Texture));
        this.texture_20 = (Texture)Resources.Load("GameGui/Common/Red");
        this.texture_21 = (Texture)Resources.Load("GameGui/Common/TypeField", typeof(Texture));
        this.texture_99 = (Texture)Resources.Load("GameGui/Common/Black", typeof(Texture));
        

    }


    private void RenderCreateChar()
    {
        GUI.DrawTexture(new Rect(0f, 0f, 3500f, 3500f), this.texture_99);
        if (this.bool_2)
        {
            this.texture_13 = this.texture_14[this.int_3];
            this.int_9 = this.int_10[this.int_3];
        }
        else
        {
            this.int_9 = this.int_10[this.int_3];
            this.texture_15 = this.texture_16[this.int_3];
        }
        this.texture_17 = this.texture_18[this.int_3];

        GUI.skin = this.guiskin_0;
            float a = this.float_9;
            Color color = GUI.color;
            color.a = a;
            GUI.color = color;
            int num = Mathf.RoundToInt(0.5f * this.float_2 - (float)this.int_8 - this.float_8);
            if (-601 < num && num < 2775)
            {
                GUI.DrawTexture(new Rect((float)(num - 1035), 163f, 1036f, 714f), this.texture_9, ScaleMode.StretchToFill);
            }
            if (-1636 < num && num < 1740)
            {
                GUI.DrawTexture(new Rect((float)num, 163f, 1036f, 714f), this.texture_6, ScaleMode.StretchToFill);
            }
            if (-2670 < num && num < 705)
            {
                GUI.DrawTexture(new Rect((float)(num + 1035), 163f, 1036f, 714f), this.texture_7, ScaleMode.StretchToFill);
            }
            if (-3705 < num && num < -330)
            {
                GUI.DrawTexture(new Rect((float)(num + 2070), 163f, 1036f, 714f), this.texture_8, ScaleMode.StretchToFill);
            }
            if (-4740 < num && num < -1365)
            {
                GUI.DrawTexture(new Rect((float)(num + 3105), 163f, 1036f, 714f), this.texture_9, ScaleMode.StretchToFill);
            }
            if (-5775 < num && num < -2300)
            {
                GUI.DrawTexture(new Rect((float)(num + 4140), 163f, 1036f, 714f), this.texture_6, ScaleMode.StretchToFill);
            }
            Color color2 = GUI.color;
            color2.a = 1f;
            GUI.color = color2;
           
           
            GUI.DrawTexture(new Rect(0f, 0f, this.float_2, 162f), this.texture_10);
            GUI.DrawTexture(new Rect(0f, 874f, this.float_2, 150f), this.texture_11);
            GUI.DrawTexture(new Rect(0.5f * this.float_2 - 225f, 884f, 450f, 123f), this.texture_12);


        if (this.eCreateCharState_0 == eCreateCharState.start)
        {

            if (this.float_9 == 1f)
            {
                this.color_0 = RenderSettings.ambientLight;
                RenderSettings.ambientLight = Color.white;
                this.eCreateCharState_0 = eCreateCharState.selectChar;
                

            }
            else
            {
                this.float_9 = Mathf.Clamp01(this.float_9 + 0.5f * Time.deltaTime);
            }
            this.float_8 = (float)this.int_4[this.int_3];

        }
        else if (this.eCreateCharState_0 == eCreateCharState.selectChar)
        {

            Color color3 = GUI.color;
            color3.a = 1f;
            GUI.color = color3;
            this.float_8 = (float)this.int_4[this.int_3];
            if (this.bool_2)
            {
                GUI.DrawTexture(new Rect(0.5f * this.float_2 + (float)this.int_11[this.int_3], 163f, (float)this.int_9, 714f), this.texture_13);
                GUI.DrawTexture(new Rect(0.5f * this.float_2, 300f, 512f, 512f), this.texture_17);
                if (GUI.Button(new Rect(0.5f * this.float_2 + 115f, 540f, 200f, 77f), string.Empty, this.guistyle_5))
                {
                    Debug.Log("Create Data Char");
                    this.string_0 = "Character Name";
                    this.int_2 = 100;
                    this.texture_15 = this.texture_16[this.int_3];
                    if (this.gameObject_3)
                    {
                        UnityEngine.Object.Destroy(this.gameObject_3);
                    }
                    this.gameObject_3 = (GameObject)UnityEngine.Object.Instantiate((GameObject)Resources.Load("GameAssets/Characters/Lobby/viewChar/" + this.string_1[this.int_3], typeof(GameObject))
                        ,new Vector3(1f,1f,1f), Quaternion.Euler(-98f,90f,-90f));
                    if (this.string_1[this.int_3] == "Whale")
                    {
                        this.gameObject_3.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                    }
                    if (this.string_1[this.int_3] == "Bison")
                    {
                        
                        BisonEquipment bisonEquipment = (BisonEquipment)this.gameObject_3.GetComponent(typeof(BisonEquipment));
                        if (bisonEquipment != null)
                        {
                            bisonEquipment.scaleWeapon(1f);
                        }
                        
                    }
                    if (this.string_1[this.int_3] == "Whale")
                    {
                        WhaleEquipment whaleEquipment = (WhaleEquipment)this.gameObject_3.GetComponent(typeof(WhaleEquipment));
                        if (whaleEquipment != null)
                        {
                            whaleEquipment.scaleWeapon(1f);
                        }
                    }

                    eCreateCharState_0 = eCreateCharState.selectedChar;
                    this.float_7 = Time.time;

                }
            }
            else
            {
                GUI.DrawTexture(new Rect(0.5f * this.float_2 + (float)this.int_11[this.int_3], 163f, (float)this.int_9, 714f), this.texture_15);
                GUI.DrawTexture(new Rect(0.5f * this.float_2, 300f, 512f, 512f), this.texture_17);
            }
            if (GUI.Button(new Rect(0.5f * this.float_2 - 600f, 450f, 114f, 102f), string.Empty, this.guistyle_9))
            {
                this.NextCreateChar(false);
            }
            if (GUI.Button(new Rect(0.5f * this.float_2 + 500f, 450f, 114f, 102f), string.Empty, this.guistyle_10))
            {
                this.NextCreateChar(true);
            }
        }
        else if (this.eCreateCharState_0 == eCreateCharState.nextChar)
        {
            Color color4 = GUI.color;
            color4.a = 1f;
            GUI.color = color4;
            int num2 = this.int_4[this.int_3];
            if (!this.bool_1 && this.float_8 < (float)num2)
            {
                num2 -= 4144;
            }
            if (this.bool_1 && this.float_8 > (float)num2)
            {
                num2 += 4144;
            }
            float a2 = Mathf.Clamp01(2f * (Time.time - this.float_7));
            Color color5 = GUI.color;
            color5.a = a2;
            GUI.color = color5;
            if (this.bool_2)
            {
                GUI.DrawTexture(new Rect(0.5f * this.float_2 + (float)this.int_11[this.int_3] + (this.float_8 - (float)num2), 163f, (float)this.int_9, 714f), this.texture_13);
            }
            else
            {
                GUI.DrawTexture(new Rect(0.5f * this.float_2 + (float)this.int_11[this.int_3] + (this.float_8 - (float)num2), 163f, (float)this.int_9, 714f), this.texture_15);
            }
            GUI.DrawTexture(new Rect(0.5f * this.float_2, 300f - (this.float_8 - (float)num2), 512f, 512f), this.texture_17);
            Color color6 = GUI.color;
            color6.a = 1f;
            GUI.color = color6;
            if (GUI.Button(new Rect(0.5f * this.float_2 - 600f, 450f, 114f, 102f), string.Empty, this.guistyle_9))
            {
                this.NextCreateChar(false);
            }
            if (GUI.Button(new Rect(0.5f * this.float_2 + 500f, 450f, 114f, 102f), string.Empty, this.guistyle_10))
            {
                this.NextCreateChar(true);
            }
            if (Mathf.Abs(this.float_8 - (float)num2) > 1f)
            {
                this.float_8 = Mathf.SmoothDamp(this.float_8, (float)num2, ref this.float_12, 0.6f);
                if (this.float_8 > 4144f)
                {   
                    this.float_8 -= 4144f;
                }
                if (this.float_8 < 0f)
                {
                    this.float_8 += 4144f;
                }
            }
            else
            {
                this.eCreateCharState_0 = eCreateCharState.selectChar;
            }

        }
        else if (this.eCreateCharState_0 == eCreateCharState.selectedChar)
        {
            Color color7 = GUI.color;
            color7.a = 1f;
            GUI.color = color7;
            int num3 = this.int_4[this.int_3] + 130;
            this.float_8 = Mathf.SmoothDamp(this.float_8, (float)num3, ref this.float_12, 0.5f);
            if (this.texture_15)
            {
                GUI.DrawTexture(new Rect(0.5f * this.float_2 + (float)this.int_11[this.int_3] + ((float)this.int_4[this.int_3] - this.float_8), 163f, (float)this.int_9, 714f), this.texture_15);
            }
            if (this.texture_13)
            {
                GUI.DrawTexture(new Rect(0.5f * this.float_2 + (float)this.int_11[this.int_3] + 2f * ((float)this.int_4[this.int_3] - this.float_8), 163f, (float)this.int_9, 714f), this.texture_13);
            }
            float a3 = Mathf.Clamp01(2f * (Time.time - this.float_7));
            Color color8 = GUI.color;
            color8.a = a3;
            GUI.color = color8;
            GUI.DrawTexture(new Rect(0.5f * this.float_2 - 200f, 200f, 795f, 481f), this.texture_19);
            Color color9 = GUI.color;
            color9.a = 1f;
            GUI.color = color9;
            if (Mathf.Abs(this.float_8 - (float)num3) <= 1f)
            {

                this.float_7 = Time.time;
                this.float_10 = Time.time;
                this.float_11 = Time.time;
                this.eCreateCharState_0 = eCreateCharState.randomStat;
            }
        }
        else if (this.eCreateCharState_0 == eCreateCharState.randomStat)
        {
            Color color10 = GUI.color;
            color10.a = 1f;
            GUI.color = color10;
            this.float_8 = (float)(this.int_4[this.int_3] + 130);
            if (this.texture_15)
            {
                GUI.DrawTexture(new Rect(0.5f * this.float_2 + (float)this.int_11[this.int_3] + ((float)this.int_4[this.int_3] - this.float_8), 163f, (float)this.int_9, 714f), this.texture_15);
            }
            GUI.DrawTexture(new Rect(0.5f * this.float_2 + (float)this.int_11[this.int_3] + 2f * ((float)this.int_4[this.int_3] - this.float_8), 163f, (float)this.int_9, 714f), this.texture_13);
            GUI.BeginGroup(new Rect(0.5f * this.float_2 - 200f, 200f, 795f, 481f));
            GUI.DrawTexture(new Rect(0f, 0f, 795f, 481f), this.texture_19);
            GUI.DrawTexture(new Rect(113f, 42f, 200f, 32f), this.texture_21);
            this.string_0 = GUI.TextField(new Rect(120f, 40f, 200f, 32f), this.string_0, 15, this.guistyle_11);
            if (Time.time - this.float_10 < 2f)
            {
                this.int_6 = CharacterData.getNewRandomStat(this.string_1[this.int_3]);
                this.ResetStatGraph(this.int_6, 7);
                if (this.float_11 < Time.time)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        this.int_7[i] = UnityEngine.Random.Range(3, 9);
                    }
                    this.float_11 = Time.time + 0.03f;
                }
                for (int j = 0; j < 8; j++)
                {
                    GUI.Label(new Rect(130f, (float)(155 + j * 34), 50f, 50f), string.Empty + this.int_7[j] , this.guistyle_4);
                }
                GUI.DrawTexture(new Rect(215f, 410f, 160f, 36f), this.guistyle_8.hover.background);
            }
            else
            {
                for (int k = 0; k < 8; k++)
                {
                    GUI.Label(new Rect(130f, (float)(155 + k * 34), 50f, 50f), string.Empty + this.int_6[k], this.guistyle_4);
                }
                if (GUI.Button(new Rect(215f, 410f, 160f, 36f), string.Empty, this.guistyle_8))
                {
                    this.float_10 = Time.time;
                    this.float_11 = Time.time;
                    this.int_6 = CharacterData.getNewRandomStat(this.string_1[this.int_3]);
                    this.ResetStatGraph(this.int_6, 7);
                    
                }
            }
            GUI.EndGroup();
            if (Time.time - this.float_10 >= 2f)
            {
                this.DrawStatGraph(97, 457);
            }
            if (this.eLobbyState_0 == eLobbyState.CreateChar)
            {
                this.createCam.enabled = true;
            }
            else
            {
                this.createCam.enabled = false;
            }
            if (Time.time - this.float_7 > 2f)
            {
                
                float a4 = Mathf.Clamp01(Time.time - this.float_7 - 2f);
                Color color11 = GUI.color;
                color11.a = a4;
                GUI.color = color11;
                if (this.createCamTexture.IsCreated())
                {
                    GUI.DrawTexture(new Rect(0.5f * this.float_2 + 140f, 250f, 512f, 512f), this.createCamTexture);
                }
                Color color12 = GUI.color;
                color12.a = 1f;
                GUI.color = color12;
            }
            if (GUI.Button(new Rect(0.5f * this.float_2 + 300f, 654f, 124f, 48f), string.Empty, this.guistyle_2))
            {
            }
            if (GUI.Button(new Rect(0.5f * this.float_2 + 440f, 654f, 127f, 48f), string.Empty, this.guistyle_3))
            {
                this.eCreateCharState_0 = eCreateCharState.unselectChar;
                this.float_7 = Time.time;
                if (this.gameObject_3)
                {
                    UnityEngine.Object.Destroy(this.gameObject_3);
                }
               
            }
            


        }
        else if (eCreateCharState_0 == eCreateCharState.unselectChar)
        {
            Color color13 = GUI.color;
            color13.a = 1f;
            GUI.color = color13;
            int num4 = this.int_4[this.int_3];
            this.float_8 = Mathf.SmoothDamp(this.float_8, (float)num4, ref this.float_12, 0.5f);
            float a5 = Mathf.Lerp(1f, 0f, 2f * (Time.time - this.float_7));
            Color color14 = GUI.color;
            color14.a = a5;
            GUI.color = color14;
            GUI.DrawTexture(new Rect(0.5f * this.float_2 + (float)this.int_11[this.int_3] + ((float)this.int_4[this.int_3] - this.float_8), 163f, (float)this.int_9, 714f), this.texture_15);
            Color color15 = GUI.color;
            color15.a = 1f;
            GUI.color = color15;
            GUI.DrawTexture(new Rect(0.5f * this.float_2 + (float)this.int_11[this.int_3] + 2f * ((float)num4 - this.float_8), 163f, (float)this.int_9, 714f), this.texture_13);
            if (Mathf.Abs(this.float_8 - (float)num4) <= 1f)
            {
                this.eCreateCharState_0 = eCreateCharState.selectChar;
            }
        }

            float a7 = this.float_9;
            Color color19 = GUI.color;
            color19.a = a7;
            GUI.color = color19;
            if (GUI.Button(new Rect(0.5f * (this.float_2 - 204f), 884f, 204f, 78f), string.Empty, this.guistyle_6))
            {

            }
            Color color20 = GUI.color;
            color20.a = 1f;
            GUI.color = color20;



        
    }
    private void loadDac()
    {

    }

    public void OnGUI()
    {
            GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3((float)Screen.height / 1024f, (float)Screen.height / 1024f, 1f));
            GUI.depth = 1;
            this.float_2 = (float)(1024 * Screen.width / Screen.height);
            this.float_3 = (float)Screen.height / 1024f;
          
            if (this.eLobbyState_0 == eLobbyState.lobbyMenu)
            {
                this.RenderLobbyMenu();
                return;
            }
            else if (this.eLobbyState_0 == eLobbyState.CreateChar)
            {
                this.RenderCreateChar();
            }

        
    }
}
