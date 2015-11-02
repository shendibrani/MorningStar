using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LookAtEachotherBehaviour : MonoBehaviour,IMessage {

	Transform other;
    bool active = true;

	// Use this for initialization
	void Start () 
	{
		List<LookAtEachotherBehaviour> list = new List<LookAtEachotherBehaviour>(FindObjectsOfType<LookAtEachotherBehaviour>());
		other = list.Find(x => x != this).transform;
        MessagingManager.AddListener(this);
	}
	
	// Update is called once per frame
	void Update () {
        if (active) transform.LookAt(other);
	}

    public void Message(Messages message, GameObject sender)
    {
        switch (message){
            case Messages.DEATH:
                active = false;
                break;
            case Messages.RESTART:
                active = true;
                break;
        }
        Debug.Log(active);
    }

    void OnDestroy()
    {
        MessagingManager.RemoveListener(this);
    }
}
