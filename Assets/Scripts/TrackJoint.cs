using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackJoint : MonoBehaviour {

    public Transform jointToLookAt;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // transform.LookAt(jointToLookAt);
        if(gameObject.tag == "Tail")
        {
            transform.right = (jointToLookAt.position - transform.position).normalized;
        }
        if (gameObject.tag == "Head")
        {
            transform.up = (jointToLookAt.position - transform.position).normalized;
        }
    }
}
