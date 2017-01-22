using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    public Transform bornTransform;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        GameContext.BornPos = bornTransform.position;
        print(GameContext.BornPos);
        GetComponent<MeshRenderer>().material.color = Color.green;
    }
}
