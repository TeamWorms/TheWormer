using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Jump : MonoBehaviour {

    public string key;
    public int jumpForce;
    public int directionalForce;
    public GameObject forceModifyingObject;
    public float cooldownInWater;

    public enum MovementState{
        Ground,
        Water
    }

    public MovementState movementState;

    float cooldownWaterRemain;

    private KeyCode keyCode;
    private bool onGround;
    private int forceX = 0;
    private int forceY = 200;

	// Use this for initialization
	void Start () {
        movementState = MovementState.Ground;
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
        if (movementState == MovementState.Ground && onGround && Input.GetKeyDown(keyCode))
        {
            if (forceModifyingObject == null || forceModifyingObject.GetComponent<Jump>().onGround)
            {
                forceX = directionalForce;
                forceY = jumpForce;
            }
            Vector3 force = new Vector3(forceX, forceY, 0);
            gameObject.GetComponent<Rigidbody>().AddForce(force); 
        }
        else if(movementState == MovementState.Water && Input.GetKeyDown(keyCode) && cooldownWaterRemain <= 0) 
        {
            if (forceModifyingObject == null || forceModifyingObject.GetComponent<Jump>().onGround)
            {
                forceX = directionalForce;
                forceY = jumpForce;
            }
            Vector3 force = new Vector3(forceX, forceY, 0);
            gameObject.GetComponent<Rigidbody>().AddForce(force);
            cooldownWaterRemain = cooldownInWater;
        }
        if(cooldownWaterRemain > 0)
        {
            cooldownWaterRemain -= Time.deltaTime;
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
