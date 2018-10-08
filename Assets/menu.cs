using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu : MonoBehaviour {

	public GameObject enemies;
	public Vector3 spawns;
	public int count;
	public float wait;
	public float start;
	public float speed;

	//Rigidbody rb;
	// Use this for initialization
	void Start () {
		//rb = enemies.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void startEnemies()
	{
		//itself.SetActive (false);
		//GetComponent<Renderer>().enabled = false;

		transform.Translate (Vector3.forward * 1000 * Time.deltaTime);
		//spawnwaves ();
		//rb.velocity = transform.forward *speed;
		//enemies.GetComponent<Renderer>().enabled = true;
		StartCoroutine(spawnwaves());
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

	/*void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;
        //Instantiate(explosionPrefab, pos, rot);
        Destroy(gameObject);
    }*/
}
