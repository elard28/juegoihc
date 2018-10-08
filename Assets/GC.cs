using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GC : MonoBehaviour {

	public GameObject enemies;
	public Vector3 spawns;
	public int count;
	public float wait;
	public float start;
	public float speed;

	// Use this for initialization
	void Start () {
		StartCoroutine(spawnwaves());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator spawnwaves()
	{
		yield return new WaitForSeconds (start);
		for (;;) {
			Vector3 spawnpositions = new Vector3 (Random.Range (-spawns.x, spawns.x), Random.Range (-spawns.y, spawns.y), spawns.z);
			Quaternion spawnrotation = Quaternion.identity;
			Instantiate (enemies, spawnpositions, spawnrotation);
			yield return new WaitForSeconds (wait);
		}
	}
}
