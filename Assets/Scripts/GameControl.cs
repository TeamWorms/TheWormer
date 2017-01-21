using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {

    // Use this for initialization
    public GameObject police;
    public float timerToPolice;
    public bool PoliceEnable;

    [HideInInspector]
    public GameObject[] shelterArray;

    [HideInInspector]
    public Jump[] PlayerJoint;

     [HideInInspector]
    public GameObject PlayerParent;

    [HideInInspector]
    public float XPositionOfPlayer;


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
        PlayerParent = GameObject.FindGameObjectWithTag("Player"); 
        PlayerJoint = PlayerParent.GetComponentsInChildren<Jump>(); ;
        //do something to find trap or others tusff

    }
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < 4; i++)
        {
            XPositionOfPlayer += PlayerJoint[i].transform.position.x;
        }
        XPositionOfPlayer /= 4;
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
       
    }
}
