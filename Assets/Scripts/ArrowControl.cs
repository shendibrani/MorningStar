using UnityEngine;
using System.Collections;

public class ArrowControl : MonoBehaviour {

    [SerializeField]
    float arrowSpeed = 700f;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().AddForce(transform.forward * arrowSpeed, ForceMode.Force);
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnCollisionEnter(Collision c)
    {
        //Object.Destroy(this.gameObject);
        if (c.gameObject.GetComponent<ReceiveDamageOnCollision>())
        {
            GetComponent<DealDamageOnCollision>().enabled = false;
            GetComponent<ArrowControl>().enabled = false;
            //GetComponent<Rigidbody>().freezeRotation = true;
            GetComponent<Rigidbody>().AddForce(Vector3.forward * -arrowSpeed, ForceMode.Force);
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            GetComponent<Collider>().enabled = false;
            transform.SetParent(c.transform);
        }
        else
        {
            gameObject.SetActive(false);
        }
       
    }
}
