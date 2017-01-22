using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {

    // Use this for initialization
    public GameObject police;
    public float timerToPolice;
    public bool PoliceEnable;

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

    private float timerToGenerate;
    private float timer;
    static GameControl _instance;

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
        if (PoliceEnable)
        {
            timer += Time.deltaTime;
            if (timer > timerToGenerate)
            {
                GameObject go = Instantiate(police);
                timer = 0;
                timerToGenerate = timerToPolice * (Random.value + 1);
            }
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
}
