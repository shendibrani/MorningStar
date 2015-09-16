using UnityEngine;
using System.Collections;

public class FireWallKnockback : MonoBehaviour {

    [SerializeField]
    float force = 300f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.GetComponent<Rigidbody>()) c.gameObject.GetComponent<Rigidbody>().AddForce(this.transform.forward * force, ForceMode.Impulse);
    }
}
