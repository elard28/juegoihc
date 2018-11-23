using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;
using UnityEngine;

public class socketclient : MonoBehaviour {

	static NetworkClient client;
	public Transform vrcamera;
	bool cnd = false;
	
	public class MyMsgType {
        public static short Player = MsgType.Highest + 1;
    };
	
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

	public class PlayerMessage : MessageBase
	{
		public Vector3 forward;
		public Vector3 right;
		public float h;
		public float v;
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

			/*StringMessage msg = new StringMessage();
			msg.value = h + "|" + v;
			client.Send (888, msg);*/

			PlayerMessage msg = new PlayerMessage();
			msg.forward = vrcamera.TransformDirection (Vector3.forward);
			msg.right = vrcamera.TransformDirection (Vector3.right);
			msg.h = h;
			msg.v = v;
			client.Send (MyMsgType.Player, msg);
		}
	}

	void Connect()
	{
		client.Connect ("192.168.11.216", 25000);
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
