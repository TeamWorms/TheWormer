using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {

    // Use this for initialization
    public GameObject police;
    public float timerToPolice;
    public bool PoliceEnable;
    public Transform bornTransform;
    public GameObject playerPrefab;

    [HideInInspector]
    public UIController uiController;

    [HideInInspector]
    public GameObject[] shelterArray;

    [HideInInspector]
    public Jump[] PlayerJoint;

     [HideInInspector]
    public GameObject PlayerParent;

    [HideInInspector]
    public float XPositionOfPlayer;

    [HideInInspector]
    public bool islose;

    [HideInInspector]
    public CameraFollow camera;

    private float timerToGenerate;
    private float timer;
    private float alertTimer;
    static GameControl _instance;
    private bool isGeneratePolice;

    void Awake()
    {
        _instance = this;
    }

    public static GameControl Instance
    {
        get
        {
            return _instance;
        }
    }

    void Start () {
        timerToGenerate = timerToPolice * (Random.value + 1);
        GameContext.isPlayerHid = false;
        PlayerParent = GameObject.FindGameObjectWithTag(GameContext.Player);
        isGeneratePolice = false;
        if (GameContext.BornPos == Vector3.zero)
        {
            if (bornTransform != null)
                GameContext.BornPos = bornTransform.position;
            else
                GameContext.BornPos = PlayerParent.transform.position;
        }
        PlayerParent.transform.position = GameContext.BornPos;
        PlayerJoint = PlayerParent.GetComponentsInChildren<Jump>();
        if (GameObject.FindGameObjectWithTag(GameContext.UI)!=null)
        {
            uiController = GameObject.FindGameObjectWithTag(GameContext.UI).GetComponent<UIController>();
            uiController.InitUI();
        }
      
        //do something to find trap or others tusff

    }
	
	// Update is called once per frame
	void Update () {

        
        for (int i = 0; i < 4; i++)
        {
            XPositionOfPlayer += PlayerJoint[i].transform.position.x;
        }
        XPositionOfPlayer /= 4;

        //police
        if (PoliceEnable&&!isGeneratePolice)
        {
            timer += Time.deltaTime;
            if (timer > timerToGenerate)
            {
                GameObject go = Instantiate(police);
                isGeneratePolice = true;
                uiController.ShowPoliceAlert();
                go.transform.position = new Vector3(GameControl.Instance.XPositionOfPlayer-25,3.3f,-12);
                timer = 0;
                alertTimer = 0;
                timerToGenerate = timerToPolice * (Random.value + 1);
            }
        }
        //police alert
        if (alertTimer>=0)
        {
            alertTimer += Time.deltaTime;
        }   
        if (alertTimer>2)
        {
            alertTimer = -1;
            uiController.disablePoliceAlert();
        }


        //show UI
        if (islose)
        {
            if (uiController!=null)
            {
                uiController.ShowLoseGame();
            }  
        }  
    }
    public void ReGeneratePolice()
    {
        isGeneratePolice = false;
    }
    public void Restart()
    {
        print(GameContext.BornPos);
        GameContext.playerGroundCount = 0;
        /* PlayerParent.gameObject.SetActive(false);
         for (int i = 0; i < 4; i++)
         {
             PlayerJoint[i].gameObject.SetActive(false);
             PlayerJoint[i].gameObject.transform.localPosition = PlayerJoint[i].originalPos;
             PlayerJoint[i].gameObject.SetActive(true);
         }
         PlayerParent.transform.position = GameContext.BornPos;

         PlayerParent.SetActive(true);*/
        GameObject temp = PlayerParent;
        GameObject player = Instantiate(playerPrefab);
        player.transform.position = GameContext.BornPos;
        PlayerParent = player;
        PlayerJoint = PlayerParent.GetComponentsInChildren<Jump>();
        camera.objectToFollow = PlayerJoint[0].transform;

        Destroy(temp);
        if (uiController != null)
        {
            islose = false;
            uiController.HideLoseGame();
        }
    }
}
