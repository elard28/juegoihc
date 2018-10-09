using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ataca : MonoBehaviour {

	public Rigidbody rb;
	public float speed;
	//bool begin = false;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		//GetComponent<Renderer>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		//if(begin)
		rb.velocity = transform.forward *speed;
	}

	void OnTriggerEnter(Collider other)
	{
		//Destroy (gameObject);
		//transform.Translate(new Vector3 (Random.Range (-30, 30), Random.Range (-1, 1), 8));
	}

	/*void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;
        //Instantiate(explosionPrefab, pos, rot);
        Destroy(gameObject);
    }*/
}
