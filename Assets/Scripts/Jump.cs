using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Jump : MonoBehaviour {

    public string key;
    public int jumpForce;
    public int directionalForce;
    public GameObject forceModifyingObject;

    private KeyCode keyCode;
    private bool onGround;
    private int forceX = 0;
    private int forceY = 200;

	// Use this for initialization
	void Start () {
        switch (key)
        {
            case "q":
                keyCode = KeyCode.Q;
                break;
            case "w":
                keyCode = KeyCode.W;
                break;
            case "e":
                keyCode = KeyCode.E;
                break;
            case "r":
                keyCode = KeyCode.R;
                break;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (onGround && Input.GetKeyDown(keyCode))
        {
            if (forceModifyingObject == null || forceModifyingObject.GetComponent<Jump>().onGround)
            {
                forceX = directionalForce;
                forceY = jumpForce;
            }
            Vector3 force = new Vector3(forceX, forceY, 0);
            gameObject.GetComponent<Rigidbody>().AddForce(force); 
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            onGround = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            onGround = false;
        }
    }

}
