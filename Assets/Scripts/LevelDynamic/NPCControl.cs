using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCControl : MonoBehaviour {

    public bool willFollow;
    public GameObject joint;
    public float timeToRatetLeft;
    public float timeToRatetDown;
    public Transform standingGO;
    public Transform followingGO;


    private Transform myTrans;
    private float timerToJump;
    private Rigidbody rigi;
    private string NPCword;
    private char[] NPCInputList;
    private int InputCount;
    private bool isGenerateList;
    private bool beginToFollow;
    private bool finishRotate;
    private float randomJumpTime;



	// Use this for initialization
	void Start () {
        myTrans = GetComponent<Transform>();
        rigi = standingGO.GetComponent<Rigidbody>();
        NPCInputList = new char[4];
        NPCword = "Help!";
        isGenerateList = false;
        beginToFollow = false;
        finishRotate = false;
        randomJumpTime = 3 * (Random.value+1);
    }
	
	// Update is called once per frame
	void Update () {
        //idle stuff
        timerToJump += Time.deltaTime;
        if (timerToJump> randomJumpTime && !beginToFollow)
        {
            rigi.AddForce(new Vector3(0, 300, 0));
            timerToJump = 0;
        }

        //Follow Character
        if (beginToFollow)
        {
            if (!finishRotate)
            {
                if (timeToRatetLeft>0)
                {
                    timeToRatetLeft -= Time.deltaTime;
                    followingGO.Rotate(new Vector3(0, 1, 0), -2);
                }else
                {
                    if (timeToRatetDown>0)
                    {
                        timeToRatetDown -= Time.deltaTime;
                        followingGO.Rotate(new Vector3(1, 0, 0), -2);
                    }else
                    {
                        finishRotate = true;
                    }
                }
            }
            else
            {

            }
            //if (GameControl.Instance.XPositionOfPlayer - myTrans.position.x > 4f)
            //{
            //    myTrans.position = new Vector3(myTrans.position.x+0.05f, myTrans.position.y, myTrans.position.z);
            //}
        }

        //follow Character
        if (willFollow&&!beginToFollow)
        {
          // print(Mathf.Abs(GameControl.Instance.XPositionOfPlayer - standingGO.position.x));
            if (Mathf.Abs(GameControl.Instance.XPositionOfPlayer - standingGO.position.x)<6f)
            {
                //NPCword = "I see you";
                if (!isGenerateList)
                {
                    GenerateInputList();
                    NPCword = "Teach me to dance:\n";
                    for (int i = 0; i < 4; i++)
                    {
                        NPCword += NPCInputList[i] + ",";
                    }
                    isGenerateList = true;
                }else
                {
                    checkInput();
                    if (InputCount==4)
                    {
                        //print("begin");
                        followingGO.gameObject.SetActive(true);
                        standingGO.gameObject.SetActive(false);
                        // joint.SetActive(true);
                        NPCword = "";
                        beginToFollow = true;
                    }
                }
            }else
            {
                NPCword = "Help!";
                isGenerateList = false;
            }
        }
    }
    void checkInput()
    {
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (NPCInputList[InputCount]=='R')
            {
                InputCount++;
            }else
            {
                InputCount = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (NPCInputList[InputCount] == 'E')
            {
                InputCount++;
            }
            else
            {
                InputCount = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (NPCInputList[InputCount] == 'W')
            {
                InputCount++;
            }
            else
            {
                InputCount = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (NPCInputList[InputCount] == 'Q')
            {
                InputCount++;
            }
            else
            {
                InputCount = 0;
            }
        }
    }
    void GenerateInputList()
    {
        for (int i = 0; i < 4; i++)
        {
            float randomValue = Random.value;
            if (randomValue < 0.25)
            {
                NPCInputList[i] = 'Q';
            }
            else if (randomValue >= 0.25&& randomValue < 0.5)
            {
                NPCInputList[i] = 'W';
            }
            else if (randomValue >= 0.5 && randomValue < 0.75)
            {
                NPCInputList[i] = 'E';
            }
            else
            {
                NPCInputList[i] = 'R';
            }
        }
    }
    void OnGUI()
    {
        Vector3 worldPosition = new Vector3(standingGO.position.x, standingGO.position.y + 5.5f, standingGO.position.z);
        Vector2 position = Camera.main.WorldToScreenPoint(worldPosition);
        position = new Vector2(position.x, Screen.height - position.y);

        Vector2 nameSize = GUI.skin.label.CalcSize(new GUIContent(NPCword));
        GUI.color = Color.black;
        GUI.Label(new Rect(position.x - (nameSize.x / 2), position.y - nameSize.y, nameSize.x, nameSize.y), NPCword);
    }
}
