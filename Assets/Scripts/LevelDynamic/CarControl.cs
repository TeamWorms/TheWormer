using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControl : MonoBehaviour {
    public float speed;
    private Rigidbody carRigi;
    private float timer;
    // Use this for initialization
    void Start () {
        carRigi = GetComponentInChildren<Rigidbody>();
        timer = 0;
        speed = 2+1*Random.value;
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer<3)
        {
            return;
        }
        if (carRigi.transform.position.z > -42)
        {
            carRigi.transform.position = new Vector3(carRigi.transform.position.x, carRigi.transform.position.y, carRigi.transform.position.z - speed);

        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == GameContext.Head)
        {
            GameControl.Instance.islose=true;
        }
    }
}
