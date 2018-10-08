using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mueve : MonoBehaviour {

	public float spinvalue = 90;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.up * spinvalue * Time.deltaTime);
		//transform.Translate (Vector3.up * spinvalue * Time.deltaTime);
	}
}
