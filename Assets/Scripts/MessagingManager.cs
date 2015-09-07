using System;
using UnityEngine;
using System.Collections.Generic;

public class MessagingManager
{
	// Singleton structure
	// Not threadsafe, but I'm not making any threads here, so who cares.

	private static MessagingManager _instance;

	public static MessagingManager instance { 
		get {
			if (_instance == null) {
				_instance = new MessagingManager ();
			}
			return _instance;
		}
	}

	delegate void MessageEvent(Messages message, GameObject sender);

	event MessageEvent broadcastCallback;

	private MessagingManager(){}

	public static void Broadcast(Messages message, GameObject sender){
		instance.broadcastCallback.Invoke(message,sender);
	}

	public static void AddListener(IMessage listener){
		instance.broadcastCallback += listener.Message;
	}

	public static void RemoveListener(IMessage listener){
		instance.broadcastCallback -= listener.Message;
	}
}

public enum Messages {
    PAUSE, RESUME, DEATH, RESTART
}

