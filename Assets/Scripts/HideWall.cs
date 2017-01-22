using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideWall : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
     void Update()
    {
        if (Mathf.Abs(GameControl.Instance.XPositionOfPlayer-transform.position.x)<10)
        {
            GameContext.isPlayerHid = true;
        }else
        {
            GameContext.isPlayerHid = false;
        }
    }
    void OnTriggerEnter(Collider col)
    {


    }


    void OnTriggerExit(Collider col)
    {

    }
}
