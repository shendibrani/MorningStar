using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponInfo : MonoBehaviour {

    [SerializeField]
    Rigidbody baseComponent;
    [SerializeField]
    List <Collider> headComponents;
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
        foreach (Collider c in headComponents)
        {
            if (c.GetComponent<DealDamageOnCollision>()) c.GetComponent<DealDamageOnCollision>().enabled = false;
        }
    }

    public void Falling()
    {
        foreach (Collider c in headComponents)
        {
            c.enabled = false;
        }
        if (baseComponent.GetComponent<Collider>()) baseComponent.GetComponent<Collider>().enabled = false;
    }
}
