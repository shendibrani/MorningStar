using UnityEngine;
using System.Collections;

[RequireComponent(typeof(UIDrawerBehaviour))]
public class PauseMenu : MonoBehaviour, IMessage
{
	void Start()
	{
		MessagingManager.AddListener(this);
	}

	public void Message(Messages message, GameObject sender)
	{
		switch (message)
		{
		case Messages.PAUSE:
			GetComponent<UIDrawerBehaviour>().SetState(1);
			break;
		case Messages.RESUME:
			GetComponent<UIDrawerBehaviour>().SetState(0);
			break;
		}
	}
}

