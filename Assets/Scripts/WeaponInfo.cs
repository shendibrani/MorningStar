using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponInfo : MonoBehaviour {

    [SerializeField]
    Rigidbody baseComponent;
    [SerializeField]
    List <Collider> headComponents;
    [SerializeField]
    Vector3 rotation;
    //[SerializeField]
    //RotateAroundAxis rotator;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Attach(GameObject player, Transform pivot)
    {
        this.transform.SetParent(player.transform);
        baseComponent.transform.SetParent(pivot.transform);
        baseComponent.transform.position = pivot.transform.position;
        baseComponent.transform.eulerAngles = rotation;
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
