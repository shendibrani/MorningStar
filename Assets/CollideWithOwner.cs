using UnityEngine;
using System.Collections;

public class CollideWithOwner : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.GetComponent<RigidBodyTopDownMovement>())
        {
            GetComponentInParent<BoomerangBase>().CollideWithPlayer(col.gameObject.transform);
        }
    }
}
