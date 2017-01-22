using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    public Transform bornTransform;
    private ParticleSystem particle;

	// Use this for initialization
	void Start () {
        particle = GetComponentInChildren<ParticleSystem>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        GameContext.BornPos = bornTransform.position;
        print(GameContext.BornPos);
        particle.startColor = Color.green; //new Color(123,253,161,255); //
        GetComponent<MeshRenderer>().material.color = Color.green;
    }
}
