using UnityEngine;
using System.Collections;

public class FireWallController : MonoBehaviour,IMessage {

    [SerializeField]
    float wallSpeed;
    [SerializeField]
    float maxMotionDistance;

    float distance = 0;

	// Use this for initialization
	void Start () {
        MessagingManager.AddListener(this);
	}
	
	// Update is called once per frame
	void Update () {

        if (distance < maxMotionDistance)
        {
            transform.position += transform.forward * Time.deltaTime * wallSpeed;
            distance += Time.deltaTime * wallSpeed;
        }

	}

    public void Message(Messages message, GameObject sender)
    {
        switch (message)
        {
            case Messages.DEATH:
                StopMotion();
                break;
            case Messages.RESTART:
                ResetMotion();
                break;
        }
    }

    void ResetMotion()
    {
        distance = 0;
    }

    void StopMotion()
    {
        distance = maxMotionDistance + 1;
    }
}
