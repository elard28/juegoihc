using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logo : MonoBehaviour {

	AudioSource audioData;
	// Use this for initialization
	void Start () {
		audioData = GetComponent<AudioSource>();
		audioData.Play(0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
