using UnityEngine;
using System.Collections;

public class ShieldDecay : MonoBehaviour {

    float timer = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Time.time >= timer){
            GameObject.Destroy(this.gameObject);
        }
	}

    public void SetTimer(float time)
    {
        timer = time;
    }
}
