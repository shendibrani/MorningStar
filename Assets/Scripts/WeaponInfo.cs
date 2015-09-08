using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponInfo : MonoBehaviour {

    [SerializeField]
    Rigidbody baseComponent;
    [SerializeField]
    List <Rigidbody> headComponents;
    //[SerializeField]
    //RotateAroundAxis rotator;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Attach(GameObject player, RotateAroundAxis rotator)
    {
        this.transform.SetParent(player.transform);
        baseComponent.transform.SetParent(rotator.transform);
        baseComponent.transform.position = rotator.transform.position;
    }

    public void Death()
    {
        foreach (Rigidbody r in headComponents)
        {
            if (r.GetComponent<DealDamageOnCollision>()) r.GetComponent<DealDamageOnCollision>().enabled = false;
        }
    }

    public void Falling()
    {
        foreach (Rigidbody r in headComponents)
        {
            if (r.GetComponent<Collider>()) r.GetComponent<Collider>().enabled = false;
        }
        baseComponent.GetComponent<Collider>().enabled = false;
    }
}
