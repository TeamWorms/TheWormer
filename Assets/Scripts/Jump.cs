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
    public AudioClip movementSoundLand;
    public AudioClip movementSoundWater;

    public enum MovementState{
        Ground,
        Water
    }

    public MovementState movementState;

    float cooldownWaterRemain;

    private KeyCode keyCode;
    private string controllerInputName;

    private bool onGround;
    private int forceX = 0;
    private int forceY = 200;

    private AudioSource audioSource;

    // Use this for initialization
    void Start () {
        audioSource = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
        audioSource.clip = movementSoundLand;

        movementState = MovementState.Ground;
        switch (key)
        {
            case "q":
                keyCode = KeyCode.Q;
                controllerInputName = "LeftBumperWindows";
                break;
            case "w":
                keyCode = KeyCode.W;
                controllerInputName = "XButtonWindows";
                break;
            case "e":
                keyCode = KeyCode.E;
                controllerInputName = "AButtonWindows";
                break;
            case "r":
                controllerInputName = "RightBumperWindows";
                keyCode = KeyCode.R;
                break;
        }
	}

    bool inputDown()
    {
        return Input.GetKeyDown(keyCode) || Input.GetButtonDown(controllerInputName);
    }
	
	// Update is called once per frame
	void Update () {
        if (movementState == MovementState.Ground && GameContext.playerGroundCount > 0 && inputDown())
        {
            if (forceModifyingObject == null || forceModifyingObject.GetComponent<Jump>().onGround)
            {
                forceX = directionalForce;
                forceY = jumpForce;
            }
            Vector3 force = new Vector3(forceX, forceY, 0);
            gameObject.GetComponent<Rigidbody>().AddForce(force);
            audioSource.PlayOneShot(movementSoundLand, 1F);
        }
        else if(movementState == MovementState.Water && inputDown() && cooldownWaterRemain <= 0) 
        {
            if (forceModifyingObject == null || forceModifyingObject.GetComponent<Jump>().onGround)
            {
                forceX = directionalForce;
                forceY = jumpForce;
            }
            Vector3 force = new Vector3(forceX, forceY, 0);
            gameObject.GetComponent<Rigidbody>().AddForce(force);
            cooldownWaterRemain = cooldownInWater;
            audioSource.PlayOneShot(movementSoundWater, 1F);
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
            GameContext.playerGroundCount++;
        }
    }


    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            onGround = false;
            GameContext.playerGroundCount--;
        }
    }

}
