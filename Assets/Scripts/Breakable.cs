using UnityEngine;
using System.Collections;

public class Breakable : MonoBehaviour {
    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void GetChildren() {
        for (int i = 0; i < transform.childCount; i++) {
            Transform go = transform.GetChild(i);
            Collider col = transform.GetChild(i).GetComponent<Collider>();
            
        }
    }
}
