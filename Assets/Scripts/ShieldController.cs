using UnityEngine;
using System.Collections;

public class ShieldController : MonoBehaviour {

    [SerializeField]
    float interval = 2f;

    float timer;

	// Use this for initialization
	void Start () {
        timer = Time.time + interval;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > timer)
        {
            GameObject.Destroy(this.gameObject);
        }
	}
}
