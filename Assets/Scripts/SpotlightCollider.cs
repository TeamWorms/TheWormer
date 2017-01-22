using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if(col.tag != "Ground" && GameContext.isPlayerHid == false)
        {

            print("spotted");
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.tag != "Ground" && GameContext.isPlayerHid == false)
        {

            print("spotted");
        }
    }
}
