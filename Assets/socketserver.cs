using System.Collections;
using System.Collections.Generic;

using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;
//using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;

public class socketserver : MonoBehaviour {

	//CrossPlatformInputManager.VirtualAxis m_HVAxis;
	//CrossPlatformInputManager.VirtualAxis m_VVAxis;
	//string horizontalAxisName = "Horizontal";
	//string verticalAxisName = "Vertical";

	//public GameObject go;

	void OnGUI()
	{
		string ipaddress = Network.player.ipAddress;
		GUI.Box (new Rect(10,Screen.height -50, 100, 50),ipaddress);
		GUI.Label (new Rect (20,Screen.height - 35, 100, 20),"Status:" +NetworkServer.active);
		GUI.Label (new Rect (20,Screen.height - 20, 100, 20),"Connected:" +NetworkServer.connections.Count);
	}

	// Use this for initialization
	void Start () {
		/*m_HVAxis = new CrossPlatformInputMananger.VirtualAxis(horizontalAxisName);
		CrossPlatformInputMananger.RegisterVirtualAxis (m_HVAxis);
		m_VVAxis = new CrossPlatformInputMananger.VirtualAxis(verticalAxisName);
		CrossPlatformInputMananger.RegisterVirtualAxis (m_VVAxis);*/

		NetworkServer.Listen (25000);
		NetworkServer.RegisterHandler (888, ServerReceiveMessage);
	}

	private void ServerReceiveMessage(NetworkMessage message)
	{
		StringMessage msg = new StringMessage ();
		msg.value = message.ReadMessage<StringMessage> ().value;

		string[] deltas = msg.value.Split ('|');

		Debug.Log (deltas [0] + ' ' + deltas [1]);

		//m_HVAxis.Update (Convert.ToSingle (deltas [0]));
		//m_VVAxis.Update (Convert.ToSingle (deltas [1]));
	}

	// Update is called once per frame
	void Update () {
		
	}
}
