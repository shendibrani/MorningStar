using UnityEngine;
using System.Collections;

public class PlayerInfo : MonoBehaviour, IMessage {

	//public static int players = 1;

    PlayerState state = PlayerState.ALIVE;
	//[SerializeField] Camera camera;

	public int playerID {get; private set;}

    //[SerializeField]
    //public Transform leftRotator;
    [SerializeField]
    public Transform rightRotator;

	public AxisInversionPair movementAxisX,movementAxisY;
	public AxisInversionPair attackAxisX,attackAxisY;

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
		//playerID = players;
		//players++;


		Debug.Log(GetComponentsInChildren<AnalogToAxisLayer>().Length);

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

    public void AssignPlayer(int id)
    {
        playerID = id;

        foreach (AnalogToAxisLayer analog in GetComponentsInChildren<AnalogToAxisLayer>())
        {
            analog.player = playerID;
			if (analog.type == StickType.MOVEMENT){
				if(analog.direction == StickDirection.HORIZONTAL){
					analog.axisName = movementAxisX.axisName;
					analog.invert = movementAxisX.invert;
				} else {
					analog.axisName = movementAxisY.axisName;
					analog.invert = movementAxisY.invert;
				}
			} else if (analog.type == StickType.ATTACK){
				if(analog.direction == StickDirection.HORIZONTAL){
					analog.axisName = attackAxisX.axisName;
					analog.invert = attackAxisX.invert;
				} else {
					analog.axisName = attackAxisY.axisName;
					analog.invert = attackAxisY.invert;
				}
			}
            if (analog.type == StickType.TRIGGER)
            {
                analog.axisName = "J" + (playerID + 1) + " Triggers";
            }
        }
        foreach (AnalogToAxisLayer analog in rightRotator.GetComponentsInParent<AnalogToAxisLayer>())
        {
            analog.player = playerID;
            if (analog.type == StickType.MOVEMENT)
            {
                if (analog.direction == StickDirection.HORIZONTAL)
                {
                    Debug.Log(movementAxisX.axisName);
                    analog.axisName = movementAxisX.axisName;
                    analog.invert = movementAxisX.invert;
                }
                else
                {
                    Debug.Log(movementAxisY.axisName);
                    analog.axisName = movementAxisY.axisName;
                    analog.invert = movementAxisY.invert;
                }
            }
            else if (analog.type == StickType.ATTACK)
            {
                if (analog.direction == StickDirection.HORIZONTAL)
                {
                    analog.axisName = attackAxisX.axisName;
                    analog.invert = attackAxisX.invert;
                }
                else
                {
                    analog.axisName = attackAxisY.axisName;
                    analog.invert = attackAxisY.invert;
                }
            }
        }

    }

    public void AttachWeapon(GameObject weapon)
    {
        GetComponentInChildren<PlayerDeath>().AttachWeapon(weapon);
        weapon.GetComponent<WeaponInfo>().Attach(this.gameObject, rightRotator);
    }

    public void Message(Messages message, GameObject sender)
    {
        switch (message)
        {
            case Messages.DEATH:
                if (sender.GetComponent<PlayerInfo>() == this) { 
                    state = PlayerState.DEAD;
                    GetComponent<DecayControl>().Activate();
                    GetComponentInChildren<WeaponInfo>().Death();
                    playerID = 0;
                }
                 break;
        }
    }
}