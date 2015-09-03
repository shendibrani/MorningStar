using UnityEngine;
using System.Collections;

public class PlayerInfo : MonoBehaviour {

	public static int players = 1;

	[SerializeField] Camera camera;

	public int playerID {get; private set;}

	// Use this for initialization
	void Start () {
		playerID = players;
		players++;

		foreach (AnalogToAxisLayer analog in GetComponentsInChildren<AnalogToAxisLayer>()){
			//analog.joystick = playerID;
		}

		switch (playerID){
		case 1:
			camera.rect = new Rect(new Vector2(0,0), new Vector2(0.5f, 1));
			break;
		case 2:
			camera.rect = new Rect(new Vector2(0,0.5f), new Vector2(0.5f, 1));
			break;
		}
	}
}