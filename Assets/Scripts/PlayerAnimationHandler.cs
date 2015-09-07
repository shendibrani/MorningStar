using UnityEngine;
using System.Collections;

public class PlayerAnimationHandler : MonoBehaviour {

	[SerializeField] Rigidbody mover;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//TODO FIX
		GetComponent<Animator>().SetBool("Walking", Mathf.Abs(Vector3.Dot(mover.velocity.normalized, transform.forward)) > 0);
	}
}
