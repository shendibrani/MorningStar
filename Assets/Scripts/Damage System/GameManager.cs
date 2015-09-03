using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    static GameManager instance;

    List <IListener> listnerList = new List<IListener>();

    public static GameManager Instance
    {
        get
        {
            if (instance == null) instance = new GameManager();
            return instance;
        }

    }

    GameManager()
    {

    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void PlayerDeath()
    {

    }
}
