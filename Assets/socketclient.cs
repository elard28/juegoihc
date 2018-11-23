using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;
using UnityEngine;

public class socketclient : MonoBehaviour {

	static NetworkClient client;
	bool cnd = false;
	void OnGUI()
	{
		string ipaddress = Network.player.ipAddress;
		GUI.Box (new Rect(10,Screen.height -50, 100, 50),ipaddress);
		GUI.Label (new Rect (20,Screen.height - 35, 100, 20),"Status:" +client.isConnected);

		/*if (!client.isConnected) {
			if (GUI.Button (new Rect (10, 10, 60, 50), "Connect"))
				Connect ();
		}*/
		if (!cnd) {
			Connect ();
			cnd = true;
		}
	}

	// Use this for initialization
	void Start () {
		client = new NetworkClient ();
		//client.Connect ("192.168.1.3", 25000);
	}
	
	// Update is called once per frame
	void Update () {
		if (client.isConnected) 
		{
			float h = Input.GetAxis ("Horizontal");
			float v = Input.GetAxis ("Vertical");

			StringMessage msg = new StringMessage();
			msg.value = h + "|" + v;
			client.Send (888, msg);
		}
	}

	void Connect()
	{
		client.Connect ("192.168.11.137", 25000);
	}

	/*static public void SendJoystickInfo(float hDelta, float vDelta)
	{
		if (client.isConnected) 
		{
			StringMessage msg = new StringMessage();
			msg.value = hDelta + "|" + vDelta;
			client.Send (888, msg);
		}
	}*/

}
