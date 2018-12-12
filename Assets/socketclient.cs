using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;
using UnityEngine;

public class socketclient : MonoBehaviour {

	static NetworkClient client;
	public Transform vrcamera;
	bool cnd = false;

	public GameObject enemy;

    public GameObject player;
    movimiento mov;
	
    public GameObject[] cubes;
    mueve[] mv;

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
		public Vector3 position;
		public int lives;
		public bool holding;
		public int completed;

		public Vector3 forward;
		public Vector3 right;
		public float h;
		public float v;
	}

	public class CubeMessage : MessageBase
	{
		public int numcube;
		public Vector3 position;
	}

	public class EnemyMessage : MessageBase //sin uso
	{
		public Vector3 position;
		public string name;
	}

	public class PlayerUpdateMessage : MessageBase //sin uso
	{
		public Vector3 position;
		public float speed;
		public int lives;
		public float remain;
	}

	public class PlayerTypeMessage : MessageBase //sin uso
	{
		public bool type;
	}

	// Use this for initialization
	void Start () {
		
		mov = player.GetComponent<movimiento>();

		client = new NetworkClient ();
		//client.Connect ("192.168.1.3", 25000);
		enemy.SetActive(false);


		mv = new mueve[cubes.Length];
		for(int i=0 ; i < mv.Length; i++)
			mv[i] = cubes[i].GetComponent<mueve>();
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
			msg.position = player.transform.position;
			msg.lives = mov.lives;
			msg.holding = mov.holding;
			msg.completed = mov.completed;

			msg.forward = vrcamera.TransformDirection (Vector3.forward);
			msg.right = vrcamera.TransformDirection (Vector3.right);
			msg.h = h;
			msg.v = v;
			//client.Send (MyMsgType.Player, msg);
			client.Send (888, msg);


			for (int i = 0; i < cubes.Length; i++)
			{
				if(cubes[i] != null) //si no fue destruido
				{
					CubeMessage msgc = new CubeMessage();
					msgc.numcube = mv[i].numcube;
					msgc.position = cubes[i].transform.position;
					client.Send (MsgType.Animation, msgc);
				}
			}
		}
	}

	void Connect()
	{
		client.Connect ("192.168.43.142", 25000);
		//client.RegisterHandler (MsgType.Connect, OnConnected);
		//client.RegisterHandler (888, ClientReceiveMessage);
		//client.RegisterHandler (MsgType.Connect, ClientReceiveUpdate);

		client.RegisterHandler (MsgType.Command, ClientReceiveMessageEnemy);

		/*PlayerTypeMessage msg = new PlayerTypeMessage();
		msg.type = false;
		client.Send (MsgType.Connect, msg);*/
	}

	void OnConnected(NetworkMessage netMsg)
	{
		
	}

	private void ClientReceiveMessageEnemy(NetworkMessage message)
	{
		EnemyMessage msg = message.ReadMessage<EnemyMessage>();
		//Debug.log(msg.position);
		GameObject shot = GameObject.Find(msg.name);
		GameCo gc = shot.GetComponent<GameCo>();
		gc.spawns = msg.position;
		gc.spawnwave();
	}

	private void ClientReceiveMessage(NetworkMessage message)
	{
		//EnemyMessage msg = message.ReadMessage<EnemyMessage>();
		//Debug.log(msg.pos);

		StringMessage msg = message.ReadMessage<StringMessage>();
		enemy.SetActive(true);
		Debug.Log(msg.value);
	}

	private void ClientReceiveUpdate(NetworkMessage message) //lo que recibe al conectarse
	{
		PlayerUpdateMessage msg = message.ReadMessage<PlayerUpdateMessage>();
		player.transform.position = msg.position;
		mov.speed = msg.speed;
		mov.lives = msg.lives;
	}

}
