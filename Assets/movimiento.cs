using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movimiento : MonoBehaviour {

	public Transform vrcamera;
	public float toggleangle = 30.0f;
	public float speed = 3.0f;
	public float throwing = 20.0f;
	//public bool  moveforward;

	public Text lifetext;
	public Text countertext;
	public Text finished;

	public int lives;
	private int completed = 0;

	private bool holding = false;
	private GameObject hold;

	private CharacterController cc;

	// Use this for initialization
	void Start () {
		cc = GetComponent<CharacterController> ();
		lifetext.text = "Vidas: "+lives;
		countertext.text = "Completos: "+completed;
	}
	
	// Update is called once per frame
	void Update () {
		if (completed == 5)
			finished.text = "LOGRADO";
		else if (lives == 0)
			finished.text = "FINALIZADO";

		/*if (vrcamera.eulerAngles.x >= toggleangle && vrcamera.eulerAngles.x < 90.0f)
			moveforward = true;
		else
			moveforward = false;

		if (moveforward) {
			Vector3 forward = vrcamera.TransformDirection (Vector3.forward);
			cc.SimpleMove (forward * speed);
		}*/

		lifetext.text = "Vidas: "+lives;
		countertext.text = "Completos: "+completed;

		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");

		Vector3 forward = vrcamera.TransformDirection (Vector3.forward);
		Debug.Log (forward);


		Vector3 pad = new Vector3 (v*1.5f,0.0f,-h*1.5f);

		//Debug.Log (pad);

		cc.SimpleMove (pad * speed);

		if (Input.GetButtonUp ("Fire1")) {
			holding = false;
			Rigidbody rb = hold.GetComponent<Rigidbody> ();

			Vector3 movement = new Vector3 (5.0f, 0.0f, 0.0f);
			rb.AddForce (movement * throwing);
			throwing = 0.0f;
		}

		if (holding)
			hold.transform.position = new Vector3 (transform.position.x+2.0f, hold.transform.position.y, transform.position.z);
	}

	void OnTriggerEnter (Collider col)
	{
		Debug.Log ("Entrada");
		if(col.gameObject.CompareTag ("enemigo"))
		{
			//Destroy(col.gameObject);
			lives = lives - 1;
		}
	}

	void OnTriggerStay (Collider col)
	{
		Debug.Log ("Dentro");
		if(col.gameObject.CompareTag ("CuboAgarre"))
		{
			if (Input.GetButtonDown ("Fire1")) {
				throwing = 20.0f;
				holding = true;
				hold = col.gameObject;
			}
		}
	}

	public void onepoint(){
		completed = completed + 1;
	}
}

//