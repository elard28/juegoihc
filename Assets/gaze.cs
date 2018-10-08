using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class gaze : MonoBehaviour {

	public float gazetime = 3.0f;
	private float timer;
	private bool gazedat;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= gazetime) {
			ExecuteEvents.Execute (gameObject, new PointerEventData (EventSystem.current), ExecuteEvents.pointerDownHandler);
			timer = 0f;
		}
	}

	public void PointerEnter()
	{
		gazedat = true;
	}

	public void PointerExit()
	{
		gazedat = false;
	}

	public void PointerDown()
	{
		Debug.Log ("PointerDown");	
	}
}
