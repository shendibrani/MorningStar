using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    [SerializeField]
    float displayInterval = 20f;
    float targetTime = 0f;

    void Start()
    {

    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void PlayerDeath(PlayerInfo info)
    {
        targetTime = Time.time + displayInterval;

    }
}
