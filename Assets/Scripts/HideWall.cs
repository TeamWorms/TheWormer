using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideWall : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter(Collider col)
    {
        GameContext.isPlayerHid = true;
    }


    void OnTriggerExit(Collider col)
    {
        GameContext.isPlayerHid = false;
    }
}
