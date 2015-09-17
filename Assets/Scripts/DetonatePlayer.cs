using UnityEngine;
using System.Collections;

public class DetonatePlayer : MonoBehaviour, IDeath {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnDeath()
    {
        Debug.Log(this);
        //this.GetComponent<BoxCollider>().enabled = false;
        foreach (Collider c in GetComponentsInChildren<Collider>())
        {
            c.enabled = true;
        }
        gameObject.AddComponent<Rigidbody>();
        GetComponent<Rigidbody>().WakeUp();
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        //if (GetComponent<DealDamageOnCollision>()) GetComponent<DealDamageOnCollision>().enabled = false;
    }
}
