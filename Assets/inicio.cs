using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class inicio : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void initGame(int changeToScene)
	{
		SceneManager.LoadScene (changeToScene);
	}

	public void closeGame()
	{
		Application.Quit ();
	}
}
