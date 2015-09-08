using UnityEngine;
using System.Collections;

public class SplashLoad : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKeyDown)
        {
            this.enabled = false;
        }
	}
}
