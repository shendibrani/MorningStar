using UnityEngine;
using System.Collections;

public class LoadingImage : MonoBehaviour, IMessage {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Message(Messages message, GameObject sender)
    {
        switch (message)
        {
            case Messages.LOADED:
                Destroy(gameObject);
                break;
        }
    }
}
