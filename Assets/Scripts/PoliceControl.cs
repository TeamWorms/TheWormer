using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceControl : MonoBehaviour {

    // Use this for initialization
    public float lifetime;
    public float speed;

    private Transform myTrans;
    private Rigidbody rigi;
    private float timer;
    private float lifeTimer;
    private GameObject player;
    private string TextOfPolice;

    private float spotTimer;
    private Transform transOfSpotLight;
    private bool RightRotate;
	void Start () {
        rigi = GetComponent<Rigidbody>();
        myTrans = GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player");
        timer = 0;
        lifeTimer = 0;
        spotTimer = 0;
        RightRotate = true;
        TextOfPolice = "Police";
        transOfSpotLight = myTrans.FindChild("Spotlight");
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        lifeTimer += Time.deltaTime;
        if (myTrans.position.z>player.transform.position.z&&!GameContext.isPlayerHid)
        {
            myTrans.position = new Vector3(myTrans.position.x, myTrans.position.y, myTrans.position.z - speed);
        }
        else
        {
            TextOfPolice = "What the hell you are doing";
        }

        if (timer>=2)
        {
            rigi.AddForce(new Vector3(0, 300, 0));
            timer = 0;
        }

        if (lifeTimer> lifetime)
        {
            Destroy(this.gameObject);
        }

        if (transOfSpotLight!=null)
        {
            spotTimer += Time.deltaTime;
            if (spotTimer>0.5)
            {
                RightRotate = !RightRotate;
                spotTimer = 0;
            }
            if (RightRotate)
            {
                transOfSpotLight.Rotate(new Vector3(0, 1, 0), 2);
            }else
            {
                transOfSpotLight.Rotate(new Vector3(0, 1, 0), -2);
            }
            
        }
    }

    void OnGUI()
    {
        Vector3 worldPosition = new Vector3(transform.position.x, transform.position.y + 2.5f, transform.position.z);
        Vector2 position =Camera.main.WorldToScreenPoint(worldPosition);
        position = new Vector2(position.x, Screen.height - position.y);

        Vector2 nameSize = GUI.skin.label.CalcSize(new GUIContent(TextOfPolice));
        GUI.color = Color.black;
        GUI.Label(new Rect(position.x - (nameSize.x / 2), position.y - nameSize.y, nameSize.x, nameSize.y), TextOfPolice);

    }
}
