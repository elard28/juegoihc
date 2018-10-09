using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puntero : MonoBehaviour {

	public Rigidbody rb;
	public GameObject player;
	movimiento sc;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		sc = player.GetComponent<movimiento>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter(Collider col)
	{
		Debug.Log ("Choca");
		if(col.gameObject.CompareTag ("CuboAgarre"))
		{
			Destroy(col.gameObject);
			sc.onepoint();

		}
	}
}
