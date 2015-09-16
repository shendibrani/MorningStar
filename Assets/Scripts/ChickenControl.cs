using UnityEngine;
using System.Collections;

public class ChickenControl : MonoBehaviour {

    [SerializeField]
    float movementForce;
    [SerializeField]
    float healValue;
    [SerializeField]
    float damageValue;

    public enum ChickenState
    {
        HEALTH,DAMAGE
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
