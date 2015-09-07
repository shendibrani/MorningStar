using UnityEngine;
using System.Collections;

public class PlayerInfo : MonoBehaviour, IMessage {

	public static int players = 1;

    PlayerState state = PlayerState.ALIVE;
	//[SerializeField] Camera camera;

	public int playerID {get; private set;}

    public PlayerState State
    {
        get
        {
            return state;
        }
    }

    public enum PlayerState{
        ALIVE, DEAD
    }

	// Use this for initialization
	void Start () {
		playerID = players;
		players++;

		Debug.Log(GetComponentsInChildren<AnalogToAxisLayer>().Length);

		foreach (AnalogToAxisLayer analog in GetComponentsInChildren<AnalogToAxisLayer>()){
			analog.player = playerID;
		}

        MessagingManager.AddListener(this);
//		switch (playerID){
//		case 1:
//			camera.rect = new Rect(new Vector2(0,0), new Vector2(0.5f, 1));
//			break;
//		case 2:
//			camera.rect = new Rect(new Vector2(0,0.5f), new Vector2(0.5f, 1));
//			break;
//		}
	}

    public void Update()
    {
    }

    public void Message(Messages message, GameObject sender)
    {
        switch (message)
        {
            case Messages.DEATH:
                 if (sender.GetComponent<PlayerInfo>() == this) state = PlayerState.DEAD;
                 break;
        }
    }
}