using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour {

	public Transform vrcamera;
	public float toggleangle = 30.0f;
	public float speed = 3.0f;
	public bool  moveforward;

	private CharacterController cc;

	// Use this for initialization
	void Start () {
		cc = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (vrcamera.eulerAngles.x >= toggleangle && vrcamera.eulerAngles.x < 90.0f)
			moveforward = true;
		else
			moveforward = false;

		if (moveforward) {
			Vector3 forward = vrcamera.TransformDirection (Vector3.forward);
			cc.SimpleMove (forward * speed);
		}
	}

	/*void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;
        //Instantiate(explosionPrefab, pos, rot);
        Destroy(gameObject);
    }*/

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.tag == "enemigo")
		{
			Destroy(col.gameObject);
		}
	}
}
