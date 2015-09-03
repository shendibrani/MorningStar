using UnityEngine;
using System.Collections;

public class PlayerInfo : MonoBehaviour {

	public static int players = 1;

	public int playerID {get; private set;}

	// Use this for initialization
	void Start () {
		playerID = players;
		players++;
	}
}