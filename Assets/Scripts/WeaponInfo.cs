using UnityEngine;
using System.Collections;

public class WeaponInfo : MonoBehaviour {

    [SerializeField]
    Rigidbody baseComponent;
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
    }
}
